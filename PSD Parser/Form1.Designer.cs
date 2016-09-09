namespace KitGenerator
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.runButton = new System.Windows.Forms.Button();
            this.manComboBox = new System.Windows.Forms.ComboBox();
            this.designComboBox = new System.Windows.Forms.ComboBox();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.sponsorComboBox = new System.Windows.Forms.ComboBox();
            this.designColorButton1 = new System.Windows.Forms.Button();
            this.designColorButton2 = new System.Windows.Forms.Button();
            this.designColorButton3 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.collarComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.brandComboBox = new System.Windows.Forms.ComboBox();
            this.mainColorButton = new System.Windows.Forms.Button();
            this.collarColorButton3 = new System.Windows.Forms.Button();
            this.collarColorButton2 = new System.Windows.Forms.Button();
            this.collarColorButton1 = new System.Windows.Forms.Button();
            this.brandColorButton3 = new System.Windows.Forms.Button();
            this.brandColorButton2 = new System.Windows.Forms.Button();
            this.brandColorButton1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(226, 10);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(500, 500);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // runButton
            // 
            this.runButton.Location = new System.Drawing.Point(9, 374);
            this.runButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(56, 42);
            this.runButton.TabIndex = 1;
            this.runButton.Text = "Go";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // manComboBox
            // 
            this.manComboBox.FormattingEnabled = true;
            this.manComboBox.Location = new System.Drawing.Point(9, 27);
            this.manComboBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.manComboBox.Name = "manComboBox";
            this.manComboBox.Size = new System.Drawing.Size(156, 21);
            this.manComboBox.TabIndex = 2;
            this.manComboBox.SelectedIndexChanged += new System.EventHandler(this.manComboBox_SelectedIndexChanged);
            // 
            // designComboBox
            // 
            this.designComboBox.FormattingEnabled = true;
            this.designComboBox.Location = new System.Drawing.Point(9, 64);
            this.designComboBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.designComboBox.Name = "designComboBox";
            this.designComboBox.Size = new System.Drawing.Size(156, 21);
            this.designComboBox.TabIndex = 3;
            this.designComboBox.SelectedIndexChanged += new System.EventHandler(this.designComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "Manufacturer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 49);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 15);
            this.label2.TabIndex = 11;
            this.label2.Text = "Design";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 110);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 15);
            this.label3.TabIndex = 13;
            this.label3.Text = "Sponsor";
            // 
            // sponsorComboBox
            // 
            this.sponsorComboBox.FormattingEnabled = true;
            this.sponsorComboBox.Location = new System.Drawing.Point(9, 125);
            this.sponsorComboBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.sponsorComboBox.Name = "sponsorComboBox";
            this.sponsorComboBox.Size = new System.Drawing.Size(156, 21);
            this.sponsorComboBox.TabIndex = 12;
            this.sponsorComboBox.SelectedIndexChanged += new System.EventHandler(this.sponsorComboBox_SelectedIndexChanged);
            // 
            // designColorButton1
            // 
            this.designColorButton1.BackColor = System.Drawing.Color.Maroon;
            this.designColorButton1.Location = new System.Drawing.Point(9, 89);
            this.designColorButton1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.designColorButton1.Name = "designColorButton1";
            this.designColorButton1.Size = new System.Drawing.Size(49, 19);
            this.designColorButton1.TabIndex = 14;
            this.designColorButton1.UseVisualStyleBackColor = false;
            this.designColorButton1.Click += new System.EventHandler(this.colorButton1_Click);
            // 
            // designColorButton2
            // 
            this.designColorButton2.BackColor = System.Drawing.Color.Cyan;
            this.designColorButton2.Location = new System.Drawing.Point(62, 89);
            this.designColorButton2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.designColorButton2.Name = "designColorButton2";
            this.designColorButton2.Size = new System.Drawing.Size(49, 19);
            this.designColorButton2.TabIndex = 15;
            this.designColorButton2.UseVisualStyleBackColor = false;
            this.designColorButton2.Click += new System.EventHandler(this.colorButton2_Click);
            // 
            // designColorButton3
            // 
            this.designColorButton3.BackColor = System.Drawing.Color.Yellow;
            this.designColorButton3.Location = new System.Drawing.Point(115, 89);
            this.designColorButton3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.designColorButton3.Name = "designColorButton3";
            this.designColorButton3.Size = new System.Drawing.Size(49, 19);
            this.designColorButton3.TabIndex = 16;
            this.designColorButton3.UseVisualStyleBackColor = false;
            this.designColorButton3.Click += new System.EventHandler(this.colorButton3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 158);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 15);
            this.label4.TabIndex = 18;
            this.label4.Text = "Collar";
            // 
            // collarComboBox
            // 
            this.collarComboBox.FormattingEnabled = true;
            this.collarComboBox.Location = new System.Drawing.Point(9, 174);
            this.collarComboBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.collarComboBox.Name = "collarComboBox";
            this.collarComboBox.Size = new System.Drawing.Size(156, 21);
            this.collarComboBox.TabIndex = 17;
            this.collarComboBox.SelectedIndexChanged += new System.EventHandler(this.collarComboBox_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 239);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 15);
            this.label5.TabIndex = 23;
            this.label5.Text = "Brand";
            // 
            // brandComboBox
            // 
            this.brandComboBox.FormattingEnabled = true;
            this.brandComboBox.Location = new System.Drawing.Point(9, 254);
            this.brandComboBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.brandComboBox.Name = "brandComboBox";
            this.brandComboBox.Size = new System.Drawing.Size(156, 21);
            this.brandComboBox.TabIndex = 22;
            this.brandComboBox.SelectedIndexChanged += new System.EventHandler(this.brandComboBox_SelectedIndexChanged);
            // 
            // mainColorButton
            // 
            this.mainColorButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.mainColorButton.Location = new System.Drawing.Point(168, 64);
            this.mainColorButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.mainColorButton.Name = "mainColorButton";
            this.mainColorButton.Size = new System.Drawing.Size(49, 19);
            this.mainColorButton.TabIndex = 24;
            this.mainColorButton.UseVisualStyleBackColor = false;
            this.mainColorButton.Click += new System.EventHandler(this.mainColorButton_Click);
            // 
            // collarColorButton3
            // 
            this.collarColorButton3.BackColor = System.Drawing.Color.Yellow;
            this.collarColorButton3.Location = new System.Drawing.Point(115, 198);
            this.collarColorButton3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.collarColorButton3.Name = "collarColorButton3";
            this.collarColorButton3.Size = new System.Drawing.Size(49, 19);
            this.collarColorButton3.TabIndex = 27;
            this.collarColorButton3.UseVisualStyleBackColor = false;
            this.collarColorButton3.Click += new System.EventHandler(this.collarColorButton3_Click);
            // 
            // collarColorButton2
            // 
            this.collarColorButton2.BackColor = System.Drawing.Color.Cyan;
            this.collarColorButton2.Location = new System.Drawing.Point(62, 198);
            this.collarColorButton2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.collarColorButton2.Name = "collarColorButton2";
            this.collarColorButton2.Size = new System.Drawing.Size(49, 19);
            this.collarColorButton2.TabIndex = 26;
            this.collarColorButton2.UseVisualStyleBackColor = false;
            this.collarColorButton2.Click += new System.EventHandler(this.collarColorButton2_Click);
            // 
            // collarColorButton1
            // 
            this.collarColorButton1.BackColor = System.Drawing.Color.Maroon;
            this.collarColorButton1.Location = new System.Drawing.Point(9, 198);
            this.collarColorButton1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.collarColorButton1.Name = "collarColorButton1";
            this.collarColorButton1.Size = new System.Drawing.Size(49, 19);
            this.collarColorButton1.TabIndex = 25;
            this.collarColorButton1.UseVisualStyleBackColor = false;
            this.collarColorButton1.Click += new System.EventHandler(this.collarColorButton1_Click);
            // 
            // brandColorButton3
            // 
            this.brandColorButton3.BackColor = System.Drawing.Color.Yellow;
            this.brandColorButton3.Location = new System.Drawing.Point(115, 279);
            this.brandColorButton3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.brandColorButton3.Name = "brandColorButton3";
            this.brandColorButton3.Size = new System.Drawing.Size(49, 19);
            this.brandColorButton3.TabIndex = 30;
            this.brandColorButton3.UseVisualStyleBackColor = false;
            this.brandColorButton3.Click += new System.EventHandler(this.brandColorButton3_Click);
            // 
            // brandColorButton2
            // 
            this.brandColorButton2.BackColor = System.Drawing.Color.Cyan;
            this.brandColorButton2.Location = new System.Drawing.Point(62, 279);
            this.brandColorButton2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.brandColorButton2.Name = "brandColorButton2";
            this.brandColorButton2.Size = new System.Drawing.Size(49, 19);
            this.brandColorButton2.TabIndex = 29;
            this.brandColorButton2.UseVisualStyleBackColor = false;
            this.brandColorButton2.Click += new System.EventHandler(this.brandColorButton2_Click);
            // 
            // brandColorButton1
            // 
            this.brandColorButton1.BackColor = System.Drawing.Color.Maroon;
            this.brandColorButton1.Location = new System.Drawing.Point(9, 279);
            this.brandColorButton1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.brandColorButton1.Name = "brandColorButton1";
            this.brandColorButton1.Size = new System.Drawing.Size(49, 19);
            this.brandColorButton1.TabIndex = 28;
            this.brandColorButton1.UseVisualStyleBackColor = false;
            this.brandColorButton1.Click += new System.EventHandler(this.brandColorButton1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(610, 428);
            this.Controls.Add(this.brandColorButton3);
            this.Controls.Add(this.brandColorButton2);
            this.Controls.Add(this.brandColorButton1);
            this.Controls.Add(this.collarColorButton3);
            this.Controls.Add(this.collarColorButton2);
            this.Controls.Add(this.collarColorButton1);
            this.Controls.Add(this.mainColorButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.brandComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.collarComboBox);
            this.Controls.Add(this.designColorButton3);
            this.Controls.Add(this.designColorButton2);
            this.Controls.Add(this.designColorButton1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.sponsorComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.designComboBox);
            this.Controls.Add(this.manComboBox);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.pictureBox);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.ComboBox manComboBox;
        private System.Windows.Forms.ComboBox designComboBox;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox sponsorComboBox;
        private System.Windows.Forms.Button designColorButton1;
        private System.Windows.Forms.Button designColorButton2;
        private System.Windows.Forms.Button designColorButton3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox collarComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox brandComboBox;
        private System.Windows.Forms.Button mainColorButton;
        private System.Windows.Forms.Button collarColorButton3;
        private System.Windows.Forms.Button collarColorButton2;
        private System.Windows.Forms.Button collarColorButton1;
        private System.Windows.Forms.Button brandColorButton3;
        private System.Windows.Forms.Button brandColorButton2;
        private System.Windows.Forms.Button brandColorButton1;
    }
}

