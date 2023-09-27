using IsoTilesBuild.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsoTilesBuild.Utils
{
    internal static class Mask
    {
        public static Bitmap ApplyTransparencyMask(this Bitmap bmp, Bitmap mask)
        {
            int w = Math.Min(bmp.Width, mask.Width);
            int h = Math.Min(bmp.Height, mask.Height);
            Bitmap result = new Bitmap(w, h);

            var rect = new Rectangle(0, 0, w, h);
            var bitsMask = mask.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            var bitsbmp = bmp.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            var bitsOutput = result.LockBits(rect, ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            unsafe
            {
                for (int y = 0; y < h; y++)
                {
                    byte* ptrMask = (byte*)bitsMask.Scan0 + y * bitsMask.Stride;
                    byte* ptrbmp = (byte*)bitsbmp.Scan0 + y * bitsbmp.Stride;
                    byte* ptrOutput = (byte*)bitsOutput.Scan0 + y * bitsOutput.Stride;
                    for (int x = 0; x < w; x++)
                    {
                        if (ptrMask[4*x]==255)
                        {
                            ptrOutput[4 * x] = ptrbmp[4 * x];           // blue
                            ptrOutput[4 * x + 1] = ptrbmp[4 * x + 1];   // green
                            ptrOutput[4 * x + 2] = ptrbmp[4 * x + 2];   // red
                            ptrOutput[4 * x + 3] = ptrbmp[4 * x + 3];        // alpha
                        }                        
                    }
                }
            }
            mask.UnlockBits(bitsMask);
            bmp.UnlockBits(bitsbmp);
            result.UnlockBits(bitsOutput);

            return result;
        }

        public static Bitmap TileMask(Color color)
        {
            using (Bitmap solid = new Bitmap(24, 16))
            {
                using (var g = Graphics.FromImage(solid))
                {
                    g.Clear(color);
                }
                return solid.ApplyTransparencyMask(Resources.iso_mask);
            }
        }
    }
}
