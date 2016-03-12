using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImageMagick;
using PhotoshopFile;
using PaintDotNet.Core;

namespace Kit_Generator
{
    public partial class Form1 : Form
    {
        const string manufacturer = "Adidas";
        string imagePath = "C:\\Users\\Kirill\\Documents\\Uni\\tentacleporn\\kits\\adidas\\Adidas 85.psd";

        int[] values = { };
        

        public Form1()
        {
            InitializeComponent();
            action();
        }

        private void action()
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
            colorDic.Add(0, Color.FromArgb(16, 64, 152));
            colorDic.Add(1, Color.FromArgb(255, 255, 255));
            colorDic.Add(2, Color.FromArgb(16, 64, 152));
            colorDic.Add(3, Color.FromArgb(16, 64, 152));
            colorDic.Add(4, Color.FromArgb(255, 255, 255));
            colorDic.Add(5, Color.FromArgb(16, 64, 152));
            colorDic.Add(6, Color.FromArgb(16, 64, 152));
            colorDic.Add(7, Color.FromArgb(16, 64, 152));
            colorDic.Add(8, Color.FromArgb(16, 64, 152));
            colorDic.Add(9, Color.FromArgb(16, 64, 152));
            colorDic.Add(10, Color.FromArgb(16, 64, 152));
            colorDic.Add(11, Color.FromArgb(16, 64, 152));
            colorDic.Add(12, Color.FromArgb(255, 0, 0));
            colorDic.Add(13, Color.FromArgb(255, 255, 255));
            colorDic.Add(14, Color.FromArgb(16, 64, 152));
            colorDic.Add(15, Color.FromArgb(255, 255, 255));
            colorDic.Add(16, Color.FromArgb(16, 64, 152));
            colorDic.Add(17, Color.FromArgb(16, 64, 152));
            colorDic.Add(18, Color.FromArgb(16, 64, 152));
            colorDic.Add(19, Color.FromArgb(16, 64, 152));
            colorDic.Add(20, Color.FromArgb(16, 64, 152));
            colorDic.Add(21, Color.FromArgb(16, 64, 152));
            colorDic.Add(22, Color.FromArgb(46, 94, 182));
            colorDic.Add(23, Color.FromArgb(46, 94, 182));
            colorDic.Add(24, Color.FromArgb(46, 94, 182));
            colorDic.Add(25, Color.FromArgb(255, 255, 255));
            colorDic.Add(26, Color.FromArgb(255, 0, 0));

            foreach (var pair in colorDic)
            {
                MagickImage frame = paintImage(collection[pair.Key], pair.Value);
                frame.Page = new MagickGeometry(offsets[pair.Key].Item1, offsets[pair.Key].Item2, 0, 0);
                newCollection.Add(frame);
            }
            newCollection.Add(collection.Last());
            pictureBox.Image = newCollection.Mosaic().ToBitmap();
        }

        public static bool FilePathHasInvalidChars(string path)
        {
            return (!string.IsNullOrEmpty(path) && path.IndexOfAny(System.IO.Path.GetInvalidPathChars()) >= 0);
        }

        private bool pixelCheck(MagickImage image, int x, int y)
        {
            
            if (((x >= 0) && (y >= 0) && (x < image.Width) && (y < image.Height))&&
                    (image.GetPixels()[x, y].ToColor() != image.GetPixels()[0, 0].ToColor()))
                return true;
            else
                return false;
        }

        private Pixel validPixel(MagickImage image)
        {
            for (int x = 0; x < image.Width; ++x)
                for (int y = 0; y < image.Width; ++y)
                    if (pixelCheck(image, x, y) && pixelCheck(image, x - 1, y) && pixelCheck(image, x, y - 1) && pixelCheck(image, x + 1, y) && pixelCheck(image, x, y + 1))
                        return image.GetPixels()[x, y];
            
            return image.GetPixels()[0, 0];
        }

        private MagickImage paintImage(MagickImage image, Color NetColor)
        {
            Bitmap bm = image.ToBitmap();
            for (int i = 0; i < bm.Width; i++)
                for (int j = 0; j < bm.Height; j++)
                    if (bm.GetPixel(i, j).A != 0)
                        bm.SetPixel(i, j, NetColor);

            MagickImage res = new MagickImage(bm);
            return res;
        }
    }
}
