using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bio3
{
    class Filter
    {
        public Bitmap FilterM(int rozmiarMaski, System.Drawing.Bitmap b)
        {
            int dlugosc = rozmiarMaski * rozmiarMaski;
            int pol = rozmiarMaski / 2;
            if (b != null)
            {
                System.Drawing.Color kolorWejsciowy;
                int[,] nowePixeleR = new int[b.Width, b.Height];


                for (int x = 0 + pol; x < b.Width - pol; x++)
                {
                    for (int y = 0 + pol; y < b.Height - pol; y++)
                    {
                        int[] tableR = new int[dlugosc];

                        int o = 0;
                        for (int i = x - pol; i <= x + pol; i++)
                        {
                            for (int j = y - pol; j <= y + pol; j++)
                            {
                                kolorWejsciowy = b.GetPixel(i, j);
                                tableR[o] = kolorWejsciowy.R;
                                o++;
                            }
                        }

                        Array.Sort(tableR);
                        int medianValueR = tableR[dlugosc / 2];
                      
                        nowePixeleR[x, y] = medianValueR;
                   
                    }
                }
                for (int x = 0 + pol; x < b.Width - pol; x++)
                    for (int y = 0 + pol; y < b.Height - pol; y++)
                        b.SetPixel(x, y, System.Drawing.Color.FromArgb(nowePixeleR[x, y], nowePixeleR[x, y], nowePixeleR[x, y]));
            }
            return b;
        }
    }
}
