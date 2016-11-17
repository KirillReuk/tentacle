using ImageMagick;
using PhotoshopFile;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

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
            byte[] array1D = Coloring.Array1DFromBitmap(bm);
            byte[] resArray1D = new byte[array1D.Length];

            for (int ii = 0; ii < array1D.Length; ii += 4)
            {
                Color oldColor = Color.FromArgb(array1D[ii + 3], array1D[ii], array1D[ii + 1], array1D[ii + 2]); //ARGB

                resArray1D[ii] = NetColor.B;
                resArray1D[ii + 1] = NetColor.G;
                resArray1D[ii + 2] = NetColor.R;
                resArray1D[ii + 3] = array1D[ii + 3];
            }

            Bitmap res = Coloring.BitmapFromArray1D(resArray1D, image.Width, image.Height);
            
            return new MagickImage(res);
        }
    }

    public class KitGenerator
    {
        public string manufacturer;
        Color mainColor;
        List<KitLayer> kitLayers;
        int boxX, boxY;

        public const int defaultXResolution = 414;
        public const int defaultYResolution = 414;
        public const string topImagePath = "..\\..\\..\\kits\\top.psd";
        public const string bottomImagePath = "..\\..\\..\\kits\\bottom.psd";
        public const string blankImagePath = "..\\..\\..\\kits\\_blank.png";

        public KitGenerator(Color? baseColor = null, List<KitLayer> _kitLayers = null)
        {
            mainColor = (Color)baseColor;

            kitLayers = _kitLayers;
        }

        public KitGenerator(string _manufacturer = "", Color? baseColor = null, List<KitLayer> _kitLayers = null, int _boxX = 0, int _boxY = 0)
        {
            manufacturer = _manufacturer;
            
            kitLayers = _kitLayers;
            
            boxX = _boxX;
            boxY = _boxY;

            mainColor = (Color)baseColor;
        }
        
        public Image GetKit(bool bottomFlag = true, bool topFlag = true)
        {
            MagickImageCollection collection;

            if (bottomFlag)
            {
                collection = new MagickImageCollection(bottomImagePath);

                Rectangle offsetRect = new PsdFile(bottomImagePath, Encoding.ASCII).Layers[2].Rect;
                collection[3] = new MagickImage(collection[3].paintMagickImage(mainColor));
                collection[3].Page = new MagickGeometry(offsetRect.X, offsetRect.Y, 0, 0);
            }
            else
            {
                collection = new MagickImageCollection();
                Bitmap blank = new Bitmap(blankImagePath);
                collection.Add(new MagickImage(blank));
            }

            foreach (KitLayer kl in kitLayers)
            {
                Bitmap bm = (Bitmap)Bitmap.FromFile(kl.ImageLocation);
                if (!kl.SystemLayer)
                    bm = Coloring.CustomizeBitmap(bm, kl.XShift, kl.YShift, kl.Rotation, kl.Scaling, boxX, boxY);
                MagickImage img = new MagickImage(Coloring.ColorizeTemplateImage(bm, kl.Colors[0], kl.Colors[1], kl.Colors[2]));
                collection.Add(img);
            }

            MagickImage result;

            result = collection.Mosaic();

            if (topFlag)
                return Coloring.AddTopLayer(result.ToBitmap(), topImagePath);
            else           
                return result.ToBitmap();
        }
    }
}