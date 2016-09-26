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

        bool brandIsSelected = false;
        bool collarIsSelected = false;

        int currentItemIndex = -1; //manufacturer 1, collar 2, branding 3, layers 4
        const string collarLayersPath = "..\\..\\..\\kits\\collars\\";
        const string brandLayersPath = "..\\..\\..\\kits\\brands\\";
        const string manLayersPath = "..\\..\\..\\kits\\manufacturers\\";
        const string designLayersPath = "..\\..\\..\\kits\\layers\\";
        const string blankImagePath = "..\\..\\..\\kits\\_blank.png";
        List<Color> defaultColorPalette = new List<Color>(new Color[] { Color.White, Color.Blue, Color.Red });

        const string collarWelcome = "Select collar...";
        const string manWelcome = "Select manufacturer...";
        const string brandWelcome = "Select branding...";
        const string designWelcome = "Add layer...";

        Bitmap oldPreview;
        int layerEdited = -1;
        string currentPath = "";

        string currentFilePath = "";

        public Form1()
        {
            InitializeComponent();
            Initialization();
        }

        private void Initialization()
        {
            manDataGridView.Rows.Clear();
            manDataGridView.Rows.Add();
            manDataGridView[0, 0].Value = manWelcome;

            collarIsSelected = false;
            collarDataGridView.Rows.Clear();
            collarDataGridView.Rows.Add();
            collarDataGridView[0, 0].Value = collarWelcome;

            brandIsSelected = false;
            brandDataGridView.Rows.Clear();
            brandDataGridView.Rows.Add();
            brandDataGridView[0, 0].Value = brandWelcome;

            designDataGridView.Rows.Clear();
            designDataGridView.Rows.Add();
            designDataGridView[0, 0].Value = designWelcome;

            currentFilePath = "";

            RefreshImage();
        }

        private void RefreshImage()
        {
            List<KitLayer> kitLayers = new List<KitLayer>();
            
            for (int ii = 0; ii < designDataGridView.RowCount - 1; ii++)
            {
                DataGridViewRow designRow = designDataGridView.Rows[ii];
                KitLayer designLayer = new KitLayer(
                    designRow.Cells[0].Value.ToString(),
                    designLayersPath + layerTabControl.SelectedTab.Text + "\\" + designRow.Cells[0].Value + ".png",
                    new List<Color>(new Color[] { designRow.Cells[1].Style.BackColor, designRow.Cells[2].Style.BackColor, designRow.Cells[3].Style.BackColor }),
                    0,
                    new Rectangle());
                kitLayers.Add(designLayer);
            }
            
            if (brandIsSelected)
            {
                KitLayer brandLayer = new KitLayer(
                brandDataGridView[0, 0].Value.ToString(),
                brandLayersPath + brandDataGridView[0, 0].Value + ".png",
                new List<Color>(new Color[] { brandDataGridView[1, 0].Style.BackColor, brandDataGridView[2, 0].Style.BackColor, brandDataGridView[3, 0].Style.BackColor }),
                0,
                new Rectangle());
                kitLayers.Add(brandLayer);
            }

            if (collarIsSelected)
            {
                KitLayer collarLayer = new KitLayer(
                collarDataGridView[0, 0].Value.ToString(),
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
                    previewString = collarLayersPath + layerTabControl.SelectedTab.Text + "\\"+ currentTag + ".png";
                    break;
                case 3:
                    previewString = brandLayersPath + layerTabControl.SelectedTab.Text + "\\" + currentTag + ".png";
                    break;
                case 4:
                    previewString = designLayersPath + layerTabControl.SelectedTab.Text + "\\" + currentTag + ".png";
                    break;
            }
            Bitmap img = Coloring.ColorizeTemplateImage(new Bitmap(previewString), colorButton1.BackColor, colorButton2.BackColor, colorButton3.BackColor);
            if (File.Exists(previewString))
                previewWithLayer(img);
        }
        
        private void collarDataGridView_Click(object sender, EventArgs e)
        {
            RefreshImage();
            showLayers(collarLayersPath, collarDataGridView[0, 0].Value.ToString(), new List<Color>(new Color[] { collarDataGridView[1, 0].Style.BackColor, collarDataGridView[2, 0].Style.BackColor , collarDataGridView[3, 0].Style.BackColor}));
            currentItemIndex = 2;
            mainTabControl.SelectTab(1);
        }

        private void refreshLayerTab(string path)
        {
            layerDataGridView.Rows.Clear();

            List<string> layerFiles = new List<string>(Directory.GetFiles(path).Where(x => Path.GetFileName(x).StartsWith(manufacturer)));
            layerFiles.Insert(0, blankImagePath);
            while (layerFiles.Count % 3 != 0)
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

                    //if (layerDataGridView[jj, ii / 3].Tag.ToString().EndsWith(selectedElement))
                    //    layerDataGridView[jj, ii / 3].Selected = true;
                }
            }
            
            repaintLayers();
            oldPreview = new Bitmap(pictureBox.Image);
        }

        private void showLayers(string path, string selectedElement, List<Color> colors) //from which folder to show, what to put selection on, colors used
        {
            layerTabControl.TabPages.Clear();

            currentPath = path;
            List<string> directories = new List<string>(Directory.GetDirectories(path).Select(x => Path.GetFileName(x)));
            foreach (string directory in directories)
            {
                layerTabControl.TabPages.Add(directory);
            }

            layerTabControl.SelectTab(0);

            if (colors.Count == 0)
                colorButton1.Visible = false;
            else
            {
                colorButton1.Visible = true;
                colorButton1.BackColor = colors[0];
            }
            if (colors.Count < 2)
                colorButton2.Visible = false;
            else
            {
                colorButton2.Visible = true;
                colorButton2.BackColor = colors[1];
            }
            if (colors.Count < 3)
                colorButton3.Visible = false;
            else
            {
                colorButton3.Visible = true;
                colorButton3.BackColor = colors[2];
            }

            refreshLayerTab(path + layerTabControl.SelectedTab.Text);
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
            RefreshImage();
            currentItemIndex = -1;
            mainTabControl.SelectTab(0);
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
                    previewString = collarLayersPath + layerTabControl.SelectedTab.Text + "\\" + currentTag + ".png";
                    break;
                case 3:
                    previewString = brandLayersPath + layerTabControl.SelectedTab.Text + "\\" + currentTag + ".png";
                    break;
                case 4:
                    previewString = designLayersPath + layerTabControl.SelectedTab.Text + "\\" + currentTag + ".png";
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
                    collarIsSelected = true;
                    break;
                case 3:
                    brandDataGridView[0, 0].Value = currentTag;
                    brandDataGridView[1, 0].Style.BackColor = colorButton1.BackColor;
                    brandDataGridView[2, 0].Style.BackColor = colorButton2.BackColor;
                    brandDataGridView[3, 0].Style.BackColor = colorButton3.BackColor;
                    brandIsSelected = true;
                    break;
                case 4:
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(designDataGridView);
                    row.Cells[0].Value = currentTag;
                    row.Cells[1].Style.BackColor = colorButton1.BackColor;
                    row.Cells[2].Style.BackColor = colorButton2.BackColor;
                    row.Cells[3].Style.BackColor = colorButton3.BackColor;
                    if (layerEdited >= 0)
                    {
                        designDataGridView.Rows.RemoveAt(layerEdited);
                        designDataGridView.Rows.Insert(layerEdited, row);
                    }
                    else
                        designDataGridView.Rows.Insert(designDataGridView.RowCount - 1, row);
                    break;
            }
            RefreshImage();
            mainTabControl.SelectTab(0);
        }

        private void repaintLayers()
        {
            foreach (DataGridViewRow row in layerDataGridView.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (Path.GetFileNameWithoutExtension(blankImagePath) == cell.Tag.ToString())
                        continue;
                    Bitmap bm = new Bitmap((Bitmap)cell.Value);
                    cell.Value = Coloring.ColorizeTemplateImage(bm, colorButton1.BackColor, colorButton2.BackColor, colorButton3.BackColor);
                }
            }
        }
        
        private void manDataGridView_DoubleClick(object sender, EventArgs e)
        {
            manufacturer = "";
            RefreshImage();
            showLayers(manLayersPath, manDataGridView[0, 0].Value.ToString(), new List<Color>());
            currentItemIndex = 1;
            mainTabControl.SelectTab(1);
        }

        private void brandDataGridView_DoubleClick(object sender, EventArgs e)
        {
            RefreshImage();
            showLayers(brandLayersPath, brandDataGridView[0, 0].Value.ToString(), new List<Color>(new Color[] { brandDataGridView[1, 0].Style.BackColor, brandDataGridView[2, 0].Style.BackColor, brandDataGridView[3, 0].Style.BackColor }));
            currentItemIndex = 3;
            mainTabControl.SelectTab(1);
        }

        private void designDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (designDataGridView.Rows.Count == e.RowIndex + 1)
            {
                showLayers(designLayersPath, "", defaultColorPalette);
                layerEdited = -1;
            }
            else
            {
                showLayers(designLayersPath, designDataGridView[e.ColumnIndex, e.RowIndex].Value.ToString(), new List<Color>(new Color[] { designDataGridView[1, 0].Style.BackColor, designDataGridView[2, 0].Style.BackColor, designDataGridView[3, 0].Style.BackColor }));
                layerEdited = e.RowIndex;
            }

            currentItemIndex = 4;
            mainTabControl.SelectTab(1);
        }

        private void designDataGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            RefreshImage();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Initialization();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentFilePath == "")
                saveAs();
            else
                pictureBox.Image.Save(currentFilePath);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveAs();
        }

        private void saveAs()
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                RefreshImage();
                currentFilePath = saveFileDialog.FileName;
                pictureBox.Image.Save(currentFilePath);
            }
        }

        private void designDataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (e.Row.Index == designDataGridView.RowCount - 1)
            {
                e.Cancel = true;
            }
        }

        private void layerTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshLayerTab(currentPath + "\\" + layerTabControl.SelectedTab.Name);
        }
    }
}