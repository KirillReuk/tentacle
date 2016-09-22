using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitGenerator
{
    public static class Coloring
    {
        readonly static Color templateColor1 = Color.Magenta;
        readonly static Color templateColor2 = Color.Cyan;
        readonly static Color templateColor3 = Color.Yellow;

        public static bool ColorsAreClose(Color colorA, Color colorB, int threshold = 250)
        {
            int r = colorA.R - colorB.R;
            int g = colorA.G - colorB.G;
            int b = colorA.B - colorB.B;
            return (r * r + g * g + b * b) <= (threshold * threshold);
        }

        public static Color colorShift(Color rgbRefColor, Color rgbTargetColor, Color rgbPixelColor)
        {
            HSLColor refColor = new HSLColor(rgbRefColor);
            HSLColor targetColor = new HSLColor(rgbTargetColor);
            HSLColor pixelColor = new HSLColor(rgbPixelColor);

            pixelColor.Hue += targetColor.Hue - refColor.Hue;
            pixelColor.Saturation += targetColor.Saturation - refColor.Saturation;
            pixelColor.Luminosity += targetColor.Luminosity - refColor.Luminosity;

            return pixelColor;
        }

        public static byte[] Array1DFromBitmap(Bitmap bmp)
        {
            if (bmp == null) throw new NullReferenceException("Bitmap is null");

            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData data = bmp.LockBits(rect, ImageLockMode.ReadOnly, bmp.PixelFormat);
            IntPtr ptr = data.Scan0;

            int numBytes = data.Stride * bmp.Height;
            byte[] bytes = new byte[numBytes];

            System.Runtime.InteropServices.Marshal.Copy(ptr, bytes, 0, numBytes);

            bmp.UnlockBits(data);

            return bytes;
        }

        public static Bitmap BitmapFromArray1D(byte[] bytes, int width, int height)
        {
            Bitmap bmp = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData data = bmp.LockBits(rect, ImageLockMode.ReadWrite, bmp.PixelFormat);
            IntPtr ptr = data.Scan0;

            int grayBytes = data.Stride * bmp.Height;

            System.Runtime.InteropServices.Marshal.Copy(bytes, 0, ptr, grayBytes);

            bmp.UnlockBits(data);
            return bmp;
        }

        public static Bitmap ColorizeTemplateImage(Bitmap image, Color color1, Color color2, Color color3)
        {
            byte[] array1D = Array1DFromBitmap(image);
            byte[] resArray1D = new byte[array1D.Length];

            for (int ii = 0; ii < array1D.Length; ii += 4)
            {
                Color newColor = new Color();
                Color oldColor = Color.FromArgb(array1D[ii + 3], array1D[ii], array1D[ii + 1], array1D[ii + 2]);
                byte opacity = oldColor.A;

                if (ColorsAreClose(oldColor, templateColor1))
                {
                    newColor = Color.FromArgb(opacity, colorShift(templateColor1, color1, oldColor));
                }
                else if (ColorsAreClose(oldColor, templateColor2))
                {
                    newColor = Color.FromArgb(opacity, colorShift(templateColor2, color2, oldColor));
                }
                else if (ColorsAreClose(oldColor, templateColor3))
                {
                    newColor = Color.FromArgb(opacity, colorShift(templateColor3, color3, oldColor));
                }
                else
                    newColor = oldColor;

                resArray1D[ii] = newColor.B;
                resArray1D[ii + 1] = newColor.G;
                resArray1D[ii + 2] = newColor.R;
                resArray1D[ii + 3] = newColor.A;
            }

            Bitmap res = BitmapFromArray1D(resArray1D, image.Width, image.Height);
            return res;
        }

    }
}
