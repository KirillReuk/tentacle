using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using ImageMagick;
using PhotoshopFile;
using System.IO;

namespace KitGenerator
{
    public class KitGenerator
    {
        public string manufacturer { get; set;}
        public int kitNumber { get; set;}   
        string imagePath;
        string colorsPath;
        List<Color> colors;

        public KitGenerator(string _manufacturer, int _kitNumber)
        {
            manufacturer = _manufacturer;
            kitNumber = _kitNumber;
            imagePath = "..\\..\\..\\kits\\" + manufacturer + "\\" + manufacturer + " " + kitNumber.ToString() + ".psd";
            colorsPath = "..\\..\\..\\kits\\" + manufacturer + "\\colors.txt";

            colors = new List<Color>();
            colors.Add(Color.FromArgb(255, 255, 255));
            colors.Add(Color.FromArgb(255, 0, 0));
            colors.Add(Color.FromArgb(16, 64, 152));
        }

        public KitGenerator(string _manufacturer, int _kitNumber, Color color1, Color color2, Color color3)
        {
            manufacturer = _manufacturer;
            kitNumber = _kitNumber;
            imagePath = "..\\..\\..\\kits\\" + manufacturer + "\\" + manufacturer + " " + kitNumber.ToString() + ".psd";
            colorsPath = "..\\..\\..\\kits\\" + manufacturer + "\\colors.txt";

            colors = new List<Color>();
            colors.Add(color1);
            colors.Add(color2);
            colors.Add(color3);
        }

        public Image GetImage()
        {
            MagickImageCollection collection = new MagickImageCollection(imagePath);
            collection.RemoveAt(0);
            MagickImageCollection newCollection = new MagickImageCollection();
            List<Tuple<int, int>> offsets = new List<Tuple<int, int>>();

            PsdFile ps = new PsdFile(imagePath, Encoding.ASCII);
            foreach (Layer layer in ps.Layers)
            {
                if (layer.Name != "</Layer group>")
                    offsets.Add(new Tuple<int, int>(layer.Rect.X, layer.Rect.Y));
            }

            Dictionary<int, Color> colorDic = new Dictionary<int, Color>();
            
            
            
            String line = "";
            using (StreamReader sr = new StreamReader(colorsPath))
            {
                line = sr.ReadLine();
                while (!line.StartsWith(kitNumber.ToString()))
                {
                    line = sr.ReadLine();
                }
            }

            foreach (var x in line.Remove(0, kitNumber.ToString().Length + 1).Split(' ').Select((value, index) => new { value, index }))
            {
                int res = 0;
                string val = x.value;
                if (val.EndsWith("+") && (Int32.TryParse(val.Remove(val.Length - 1), out res)))
                    colorDic.Add(x.index, SlightlyDarker(colors[res]));
                if (val.EndsWith("-") && (Int32.TryParse(val.Remove(val.Length - 1), out res)))
                    colorDic.Add(x.index, SlightlyBrighter(colors[res]));
                if (Int32.TryParse(val, out res) && (res >= 0))
                    colorDic.Add(x.index, colors[res]);
            }

            foreach (var pair in colorDic)
            {
                MagickImage frame = paintImage(collection[pair.Key], pair.Value);
                frame.Page = new MagickGeometry(offsets[pair.Key].Item1, offsets[pair.Key].Item2, 0, 0);
                newCollection.Add(frame);
            }
            newCollection.Add(collection.Last());
            return newCollection.Mosaic().ToBitmap();
        }

        public static bool FilePathHasInvalidChars(string path)
        {
            return (!string.IsNullOrEmpty(path) && path.IndexOfAny(System.IO.Path.GetInvalidPathChars()) >= 0);
        }

        private Color SlightlyBrighter(Color color)
        {
            return Color.FromArgb(color.A, Math.Min(color.R + 30, 255), Math.Min(color.G + 30, 255), Math.Min(color.B + 30, 255));
        }

        private Color SlightlyDarker(Color color)
        {
            return Color.FromArgb(color.A, Math.Max(color.R - 30, 0), Math.Max(color.G - 30, 0), Math.Max(color.B - 30, 0));
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