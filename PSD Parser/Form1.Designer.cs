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
            this.numberComboBox = new System.Windows.Forms.ComboBox();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.colorButton1 = new System.Windows.Forms.Button();
            this.colorButton2 = new System.Windows.Forms.Button();
            this.colorButton3 = new System.Windows.Forms.Button();
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
            this.manComboBox.Location = new System.Drawing.Point(12, 49);
            this.manComboBox.Name = "manComboBox";
            this.manComboBox.Size = new System.Drawing.Size(206, 24);
            this.manComboBox.TabIndex = 2;
            this.manComboBox.SelectedIndexChanged += new System.EventHandler(this.manComboBox_SelectedIndexChanged);
            // 
            // numberComboBox
            // 
            this.numberComboBox.FormattingEnabled = true;
            this.numberComboBox.Location = new System.Drawing.Point(12, 79);
            this.numberComboBox.Name = "numberComboBox";
            this.numberComboBox.Size = new System.Drawing.Size(206, 24);
            this.numberComboBox.TabIndex = 3;
            this.numberComboBox.SelectedIndexChanged += new System.EventHandler(this.numberComboBox_SelectedIndexChanged);
            // 
            // colorButton1
            // 
            this.colorButton1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.colorButton1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.colorButton1.Location = new System.Drawing.Point(12, 127);
            this.colorButton1.Name = "colorButton1";
            this.colorButton1.Size = new System.Drawing.Size(75, 23);
            this.colorButton1.TabIndex = 7;
            this.colorButton1.UseVisualStyleBackColor = false;
            this.colorButton1.Click += new System.EventHandler(this.colorButton1_Click);
            // 
            // colorButton2
            // 
            this.colorButton2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.colorButton2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.colorButton2.Location = new System.Drawing.Point(12, 156);
            this.colorButton2.Name = "colorButton2";
            this.colorButton2.Size = new System.Drawing.Size(75, 23);
            this.colorButton2.TabIndex = 8;
            this.colorButton2.UseVisualStyleBackColor = false;
            this.colorButton2.Click += new System.EventHandler(this.colorButton2_Click);
            // 
            // colorButton3
            // 
            this.colorButton3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.colorButton3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.colorButton3.Location = new System.Drawing.Point(12, 185);
            this.colorButton3.Name = "colorButton3";
            this.colorButton3.Size = new System.Drawing.Size(75, 23);
            this.colorButton3.TabIndex = 9;
            this.colorButton3.UseVisualStyleBackColor = false;
            this.colorButton3.Click += new System.EventHandler(this.colorButton3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(814, 527);
            this.Controls.Add(this.colorButton3);
            this.Controls.Add(this.colorButton2);
            this.Controls.Add(this.colorButton1);
            this.Controls.Add(this.numberComboBox);
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
        private System.Windows.Forms.ComboBox numberComboBox;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Button colorButton1;
        private System.Windows.Forms.Button colorButton2;
        private System.Windows.Forms.Button colorButton3;
    }
}

