namespace TopBillboard
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panelLeft = new System.Windows.Forms.Panel();
            this.buttonResize = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonInfo = new System.Windows.Forms.Button();
            this.buttonGenius = new System.Windows.Forms.Button();
            this.panelSelect = new System.Windows.Forms.Panel();
            this.buttonHome = new System.Windows.Forms.Button();
            this.panelTop = new System.Windows.Forms.Panel();
            this.labelLogo = new System.Windows.Forms.Label();
            this.buttonGraph = new System.Windows.Forms.Button();
            this.panelColor1 = new System.Windows.Forms.Panel();
            this.buttonAlbum = new System.Windows.Forms.Button();
            this.buttonArtist = new System.Windows.Forms.Button();
            this.buttonWeek = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textBoxInfo = new System.Windows.Forms.TextBox();
            this.labelHeadingInfo = new System.Windows.Forms.Label();
            this.panelChart = new System.Windows.Forms.Panel();
            this.panelLyrics = new System.Windows.Forms.Panel();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.panelMiddle = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonMinimize = new System.Windows.Forms.Button();
            this.panelLeft.SuspendLayout();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panelChart.SuspendLayout();
            this.panelLyrics.SuspendLayout();
            this.panelMiddle.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(39)))), ((int)(((byte)(41)))));
            this.panelLeft.Controls.Add(this.panel1);
            this.panelLeft.Controls.Add(this.buttonInfo);
            this.panelLeft.Controls.Add(this.buttonGenius);
            this.panelLeft.Controls.Add(this.panelSelect);
            this.panelLeft.Controls.Add(this.buttonHome);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(133, 569);
            this.panelLeft.TabIndex = 0;
            // 
            // buttonResize
            // 
            this.buttonResize.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonResize.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonResize.BackgroundImage")));
            this.buttonResize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonResize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonResize.Location = new System.Drawing.Point(53, 5);
            this.buttonResize.Name = "buttonResize";
            this.buttonResize.Size = new System.Drawing.Size(27, 26);
            this.buttonResize.TabIndex = 7;
            this.buttonResize.UseVisualStyleBackColor = true;
            this.buttonResize.Click += new System.EventHandler(this.buttonMaximize_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonExit.BackgroundImage")));
            this.buttonExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExit.Location = new System.Drawing.Point(99, 2);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(31, 34);
            this.buttonExit.TabIndex = 6;
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonInfo
            // 
            this.buttonInfo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonInfo.BackgroundImage")));
            this.buttonInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonInfo.FlatAppearance.BorderSize = 0;
            this.buttonInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonInfo.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.buttonInfo.Location = new System.Drawing.Point(7, 256);
            this.buttonInfo.Name = "buttonInfo";
            this.buttonInfo.Size = new System.Drawing.Size(125, 124);
            this.buttonInfo.TabIndex = 5;
            this.buttonInfo.Text = "Info";
            this.buttonInfo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonInfo.UseVisualStyleBackColor = true;
            this.buttonInfo.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonGenius
            // 
            this.buttonGenius.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonGenius.BackgroundImage")));
            this.buttonGenius.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonGenius.FlatAppearance.BorderSize = 0;
            this.buttonGenius.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGenius.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.buttonGenius.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.buttonGenius.Location = new System.Drawing.Point(7, 130);
            this.buttonGenius.Name = "buttonGenius";
            this.buttonGenius.Size = new System.Drawing.Size(125, 124);
            this.buttonGenius.TabIndex = 5;
            this.buttonGenius.Text = "Genius\'s Trending";
            this.buttonGenius.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonGenius.UseVisualStyleBackColor = true;
            this.buttonGenius.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // panelSelect
            // 
            this.panelSelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(180)))), ((int)(((byte)(17)))));
            this.panelSelect.Location = new System.Drawing.Point(3, 0);
            this.panelSelect.Name = "panelSelect";
            this.panelSelect.Size = new System.Drawing.Size(5, 124);
            this.panelSelect.TabIndex = 1;
            // 
            // buttonHome
            // 
            this.buttonHome.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonHome.BackgroundImage")));
            this.buttonHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonHome.FlatAppearance.BorderSize = 0;
            this.buttonHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHome.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.buttonHome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.buttonHome.Location = new System.Drawing.Point(7, 0);
            this.buttonHome.Name = "buttonHome";
            this.buttonHome.Size = new System.Drawing.Size(125, 124);
            this.buttonHome.TabIndex = 1;
            this.buttonHome.Text = "Dashboard";
            this.buttonHome.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonHome.UseVisualStyleBackColor = true;
            this.buttonHome.Click += new System.EventHandler(this.button1_Click);
            // 
            // panelTop
            // 
            this.panelTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTop.Controls.Add(this.labelLogo);
            this.panelTop.Controls.Add(this.buttonGraph);
            this.panelTop.Controls.Add(this.panelColor1);
            this.panelTop.Controls.Add(this.buttonAlbum);
            this.panelTop.Controls.Add(this.buttonArtist);
            this.panelTop.Controls.Add(this.buttonWeek);
            this.panelTop.Location = new System.Drawing.Point(134, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(749, 76);
            this.panelTop.TabIndex = 3;
            // 
            // labelLogo
            // 
            this.labelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(180)))), ((int)(((byte)(17)))));
            this.labelLogo.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLogo.ForeColor = System.Drawing.Color.Black;
            this.labelLogo.Image = ((System.Drawing.Image)(resources.GetObject("labelLogo.Image")));
            this.labelLogo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.labelLogo.Location = new System.Drawing.Point(91, 10);
            this.labelLogo.Name = "labelLogo";
            this.labelLogo.Size = new System.Drawing.Size(122, 65);
            this.labelLogo.TabIndex = 6;
            this.labelLogo.Text = "billboard top 100";
            this.labelLogo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // buttonGraph
            // 
            this.buttonGraph.FlatAppearance.BorderSize = 2;
            this.buttonGraph.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGraph.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.buttonGraph.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.buttonGraph.Location = new System.Drawing.Point(325, 35);
            this.buttonGraph.Name = "buttonGraph";
            this.buttonGraph.Size = new System.Drawing.Size(83, 31);
            this.buttonGraph.TabIndex = 5;
            this.buttonGraph.Text = "Graph";
            this.buttonGraph.UseVisualStyleBackColor = true;
            this.buttonGraph.Click += new System.EventHandler(this.buttonGraph_Click);
            // 
            // panelColor1
            // 
            this.panelColor1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(180)))), ((int)(((byte)(17)))));
            this.panelColor1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelColor1.Location = new System.Drawing.Point(0, 0);
            this.panelColor1.Name = "panelColor1";
            this.panelColor1.Size = new System.Drawing.Size(749, 18);
            this.panelColor1.TabIndex = 4;
            this.panelColor1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelColor1_MouseDown);
            this.panelColor1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelColor1_MouseMove);
            this.panelColor1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelColor1_MouseUp);
            // 
            // buttonAlbum
            // 
            this.buttonAlbum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAlbum.FlatAppearance.BorderSize = 2;
            this.buttonAlbum.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAlbum.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.buttonAlbum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.buttonAlbum.Location = new System.Drawing.Point(646, 35);
            this.buttonAlbum.Name = "buttonAlbum";
            this.buttonAlbum.Size = new System.Drawing.Size(83, 31);
            this.buttonAlbum.TabIndex = 3;
            this.buttonAlbum.Text = "Album";
            this.buttonAlbum.UseVisualStyleBackColor = true;
            this.buttonAlbum.Click += new System.EventHandler(this.button6_Click);
            // 
            // buttonArtist
            // 
            this.buttonArtist.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonArtist.FlatAppearance.BorderSize = 2;
            this.buttonArtist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonArtist.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.buttonArtist.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.buttonArtist.Location = new System.Drawing.Point(539, 35);
            this.buttonArtist.Name = "buttonArtist";
            this.buttonArtist.Size = new System.Drawing.Size(83, 31);
            this.buttonArtist.TabIndex = 3;
            this.buttonArtist.Text = "Artist 100";
            this.buttonArtist.UseVisualStyleBackColor = true;
            this.buttonArtist.Click += new System.EventHandler(this.button5_Click);
            // 
            // buttonWeek
            // 
            this.buttonWeek.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonWeek.FlatAppearance.BorderSize = 2;
            this.buttonWeek.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonWeek.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.buttonWeek.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.buttonWeek.Location = new System.Drawing.Point(432, 35);
            this.buttonWeek.Name = "buttonWeek";
            this.buttonWeek.Size = new System.Drawing.Size(83, 31);
            this.buttonWeek.TabIndex = 3;
            this.buttonWeek.Text = "Week ";
            this.buttonWeek.UseVisualStyleBackColor = true;
            this.buttonWeek.Click += new System.EventHandler(this.button4_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(369, 471);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // textBoxInfo
            // 
            this.textBoxInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(42)))), ((int)(((byte)(56)))));
            this.textBoxInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(180)))), ((int)(((byte)(17)))));
            this.textBoxInfo.Location = new System.Drawing.Point(0, 23);
            this.textBoxInfo.Multiline = true;
            this.textBoxInfo.Name = "textBoxInfo";
            this.textBoxInfo.Size = new System.Drawing.Size(338, 448);
            this.textBoxInfo.TabIndex = 5;
            this.textBoxInfo.TextChanged += new System.EventHandler(this.textBoxInfo_TextChanged);
            // 
            // labelHeadingInfo
            // 
            this.labelHeadingInfo.AutoSize = true;
            this.labelHeadingInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelHeadingInfo.Font = new System.Drawing.Font("Century Gothic", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.labelHeadingInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.labelHeadingInfo.Location = new System.Drawing.Point(0, 0);
            this.labelHeadingInfo.Name = "labelHeadingInfo";
            this.labelHeadingInfo.Size = new System.Drawing.Size(60, 23);
            this.labelHeadingInfo.TabIndex = 6;
            this.labelHeadingInfo.Text = "Lyrics";
            this.labelHeadingInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelHeadingInfo.Click += new System.EventHandler(this.label3_Click);
            // 
            // panelChart
            // 
            this.panelChart.Controls.Add(this.dataGridView1);
            this.panelChart.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelChart.Location = new System.Drawing.Point(0, 0);
            this.panelChart.Name = "panelChart";
            this.panelChart.Size = new System.Drawing.Size(369, 471);
            this.panelChart.TabIndex = 7;
            // 
            // panelLyrics
            // 
            this.panelLyrics.Controls.Add(this.webBrowser1);
            this.panelLyrics.Controls.Add(this.textBoxInfo);
            this.panelLyrics.Controls.Add(this.labelHeadingInfo);
            this.panelLyrics.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelLyrics.Location = new System.Drawing.Point(375, 0);
            this.panelLyrics.Name = "panelLyrics";
            this.panelLyrics.Size = new System.Drawing.Size(338, 471);
            this.panelLyrics.TabIndex = 8;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(4, 55);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(299, 330);
            this.webBrowser1.TabIndex = 7;
            this.webBrowser1.Visible = false;
            // 
            // panelMiddle
            // 
            this.panelMiddle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMiddle.Controls.Add(this.panelChart);
            this.panelMiddle.Controls.Add(this.panelLyrics);
            this.panelMiddle.Location = new System.Drawing.Point(159, 83);
            this.panelMiddle.Name = "panelMiddle";
            this.panelMiddle.Size = new System.Drawing.Size(713, 471);
            this.panelMiddle.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
            this.panel1.Controls.Add(this.buttonMinimize);
            this.panel1.Controls.Add(this.buttonExit);
            this.panel1.Controls.Add(this.buttonResize);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 530);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(133, 39);
            this.panel1.TabIndex = 8;
            // 
            // buttonMinimize
            // 
            this.buttonMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMinimize.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonMinimize.BackgroundImage")));
            this.buttonMinimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonMinimize.FlatAppearance.BorderSize = 0;
            this.buttonMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMinimize.Location = new System.Drawing.Point(7, 6);
            this.buttonMinimize.Name = "buttonMinimize";
            this.buttonMinimize.Size = new System.Drawing.Size(26, 26);
            this.buttonMinimize.TabIndex = 8;
            this.buttonMinimize.UseVisualStyleBackColor = true;
            this.buttonMinimize.Click += new System.EventHandler(this.buttonMinimize_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(42)))), ((int)(((byte)(56)))));
            this.ClientSize = new System.Drawing.Size(884, 569);
            this.Controls.Add(this.panelMiddle);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelLeft);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(42)))), ((int)(((byte)(56)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Top Billboard";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.panelLeft.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panelChart.ResumeLayout(false);
            this.panelLyrics.ResumeLayout(false);
            this.panelLyrics.PerformLayout();
            this.panelMiddle.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Button buttonHome;
        private System.Windows.Forms.Panel panelSelect;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonGenius;
        private System.Windows.Forms.Button buttonInfo;
        private System.Windows.Forms.TextBox textBoxInfo;
        private System.Windows.Forms.Button buttonAlbum;
        private System.Windows.Forms.Button buttonArtist;
        private System.Windows.Forms.Button buttonWeek;
        private System.Windows.Forms.Label labelHeadingInfo;
        private System.Windows.Forms.Panel panelChart;
        private System.Windows.Forms.Panel panelLyrics;
        private System.Windows.Forms.Panel panelMiddle;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Panel panelColor1;
        private System.Windows.Forms.Button buttonGraph;
        private System.Windows.Forms.Label labelLogo;
        private System.Windows.Forms.Button buttonResize;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonMinimize;
    }
}

