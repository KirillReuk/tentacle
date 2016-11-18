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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.runButton = new System.Windows.Forms.Button();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.designDataGridView = new System.Windows.Forms.DataGridView();
            this.names = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.color1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.color2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.color3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.mainTab = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.mainColorButton = new System.Windows.Forms.Button();
            this.layersLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.collarDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.layerTab = new System.Windows.Forms.TabPage();
            this.layerDataGridView = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewImageColumn();
            this.layerTabControl = new System.Windows.Forms.TabControl();
            this.layersNextButton = new System.Windows.Forms.Button();
            this.layersBackButton = new System.Windows.Forms.Button();
            this.customizationTab = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.scaleDecalButton = new System.Windows.Forms.Button();
            this.rotateDecalButton = new System.Windows.Forms.Button();
            this.moveDecalButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.colorButton1 = new System.Windows.Forms.Button();
            this.colorButton3 = new System.Windows.Forms.Button();
            this.colorButton2 = new System.Windows.Forms.Button();
            this.customizationFinishButton = new System.Windows.Forms.Button();
            this.customizationBackButton = new System.Windows.Forms.Button();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.upTimer = new System.Windows.Forms.Timer(this.components);
            this.downTimer = new System.Windows.Forms.Timer(this.components);
            this.rightTimer = new System.Windows.Forms.Timer(this.components);
            this.leftTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.designDataGridView)).BeginInit();
            this.mainTabControl.SuspendLayout();
            this.mainTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.collarDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.manDataGridView)).BeginInit();
            this.layerTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layerDataGridView)).BeginInit();
            this.customizationTab.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox.Location = new System.Drawing.Point(323, 28);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(625, 615);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // runButton
            // 
            this.runButton.Location = new System.Drawing.Point(125, 551);
            this.runButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(75, 52);
            this.runButton.TabIndex = 1;
            this.runButton.Text = "Go";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // designDataGridView
            // 
            this.designDataGridView.AllowUserToAddRows = false;
            this.designDataGridView.AllowUserToResizeColumns = false;
            this.designDataGridView.AllowUserToResizeRows = false;
            this.designDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.designDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.designDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.designDataGridView.ColumnHeadersVisible = false;
            this.designDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.names,
            this.color1,
            this.color2,
            this.color3});
            this.designDataGridView.Location = new System.Drawing.Point(11, 237);
            this.designDataGridView.MultiSelect = false;
            this.designDataGridView.Name = "designDataGridView";
            this.designDataGridView.RowHeadersVisible = false;
            this.designDataGridView.RowTemplate.Height = 24;
            this.designDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.designDataGridView.Size = new System.Drawing.Size(287, 297);
            this.designDataGridView.TabIndex = 31;
            this.designDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.designDataGridView_CellDoubleClick);
            this.designDataGridView.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.designDataGridView_RowsRemoved);
            this.designDataGridView.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.designDataGridView_UserDeletingRow);
            // 
            // names
            // 
            this.names.FillWeight = 70F;
            this.names.HeaderText = "names";
            this.names.Name = "names";
            this.names.ReadOnly = true;
            this.names.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // color1
            // 
            this.color1.FillWeight = 10F;
            this.color1.HeaderText = "color1";
            this.color1.Name = "color1";
            this.color1.ReadOnly = true;
            this.color1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // color2
            // 
            this.color2.FillWeight = 10F;
            this.color2.HeaderText = "color2";
            this.color2.Name = "color2";
            this.color2.ReadOnly = true;
            this.color2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // color3
            // 
            this.color3.FillWeight = 10F;
            this.color3.HeaderText = "color3";
            this.color3.Name = "color3";
            this.color3.ReadOnly = true;
            this.color3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // mainTabControl
            // 
            this.mainTabControl.Controls.Add(this.mainTab);
            this.mainTabControl.Controls.Add(this.layerTab);
            this.mainTabControl.Controls.Add(this.customizationTab);
            this.mainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTabControl.ItemSize = new System.Drawing.Size(0, 1);
            this.mainTabControl.Location = new System.Drawing.Point(0, 28);
            this.mainTabControl.Margin = new System.Windows.Forms.Padding(0);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(323, 615);
            this.mainTabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.mainTabControl.TabIndex = 33;
            // 
            // mainTab
            // 
            this.mainTab.Controls.Add(this.label2);
            this.mainTab.Controls.Add(this.mainColorButton);
            this.mainTab.Controls.Add(this.layersLabel);
            this.mainTab.Controls.Add(this.label1);
            this.mainTab.Controls.Add(this.collarDataGridView);
            this.mainTab.Controls.Add(this.manDataGridView);
            this.mainTab.Controls.Add(this.runButton);
            this.mainTab.Controls.Add(this.designDataGridView);
            this.mainTab.Controls.Add(this.label4);
            this.mainTab.Location = new System.Drawing.Point(4, 5);
            this.mainTab.Name = "mainTab";
            this.mainTab.Padding = new System.Windows.Forms.Padding(3);
            this.mainTab.Size = new System.Drawing.Size(315, 606);
            this.mainTab.TabIndex = 0;
            this.mainTab.Text = "tabPage1";
            this.mainTab.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 17);
            this.label2.TabIndex = 59;
            this.label2.Text = "Main Color";
            // 
            // mainColorButton
            // 
            this.mainColorButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mainColorButton.BackColor = System.Drawing.Color.OliveDrab;
            this.mainColorButton.Location = new System.Drawing.Point(11, 52);
            this.mainColorButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mainColorButton.Name = "mainColorButton";
            this.mainColorButton.Size = new System.Drawing.Size(287, 27);
            this.mainColorButton.TabIndex = 58;
            this.mainColorButton.UseVisualStyleBackColor = false;
            this.mainColorButton.Click += new System.EventHandler(this.mainColorButton_Click);
            // 
            // layersLabel
            // 
            this.layersLabel.AutoSize = true;
            this.layersLabel.Location = new System.Drawing.Point(8, 217);
            this.layersLabel.Name = "layersLabel";
            this.layersLabel.Size = new System.Drawing.Size(51, 17);
            this.layersLabel.TabIndex = 57;
            this.layersLabel.Text = "Layers";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 17);
            this.label1.TabIndex = 56;
            this.label1.Text = "Manufacturer";
            // 
            // collarDataGridView
            // 
            this.collarDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.collarDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.collarDataGridView.ColumnHeadersVisible = false;
            this.collarDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12});
            this.collarDataGridView.Location = new System.Drawing.Point(11, 167);
            this.collarDataGridView.Name = "collarDataGridView";
            this.collarDataGridView.RowHeadersVisible = false;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.Black;
            this.collarDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle13;
            this.collarDataGridView.RowTemplate.Height = 24;
            this.collarDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.collarDataGridView.Size = new System.Drawing.Size(287, 24);
            this.collarDataGridView.TabIndex = 55;
            this.collarDataGridView.DoubleClick += new System.EventHandler(this.collarDataGridView_Click);
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.FillWeight = 70F;
            this.dataGridViewTextBoxColumn9.HeaderText = "names";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.FillWeight = 10F;
            this.dataGridViewTextBoxColumn10.HeaderText = "color1";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.FillWeight = 10F;
            this.dataGridViewTextBoxColumn11.HeaderText = "color2";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.FillWeight = 10F;
            this.dataGridViewTextBoxColumn12.HeaderText = "color3";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            this.dataGridViewTextBoxColumn12.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // manDataGridView
            // 
            this.manDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.manDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.manDataGridView.ColumnHeadersVisible = false;
            this.manDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1});
            this.manDataGridView.Location = new System.Drawing.Point(11, 120);
            this.manDataGridView.Name = "manDataGridView";
            this.manDataGridView.RowHeadersVisible = false;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.Black;
            this.manDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle14;
            this.manDataGridView.RowTemplate.Height = 24;
            this.manDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.manDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.manDataGridView.Size = new System.Drawing.Size(287, 24);
            this.manDataGridView.TabIndex = 53;
            this.manDataGridView.DoubleClick += new System.EventHandler(this.manDataGridView_DoubleClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.FillWeight = 70F;
            this.dataGridViewTextBoxColumn1.HeaderText = "names";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 17);
            this.label4.TabIndex = 43;
            this.label4.Text = "Collar";
            // 
            // layerTab
            // 
            this.layerTab.Controls.Add(this.layerDataGridView);
            this.layerTab.Controls.Add(this.layerTabControl);
            this.layerTab.Controls.Add(this.layersNextButton);
            this.layerTab.Controls.Add(this.layersBackButton);
            this.layerTab.Location = new System.Drawing.Point(4, 5);
            this.layerTab.Name = "layerTab";
            this.layerTab.Padding = new System.Windows.Forms.Padding(3);
            this.layerTab.Size = new System.Drawing.Size(315, 606);
            this.layerTab.TabIndex = 1;
            this.layerTab.Text = "tabPage2";
            this.layerTab.UseVisualStyleBackColor = true;
            // 
            // layerDataGridView
            // 
            this.layerDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.layerDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.layerDataGridView.ColumnHeadersVisible = false;
            this.layerDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.layerDataGridView.Location = new System.Drawing.Point(6, 27);
            this.layerDataGridView.Margin = new System.Windows.Forms.Padding(0);
            this.layerDataGridView.MultiSelect = false;
            this.layerDataGridView.Name = "layerDataGridView";
            this.layerDataGridView.RowHeadersVisible = false;
            this.layerDataGridView.RowTemplate.Height = 103;
            this.layerDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.layerDataGridView.Size = new System.Drawing.Size(299, 534);
            this.layerDataGridView.TabIndex = 34;
            this.layerDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.layerDataGridView_CellDoubleClick);
            this.layerDataGridView.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.layerDataGridView_CellMouseEnter);
            this.layerDataGridView.MouseLeave += new System.EventHandler(this.layerDataGridView_MouseLeave);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Column1.Name = "Column1";
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Column2";
            this.Column2.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Column2.Name = "Column2";
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Column3";
            this.Column3.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Column3.Name = "Column3";
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // layerTabControl
            // 
            this.layerTabControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.layerTabControl.Location = new System.Drawing.Point(3, 3);
            this.layerTabControl.Name = "layerTabControl";
            this.layerTabControl.SelectedIndex = 0;
            this.layerTabControl.Size = new System.Drawing.Size(309, 21);
            this.layerTabControl.TabIndex = 49;
            this.layerTabControl.SelectedIndexChanged += new System.EventHandler(this.layerTabControl_SelectedIndexChanged);
            // 
            // layersNextButton
            // 
            this.layersNextButton.Location = new System.Drawing.Point(183, 564);
            this.layersNextButton.Name = "layersNextButton";
            this.layersNextButton.Size = new System.Drawing.Size(123, 33);
            this.layersNextButton.TabIndex = 48;
            this.layersNextButton.Text = "Next";
            this.layersNextButton.UseVisualStyleBackColor = true;
            this.layersNextButton.Click += new System.EventHandler(this.layersDoneButton_Click);
            // 
            // layersBackButton
            // 
            this.layersBackButton.Location = new System.Drawing.Point(3, 564);
            this.layersBackButton.Name = "layersBackButton";
            this.layersBackButton.Size = new System.Drawing.Size(174, 33);
            this.layersBackButton.TabIndex = 35;
            this.layersBackButton.Text = "Back";
            this.layersBackButton.UseVisualStyleBackColor = true;
            this.layersBackButton.Click += new System.EventHandler(this.layersBackButton_Click);
            // 
            // customizationTab
            // 
            this.customizationTab.Controls.Add(this.panel2);
            this.customizationTab.Controls.Add(this.panel1);
            this.customizationTab.Controls.Add(this.customizationFinishButton);
            this.customizationTab.Controls.Add(this.customizationBackButton);
            this.customizationTab.Location = new System.Drawing.Point(4, 5);
            this.customizationTab.Name = "customizationTab";
            this.customizationTab.Size = new System.Drawing.Size(315, 606);
            this.customizationTab.TabIndex = 2;
            this.customizationTab.Text = "settings";
            this.customizationTab.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.scaleDecalButton);
            this.panel2.Controls.Add(this.rotateDecalButton);
            this.panel2.Controls.Add(this.moveDecalButton);
            this.panel2.Location = new System.Drawing.Point(3, 119);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(312, 432);
            this.panel2.TabIndex = 54;
            // 
            // scaleDecalButton
            // 
            this.scaleDecalButton.BackColor = System.Drawing.Color.White;
            this.scaleDecalButton.Location = new System.Drawing.Point(0, 216);
            this.scaleDecalButton.Margin = new System.Windows.Forms.Padding(0);
            this.scaleDecalButton.Name = "scaleDecalButton";
            this.scaleDecalButton.Size = new System.Drawing.Size(312, 108);
            this.scaleDecalButton.TabIndex = 2;
            this.scaleDecalButton.Text = "Scale";
            this.scaleDecalButton.UseVisualStyleBackColor = false;
            this.scaleDecalButton.Click += new System.EventHandler(this.scaleDecalButton_Click);
            // 
            // rotateDecalButton
            // 
            this.rotateDecalButton.BackColor = System.Drawing.Color.White;
            this.rotateDecalButton.Location = new System.Drawing.Point(0, 108);
            this.rotateDecalButton.Margin = new System.Windows.Forms.Padding(0);
            this.rotateDecalButton.Name = "rotateDecalButton";
            this.rotateDecalButton.Size = new System.Drawing.Size(312, 108);
            this.rotateDecalButton.TabIndex = 1;
            this.rotateDecalButton.Text = "Rotate";
            this.rotateDecalButton.UseVisualStyleBackColor = false;
            this.rotateDecalButton.Click += new System.EventHandler(this.rotateDecalButton_Click);
            // 
            // moveDecalButton
            // 
            this.moveDecalButton.BackColor = System.Drawing.Color.White;
            this.moveDecalButton.FlatAppearance.BorderSize = 0;
            this.moveDecalButton.Location = new System.Drawing.Point(0, 0);
            this.moveDecalButton.Margin = new System.Windows.Forms.Padding(0);
            this.moveDecalButton.Name = "moveDecalButton";
            this.moveDecalButton.Size = new System.Drawing.Size(312, 108);
            this.moveDecalButton.TabIndex = 0;
            this.moveDecalButton.Text = "Move";
            this.moveDecalButton.UseVisualStyleBackColor = false;
            this.moveDecalButton.Click += new System.EventHandler(this.moveDecalButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.colorButton1);
            this.panel1.Controls.Add(this.colorButton3);
            this.panel1.Controls.Add(this.colorButton2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(315, 100);
            this.panel1.TabIndex = 53;
            // 
            // colorButton1
            // 
            this.colorButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.colorButton1.BackColor = System.Drawing.Color.Maroon;
            this.colorButton1.Location = new System.Drawing.Point(0, 0);
            this.colorButton1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.colorButton1.Name = "colorButton1";
            this.colorButton1.Size = new System.Drawing.Size(105, 100);
            this.colorButton1.TabIndex = 48;
            this.colorButton1.UseVisualStyleBackColor = false;
            this.colorButton1.Click += new System.EventHandler(this.colorButton1_Click);
            // 
            // colorButton3
            // 
            this.colorButton3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.colorButton3.BackColor = System.Drawing.Color.Yellow;
            this.colorButton3.Dock = System.Windows.Forms.DockStyle.Right;
            this.colorButton3.Location = new System.Drawing.Point(210, 0);
            this.colorButton3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.colorButton3.Name = "colorButton3";
            this.colorButton3.Size = new System.Drawing.Size(105, 100);
            this.colorButton3.TabIndex = 50;
            this.colorButton3.UseVisualStyleBackColor = false;
            this.colorButton3.Click += new System.EventHandler(this.colorButton3_Click);
            // 
            // colorButton2
            // 
            this.colorButton2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.colorButton2.BackColor = System.Drawing.Color.Cyan;
            this.colorButton2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colorButton2.Location = new System.Drawing.Point(0, 0);
            this.colorButton2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.colorButton2.Name = "colorButton2";
            this.colorButton2.Size = new System.Drawing.Size(315, 100);
            this.colorButton2.TabIndex = 49;
            this.colorButton2.UseVisualStyleBackColor = false;
            this.colorButton2.Click += new System.EventHandler(this.colorButton2_Click);
            // 
            // customizationFinishButton
            // 
            this.customizationFinishButton.Location = new System.Drawing.Point(183, 565);
            this.customizationFinishButton.Name = "customizationFinishButton";
            this.customizationFinishButton.Size = new System.Drawing.Size(123, 33);
            this.customizationFinishButton.TabIndex = 52;
            this.customizationFinishButton.Text = "Next";
            this.customizationFinishButton.UseVisualStyleBackColor = true;
            this.customizationFinishButton.Click += new System.EventHandler(this.customizationFinishButton_Click);
            // 
            // customizationBackButton
            // 
            this.customizationBackButton.Location = new System.Drawing.Point(3, 565);
            this.customizationBackButton.Name = "customizationBackButton";
            this.customizationBackButton.Size = new System.Drawing.Size(174, 33);
            this.customizationBackButton.TabIndex = 51;
            this.customizationBackButton.Text = "Back";
            this.customizationBackButton.UseVisualStyleBackColor = true;
            this.customizationBackButton.Click += new System.EventHandler(this.customizationBackButton_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(948, 28);
            this.menuStrip.TabIndex = 34;
            this.menuStrip.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // upTimer
            // 
            this.upTimer.Interval = 50;
            this.upTimer.Tick += new System.EventHandler(this.upTimer_Tick);
            // 
            // downTimer
            // 
            this.downTimer.Interval = 50;
            this.downTimer.Tick += new System.EventHandler(this.downTimer_Tick);
            // 
            // rightTimer
            // 
            this.rightTimer.Interval = 50;
            this.rightTimer.Tick += new System.EventHandler(this.rightTimer_Tick);
            // 
            // leftTimer
            // 
            this.leftTimer.Interval = 50;
            this.leftTimer.Tick += new System.EventHandler(this.leftTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 643);
            this.Controls.Add(this.mainTabControl);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "SSD";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.designDataGridView)).EndInit();
            this.mainTabControl.ResumeLayout(false);
            this.mainTab.ResumeLayout(false);
            this.mainTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.collarDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.manDataGridView)).EndInit();
            this.layerTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layerDataGridView)).EndInit();
            this.customizationTab.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.DataGridView designDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn names;
        private System.Windows.Forms.DataGridViewTextBoxColumn color1;
        private System.Windows.Forms.DataGridViewTextBoxColumn color2;
        private System.Windows.Forms.DataGridViewTextBoxColumn color3;
        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage mainTab;
        private System.Windows.Forms.TabPage layerTab;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView manDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridView layerDataGridView;
        private System.Windows.Forms.Button layersBackButton;
        private System.Windows.Forms.DataGridViewImageColumn Column1;
        private System.Windows.Forms.DataGridViewImageColumn Column2;
        private System.Windows.Forms.DataGridViewImageColumn Column3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView collarDataGridView;
        private System.Windows.Forms.Button layersNextButton;
        private System.Windows.Forms.Label layersLabel;
        private System.Windows.Forms.Button mainColorButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.TabControl layerTabControl;
        private System.Windows.Forms.TabPage customizationTab;
        private System.Windows.Forms.Button colorButton1;
        private System.Windows.Forms.Button colorButton2;
        private System.Windows.Forms.Button colorButton3;
        private System.Windows.Forms.Button customizationFinishButton;
        private System.Windows.Forms.Button customizationBackButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button rotateDecalButton;
        private System.Windows.Forms.Button scaleDecalButton;
        private System.Windows.Forms.Button moveDecalButton;
        private System.Windows.Forms.Timer upTimer;
        private System.Windows.Forms.Timer downTimer;
        private System.Windows.Forms.Timer rightTimer;
        private System.Windows.Forms.Timer leftTimer;
    }
}

