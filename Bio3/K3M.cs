using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bio3
{
    class K3M
    {
        int[] A0 = {3, 6, 7, 12, 14, 15, 24, 28, 30, 31, 48, 56, 60,
            62, 63, 96, 112, 120, 124, 126, 127, 129, 131, 135,
            143, 159, 191, 192, 193, 195, 199, 207, 223, 224,
            225, 227, 231, 239, 240, 241, 243, 247, 248, 249,
            251, 252, 253, 254};
        int[] A1 = { 7, 14, 28, 56, 112, 131, 193, 224 };
        int[] A2 = {7, 14, 15, 28, 30, 56, 60, 112, 120, 131, 135,
            193, 195, 224, 225, 240};
        int[] A3 = {7, 14, 15, 28, 30, 31, 56, 60, 62, 112, 120,
            124, 131, 135, 143, 193, 195, 199, 224, 225, 227,
            240, 241, 248};
        int[] A4 = {7, 14, 15, 28, 30, 31, 56, 60, 62, 63, 112, 120,
            124, 126, 131, 135, 143, 159, 193, 195, 199, 207,
            224, 225, 227, 231, 240, 241, 243, 248, 249, 252};
        int[] A5 = {7, 14, 15, 28, 30, 31, 56, 60, 62, 63, 112, 120,
            124, 126, 131, 135, 143, 159, 191, 193, 195, 199,
            207, 224, 225, 227, 231, 239, 240, 241, 243, 248,
            249, 251, 252, 254};
        int[] A1pix = {3, 6, 7, 12, 14, 15, 24, 28, 30, 31, 48, 56,
            60, 62, 63, 96, 112, 120, 124, 126, 127, 129, 131,
            135, 143, 159, 191, 192, 193, 195, 199, 207, 223,
            224, 225, 227, 231, 239, 240, 241, 243, 247, 248,
            249, 251, 252, 253, 254};

        public Bitmap K3MSkeletonization(Bitmap bmap)
        {
            int start = 1;

            for (int x = start; x < bmap.Width - start; x++)
            {
                for (int y = start; y < bmap.Height - start; y++)
                {
                    Color colorOb = bmap.GetPixel(x, y);
                    if (colorOb.R == 0) bmap.SetPixel(x, y, Color.FromArgb(1, 0, 0));
                    else bmap.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                }
            }

            Boolean change = false;
            do
            {
                change = false;

                for (int x = start; x < bmap.Width - start; x++)
                {
                    for (int y = start; y < bmap.Height - start; y++)
                    {
                        if (A0.Contains(Weight(bmap, x, y)))
                        {
                            bmap.SetPixel(x, y, Color.FromArgb(2, 0, 0));
                        }
                    }
                }

                for (int x = start; x < bmap.Width - start; x++)
                {
                    for (int y = start; y < bmap.Height - start; y++)
                    {
                        Color color = bmap.GetPixel(x, y);
                        int colorWeight = Weight(bmap, x, y);
                        if (color.R == 2)
                        {
                            if (A1.Contains(colorWeight))
                            {
                                bmap.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                                change = true;
                            }
                        }
                    }
                }

                for (int x = start; x < bmap.Width - start; x++)
                {
                    for (int y = start; y < bmap.Height - start; y++)
                    {
                        Color color = bmap.GetPixel(x, y);
                        int colorWeight = Weight(bmap, x, y);
                        if (color.R == 2)
                        {
                            if (A2.Contains(colorWeight))
                            {
                                bmap.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                                change = true;
                            }
                        }
                    }
                }

                for (int x = start; x < bmap.Width - start; x++)
                {
                    for (int y = start; y < bmap.Height - start; y++)
                    {
                        Color color = bmap.GetPixel(x, y);
                        int colorWeight = Weight(bmap, x, y);
                        if (color.R == 2)
                        {
                            if (A3.Contains(colorWeight))
                            {
                                bmap.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                                change = true;
                            }
                        }
                    }
                }

                for (int x = start; x < bmap.Width - start; x++)
                {
                    for (int y = start; y < bmap.Height - start; y++)
                    {
                        Color color = bmap.GetPixel(x, y);
                        int colorWeight = Weight(bmap, x, y);
                        if (color.R == 2)
                        {
                            if (A4.Contains(colorWeight))
                            {
                                bmap.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                                change = true;
                            }
                        }
                    }
                }

                for (int x = start; x < bmap.Width - start; x++)
                {
                    for (int y = start; y < bmap.Height - start; y++)
                    {
                        Color color = bmap.GetPixel(x, y);
                        int colorWeight = Weight(bmap, x, y);
                        if (color.R == 2)
                        {
                            if (A5.Contains(colorWeight))
                            {
                                bmap.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                                change = true;
                            }
                        }
                    }
                }

                for (int x = start; x < bmap.Width - start; x++)
                {
                    for (int y = start; y < bmap.Height - start; y++)
                    {
                        Color color = bmap.GetPixel(x, y);
                        if (color.R > 0) bmap.SetPixel(x, y, Color.FromArgb(1, 0, 0));
                    }
                }

            } while (change == true);

            for (int x = start; x < bmap.Width - start; x++)
            {
                for (int y = start; y < bmap.Height - start; y++)
                {
                    Color color = bmap.GetPixel(x, y);
                    if (color.R > 0)
                    {
                        if(A1pix.Contains(Weight(bmap, x, y)))
                            bmap.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                    }
                }
            }

            for (int x = start; x < bmap.Width - start; x++)
            {
                for (int y = start; y < bmap.Height - start; y++)
                {
                    Color color = bmap.GetPixel(x, y);
                    if (color.R == 0)
                    {
                        bmap.SetPixel(x, y, Color.FromArgb(255, 255, 255));
                    }
                    else
                        bmap.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                }
            }

            return bmap;
        }

        public int Weight(Bitmap img, int i, int j)
        {
            return 1 * (img.GetPixel(i - 1, j).R ) + 2 * (img.GetPixel(i - 1, j + 1).R) +
                64 * (img.GetPixel(i, j - 1).R) + 4 * (img.GetPixel(i, j + 1).R) +
                32 * (img.GetPixel(i + 1, j - 1).R) + 16 * (img.GetPixel(i + 1, j).R) +
                8 * (img.GetPixel(i + 1, j + 1).R) + 128 * (img.GetPixel(i - 1, j - 1).R);
        }
    }
}
