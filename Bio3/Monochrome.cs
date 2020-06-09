using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bio3
{
    class Monochrome
    {
        public Bitmap ReplacementForGray(Bitmap bmp)
        {
            System.Drawing.Color p;
            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    p = bmp.GetPixel(x, y);

                    int a = p.A;
                    int r = p.R;
                    int g = p.G;
                    int b = p.B;
                    int avg = (r + g + b) / 3;

                    bmp.SetPixel(x, y, System.Drawing.Color.FromArgb(a, avg, avg, avg));
                }
            }
            return bmp;
        }
    }
}
