namespace TrianglesFilller
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.menuTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Phong = new System.Windows.Forms.RadioButton();
            this.Gouard = new System.Windows.Forms.RadioButton();
            this.staticColor = new System.Windows.Forms.RadioButton();
            this.objectColorView = new System.Windows.Forms.TextBox();
            this.objectColor = new System.Windows.Forms.Button();
            this.lightPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.Fov = new System.Windows.Forms.TrackBar();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ZCoordinate = new System.Windows.Forms.NumericUpDown();
            this.YCoordinate = new System.Windows.Forms.NumericUpDown();
            this.XCoordinate = new System.Windows.Forms.NumericUpDown();
            this.labelZ = new System.Windows.Forms.Label();
            this.labelY = new System.Windows.Forms.Label();
            this.labelX = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Camera = new System.Windows.Forms.GroupBox();
            this.camera1 = new System.Windows.Forms.RadioButton();
            this.camera3 = new System.Windows.Forms.RadioButton();
            this.camera2 = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.fog = new System.Windows.Forms.CheckBox();
            this.day_night = new System.Windows.Forms.CheckBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.menuTablePanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.lightPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Fov)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ZCoordinate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YCoordinate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.XCoordinate)).BeginInit();
            this.panel1.SuspendLayout();
            this.Camera.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.93631F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.0637F));
            this.tableLayoutPanel.Controls.Add(this.pictureBox, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.menuTablePanel, 0, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 1;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(1133, 870);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // pictureBox
            // 
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Location = new System.Drawing.Point(342, 3);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(788, 864);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // menuTablePanel
            // 
            this.menuTablePanel.ColumnCount = 1;
            this.menuTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.menuTablePanel.Controls.Add(this.groupBox1, 0, 2);
            this.menuTablePanel.Controls.Add(this.lightPanel, 0, 0);
            this.menuTablePanel.Controls.Add(this.panel1, 0, 1);
            this.menuTablePanel.Controls.Add(this.panel2, 0, 3);
            this.menuTablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuTablePanel.Location = new System.Drawing.Point(3, 3);
            this.menuTablePanel.Name = "menuTablePanel";
            this.menuTablePanel.RowCount = 4;
            this.menuTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 62.67281F));
            this.menuTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 37.32719F));
            this.menuTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 214F));
            this.menuTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 136F));
            this.menuTablePanel.Size = new System.Drawing.Size(333, 864);
            this.menuTablePanel.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Phong);
            this.groupBox1.Controls.Add(this.Gouard);
            this.groupBox1.Controls.Add(this.staticColor);
            this.groupBox1.Controls.Add(this.objectColorView);
            this.groupBox1.Controls.Add(this.objectColor);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 516);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(327, 208);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Shading";
            // 
            // Phong
            // 
            this.Phong.AutoSize = true;
            this.Phong.Location = new System.Drawing.Point(11, 173);
            this.Phong.Name = "Phong";
            this.Phong.Size = new System.Drawing.Size(89, 29);
            this.Phong.TabIndex = 7;
            this.Phong.Text = "Phong";
            this.Phong.UseVisualStyleBackColor = true;
            this.Phong.CheckedChanged += new System.EventHandler(this.Phong_CheckedChanged);
            // 
            // Gouard
            // 
            this.Gouard.AutoSize = true;
            this.Gouard.Location = new System.Drawing.Point(11, 135);
            this.Gouard.Name = "Gouard";
            this.Gouard.Size = new System.Drawing.Size(96, 29);
            this.Gouard.TabIndex = 6;
            this.Gouard.Text = "Gourad";
            this.Gouard.UseVisualStyleBackColor = true;
            this.Gouard.CheckedChanged += new System.EventHandler(this.Gouard_CheckedChanged);
            // 
            // staticColor
            // 
            this.staticColor.AutoSize = true;
            this.staticColor.Checked = true;
            this.staticColor.Location = new System.Drawing.Point(11, 100);
            this.staticColor.Name = "staticColor";
            this.staticColor.Size = new System.Drawing.Size(83, 29);
            this.staticColor.TabIndex = 5;
            this.staticColor.TabStop = true;
            this.staticColor.Text = "Const";
            this.staticColor.UseVisualStyleBackColor = true;
            this.staticColor.CheckedChanged += new System.EventHandler(this.staticColor_CheckedChanged);
            // 
            // objectColorView
            // 
            this.objectColorView.Enabled = false;
            this.objectColorView.Location = new System.Drawing.Point(166, 46);
            this.objectColorView.Name = "objectColorView";
            this.objectColorView.Size = new System.Drawing.Size(146, 31);
            this.objectColorView.TabIndex = 4;
            // 
            // objectColor
            // 
            this.objectColor.Location = new System.Drawing.Point(11, 40);
            this.objectColor.Name = "objectColor";
            this.objectColor.Size = new System.Drawing.Size(131, 42);
            this.objectColor.TabIndex = 3;
            this.objectColor.Text = "Kolor";
            this.objectColor.UseVisualStyleBackColor = true;
            this.objectColor.Click += new System.EventHandler(this.objectColor_Click);
            // 
            // lightPanel
            // 
            this.lightPanel.Controls.Add(this.label1);
            this.lightPanel.Controls.Add(this.Fov);
            this.lightPanel.Controls.Add(this.button1);
            this.lightPanel.Controls.Add(this.groupBox3);
            this.lightPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lightPanel.Location = new System.Drawing.Point(3, 3);
            this.lightPanel.Name = "lightPanel";
            this.lightPanel.Size = new System.Drawing.Size(327, 316);
            this.lightPanel.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 277);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = "FOV";
            // 
            // Fov
            // 
            this.Fov.LargeChange = 1;
            this.Fov.Location = new System.Drawing.Point(125, 267);
            this.Fov.Maximum = 120;
            this.Fov.Minimum = 30;
            this.Fov.Name = "Fov";
            this.Fov.Size = new System.Drawing.Size(192, 69);
            this.Fov.TabIndex = 8;
            this.Fov.TickFrequency = 10;
            this.Fov.Value = 60;
            this.Fov.Scroll += new System.EventHandler(this.Fov_Scroll);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(11, 5);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(306, 42);
            this.button1.TabIndex = 7;
            this.button1.Text = "Load Object";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ZCoordinate);
            this.groupBox3.Controls.Add(this.YCoordinate);
            this.groupBox3.Controls.Add(this.XCoordinate);
            this.groupBox3.Controls.Add(this.labelZ);
            this.groupBox3.Controls.Add(this.labelY);
            this.groupBox3.Controls.Add(this.labelX);
            this.groupBox3.Location = new System.Drawing.Point(-3, 50);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Size = new System.Drawing.Size(330, 209);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Camera Position";
            // 
            // ZCoordinate
            // 
            this.ZCoordinate.Location = new System.Drawing.Point(180, 158);
            this.ZCoordinate.Name = "ZCoordinate";
            this.ZCoordinate.Size = new System.Drawing.Size(140, 31);
            this.ZCoordinate.TabIndex = 10;
            this.ZCoordinate.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.ZCoordinate.ValueChanged += new System.EventHandler(this.ZCoordinate_ValueChanged);
            // 
            // YCoordinate
            // 
            this.YCoordinate.Location = new System.Drawing.Point(180, 95);
            this.YCoordinate.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.YCoordinate.Name = "YCoordinate";
            this.YCoordinate.Size = new System.Drawing.Size(140, 31);
            this.YCoordinate.TabIndex = 9;
            this.YCoordinate.ValueChanged += new System.EventHandler(this.YCoordinate_ValueChanged);
            // 
            // XCoordinate
            // 
            this.XCoordinate.Location = new System.Drawing.Point(180, 39);
            this.XCoordinate.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.XCoordinate.Name = "XCoordinate";
            this.XCoordinate.Size = new System.Drawing.Size(140, 31);
            this.XCoordinate.TabIndex = 8;
            this.XCoordinate.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.XCoordinate.ValueChanged += new System.EventHandler(this.XCoordinate_ValueChanged);
            // 
            // labelZ
            // 
            this.labelZ.AutoSize = true;
            this.labelZ.Location = new System.Drawing.Point(64, 158);
            this.labelZ.Name = "labelZ";
            this.labelZ.Size = new System.Drawing.Size(22, 25);
            this.labelZ.TabIndex = 7;
            this.labelZ.Text = "Z";
            // 
            // labelY
            // 
            this.labelY.AutoSize = true;
            this.labelY.Location = new System.Drawing.Point(64, 101);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(22, 25);
            this.labelY.TabIndex = 6;
            this.labelY.Text = "Y";
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.Location = new System.Drawing.Point(64, 45);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(23, 25);
            this.labelX.TabIndex = 5;
            this.labelX.Text = "X";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Camera);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 325);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(327, 185);
            this.panel1.TabIndex = 1;
            // 
            // Camera
            // 
            this.Camera.Controls.Add(this.camera1);
            this.Camera.Controls.Add(this.camera3);
            this.Camera.Controls.Add(this.camera2);
            this.Camera.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Camera.Location = new System.Drawing.Point(0, 0);
            this.Camera.Name = "Camera";
            this.Camera.Size = new System.Drawing.Size(327, 185);
            this.Camera.TabIndex = 3;
            this.Camera.TabStop = false;
            this.Camera.Text = "Camera ";
            // 
            // camera1
            // 
            this.camera1.AutoSize = true;
            this.camera1.Checked = true;
            this.camera1.Location = new System.Drawing.Point(11, 43);
            this.camera1.Name = "camera1";
            this.camera1.Size = new System.Drawing.Size(112, 29);
            this.camera1.TabIndex = 0;
            this.camera1.TabStop = true;
            this.camera1.Text = "Camera 1";
            this.camera1.UseVisualStyleBackColor = true;
            // 
            // camera3
            // 
            this.camera3.AutoSize = true;
            this.camera3.Location = new System.Drawing.Point(11, 140);
            this.camera3.Name = "camera3";
            this.camera3.Size = new System.Drawing.Size(112, 29);
            this.camera3.TabIndex = 2;
            this.camera3.Text = "Camera 3";
            this.camera3.UseVisualStyleBackColor = true;
            // 
            // camera2
            // 
            this.camera2.AutoSize = true;
            this.camera2.Location = new System.Drawing.Point(11, 90);
            this.camera2.Name = "camera2";
            this.camera2.Size = new System.Drawing.Size(112, 29);
            this.camera2.TabIndex = 1;
            this.camera2.Text = "Camera 2";
            this.camera2.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.fog);
            this.panel2.Controls.Add(this.day_night);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 730);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(327, 131);
            this.panel2.TabIndex = 2;
            // 
            // fog
            // 
            this.fog.AutoSize = true;
            this.fog.Location = new System.Drawing.Point(11, 23);
            this.fog.Name = "fog";
            this.fog.Size = new System.Drawing.Size(69, 29);
            this.fog.TabIndex = 2;
            this.fog.Text = "Fog";
            this.fog.UseVisualStyleBackColor = true;
            this.fog.CheckedChanged += new System.EventHandler(this.fog_CheckedChanged);
            // 
            // day_night
            // 
            this.day_night.AutoSize = true;
            this.day_night.Location = new System.Drawing.Point(11, 74);
            this.day_night.Name = "day_night";
            this.day_night.Size = new System.Drawing.Size(82, 29);
            this.day_night.TabIndex = 2;
            this.day_night.Text = "Night";
            this.day_night.UseVisualStyleBackColor = true;
            this.day_night.CheckedChanged += new System.EventHandler(this.day_night_CheckedChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // timer1
            // 
            this.timer1.Interval = 30;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 30;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer3
            // 
            this.timer3.Interval = 30;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1133, 870);
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "MainWindow";
            this.Text = "TrianglesFiller";
            this.tableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.menuTablePanel.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.lightPanel.ResumeLayout(false);
            this.lightPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Fov)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ZCoordinate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YCoordinate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.XCoordinate)).EndInit();
            this.panel1.ResumeLayout(false);
            this.Camera.ResumeLayout(false);
            this.Camera.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel;
        private PictureBox pictureBox;
        private TableLayoutPanel menuTablePanel;
        private Panel lightPanel;
        private Panel panel1;
        private ColorDialog colorDialog1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Timer timer1;
        private GroupBox groupBox3;
        private Button button1;
        private Label labelZ;
        private Label labelY;
        private Label labelX;
        private System.Windows.Forms.Timer timer2;
        private TrackBar Fov;
        private NumericUpDown ZCoordinate;
        private NumericUpDown YCoordinate;
        private NumericUpDown XCoordinate;
        private GroupBox groupBox1;
        private RadioButton Phong;
        private RadioButton Gouard;
        private RadioButton staticColor;
        private TextBox objectColorView;
        private Button objectColor;
        private RadioButton camera3;
        private RadioButton camera2;
        private RadioButton camera1;
        private CheckBox fog;
        private CheckBox day_night;
        private Label label1;
        private GroupBox Camera;
        private Panel panel2;
        private System.Windows.Forms.Timer timer3;
    }
}