using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bio3
{
    class Blur
    {
        public Bitmap Smudge(Bitmap tmp)
        {
            double width = tmp.Width;
            double height = (double)tmp.Height;
            int size = 3;
            Bitmap pom = new Bitmap(tmp);
            for (int w = 0; (double)w < width; ++w)
            {
                for (int h = 0; (double)h < height; ++h)
                {
                    int iloscPixeli = 0;
                    int sumaR = 0;
                    int sumaG = 0;
                    int sumaB = 0;

                    for (int i = -size; i <= size; ++i)
                    {
                        for (int j = -size; j <= size; ++j)
                        {
                            if (w + i >= 0 && (double)(w + i) < width && h + j >= 0 && (double)(h + j) < height)
                            {
                                System.Drawing.Color pixel = tmp.GetPixel(w + i, h + j);
                                sumaR += pixel.R;
                                sumaG += pixel.G;
                                sumaB += pixel.B;
                                ++iloscPixeli;
                            }
                        }
                    }

                    sumaR /= iloscPixeli;
                    sumaG /= iloscPixeli;
                    sumaB /= iloscPixeli;
                    sumaR = checkerRange(sumaR);
                    sumaG = checkerRange(sumaG);
                    sumaR = checkerRange(sumaR);

                    System.Drawing.Color newPixel = System.Drawing.Color.FromArgb(sumaR, sumaG, sumaB);

                    pom.SetPixel(w, h, newPixel);
                }
            }
            tmp = pom;

            return tmp;
        }
        private int checkerRange(int pixel)
        {
            if (pixel > 255)
            {
                pixel = 255;
            }
            else if (pixel < 0)
            {
                pixel = 0;
            }
            return pixel;
        }


        public Bitmap BlurImage(Bitmap bmp) // rzomycie 
        {
            Bitmap imgPom = new Bitmap(bmp);
            for (int i = 3; i < bmp.Width - 3; ++i)
            {
                int[,] pixelMatrixR = new int[7, 7];
                int[,] pixelMatrixG = new int[7, 7];
                int[,] pixelMatrixB = new int[7, 7];

                for (int j = 3; j < bmp.Height - 3; ++j)
                {
                    pixelMatrixR = fillingTab7x7(pixelMatrixR, i, j, 1, bmp);
                    pixelMatrixG = fillingTab7x7(pixelMatrixG, i, j, 2, bmp);
                    pixelMatrixB = fillingTab7x7(pixelMatrixB, i, j, 3, bmp);
                    int averageR0, averageR1, averageR2, averageR3;
                    int averageG0, averageG1, averageG2, averageG3;
                    int averageB0, averageB1, averageB2, averageB3;

                    averageR0 = average(pixelMatrixR, 0, 0);
                    averageR1 = average(pixelMatrixR, 0, 3);
                    averageR2 = average(pixelMatrixR, 3, 0);
                    averageR3 = average(pixelMatrixR, 3, 3);

                    averageG0 = average(pixelMatrixG, 0, 0);
                    averageG1 = average(pixelMatrixG, 0, 3);
                    averageG2 = average(pixelMatrixG, 3, 0);
                    averageG3 = average(pixelMatrixG, 3, 3);

                    averageB0 = average(pixelMatrixB, 0, 0);
                    averageB1 = average(pixelMatrixB, 0, 3);
                    averageB2 = average(pixelMatrixB, 3, 0);
                    averageB3 = average(pixelMatrixB, 3, 3);


                    int edgeR = biggestVariance(averageR0, averageR1, averageR2, averageR3, pixelMatrixR);
                    int edgeG = biggestVariance(averageG0, averageG1, averageG2, averageG3, pixelMatrixG);
                    int edgeB = biggestVariance(averageB0, averageB1, averageB2, averageB3, pixelMatrixB);


                    System.Drawing.Color newPixel = System.Drawing.Color.FromArgb(edgeR, edgeG, edgeB);

                    imgPom.SetPixel(i, j, newPixel);
                }
            }
            bmp = imgPom;
            return bmp;
        }
        private int average(int[,] tab, int positionX, int positionY)
        {
            int aver, sum = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    sum += tab[positionX + i, positionY + j];
                }
            }
            aver = sum / 16;


            return aver;
        }
        private int[,] fillingTab7x7(int[,] tab, int x, int y, int color, Bitmap bmp)
        {
            for (int i = x - 3; i <= x + 3; i++)
            {
                for (int j = y - 3; j <= y + 3; j++)
                {
                    if (color == 1) tab[i - (x - 3), j - (y - 3)] = bmp.GetPixel(i, j).R;
                    else if (color == 2) tab[i - (x - 3), j - (y - 3)] = bmp.GetPixel(i, j).G;
                    else tab[i - (x - 3), j - (y - 3)] = bmp.GetPixel(i, j).B;
                }
            }
            return tab;
        }
        private int biggestVariance(int ave0, int ave1, int ave2, int ave3, int[,] tab)
        {
            double sum0 = 0, sum1 = 0, sum2 = 0, sum3 = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    sum0 = +Math.Pow(ave0 - tab[i, j], 2);
                    sum1 = +Math.Pow(ave1 - tab[i, j + 2], 2);
                    sum2 = +Math.Pow(ave2 - tab[i + 2, j], 2);
                    sum3 = +Math.Pow(ave3 - tab[i + 2, j + 2], 2);
                }
            }
            if (sum0 <= sum1 && sum0 <= sum2 && sum0 <= sum3) return ave0;
            else if (sum1 <= sum0 && sum1 <= sum2 && sum1 <= sum3) return ave1;
            else if (sum2 <= sum0 && sum2 <= sum1 && sum2 <= sum3) return ave2;
            else return ave3;
        }
    }
}
