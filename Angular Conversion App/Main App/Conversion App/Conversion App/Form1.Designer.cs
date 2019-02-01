namespace Conversion_App
{
    partial class Angular
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Angular));
            this.Select_File = new System.Windows.Forms.Button();
            this.Enter_Code = new System.Windows.Forms.Button();
            this.Convert = new System.Windows.Forms.Button();
            this.InputBox = new System.Windows.Forms.RichTextBox();
            this.OutputBox = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RouteConverter = new System.Windows.Forms.Button();
            this.PredefinedServiceConverter = new System.Windows.Forms.Button();
            this.CustomServiceConverter = new System.Windows.Forms.Button();
            this.ModuleConverter = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Select_File
            // 
            this.Select_File.BackColor = System.Drawing.Color.Transparent;
            this.Select_File.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Select_File.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Select_File.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.Select_File.FlatAppearance.BorderSize = 2;
            this.Select_File.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Select_File.Font = new System.Drawing.Font("Lucida Sans Typewriter", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Select_File.ForeColor = System.Drawing.Color.White;
            this.Select_File.Location = new System.Drawing.Point(27, 39);
            this.Select_File.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Select_File.Name = "Select_File";
            this.Select_File.Size = new System.Drawing.Size(154, 46);
            this.Select_File.TabIndex = 0;
            this.Select_File.Text = "Select File";
            this.Select_File.UseVisualStyleBackColor = false;
            this.Select_File.Visible = false;
            this.Select_File.Click += new System.EventHandler(this.button1_Click);
            // 
            // Enter_Code
            // 
            this.Enter_Code.BackColor = System.Drawing.Color.Transparent;
            this.Enter_Code.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Enter_Code.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.Enter_Code.FlatAppearance.BorderSize = 2;
            this.Enter_Code.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Enter_Code.Font = new System.Drawing.Font("Lucida Sans Typewriter", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Enter_Code.ForeColor = System.Drawing.Color.White;
            this.Enter_Code.Location = new System.Drawing.Point(27, 112);
            this.Enter_Code.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Enter_Code.Name = "Enter_Code";
            this.Enter_Code.Size = new System.Drawing.Size(154, 46);
            this.Enter_Code.TabIndex = 1;
            this.Enter_Code.Text = "Enter Code";
            this.Enter_Code.UseVisualStyleBackColor = false;
            this.Enter_Code.Visible = false;
            this.Enter_Code.Click += new System.EventHandler(this.button2_Click);
            // 
            // Convert
            // 
            this.Convert.BackColor = System.Drawing.Color.Gray;
            this.Convert.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Convert.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Convert.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Convert.Font = new System.Drawing.Font("Stencil", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Convert.ForeColor = System.Drawing.Color.White;
            this.Convert.Image = ((System.Drawing.Image)(resources.GetObject("Convert.Image")));
            this.Convert.Location = new System.Drawing.Point(637, 166);
            this.Convert.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Convert.Name = "Convert";
            this.Convert.Size = new System.Drawing.Size(124, 89);
            this.Convert.TabIndex = 2;
            this.Convert.Text = "CONVERT";
            this.Convert.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Convert.UseVisualStyleBackColor = false;
            this.Convert.Visible = false;
            this.Convert.Click += new System.EventHandler(this.button3_Click);
            // 
            // InputBox
            // 
            this.InputBox.BackColor = System.Drawing.Color.White;
            this.InputBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputBox.Location = new System.Drawing.Point(197, 39);
            this.InputBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.InputBox.Name = "InputBox";
            this.InputBox.Size = new System.Drawing.Size(416, 417);
            this.InputBox.TabIndex = 3;
            this.InputBox.Text = "";
            this.InputBox.Visible = false;
            this.InputBox.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // OutputBox
            // 
            this.OutputBox.BackColor = System.Drawing.Color.White;
            this.OutputBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OutputBox.FormattingEnabled = true;
            this.OutputBox.HorizontalScrollbar = true;
            this.OutputBox.ItemHeight = 16;
            this.OutputBox.Location = new System.Drawing.Point(787, 39);
            this.OutputBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.OutputBox.Name = "OutputBox";
            this.OutputBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.OutputBox.Size = new System.Drawing.Size(419, 420);
            this.OutputBox.TabIndex = 4;
            this.OutputBox.Visible = false;
            this.OutputBox.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Cursor = System.Windows.Forms.Cursors.No;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.ForeColor = System.Drawing.Color.IndianRed;
            this.panel1.Location = new System.Drawing.Point(33, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panel1.Size = new System.Drawing.Size(1243, 90);
            this.panel1.TabIndex = 5;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(367, 10);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(537, 57);
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gainsboro;
            this.label2.Location = new System.Drawing.Point(356, 18);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "AngularJS";
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.LightGray;
            this.label3.Location = new System.Drawing.Point(936, 17);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Angular 2+";
            this.label3.Visible = false;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox1.Controls.Add(this.RouteConverter);
            this.groupBox1.Controls.Add(this.PredefinedServiceConverter);
            this.groupBox1.Controls.Add(this.CustomServiceConverter);
            this.groupBox1.Controls.Add(this.ModuleConverter);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Red;
            this.groupBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.groupBox1.Location = new System.Drawing.Point(33, 95);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox1.Size = new System.Drawing.Size(1243, 123);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Coversion Type";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // RouteConverter
            // 
            this.RouteConverter.BackColor = System.Drawing.Color.Black;
            this.RouteConverter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.RouteConverter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RouteConverter.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.RouteConverter.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.RouteConverter.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RouteConverter.ForeColor = System.Drawing.Color.DarkOrange;
            this.RouteConverter.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.RouteConverter.Location = new System.Drawing.Point(967, 50);
            this.RouteConverter.Name = "RouteConverter";
            this.RouteConverter.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.RouteConverter.Size = new System.Drawing.Size(150, 49);
            this.RouteConverter.TabIndex = 3;
            this.RouteConverter.Text = "Routes";
            this.RouteConverter.UseVisualStyleBackColor = false;
            this.RouteConverter.Click += new System.EventHandler(this.RouteConverter_Click);
            // 
            // PredefinedServiceConverter
            // 
            this.PredefinedServiceConverter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PredefinedServiceConverter.BackColor = System.Drawing.Color.Black;
            this.PredefinedServiceConverter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.PredefinedServiceConverter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PredefinedServiceConverter.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.PredefinedServiceConverter.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.PredefinedServiceConverter.Font = new System.Drawing.Font("Impact", 12F);
            this.PredefinedServiceConverter.ForeColor = System.Drawing.Color.DarkOrange;
            this.PredefinedServiceConverter.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.PredefinedServiceConverter.Location = new System.Drawing.Point(666, 51);
            this.PredefinedServiceConverter.Name = "PredefinedServiceConverter";
            this.PredefinedServiceConverter.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.PredefinedServiceConverter.Size = new System.Drawing.Size(168, 48);
            this.PredefinedServiceConverter.TabIndex = 2;
            this.PredefinedServiceConverter.Text = "Predefined Service";
            this.PredefinedServiceConverter.UseVisualStyleBackColor = false;
            this.PredefinedServiceConverter.Click += new System.EventHandler(this.PredefinedServiceConverter_Click);
            // 
            // CustomServiceConverter
            // 
            this.CustomServiceConverter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CustomServiceConverter.BackColor = System.Drawing.Color.Black;
            this.CustomServiceConverter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CustomServiceConverter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CustomServiceConverter.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CustomServiceConverter.Font = new System.Drawing.Font("Impact", 12F);
            this.CustomServiceConverter.ForeColor = System.Drawing.Color.DarkOrange;
            this.CustomServiceConverter.Location = new System.Drawing.Point(367, 50);
            this.CustomServiceConverter.Name = "CustomServiceConverter";
            this.CustomServiceConverter.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.CustomServiceConverter.Size = new System.Drawing.Size(176, 48);
            this.CustomServiceConverter.TabIndex = 1;
            this.CustomServiceConverter.Text = "Custom Service";
            this.CustomServiceConverter.UseVisualStyleBackColor = false;
            this.CustomServiceConverter.Click += new System.EventHandler(this.CustomServiceConverter_Click);
            // 
            // ModuleConverter
            // 
            this.ModuleConverter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ModuleConverter.BackColor = System.Drawing.Color.Black;
            this.ModuleConverter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ModuleConverter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ModuleConverter.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.ModuleConverter.FlatAppearance.BorderSize = 2;
            this.ModuleConverter.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ModuleConverter.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModuleConverter.ForeColor = System.Drawing.Color.DarkOrange;
            this.ModuleConverter.Location = new System.Drawing.Point(105, 50);
            this.ModuleConverter.Name = "ModuleConverter";
            this.ModuleConverter.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ModuleConverter.Size = new System.Drawing.Size(169, 48);
            this.ModuleConverter.TabIndex = 0;
            this.ModuleConverter.Text = "Module";
            this.ModuleConverter.UseVisualStyleBackColor = false;
            this.ModuleConverter.Click += new System.EventHandler(this.ModuleConverter_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.OutputBox);
            this.groupBox2.Controls.Add(this.Convert);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.Enter_Code);
            this.groupBox2.Controls.Add(this.Select_File);
            this.groupBox2.Controls.Add(this.InputBox);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Red;
            this.groupBox2.Location = new System.Drawing.Point(33, 224);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox2.Size = new System.Drawing.Size(1243, 474);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Select File or Enter Source Code";
            this.groupBox2.Visible = false;
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // Angular
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1256, 482);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Angular";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "Angular Converter";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Select_File;
        private System.Windows.Forms.Button Enter_Code;
        private System.Windows.Forms.Button Convert;
        public System.Windows.Forms.RichTextBox InputBox;
        public System.Windows.Forms.ListBox OutputBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button RouteConverter;
        private System.Windows.Forms.Button PredefinedServiceConverter;
        private System.Windows.Forms.Button CustomServiceConverter;
        private System.Windows.Forms.Button ModuleConverter;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

