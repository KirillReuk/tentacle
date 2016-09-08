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

        Color mainColor, color1, color2, color3;

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
                color1 = designColorButton1.BackColor;
                color2 = designColorButton2.BackColor;
                color3 = designColorButton3.BackColor;
                
                KitGenerator kg = new KitGenerator(manufacturer, design, sponsor, collar, brand, mainColor, color1, color2, color3);
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

            List<string> designFiles = new List<string>(Directory.GetFiles("..\\..\\..\\kits\\designs\\"));
            designComboBox.DataSource = designFiles.Select(x => Path.GetFileNameWithoutExtension(x)).Where(x => x.Split(' ')[0] == manufacturer).Select(x => x.Split(' ')[1]).ToArray();

            List<string> collarFiles = new List<string>(Directory.GetFiles("..\\..\\..\\kits\\collars\\"));
            collarComboBox.DataSource = collarFiles.Select(x => Path.GetFileNameWithoutExtension(x)).Where(x => x.Split(' ')[0] == manufacturer).Select(x => x.Split(' ')[1]).ToArray();

            List<string> brandFiles = new List<string>(Directory.GetFiles("..\\..\\..\\kits\\brands\\"));
            brandComboBox.DataSource = brandFiles.Select(x => Path.GetFileNameWithoutExtension(x)).Where(x => x.Split(' ')[0] == manufacturer).Select(x => x.Split(' ')[1]).ToArray();
        }

        private void numberComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
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

        private void brandComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            brand = brandComboBox.SelectedItem.ToString();

            RefreshImage();
        }
        
        private void collarComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            collar = collarComboBox.SelectedItem.ToString();

            RefreshImage();
        }

        private void sponsorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            sponsor = sponsorComboBox.SelectedItem.ToString();

            RefreshImage();
        }
    }
}