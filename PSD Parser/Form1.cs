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
        const int countStart = 81;
        const int countEnd = 95;
        string imagePath = "C:\\Users\\Kirill\\Documents\\Uni\\tentacleporn\\Standard Pack v3.0\\Adidas\\Adidas 81-94.psd";
        string imageSavePath = "C:\\Users\\Kirill\\Documents\\Uni\\tentacleporn\\Standard Pack v3.0\\Adidas\\Adidas 1-401.psd";
        string imageSaveFolder = "C:\\Users\\Kirill\\Documents\\Uni\\tentacleporn\\Standard Pack v3.0\\Adidas\\";

        public Form1()
        {
            InitializeComponent();
            action();
        }

        private void action()
        {
            PsdFile image = new PsdFile();
            if (!FilePathHasInvalidChars(imagePath))
            {
                image = new PsdFile(imagePath, Encoding.ASCII);
                image.Save(imageSavePath, Encoding.ASCII);
            }

            int cow = 3;
            for (int j = countStart; j < countEnd; ++j)
            {
                PsdFile newImage = new PsdFile(imageSavePath, Encoding.ASCII);
                newImage.Layers.Clear();

                newImage.Layers.Add(image.Layers[1]);
                for (; (image.Layers[cow].Name != manufacturer + " " + j) && (image.Layers[cow].Name != manufacturer + j); cow++)
                    newImage.Layers.Add(image.Layers[cow]);
                newImage.Layers.Add(image.Layers[cow]);
                newImage.Layers.Add(image.Layers[image.Layers.Count-2]);

                newImage.Save(imageSaveFolder + manufacturer + " " + j + ".psd", Encoding.ASCII);
                cow++;
            }
        }

        public static bool FilePathHasInvalidChars(string path)
        {
            return (!string.IsNullOrEmpty(path) && path.IndexOfAny(System.IO.Path.GetInvalidPathChars()) >= 0);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int convertedInt;
            if (Int32.TryParse(textBox1.Text, out convertedInt))
            {
                showLayer(convertedInt);
            }
        }

        private void showLayer(int layerNumber)
        {
            
            using (MagickImageCollection collection = new MagickImageCollection(imagePath))
            {
                MagickReadSettings settings = new MagickReadSettings();
                
                MagickImage image = collection[layerNumber];
                MagickFormatInfo info = image.FormatInfo;

                pictureBox.Image = image.ToBitmap();
            }
        }
    }
}
