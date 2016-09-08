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
        string manufacturer;
        string sponsor;
        string design;
        string collar;
        string brand;

        Color mainColor;
        List<Color> designColors = new List<Color>(), collarColors = new List<Color>(), brandColors = new List<Color>();

        public Form1()
        {
            InitializeComponent();
            Initialization();
        }

        private void Initialization()
        {
            List<string> manufacturers = new List<string>(Directory.GetFiles("..\\..\\..\\kits\\designs\\"));
            manComboBox.DataSource = manufacturers.Select(x => Path.GetFileNameWithoutExtension(x)).Select(x => x.Split(' ')[0]).Distinct().ToArray();

            List<string> sponsors = new List<string>(Directory.GetFiles("..\\..\\..\\kits\\sponsors\\"));
            sponsorComboBox.DataSource = sponsors.Select(x => Path.GetFileNameWithoutExtension(x)).ToArray();
        }

        private void RefreshImage()
        {
            if (!String.IsNullOrEmpty(manufacturer)&&!String.IsNullOrEmpty(design)&&!String.IsNullOrEmpty(sponsor)&&!String.IsNullOrEmpty(collar)&&!String.IsNullOrEmpty(brand))
            {
                mainColor = mainColorButton.BackColor;

                designColors.Clear();
                collarColors.Clear();
                brandColors.Clear();

                designColors.Add(designColorButton1.BackColor);
                designColors.Add(designColorButton2.BackColor);
                designColors.Add(designColorButton3.BackColor);
                collarColors.Add(collarColorButton1.BackColor);
                collarColors.Add(collarColorButton2.BackColor);
                collarColors.Add(collarColorButton3.BackColor);
                brandColors.Add(brandColorButton1.BackColor);
                brandColors.Add(brandColorButton2.BackColor);
                brandColors.Add(brandColorButton3.BackColor);

                KitGenerator kg = new KitGenerator(manufacturer, design, sponsor, collar, brand, mainColor, designColors, collarColors, brandColors);
                pictureBox.Image = kg.GetKit();
            }
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            RefreshImage();
        }

        private void manComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            manufacturer = manComboBox.SelectedItem.ToString();
            
            design = "";
            collar = "";
            brand = "";

            List<string> designFiles = new List<string>(Directory.GetFiles("..\\..\\..\\kits\\designs\\"));
            designComboBox.DataSource = designFiles.Select(x => Path.GetFileNameWithoutExtension(x)).Where(x => x.Split(' ')[0] == manufacturer).Select(x => x.Split(' ')[1]).ToArray();

            List<string> collarFiles = new List<string>(Directory.GetFiles("..\\..\\..\\kits\\collars\\"));
            collarComboBox.DataSource = collarFiles.Select(x => Path.GetFileNameWithoutExtension(x)).Where(x => x.Split(' ')[0] == manufacturer).Select(x => x.Split(' ')[1]).ToArray();

            List<string> brandFiles = new List<string>(Directory.GetFiles("..\\..\\..\\kits\\brands\\"));
            brandComboBox.DataSource = brandFiles.Select(x => Path.GetFileNameWithoutExtension(x)).Where(x => x.Split(' ')[0] == manufacturer).Select(x => x.Split(' ')[1]).ToArray();
        }

        private void designComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (designComboBox.DataSource == null)
                return;
            design = designComboBox.SelectedItem.ToString();

            RefreshImage();
        }

        private void mainColorButton_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                mainColorButton.BackColor = colorDialog.Color;
            }
            RefreshImage();
        }

        private void colorButton1_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                designColorButton1.BackColor = colorDialog.Color;
            }   
            RefreshImage();
        }

        private void colorButton2_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                designColorButton2.BackColor = colorDialog.Color;
            }
            RefreshImage();
        }
        
        private void colorButton3_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                designColorButton3.BackColor = colorDialog.Color;
            }
            RefreshImage();
        }

        private void collarColorButton1_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                collarColorButton1.BackColor = colorDialog.Color;
            }
            RefreshImage();
        }

        private void collarColorButton2_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                collarColorButton2.BackColor = colorDialog.Color;
            }
            RefreshImage();
        }


        private void collarColorButton3_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                collarColorButton3.BackColor = colorDialog.Color;
            }
            RefreshImage();
        }

        private void brandComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (brandComboBox.DataSource == null)
                return;
            brand = brandComboBox.SelectedItem.ToString();

            RefreshImage();
        }

        private void brandColorButton1_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                brandColorButton1.BackColor = colorDialog.Color;
            }
            RefreshImage();
        }

        private void brandColorButton2_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                brandColorButton2.BackColor = colorDialog.Color;
            }
            RefreshImage();
        }

        private void brandColorButton3_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                brandColorButton3.BackColor = colorDialog.Color;
            }
            RefreshImage();
        }

        private void collarComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (collarComboBox.DataSource == null)
                return;
            collar = collarComboBox.SelectedItem.ToString();

            RefreshImage();
        }

        private void sponsorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sponsorComboBox.SelectedItem == null)
                return;
            sponsor = sponsorComboBox.SelectedItem.ToString();

            RefreshImage();
        }
    }
}