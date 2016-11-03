using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;

namespace KitGenerator
{
    public static unsafe class Coloring
    {
        readonly static Color templateColor1 = Color.Magenta;
        readonly static Color templateColor2 = Color.Cyan;
        readonly static Color templateColor3 = Color.Yellow;

        public static int GetNumberOfColors(Bitmap image)
        {
            bool[] cols = new bool[3];
            byte[] array1D = Array1DFromBitmap(image);
            
            for (int ii = 0; ii < array1D.Length; ii =+ 4)
            {
                Color theColor = Color.FromArgb(array1D[ii + 3], array1D[ii], array1D[ii + 1], array1D[ii + 2]);
                if (ColorsAreClose(templateColor1, theColor))
                    cols[1] = true;
                if (ColorsAreClose(templateColor2, theColor))
                    cols[2] = true;
                if (ColorsAreClose(templateColor3, theColor))
                    cols[3] = true;

                if (cols[1] && cols[2] && cols[3])
                    return 3;
            }
            return cols.Count(c => c);
        }

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

        public static Rectangle GetTrimmedCoordinates(Bitmap source)
        {
            if (source == null)
                return new Rectangle();
            Rectangle srcRect = default(Rectangle);
            BitmapData data = null;
            try
            {
                data = source.LockBits(new Rectangle(0, 0, source.Width, source.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
                byte[] buffer = new byte[data.Height * data.Stride];
                System.Runtime.InteropServices.Marshal.Copy(data.Scan0, buffer, 0, buffer.Length);

                int xMin = int.MaxValue,
                    xMax = int.MinValue,
                    yMin = int.MaxValue,
                    yMax = int.MinValue;

                bool foundPixel = false;

                // Find xMin
                for (int x = 0; x < data.Width; x++)
                {
                    bool stop = false;
                    for (int y = 0; y < data.Height; y++)
                    {
                        byte alpha = buffer[y * data.Stride + 4 * x + 3];
                        if (alpha != 0)
                        {
                            xMin = x;
                            stop = true;
                            foundPixel = true;
                            break;
                        }
                    }
                    if (stop)
                        break;
                }

                // Image is empty...
                if (!foundPixel)
                    return new Rectangle();

                // Find yMin
                for (int y = 0; y < data.Height; y++)
                {
                    bool stop = false;
                    for (int x = xMin; x < data.Width; x++)
                    {
                        byte alpha = buffer[y * data.Stride + 4 * x + 3];
                        if (alpha != 0)
                        {
                            yMin = y;
                            stop = true;
                            break;
                        }
                    }
                    if (stop)
                        break;
                }

                // Find xMax
                for (int x = data.Width - 1; x >= xMin; x--)
                {
                    bool stop = false;
                    for (int y = yMin; y < data.Height; y++)
                    {
                        byte alpha = buffer[y * data.Stride + 4 * x + 3];
                        if (alpha != 0)
                        {
                            xMax = x;
                            stop = true;
                            break;
                        }
                    }
                    if (stop)
                        break;
                }

                // Find yMax
                for (int y = data.Height - 1; y >= yMin; y--)
                {
                    bool stop = false;
                    for (int x = xMin; x <= xMax; x++)
                    {
                        byte alpha = buffer[y * data.Stride + 4 * x + 3];
                        if (alpha != 0)
                        {
                            yMax = y;
                            stop = true;
                            break;
                        }
                    }
                    if (stop)
                        break;
                }

                srcRect = Rectangle.FromLTRB(xMin, yMin, xMax, yMax);
            }
            finally
            {
                if (data != null)
                    source.UnlockBits(data);
            }
            
            return srcRect;
        }

        public static Bitmap MatrixBlend(Bitmap _image1, Bitmap image2, byte alpha = 255)
        {
            Bitmap image1 = new Bitmap(_image1);

            if ((_image1 == null) || (image2 == null))
                return image1;

            float alphaNorm = (float)alpha / 255.0F;

            ColorMatrix matrix = new ColorMatrix(new float[][]{
                new float[] {1F, 0, 0, 0, 0},
                new float[] {0, 1F, 0, 0, 0},
                new float[] {0, 0, 1F, 0, 0},
                new float[] {0, 0, 0, alphaNorm, 0},
                new float[] {0, 0, 0, 0, 1F}});

            ImageAttributes imageAttributes = new ImageAttributes();
            imageAttributes.SetColorMatrix(matrix);

            using (Graphics g = Graphics.FromImage(image1))
            {
                g.CompositingMode = CompositingMode.SourceOver;
                g.CompositingQuality = CompositingQuality.HighQuality;

                g.DrawImage(image2,
                    new Rectangle(0, 0, image1.Width, image1.Height),
                    0,
                    0,
                    image2.Width,
                    image2.Height,
                    GraphicsUnit.Pixel,
                    imageAttributes);
            }
            return image1;
        }

    }
}
