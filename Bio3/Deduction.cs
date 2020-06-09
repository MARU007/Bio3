using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bio3
{
    class Deduction
    {
        public Bitmap DeductionImage(Bitmap monochrome, Bitmap  blur)
        {
            Bitmap bitmap = new Bitmap(blur);
            Color newPixel;
            int tmpR, tmpG, tmpB;
            for (int i = 0; i < blur.Width; i++)
            {
                for (int j = 0; j < blur.Height; j++)
                {
                    tmpR = blur.GetPixel(i, j).R - monochrome.GetPixel(i, j).R;
                    tmpG = blur.GetPixel(i, j).G - monochrome.GetPixel(i, j).G;
                    tmpB = blur.GetPixel(i, j).B - monochrome.GetPixel(i, j).B;
                    if (tmpR < 0) tmpR = 0;
                    if (tmpG < 0) tmpG = 0;
                    if (tmpB < 0) tmpB = 0;
                    newPixel = System.Drawing.Color.FromArgb(tmpR, tmpG, tmpB);
                    bitmap.SetPixel(i,j,newPixel);
                }
            }
            return bitmap;
        }

    }
}
