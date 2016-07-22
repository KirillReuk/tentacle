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
        int kitNumber;
        Color color1, color2, color3;

        public Form1()
        {
            InitializeComponent();
            Initialization();
        }

        private void Initialization()
        {
            List<string> directories = new List<string>(Directory.GetDirectories("..\\..\\..\\kits\\"));
            manComboBox.DataSource = directories.Select(x => Path.GetFileName(x)).ToArray();
        }

        private void RefreshImage()
        {
            KitGenerator kg = new KitGenerator(manufacturer, kitNumber, color1, color2, color3);
            pictureBox.Image = kg.GetImage();
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            RefreshImage();
        }

        private void manComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            manufacturer = manComboBox.SelectedItem.ToString();

            List<string> files = new List<string>(Directory.GetFiles("..\\..\\..\\kits\\" + manufacturer));
            numberComboBox.DataSource = files.Select(x => Path.GetFileNameWithoutExtension(x)).Where(x => x != "colors").ToArray();
        }

        private void numberComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            kitNumber = Int32.Parse(numberComboBox.SelectedItem.ToString().Split(' ')[1]);

            RefreshImage();
        }

        private void colorButton1_Click(object sender, EventArgs e)
        {            
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                colorButton1.BackColor = colorDialog.Color;
                color1 = colorDialog.Color;
                RefreshImage();
            }
        }

        private void colorButton2_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                colorButton2.BackColor = colorDialog.Color;
                color2 = colorDialog.Color;
                RefreshImage();
            }
        }

        private void colorButton3_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                colorButton3.BackColor = colorDialog.Color;
                color3 = colorDialog.Color;
                RefreshImage();
            }
        }
    }
}
