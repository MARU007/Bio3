using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bio3
{
    class FindMinutiae
    {
        public Bitmap SearchMinutiae(Bitmap b)
        {
            Bitmap bb = new Bitmap(b);
            int dlugosc = 2;
            int[,] cn = new int[b.Width, b.Height];
            int[,] nowePixele = new int[b.Width, b.Height];
           // int[,,] filtr = new int[10000, b.Width, b.Height];
            for (int x = dlugosc; x < b.Width - dlugosc; x++)
            {
                for (int y = dlugosc; y < b.Height - dlugosc; y++)
                {
                    Color koloryOb = b.GetPixel(x, y);
                    if (koloryOb.R == 0) nowePixele[x, y] = 1;
                    else nowePixele[x, y] = 0;
                }
            }
            for (int x = dlugosc; x < b.Width - dlugosc; x++)
            {
                for (int y = dlugosc; y < b.Height - dlugosc; y++)
                {
                    if (nowePixele[x, y] == 1)
                    {
                        cn[x, y] = ((Math.Abs(nowePixele[x, y + 1] - nowePixele[x - 1, y + 1]) + //1-2
                                     Math.Abs(nowePixele[x - 1, y + 1] - nowePixele[x - 1, y]) + //2-3
                                     Math.Abs(nowePixele[x - 1, y] - nowePixele[x - 1, y - 1]) + //3-4
                                     Math.Abs(nowePixele[x - 1, y - 1] - nowePixele[x, y - 1]) + //4-5
                                     Math.Abs(nowePixele[x, y - 1] - nowePixele[x + 1, y - 1]) + //5-6
                                     Math.Abs(nowePixele[x + 1, y - 1] - nowePixele[x + 1, y]) + //6-7
                                     Math.Abs(nowePixele[x + 1, y] - nowePixele[x + 1, y + 1]) + //7-8
                                     Math.Abs(nowePixele[x + 1, y + 1] - nowePixele[x, y + 1])) / 2); //8-1    

                        if (cn[x, y] == 0) // pojedyńczy punkt - minucja - różowy
                        {
                            bb.SetPixel(x - 2, y - 2, Color.FromArgb(255, 0, 255));
                            bb.SetPixel(x - 2, y - 1, Color.FromArgb(255, 0, 255));
                            bb.SetPixel(x - 2, y, Color.FromArgb(255, 0, 255));
                            bb.SetPixel(x - 2, y + 1, Color.FromArgb(255, 0, 255));
                            bb.SetPixel(x - 2, y + 2, Color.FromArgb(255, 0, 255));

                            bb.SetPixel(x - 1, y - 2, Color.FromArgb(255, 0, 255));
                            bb.SetPixel(x - 1, y + 2, Color.FromArgb(255, 0, 255));

                            bb.SetPixel(x, y - 2, Color.FromArgb(255, 0, 255));
                            bb.SetPixel(x, y + 2, Color.FromArgb(255, 0, 255));

                            bb.SetPixel(x + 1, y - 2, Color.FromArgb(255, 0, 255));
                            bb.SetPixel(x + 1, y + 2, Color.FromArgb(255, 0, 255));

                            bb.SetPixel(x + 2, y - 2, Color.FromArgb(255, 0, 255));
                            bb.SetPixel(x + 2, y - 1, Color.FromArgb(255, 0, 255));
                            bb.SetPixel(x + 2, y, Color.FromArgb(255, 0, 255));
                            bb.SetPixel(x + 2, y + 1, Color.FromArgb(255, 0, 255));
                            bb.SetPixel(x + 2, y + 2, Color.FromArgb(255, 0, 255));
                        }

                        if (cn[x, y] == 1) //zakończenie krawędzi - minucja - pomarańczowy
                        {
                            bb.SetPixel(x - 2, y - 2, Color.FromArgb(255, 140, 0));
                            bb.SetPixel(x - 2, y - 1, Color.FromArgb(255, 140, 0));
                            bb.SetPixel(x - 2, y, Color.FromArgb(255, 140, 0));
                            bb.SetPixel(x - 2, y + 1, Color.FromArgb(255, 140, 0));
                            bb.SetPixel(x - 2, y + 2, Color.FromArgb(255, 140, 0));

                            bb.SetPixel(x - 1, y - 2, Color.FromArgb(255, 140, 0));
                            bb.SetPixel(x - 1, y + 2, Color.FromArgb(255, 140, 0));

                            bb.SetPixel(x, y - 2, Color.FromArgb(255, 140, 0));
                            bb.SetPixel(x, y + 2, Color.FromArgb(255, 140, 0));

                            bb.SetPixel(x + 1, y - 2, Color.FromArgb(255, 140, 0));
                            bb.SetPixel(x + 1, y + 2, Color.FromArgb(255, 140, 0));

                            bb.SetPixel(x + 2, y - 2, Color.FromArgb(255, 140, 0));
                            bb.SetPixel(x + 2, y - 1, Color.FromArgb(255, 140, 0));
                            bb.SetPixel(x + 2, y, Color.FromArgb(255, 140, 0));
                            bb.SetPixel(x + 2, y + 1, Color.FromArgb(255, 140, 0));
                            bb.SetPixel(x + 2, y + 2, Color.FromArgb(255, 140, 0));
                        }
                        if (cn[x, y] == 3) //rozwidlenie - minucja - zielony
                        {
                            bb.SetPixel(x - 2, y - 2, Color.FromArgb(0, 130, 0));
                            bb.SetPixel(x - 2, y - 2, Color.FromArgb(0, 130, 0));
                            bb.SetPixel(x - 2, y, Color.FromArgb(0, 130, 0));
                            bb.SetPixel(x - 2, y + 1, Color.FromArgb(0, 130, 0));
                            bb.SetPixel(x - 2, y + 2, Color.FromArgb(0, 130, 0));

                            bb.SetPixel(x - 1, y - 2, Color.FromArgb(0, 130, 0));
                            bb.SetPixel(x - 1, y + 2, Color.FromArgb(0, 130, 0));

                            bb.SetPixel(x, y - 2, Color.FromArgb(0, 130, 0));
                            bb.SetPixel(x, y + 2, Color.FromArgb(0, 130, 0));

                            bb.SetPixel(x + 1, y - 2, Color.FromArgb(0, 130, 0));
                            bb.SetPixel(x + 1, y + 2, Color.FromArgb(0, 130, 0));

                            bb.SetPixel(x + 2, y - 2, Color.FromArgb(0, 130, 0));
                            bb.SetPixel(x + 2, y - 2, Color.FromArgb(0, 130, 0));
                            bb.SetPixel(x + 2, y, Color.FromArgb(0, 130, 0));
                            bb.SetPixel(x + 2, y + 1, Color.FromArgb(0, 130, 0));
                            bb.SetPixel(x + 2, y + 2, Color.FromArgb(0, 130, 0));
                        }
                        if (cn[x, y] == 4) // skrzyżowanie - minucja - niebieski
                        {
                            bb.SetPixel(x - 2, y - 2, Color.FromArgb(0, 0, 255));
                            bb.SetPixel(x - 2, y - 1, Color.FromArgb(0, 0, 255));
                            bb.SetPixel(x - 2, y, Color.FromArgb(0, 0, 255));
                            bb.SetPixel(x - 2, y + 1, Color.FromArgb(0, 0, 255));
                            bb.SetPixel(x - 2, y + 2, Color.FromArgb(0, 0, 255));

                            bb.SetPixel(x - 1, y - 2, Color.FromArgb(0, 0, 255));
                            bb.SetPixel(x - 1, y + 2, Color.FromArgb(0, 0, 255));

                            bb.SetPixel(x, y - 2, Color.FromArgb(0, 0, 255));
                            bb.SetPixel(x, y + 2, Color.FromArgb(0, 0, 255));

                            bb.SetPixel(x + 1, y - 2, Color.FromArgb(0, 0, 255));
                            bb.SetPixel(x + 1, y + 2, Color.FromArgb(0, 0, 255));

                            bb.SetPixel(x + 2, y - 2, Color.FromArgb(0, 0, 255));
                            bb.SetPixel(x + 2, y - 1, Color.FromArgb(0, 0, 255));
                            bb.SetPixel(x + 2, y, Color.FromArgb(0, 0, 255));
                            bb.SetPixel(x + 2, y + 1, Color.FromArgb(0, 0, 255));
                            bb.SetPixel(x + 2, y + 2, Color.FromArgb(0, 0, 255));
                        }
                    }
                }
            }
            return bb;
        }
    }
}
