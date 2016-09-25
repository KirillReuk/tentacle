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
        string topImagePath, bottomImagePath;
        Color mainColor;
        List<KitLayer> kitLayers;

        public KitGenerator(string _manufacturer = "", Color? baseColor = null, List<KitLayer> _kitLayers = null)
        {
            manufacturer = _manufacturer;
        
            kitLayers = _kitLayers;

            topImagePath = "..\\..\\..\\kits\\top.psd";
            bottomImagePath = "..\\..\\..\\kits\\bottom.psd";
            
            mainColor = (Color)baseColor;
        }
        
        public Image GetKit()
        {
            MagickImageCollection collection = new MagickImageCollection(bottomImagePath);

            Rectangle offsetRect = new PsdFile(bottomImagePath, Encoding.ASCII).Layers[0].Rect;
            
            MagickImage frame = collection[0].paintMagickImage(mainColor);
            frame.Page = new MagickGeometry(offsetRect.X, offsetRect.Y, 0, 0);
            collection.Add(frame);

            foreach (KitLayer kl in kitLayers)
            {
                Bitmap bm = (Bitmap)Bitmap.FromFile(kl.imageLocation);
                MagickImage img = new MagickImage(Coloring.ColorizeTemplateImage(bm, kl.colors[0], kl.colors[1], kl.colors[2]));
                collection.Add(img);
            }
           
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