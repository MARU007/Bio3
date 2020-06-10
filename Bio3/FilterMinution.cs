using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bio3
{
    class FilterMinution
    {
        public Bitmap Filtering(Bitmap b)
        {
            Bitmap bb = new Bitmap(b);
            int[,] cn = new int[b.Width, b.Height];
            for (int x = 0; x < b.Width; x++)
            {
                for (int y = 0; y < b.Height; y++)
                {
                    cn[x, y] = 2;
                }
            }
            int[,] nowePixele = new int[b.Width, b.Height];
            for (int x = 0; x < b.Width; x++)
            {
                for (int y = 0; y < b.Height; y++)
                {
                    Color koloryOb = b.GetPixel(x, y);
                    if (koloryOb.R == 0) nowePixele[x, y] = 1;
                    else nowePixele[x, y] = 0;
                }
            }

            for (int x = 0; x < b.Width-1; x++)
            {
                for (int y = 0; y < b.Height-1; y++)
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
                    }
                }
            }
            cn = Distancefilter(cn, 0);
            cn = Distancefilter(cn, 1);
            cn = Distancefilter(cn, 3);
            cn = Distancefilter(cn, 4);

            for (int x = 0; x < b.Width; x++)
            {
                for (int y = 0; y < b.Height; y++)
                {
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
            return bb;
        }
        private int[,] Distancefilter(int[,] cn, int choice)
        {
            for (int i = 0; i < cn.GetLength(0); i++)
            {
                for (int j = 0; j < cn.GetLength(1); j++)
                {
                    if (cn[i, j] == choice) cn = MaskSeventoSeven(cn, i, j, choice);
                }
            }
            return cn;
        }
        private int[,] MaskSeventoSeven(int[,] cn, int x, int y, int choice)
        {
            int edgeLeft = x - 3, edgeRight = x + 3;
            if (edgeLeft < 0) edgeLeft = 0;
            int sizeX = cn.GetLength(0);
            if (edgeRight >= cn.GetLength(0)) edgeRight = (sizeX - 1);
            int edgeTop = y - 3, edgeDown = y + 3;
            if (edgeTop < 0) edgeTop = 0;
            if (edgeDown >= cn.GetLength(1)) edgeDown = (cn.GetLength(1) - 1);
            for (int i = edgeLeft; i <= edgeRight; i++)
            {
                for (int j = edgeTop; j <= edgeDown; j++)
                {
                    if (cn[i, j] == choice && (i != x || j != y))
                        cn[i, j] = 2;
                }
            }
            return cn;
        }
    }

}

