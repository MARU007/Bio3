using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bio3
{
    class OtsuBinarization
    {
        public Bitmap Binarization(Bitmap b) //otsu
        {
            if (b != null)
            {
                System.Drawing.Color curColor;
                int kolor;
                int prog;
                prog = ObliczanieProgOtsu(b);

                for (int i = 0; i < b.Width; i++)
                {
                    for (int j = 0; j < b.Height; j++)
                    {
                        curColor = b.GetPixel(i, j);
                        kolor = curColor.R;

                        if (kolor > prog)
                        {
                            kolor = 255;
                        }
                        else
                            kolor = 0;
                        b.SetPixel(i, j, Color.FromArgb(kolor, kolor, kolor));
                    }
                }
            }
            return b;
        }
        private int ObliczanieProgOtsu(Bitmap b)
        {
            int[] histogram = new int[256];
            for (int m = 0; m < b.Width; m++)
            {
                for (int n = 0; n < b.Height; n++)
                {
                    System.Drawing.Color pixel = b.GetPixel(m, n);
                    histogram[pixel.R]++;
                }
            }
            long[] pob = new long[256];
            long[] pt = new long[256];
            for (int t = 0; t < 256; t++)
            {
                for (int t1 = 0; t1 <= t; t1++)
                    pob[t] += histogram[t1];
                for (int t1 = t + 1; t1 < 256; t1++)
                    pt[t] += histogram[t1];
            }
            double[] srOb = new double[256];
            double[] srT = new double[256];
            for (int t = 0; t < 256; t++)
            {
                for (int k = 0; k <= t; k++)
                    srOb[t] += (k * histogram[k]);
                for (int k = t + 1; k < 256; k++)
                    srT[t] += (k * histogram[k]);
            }
            for (int t = 0; t < 256; t++)
            {
                if (pob[t] != 0)
                    srOb[t] = srOb[t] / pob[t];
                if (pt[t] != 0)
                    srT[t] = srT[t] / pt[t];
            }
            double[] wariancjaMiedzy = new double[256];
            double maks = 0;
            for (int t = 0; t < 256; t++)
                wariancjaMiedzy[t] = pob[t] * pt[t] * (srOb[t] - srT[t]) * (srOb[t] - srT[t]);
            int x = 0;
            for (int w = 0; w < 256; w++)
            {
                if (wariancjaMiedzy[w] > maks)
                {
                    maks = wariancjaMiedzy[w];
                    x = w;
                }
            }
            return x;
        }
    }
}
