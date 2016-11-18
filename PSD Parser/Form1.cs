using ImageMagick;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace KitGenerator
{ 
    public partial class Form1 : Form
    {
        string manufacturer = "";
        
        bool collarIsSelected = false;

        int currentItemIndex = -1; //manufacturer 1, collar 2,  layers 4
        const string collarLayersPath = "..\\..\\..\\kits\\collars\\";
        const string manLayersPath = "..\\..\\..\\kits\\manufacturers\\";
        const string designLayersPath = "..\\..\\..\\kits\\layers\\";
        const string blankImagePath = "..\\..\\..\\kits\\_blank.png";

        readonly List<Color> defaultLayerColorPalette = new List<Color>(new Color[] { Color.White, Color.Blue, Color.Red });
        readonly Color uncheckedButtonColor = Color.White;
        readonly Color checkedButtonColor = Color.PowderBlue;

        string activeCustomization = "none";

        const string collarWelcome = "Select collar...";
        const string manWelcome = "Select manufacturer...";
        const string designWelcome = "Add layer...";

        Bitmap lowerPreview, upperPreview;
        int layerEdited = -1;
        string currentPath = "";
        List<Color> oldColors;
        int xMove = 0, yMove = 0, rotation = 0, scaling = 100;

        List<KitLayer> kitLayers;
        KitLayer collarLayer;
        string currentFilePath = "";

        public Form1()
        {
            InitializeComponent();
            Initialization();
        }

        private void Initialization() //wipe the interface
        {
            manDataGridView.Rows.Clear();
            manDataGridView.Rows.Add();
            manDataGridView[0, 0].Value = manWelcome;

            collarIsSelected = false;
            collarDataGridView.Rows.Clear();
            collarDataGridView.Rows.Add();
            collarDataGridView[0, 0].Value = collarWelcome;
            
            designDataGridView.Rows.Clear();
            designDataGridView.Rows.Add();
            designDataGridView[0, 0].Value = designWelcome;

            kitLayers = new List<KitLayer>();
            collarLayer = new KitLayer();

            currentFilePath = "";

            xMove = 0;
            yMove = 0;
            rotation = 0;
            scaling = 100;

            RefreshImage();
        }

        private void RefreshImage()//pull all the data around, refresh the main image with it
        {
            List<KitLayer> kl = kitLayers.ToList();
            if (collarIsSelected)
                kl.Add(collarLayer);

            Color baseColor = mainColorButton.BackColor;

            KitGenerator kg = new KitGenerator(manufacturer, baseColor, kl);
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
                    previewString = collarLayersPath + layerTabControl.SelectedTab.Text + "\\"+ currentTag + ".png";
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
            Color baseColor = mainColorButton.BackColor;
            KitGenerator lowerG = new KitGenerator(baseColor, kitLayers);
            KitGenerator upperG = new KitGenerator(baseColor, new List<KitLayer>());

            lowerPreview = (Bitmap)lowerG.GetKit(true, false);
            upperPreview = new Bitmap(lowerPreview.Width, lowerPreview.Height);

           // RefreshImage();
            loadLayerTab(collarLayersPath, collarDataGridView[0, 0].Value.ToString());
            oldColors = new List<Color>(new Color[] { collarDataGridView[1, 0].Style.BackColor, collarDataGridView[2, 0].Style.BackColor, collarDataGridView[3, 0].Style.BackColor });
            currentItemIndex = 2;
            mainTabControl.SelectTab(1);
        }

        private void refreshLayerGrid(string path)//put pictures from the new path on the layer selection grid
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
                }
            }
            
            repaintLayerGrid();
        }

        private void loadLayerTab(string path, string selectedElement) //load the layer selection tab
        {
            layerTabControl.TabPages.Clear();

            currentPath = path;
            List<string> directories = new List<string>(Directory.GetDirectories(path).Select(x => Path.GetFileName(x)));
            if (directories.Count == 0)
            {
                directories.Add(Path.GetFileName(path));
            }

            foreach (string directory in directories)
            {
                layerTabControl.TabPages.Add(directory);
            }

            layerTabControl.SelectTab(0);

            

            refreshLayerGrid(path + layerTabControl.SelectedTab.Text);
        }
        
        private void layersDoneButton_Click(object sender, EventArgs e)
        {
            mainTabControl.SelectTab(2);
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
        
        private void previewWithLayer(Bitmap newLayer) //put newLayer on top of the preview, then add the frame
        {
            pictureBox.Image = Coloring.AddTopLayer(Coloring.MatrixBlend(Coloring.MatrixBlend(lowerPreview, newLayer), upperPreview), KitGenerator.topImagePath);

            //put frame around 
            using (Graphics g = Graphics.FromImage(pictureBox.Image))
            {
                Pen blackPen = new Pen(Color.Black, 2);
                g.DrawRectangle(blackPen, Coloring.GetTrimmedCoordinates(newLayer));
            }
        }

        private Bitmap getSelectedLayer()// returns the layer selected from the grid, colorized, customized
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
                case 4:
                    previewString = designLayersPath + layerTabControl.SelectedTab.Text + "\\" + currentTag + ".png";
                    break;
            }
            Bitmap rawDecal = new Bitmap(previewString);
            
            //customize
            rawDecal = Coloring.CustomizeBitmap(rawDecal, xMove, yMove, rotation, scaling, pictureBox.Width, pictureBox.Height);
            
            return Coloring.ColorizeTemplateImage(rawDecal, colorButton1.BackColor, colorButton2.BackColor, colorButton3.BackColor);
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

        private void acceptLayer() //applies the layer, returns to the main tab
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
                    collarLayer = new KitLayer(
                        currentTag,
                        collarLayersPath + currentTag + ".png",
                        new List<Color>(new Color[] { colorButton1.BackColor, colorButton2.BackColor, colorButton3.BackColor }));

                    collarDataGridView[0, 0].Value = currentTag;
                    collarDataGridView[1, 0].Style.BackColor = colorButton1.BackColor;
                    collarDataGridView[2, 0].Style.BackColor = colorButton2.BackColor;
                    collarDataGridView[3, 0].Style.BackColor = colorButton3.BackColor;
                    collarIsSelected = true;
                    break;
                case 4:
                    KitLayer designLayer = new KitLayer(
                        layerTabControl.SelectedTab.Text + "\\" + currentTag,
                        designLayersPath + "\\" + layerTabControl.SelectedTab.Text + "\\" + currentTag + ".png",
                        new List<Color>(new Color[] { colorButton1.BackColor, colorButton2.BackColor, colorButton3.BackColor }),
                        xMove,
                        yMove,
                        rotation,
                        scaling);

                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(designDataGridView);
                    row.Cells[0].Value = layerTabControl.SelectedTab.Text + "\\" + currentTag;
                    row.Cells[1].Style.BackColor = colorButton1.BackColor;
                    row.Cells[2].Style.BackColor = colorButton2.BackColor;
                    row.Cells[3].Style.BackColor = colorButton3.BackColor;

                    if (layerEdited >= 0)
                    {
                        designDataGridView.Rows.RemoveAt(layerEdited);
                        designDataGridView.Rows.Insert(layerEdited, row);

                        kitLayers[layerEdited] = designLayer;
                    }
                    else
                    {
                        designDataGridView.Rows.Insert(1, row);
                        kitLayers.Add(designLayer);
                    }
                    break;
            }
            xMove = 0;
            yMove = 0;
            rotation = 0;
            scaling = 100;
            RefreshImage();
            mainTabControl.SelectTab(0);
        }

        private void repaintLayerGrid() //repaints the layer grid with the colors selected
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
            loadLayerTab(manLayersPath, manDataGridView[0, 0].Value.ToString());
            oldColors = new List<Color>();
            currentItemIndex = 1;
            mainTabControl.SelectTab(1);
        }
        
        private void designDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Color baseColor = mainColorButton.BackColor;
            List<KitLayer> lowerLayers = new List<KitLayer>();
            List<KitLayer> upperLayers = new List<KitLayer>();
            int currentKitLayer = kitLayers.Count - e.RowIndex;

            foreach (DataGridViewRow layer in designDataGridView.Rows)
            {
                if (layer.Index == kitLayers.Count)
                    break;
                if (layer.Index < currentKitLayer)
                {
                    lowerLayers.Add(kitLayers[layer.Index]);
                }
                else
                    if (layer.Index > currentKitLayer)
                    {
                        upperLayers.Add(kitLayers[layer.Index]);
                    }
            }
            if (collarIsSelected)
                upperLayers.Add(collarLayer);

            KitGenerator lowerG = new KitGenerator(baseColor, lowerLayers);

            lowerPreview = (Bitmap)lowerG.GetKit(true, false);
            upperPreview = new Bitmap(lowerPreview.Width, lowerPreview.Height);
            for (int i = 0; i < upperLayers.Count; i++)
            {
                upperPreview = Coloring.MatrixBlend(upperPreview, Coloring.ColorizeTemplateImage((Bitmap)Bitmap.FromFile(upperLayers[i].ImageLocation), upperLayers[i].Colors[0], upperLayers[i].Colors[1], upperLayers[i].Colors[2]));
            }
            
            if (e.RowIndex == 0) //add layer
            {
                loadLayerTab(designLayersPath, "");
                oldColors = defaultLayerColorPalette;
                layerEdited = -1;
            }
            else //edit layer
            {
                loadLayerTab(designLayersPath, designDataGridView[0, e.RowIndex].Value.ToString());
                oldColors = new List<Color>(new Color[] { designDataGridView[1, 0].Style.BackColor, designDataGridView[2, 0].Style.BackColor, designDataGridView[3, 0].Style.BackColor });
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
            if (e.Row.Index == 0)
            {
                e.Cancel = true;
            }
            kitLayers.RemoveAt(e.Row.Index);
        }

        private void layerTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                refreshLayerGrid(currentPath + layerTabControl.SelectedTab.Text);
            }
            catch (NullReferenceException)
            {

            };
        }

        private void customizationBackButton_Click(object sender, EventArgs e)
        {
            mainTabControl.SelectTab(1);
        }

        private void customizationFinishButton_Click(object sender, EventArgs e)
        {
            acceptLayer();
        }

        void setActiveCustomizationType(string custType)
        {
            activeCustomization = custType;

            moveDecalButton.BackColor = uncheckedButtonColor;
            rotateDecalButton.BackColor = uncheckedButtonColor;
            scaleDecalButton.BackColor = uncheckedButtonColor;

            switch (custType)
            {
                case "move":
                    moveDecalButton.BackColor = checkedButtonColor;
                    break;
                case "rotate":
                    rotateDecalButton.BackColor = checkedButtonColor;
                    break;
                case "scale":
                    scaleDecalButton.BackColor = checkedButtonColor;
                    break;
                default:
                    break;
            }
        }
        
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    switch (activeCustomization)
                    {
                        case "move":
                            yMove++;
                            break;
                        case "rotate":
                            rotation--;
                            break;
                        case "scale":
                            scaling++;
                            break;
                    }
                    break;
                case Keys.A:
                    switch (activeCustomization)
                    {
                        case "move":
                            xMove++;
                            break;
                        case "rotate":
                            rotation--;
                            break;
                        case "scale":
                            scaling--;
                            break;
                    }
                    break;
                case Keys.S:
                    switch (activeCustomization)
                    {
                        case "move":
                            yMove--;
                            break;
                        case "rotate":
                            rotation++;
                            break;
                        case "scale":
                            scaling--;
                            break;
                    }
                    break;
                case Keys.D:
                    switch (activeCustomization)
                    {
                        case "move":
                            xMove--;
                            break;
                        case "rotate":
                            rotation++;
                            break;
                        case "scale":
                            scaling++;
                            break;
                    }
                    break;
            }

            previewWithLayer(getSelectedLayer());
        }

        private void moveDecalButton_Click(object sender, EventArgs e)
        {
            setActiveCustomizationType("move");
        }

        private void rotateDecalButton_Click(object sender, EventArgs e)
        {
            setActiveCustomizationType("rotate");
        }

        private void scaleDecalButton_Click(object sender, EventArgs e)
        {
            setActiveCustomizationType("scale");
        }

    }
}