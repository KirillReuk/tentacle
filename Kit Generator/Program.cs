using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using ImageMagick;
using PhotoshopFile;
using System.IO;
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
    }

    public class KitGenerator
    {
        public string manufacturer { get; set;}
        public string sponsor { get; set; }
        public string design { get; set;}
        public string collar { get; set; }
        public string brand { get; set; }
        string topImagePath, brandsImagePath, collarImagePath, sponsorImagePath, designImagePath, bottomImagePath;
        Color mainColor, color1, color2, color3;
        readonly Color templateColor1 = Color.Magenta;
        readonly Color templateColor2 = Color.Cyan;
        readonly Color templateColor3 = Color.Yellow;

        public KitGenerator(string _manufacturer, string _design, string _sponsor, string _collar, string _brand, Color _mainColor, Color _color1, Color _color2, Color _color3)
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
            collarImagePath = "..\\..\\..\\kits\\collars\\" + manufacturer + " " + collar.ToString() + ".png";
            brandsImagePath = "..\\..\\..\\kits\\brands\\" + manufacturer + " " + brand.ToString() + ".png";

            mainColor = _mainColor;
            color1 = _color1;
            color2 = _color2;
            color3 = _color3;
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

        private Bitmap ColorizeTemplateImage(Bitmap image, Color color1, Color color2, Color color3)
        {
            Bitmap res = (Bitmap)image.Clone();

            for (int ii = 0; ii < res.Width; ii++)
            {
                for (int jj = 0; jj < res.Height; jj++)
                {
                    byte opacity = image.GetPixel(ii, jj).A;
                    Color oldColor = Color.FromArgb(255, image.GetPixel(ii, jj));
                    Color newColor = new Color();

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
                        newColor = Color.FromArgb(opacity, oldColor);

                    Color x = res.GetPixel(0, 0);
                    res.SetPixel(ii, jj, newColor);
                }
            }

            return res;
        }
        
        public Image GetKit()
        {
            MagickImageCollection collection = new MagickImageCollection(bottomImagePath);

            Rectangle offsetRect = new PsdFile(bottomImagePath, Encoding.ASCII).Layers[0].Rect;

            MagickImage frame = paintImage(collection[0], mainColor);
            frame.Page = new MagickGeometry(offsetRect.X, offsetRect.Y, 0, 0);
            collection.Add(frame);
            
                    

            Bitmap design = (Bitmap)Bitmap.FromFile(designImagePath);
            Bitmap collar = (Bitmap)Bitmap.FromFile(collarImagePath);
            Bitmap brand = (Bitmap)Bitmap.FromFile(brandsImagePath);

            using (Graphics g = Graphics.FromImage(design))
            {
                g.DrawImage(collar, new Point(0, 0));
                g.DrawImage(brand, new Point(0, 0));
            }
            
            Bitmap colorizedDesign = ColorizeTemplateImage(design, color1, color2, color3);
            
            for (int ii = 0; ii < design.Height; ii++)
                for (int jj = 0; jj < design.Height; jj++)
                    if (design.GetPixel(ii, jj) == colorizedDesign.GetPixel(ii, jj))
                        break;
            
                        
            MagickImage img = new MagickImage(colorizedDesign);

            
            collection.Add(img);
            
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

        public static bool FilePathHasInvalidChars(string path)
        {
            return (!string.IsNullOrEmpty(path) && path.IndexOfAny(System.IO.Path.GetInvalidPathChars()) >= 0);
        }
        

        private MagickImage paintImage(MagickImage image, Color NetColor)
        {
            Bitmap bm = image.ToBitmap();

            for (int i = 0; i < bm.Width; i++)
                for (int j = 0; j < bm.Height; j++)
                    bm.SetPixel(i, j, Color.FromArgb(bm.GetPixel(i, j).A, NetColor.R, NetColor.G, NetColor.B));

            MagickImage res = new MagickImage(bm);
            return res;
        }
    }
}