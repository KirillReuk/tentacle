using System;
using System.Collections.Generic;
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
        string manufacturer = "";
        string brand = "";
        string collar = "";

        int currentItemIndex = -1; //manufacturer 1, collar 2, branding 3, layers 4
        string collarLayersPath = "..\\..\\..\\kits\\collars\\";
        string brandLayersPath = "..\\..\\..\\kits\\brands\\"; 
        string manLayersPath = "..\\..\\..\\kits\\manufacturers\\";
        string designLayersPath = "..\\..\\..\\kits\\layers\\designs\\";
        string blankImagePath = "..\\..\\..\\kits\\_blank.png";

        Bitmap oldPreview;

        public Form1()
        {
            InitializeComponent();
            Initialization();
        }

        private void Initialization()
        {
            manDataGridView.Rows.Add();
            manDataGridView[0, 0].Value = "Select manufacturer...";
            collarDataGridView.Rows.Add();
            collarDataGridView[0, 0].Value = "Select collar...";
            brandDataGridView.Rows.Add();
            brandDataGridView[0, 0].Value = "Select branding...";
            designDataGridView.Rows.Add();
            designDataGridView[0, 0].Value = "Add layer...";
            RefreshImage();
        }

        private void RefreshImage()
        {
            List<KitLayer> kitLayers = new List<KitLayer>();
            
            foreach (DataGridViewRow designRow in designDataGridView.Rows)
            {
                if ((designRow.Cells[0].Value != null) && (designRow.Cells[0].Value.ToString() != "Add layer..."))//add proper checking
                {
                    KitLayer designLayer = new KitLayer(
                        designRow.Cells[0].Value.ToString(),
                        designLayersPath + designRow.Cells[0].Value + ".png",
                        new List<Color>(new Color[] { designRow.Cells[1].Style.BackColor, designRow.Cells[2].Style.BackColor, designRow.Cells[3].Style.BackColor }),
                        0,
                        new Rectangle());
                    kitLayers.Add(designLayer);
                }
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
                repaintLayers();
                previewWithLayer(getSelectedLayer());
            }   
        }

        private void colorButton2_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                colorButton2.BackColor = colorDialog.Color;
                repaintLayers();
                previewWithLayer(getSelectedLayer());
            }
        }
        
        private void colorButton3_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                colorButton3.BackColor = colorDialog.Color;
                repaintLayers();
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
                case 4:
                    previewString = designLayersPath + currentTag + ".png";
                    break;
            }
            Bitmap img = Coloring.ColorizeTemplateImage(new Bitmap(previewString), colorButton1.BackColor, colorButton2.BackColor, colorButton3.BackColor);
            if (File.Exists(previewString))
                previewWithLayer(img);
        }
        
        private void collarDataGridView_Click(object sender, EventArgs e)
        {
            collar = "";
            RefreshImage();
            showLayers(collarLayersPath, collarDataGridView[0, 0].Value.ToString());
            currentItemIndex = 2;
            tabControl1.SelectTab(1);
        }

        private void showLayers(string path, string selectedElement) //from which folder to show, what to put selection on
        {
            layerDataGridView.Rows.Clear();

            List<string> layerFiles = new List<string>(Directory.GetFiles(path).Where(x => Path.GetFileName(x).StartsWith(manufacturer)));
            layerFiles.Insert(0, blankImagePath);
            while (layerFiles.Count%3!=0)
            {
                layerFiles.Add(blankImagePath);
            }
            
            if (layerFiles.Count > 3)
                layerDataGridView.Rows.Add(layerFiles.Count / 3 - 1);


            layerDataGridView.ClearSelection();
            for (int ii = 0; ii < layerFiles.Count; ii += 3)
            {
                for (int jj = 0; jj < 3; jj++)
                {
                    Bitmap img1 = new Bitmap(new Bitmap(layerFiles[ii + jj]), layerDataGridView[0, 0].Size);
                    layerDataGridView[jj, ii / 3].Value = img1;
                    layerDataGridView[jj, ii / 3].Tag = Path.GetFileNameWithoutExtension(layerFiles[ii + jj]);

                    if (layerDataGridView[jj, ii / 3].Tag.ToString().EndsWith(selectedElement))
                        layerDataGridView[jj, ii / 3].Selected = true;
                }
            }

            repaintLayers();
            oldPreview = new Bitmap(pictureBox.Image);
        }
        
        private void layersDoneButton_Click(object sender, EventArgs e)
        {
            acceptLayer();
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

            if ((_image1 == null)|| (image2 == null))
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
        
        private void previewWithLayer(Bitmap newLayer)
        {
            pictureBox.Image = MatrixBlend(oldPreview, newLayer);
        }

        private Bitmap getSelectedLayer()
        {

            if ((layerDataGridView.SelectedCells.Count == 0)||(layerDataGridView.SelectedCells[0].Tag == null))
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
                case 4:
                    previewString = designLayersPath + currentTag + ".png";
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

        private void layerDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            acceptLayer();
        }

        private void acceptLayer()
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
                case 4:
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(designDataGridView);
                    row.Cells[0].Value = currentTag;
                    row.Cells[1].Style.BackColor = colorButton1.BackColor;
                    row.Cells[2].Style.BackColor = colorButton2.BackColor;
                    row.Cells[3].Style.BackColor = colorButton3.BackColor;
                    designDataGridView.Rows.Insert(designDataGridView.RowCount - 1, row);
                    break;
            }
            RefreshImage();
            tabControl1.SelectTab(0);
        }

        private void repaintLayers()
        {
            foreach (DataGridViewRow row in layerDataGridView.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (Path.GetFileNameWithoutExtension(blankImagePath) == cell.Tag.ToString())
                        continue;
                    cell.Value = Coloring.ColorizeTemplateImage((Bitmap)cell.Value, colorButton1.BackColor, colorButton2.BackColor, colorButton3.BackColor);
                }
            }
        }
        
        private void manDataGridView_DoubleClick(object sender, EventArgs e)
        {
            manufacturer = "";
            RefreshImage();
            showLayers(manLayersPath, manDataGridView[0, 0].Value.ToString());
            currentItemIndex = 1;
            tabControl1.SelectTab(1);
        }

        private void brandDataGridView_DoubleClick(object sender, EventArgs e)
        {
            brand = "";
            RefreshImage();
            showLayers(brandLayersPath, brandDataGridView[0, 0].Value.ToString());
            currentItemIndex = 3;
            tabControl1.SelectTab(1);
        }

        private void designDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (designDataGridView.Rows.Count == e.RowIndex + 1)
            {
                RefreshImage();
                showLayers(designLayersPath, "");
                currentItemIndex = 4;
                tabControl1.SelectTab(1);
            }
        }

        private void designDataGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            RefreshImage();
        }
    }
}