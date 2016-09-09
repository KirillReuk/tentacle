using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using ImageMagick;
using PhotoshopFile;
using System.Drawing.Imaging;

namespace KitGenerator
{
    public static class extensionMethods
    {
        public static void AddImage(this MagickImageCollection collection, MagickImageCollection imageCollection)
        {
            foreach (MagickImage layer in imageCollection)
                collection.Add(layer);
        }
        public static MagickImage paintMagickImage(this MagickImage image, Color NetColor)
        {
            Bitmap bm = image.ToBitmap();
            byte[] array1D = KitGenerator.Array1DFromBitmap(bm);
            byte[] resArray1D = new byte[array1D.Length];

            for (int ii = 0; ii < array1D.Length; ii += 4)
            {
                Color oldColor = Color.FromArgb(array1D[ii + 3], array1D[ii], array1D[ii + 1], array1D[ii + 2]); //ARGB

                resArray1D[ii] = NetColor.B;
                resArray1D[ii + 1] = NetColor.G;
                resArray1D[ii + 2] = NetColor.R;
                resArray1D[ii + 3] = array1D[ii + 3];
            }

            Bitmap res = KitGenerator.BitmapFromArray1D(resArray1D, image.Width, image.Height);


            return new MagickImage(res);
        }
    }

    public class KitGenerator
    {
        public string manufacturer;
        public string sponsor;
        public string design;
        public string collar;
        public string brand;
        string topImagePath, brandsImagePath, collarImagePath, sponsorImagePath, designImagePath, bottomImagePath;
        Color mainColor;
        List<Color> designColors, collarColors, brandColors;
        readonly Color templateColor1 = Color.Magenta;
        readonly Color templateColor2 = Color.Cyan;
        readonly Color templateColor3 = Color.Yellow;

        public KitGenerator(string _manufacturer, string _design, string _sponsor, string _collar, string _brand, Color _mainColor, List<Color> _designColors, List<Color> _collarColors, List<Color> _brandColors)
        {
            manufacturer = _manufacturer;
            design = _design;
            sponsor = _sponsor;
            collar = _collar;
            brand = _brand;

            topImagePath = "..\\..\\..\\kits\\top.psd";
            bottomImagePath = "..\\..\\..\\kits\\bottom.psd";

            designImagePath = "..\\..\\..\\kits\\designs\\" + manufacturer + " " + design.ToString() + ".png";
            sponsorImagePath = "..\\..\\..\\kits\\sponsors\\" + sponsor + ".psd";
            collarImagePath = "..\\..\\..\\kits\\collars\\" + collar.ToString() + ".png";
            brandsImagePath = "..\\..\\..\\kits\\brands\\" + manufacturer + " " + brand.ToString() + ".png";

            mainColor = _mainColor;
            designColors = _designColors;
            collarColors = _collarColors;
            brandColors = _brandColors;
        }
        
        private bool ColorsAreClose(Color colorA, Color colorB, int threshold = 250)
        {
            int r = colorA.R - colorB.R;
            int g = colorA.G - colorB.G;
            int b = colorA.B - colorB.B;
            return (r * r + g * g + b * b) <= (threshold * threshold);
        }
        
        private Color colorShift(Color rgbRefColor, Color rgbTargetColor, Color rgbPixelColor)
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

        private Bitmap ColorizeTemplateImage(Bitmap image, Color color1, Color color2, Color color3)
        {
            byte[] array1D = Array1DFromBitmap(image);
            byte[] resArray1D = new byte[array1D.Length];

            for (int ii = 0; ii < array1D.Length; ii+=4)
            {
                Color newColor = new Color();
                Color oldColor = Color.FromArgb(array1D[ii+3], array1D[ii], array1D[ii + 1], array1D[ii + 2]);
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
                resArray1D[ii+1] = newColor.G;
                resArray1D[ii+2] = newColor.R;
                resArray1D[ii+3] = newColor.A;
            }

            Bitmap res = BitmapFromArray1D(resArray1D, image.Width, image.Height);
            return res;
        }
        
        public Image GetKit()
        {
            //bottom layer
            MagickImageCollection collection = new MagickImageCollection(bottomImagePath);

            Rectangle offsetRect = new PsdFile(bottomImagePath, Encoding.ASCII).Layers[0].Rect;

            MagickImage frame = collection[0].paintMagickImage(mainColor);
            frame.Page = new MagickGeometry(offsetRect.X, offsetRect.Y, 0, 0);
            collection.Add(frame);
            
            Bitmap design = (Bitmap)Bitmap.FromFile(designImagePath);
            MagickImage designImg = new MagickImage(ColorizeTemplateImage(design, designColors[0], designColors[1], designColors[2]));
            collection.Add(designImg);

            Bitmap collar = (Bitmap)Bitmap.FromFile(collarImagePath);
            MagickImage collarImg = new MagickImage(ColorizeTemplateImage(collar, collarColors[0], collarColors[1], collarColors[2]));
            collection.Add(collarImg);

            Bitmap brand = (Bitmap)Bitmap.FromFile(brandsImagePath);
            MagickImage brandImg = new MagickImage(ColorizeTemplateImage(brand, brandColors[0], brandColors[1], brandColors[2]));
            collection.Add(brandImg);
            
            
            collection.AddImage(new MagickImageCollection(sponsorImagePath));
            
            MagickImageCollection topImageCollection = new MagickImageCollection(topImagePath);

            List<Tuple<int, int>> offsets = new List<Tuple<int, int>>();
            PsdFile ps = new PsdFile(topImagePath, Encoding.ASCII);
            foreach (Layer layer in ps.Layers)
            {
                if (layer.Name != "</Layer group>")
                    offsets.Add(new Tuple<int, int>(layer.Rect.X, layer.Rect.Y));
            }

            MagickImage result = collection.Mosaic();
            result.Composite(topImageCollection[1], offsets[0].Item1, offsets[0].Item2, CompositeOperator.Multiply);
            result.Composite(topImageCollection[2], offsets[1].Item1, offsets[1].Item2, CompositeOperator.Darken);
            result.Composite(topImageCollection[3], offsets[2].Item1, offsets[2].Item2, CompositeOperator.Multiply);
            result.Composite(topImageCollection[4], offsets[3].Item1, offsets[3].Item2, CompositeOperator.HardLight);
            result.Composite(topImageCollection[5], offsets[4].Item1, offsets[4].Item2, CompositeOperator.No);
            
            return result.ToBitmap();
        }
    }
}