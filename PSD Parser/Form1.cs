using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace KitGenerator
{
    public partial class Form1 : Form
    {
        string manufacturer;
        string brand;
        string collar;

        int currentItemIndex = -1; //manufacturer 1, collar 2, branding 3, layers 4
        string collarLayersPath = "..\\..\\..\\kits\\collars\\";
        string brandLayersPath = "..\\..\\..\\kits\\brands\\"; 
        string manLayersPath = "..\\..\\..\\kits\\manufacturers\\";
        string blankImagePath = "..\\..\\..\\kits\\_blank.png";

        List<Color> designColors = new List<Color>();
        List<KitLayer> kitLayers = new List<KitLayer>();

        Bitmap oldPreview;

        public Form1()
        {
            InitializeComponent();
            Initialization();
        }

        private void Initialization()
        {
            manDataGridView.Rows.Add();
            collarDataGridView.Rows.Add();
            brandDataGridView.Rows.Add();
            RefreshImage();
        }

        private void RefreshImage()
        {
            kitLayers.Clear();

            designColors.Clear();

            designColors.Add(colorButton1.BackColor);
            designColors.Add(colorButton2.BackColor);
            designColors.Add(colorButton3.BackColor);


            if (!String.IsNullOrEmpty(collar))
            {
                KitLayer collarLayer = new KitLayer(
                collar,
                collarLayersPath + collarDataGridView[0, 0].Value + ".png",
                new List<Color>(new Color[] { collarDataGridView[1, 0].Style.BackColor, collarDataGridView[2, 0].Style.BackColor, collarDataGridView[3, 0].Style.BackColor }),
                0,
                new Rectangle());
                kitLayers.Add(collarLayer);
            }

            if (!String.IsNullOrEmpty(brand))
            {
                KitLayer brandLayer = new KitLayer(
                brand,
                brandLayersPath + brandDataGridView[0, 0].Value + ".png",
                new List<Color>(new Color[] { brandDataGridView[1, 0].Style.BackColor, brandDataGridView[2, 0].Style.BackColor, brandDataGridView[3, 0].Style.BackColor }),
                0,
                new Rectangle());
                kitLayers.Add(brandLayer);
            }
            
            Color baseColor = mainColorButton.BackColor;

            KitGenerator kg = new KitGenerator(manufacturer, baseColor, kitLayers);
            pictureBox.Image = kg.GetKit();
            
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            RefreshImage();
        }

        private void colorButton1_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                colorButton1.BackColor = colorDialog.Color;
                previewWithLayer(getSelectedLayer());
            }   
        }

        private void colorButton2_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                colorButton2.BackColor = colorDialog.Color;
                previewWithLayer(getSelectedLayer());
            }
        }
        
        private void colorButton3_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                colorButton3.BackColor = colorDialog.Color;
                previewWithLayer(getSelectedLayer());
            }
        }
        
        private void layerDataGridView_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (layerDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag == null)
                return;
            string previewString = "";
            string currentTag = layerDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag.ToString();
            if (Path.GetFileNameWithoutExtension(blankImagePath) == (currentTag))
                return;

            switch (currentItemIndex)
            {
                case 1:
                    return;
                case 2:
                    previewString = collarLayersPath + currentTag + ".png";
                    break;
                case 3:
                    previewString = brandLayersPath + currentTag + ".png";
                    break;
            }
            Bitmap img = Coloring.ColorizeTemplateImage(new Bitmap(previewString), colorButton1.BackColor, colorButton2.BackColor, colorButton3.BackColor);
            if (File.Exists(previewString))
                previewWithLayer(img);
        }

        private void brandDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            brand = "";
            RefreshImage();
            showLayers(brandLayersPath);
            currentItemIndex = 3;
            tabControl1.SelectTab(1);
        }

        private void collarDataGridView_Click(object sender, EventArgs e)
        {
            collar = "";
            RefreshImage();
            showLayers(collarLayersPath);
            currentItemIndex = 2;
            tabControl1.SelectTab(1);
        }

        private void showLayers(string path)
        {
            layerDataGridView.ClearSelection();
            List<string> layerFiles = new List<string>(Directory.GetFiles(path));
            while (layerFiles.Count%3!=0)
            {
                layerFiles.Add(blankImagePath);
            }

            layerDataGridView.Rows.Clear();
            if (layerFiles.Count > 3)
                layerDataGridView.Rows.Add(layerFiles.Count / 3 - 1);
            for (int i = 0; i < layerFiles.Count; i += 3)
            {
                Bitmap img1 = new Bitmap(layerFiles[i]);
                Bitmap img2 = new Bitmap(layerFiles[i + 1]);
                Bitmap img3 = new Bitmap(layerFiles[i + 2]);

                layerDataGridView[0, i / 3].Value = img1;
                layerDataGridView[0, i / 3].Tag = Path.GetFileNameWithoutExtension(layerFiles[i]);
                layerDataGridView[1, i / 3].Value = img2;
                layerDataGridView[1, i / 3].Tag = Path.GetFileNameWithoutExtension(layerFiles[i + 1]);
                layerDataGridView[2, i / 3].Value = img3;
                layerDataGridView[2, i / 3].Tag = Path.GetFileNameWithoutExtension(layerFiles[i + 2]);
            }            
            
            oldPreview = new Bitmap(pictureBox.Image);
        }

        private void manDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            manufacturer = "";
            RefreshImage();
            showLayers(manLayersPath);
            currentItemIndex = 1;
            tabControl1.SelectTab(1);
        }

        private void layersDoneButton_Click(object sender, EventArgs e)
        {
            string currentTag = layerDataGridView.SelectedCells[0].Tag.ToString();
            if (Path.GetFileNameWithoutExtension(blankImagePath) == (currentTag))
                return;

            switch (currentItemIndex)
            {
                case 1:
                    manDataGridView[0, 0].Value = currentTag;
                    manufacturer = manDataGridView[0, 0].Value.ToString();
                    break;
                case 2:
                    collarDataGridView[0, 0].Value = currentTag;
                    collarDataGridView[1, 0].Style.BackColor = colorButton1.BackColor;
                    collarDataGridView[2, 0].Style.BackColor = colorButton2.BackColor;
                    collarDataGridView[3, 0].Style.BackColor = colorButton3.BackColor;
                    collar = collarDataGridView[0, 0].Value.ToString();
                    break;
                case 3:
                    brandDataGridView[0, 0].Value = currentTag;
                    brandDataGridView[1, 0].Style.BackColor = colorButton1.BackColor;
                    brandDataGridView[2, 0].Style.BackColor = colorButton2.BackColor;
                    brandDataGridView[3, 0].Style.BackColor = colorButton3.BackColor;
                    brand = brandDataGridView[0, 0].Value.ToString();
                    break;
            }
            RefreshImage();
            tabControl1.SelectTab(0);
        }

        private void layerDataGridView_MouseLeave(object sender, EventArgs e)
        {
            previewWithLayer(getSelectedLayer());
        }
        
        private void layersBackButton_Click(object sender, EventArgs e)
        {
            pictureBox.Image = oldPreview;
            currentItemIndex = -1;
            tabControl1.SelectTab(0);
        }
        
        private static Bitmap MatrixBlend(Bitmap _image1, Bitmap image2, byte alpha = 255)
        {
            Bitmap image1 = new Bitmap(_image1);

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
        
        private void previewWithLayer(Bitmap newLayer)
        {
            pictureBox.Image = MatrixBlend(oldPreview, newLayer);
        }

        private Bitmap getSelectedLayer()
        {
            if (layerDataGridView.SelectedCells[0].Tag == null)
                return null;
            string previewString = "";
            string currentTag = layerDataGridView.SelectedCells[0].Tag.ToString();
            if (Path.GetFileNameWithoutExtension(blankImagePath) == currentTag)
                return null;

            switch (currentItemIndex)
            {
                case 1:
                    return new Bitmap(1, 1);
                case 2:
                    previewString = collarLayersPath + currentTag + ".png";
                    break;
                case 3:
                    previewString = brandLayersPath + currentTag + ".png";
                    break;
            }
            return Coloring.ColorizeTemplateImage(new Bitmap(previewString), colorButton1.BackColor, colorButton2.BackColor, colorButton3.BackColor);
        }

        private void mainColorButton_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                mainColorButton.BackColor = colorDialog.Color;
                RefreshImage();
            }
        }
    }
}