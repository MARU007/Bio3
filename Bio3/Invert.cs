using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bio3
{
    class Invert
    {
        public Bitmap InvertColors(Bitmap bitmap)
        {
            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    Color color = bitmap.GetPixel(x, y);
                    bitmap.SetPixel(x, y, Color.FromArgb((color.R * -1) + 255, (color.G * -1) + 255, (color.B * -1) + 255));
                }
            }
            return bitmap;
        }
    }
}
