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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(302, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(500, 500);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // runButton
            // 
            this.runButton.Location = new System.Drawing.Point(12, 489);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(75, 23);
            this.runButton.TabIndex = 1;
            this.runButton.Text = "Go";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // manComboBox
            // 
            this.manComboBox.FormattingEnabled = true;
            this.manComboBox.Location = new System.Drawing.Point(12, 33);
            this.manComboBox.Name = "manComboBox";
            this.manComboBox.Size = new System.Drawing.Size(206, 24);
            this.manComboBox.TabIndex = 2;
            this.manComboBox.SelectedIndexChanged += new System.EventHandler(this.manComboBox_SelectedIndexChanged);
            // 
            // designComboBox
            // 
            this.designComboBox.FormattingEnabled = true;
            this.designComboBox.Location = new System.Drawing.Point(12, 79);
            this.designComboBox.Name = "designComboBox";
            this.designComboBox.Size = new System.Drawing.Size(206, 24);
            this.designComboBox.TabIndex = 3;
            this.designComboBox.SelectedIndexChanged += new System.EventHandler(this.numberComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Manufacturer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Design";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 220);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 17);
            this.label3.TabIndex = 13;
            this.label3.Text = "Sponsor";
            // 
            // sponsorComboBox
            // 
            this.sponsorComboBox.FormattingEnabled = true;
            this.sponsorComboBox.Location = new System.Drawing.Point(12, 239);
            this.sponsorComboBox.Name = "sponsorComboBox";
            this.sponsorComboBox.Size = new System.Drawing.Size(206, 24);
            this.sponsorComboBox.TabIndex = 12;
            this.sponsorComboBox.SelectedIndexChanged += new System.EventHandler(this.sponsorComboBox_SelectedIndexChanged);
            // 
            // designColorButton1
            // 
            this.designColorButton1.BackColor = System.Drawing.Color.Maroon;
            this.designColorButton1.Location = new System.Drawing.Point(12, 138);
            this.designColorButton1.Name = "designColorButton1";
            this.designColorButton1.Size = new System.Drawing.Size(65, 23);
            this.designColorButton1.TabIndex = 14;
            this.designColorButton1.UseVisualStyleBackColor = false;
            this.designColorButton1.Click += new System.EventHandler(this.colorButton1_Click);
            // 
            // designColorButton2
            // 
            this.designColorButton2.BackColor = System.Drawing.Color.Cyan;
            this.designColorButton2.Location = new System.Drawing.Point(12, 167);
            this.designColorButton2.Name = "designColorButton2";
            this.designColorButton2.Size = new System.Drawing.Size(65, 23);
            this.designColorButton2.TabIndex = 15;
            this.designColorButton2.UseVisualStyleBackColor = false;
            this.designColorButton2.Click += new System.EventHandler(this.colorButton2_Click);
            // 
            // designColorButton3
            // 
            this.designColorButton3.BackColor = System.Drawing.Color.Yellow;
            this.designColorButton3.Location = new System.Drawing.Point(12, 196);
            this.designColorButton3.Name = "designColorButton3";
            this.designColorButton3.Size = new System.Drawing.Size(65, 23);
            this.designColorButton3.TabIndex = 16;
            this.designColorButton3.UseVisualStyleBackColor = false;
            this.designColorButton3.Click += new System.EventHandler(this.colorButton3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 280);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 17);
            this.label4.TabIndex = 18;
            this.label4.Text = "Collar";
            // 
            // collarComboBox
            // 
            this.collarComboBox.FormattingEnabled = true;
            this.collarComboBox.Location = new System.Drawing.Point(12, 299);
            this.collarComboBox.Name = "collarComboBox";
            this.collarComboBox.Size = new System.Drawing.Size(206, 24);
            this.collarComboBox.TabIndex = 17;
            this.collarComboBox.SelectedIndexChanged += new System.EventHandler(this.collarComboBox_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 344);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 17);
            this.label5.TabIndex = 23;
            this.label5.Text = "Brand";
            // 
            // brandComboBox
            // 
            this.brandComboBox.FormattingEnabled = true;
            this.brandComboBox.Location = new System.Drawing.Point(12, 363);
            this.brandComboBox.Name = "brandComboBox";
            this.brandComboBox.Size = new System.Drawing.Size(206, 24);
            this.brandComboBox.TabIndex = 22;
            this.brandComboBox.SelectedIndexChanged += new System.EventHandler(this.brandComboBox_SelectedIndexChanged);
            // 
            // mainColorButton
            // 
            this.mainColorButton.BackColor = System.Drawing.Color.DarkTurquoise;
            this.mainColorButton.Location = new System.Drawing.Point(12, 109);
            this.mainColorButton.Name = "mainColorButton";
            this.mainColorButton.Size = new System.Drawing.Size(65, 23);
            this.mainColorButton.TabIndex = 24;
            this.mainColorButton.UseVisualStyleBackColor = false;
            this.mainColorButton.Click += new System.EventHandler(this.mainColorButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(814, 527);
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
    }
}

