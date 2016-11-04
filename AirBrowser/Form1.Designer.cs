namespace AirBrowser
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.tm = new System.Windows.Forms.Timer(this.components);
            this.tmBack = new System.Windows.Forms.Timer(this.components);
            this.btnFb = new System.Windows.Forms.Button();
            this.btn9gag = new System.Windows.Forms.Button();
            this.btnTwitch = new System.Windows.Forms.Button();
            this.btnYahoo = new System.Windows.Forms.Button();
            this.txtHttps = new System.Windows.Forms.Label();
            this.txtNavigate = new System.Windows.Forms.ComboBox();
            this.homePanel = new System.Windows.Forms.FlowLayoutPanel();
            this.btnNavigate = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnForward = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.picGradient = new System.Windows.Forms.PictureBox();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picGradient)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.ItemSize = new System.Drawing.Size(100, 0);
            this.tabControl.Location = new System.Drawing.Point(-4, 63);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1285, 645);
            this.tabControl.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.webBrowser);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(1277, 619);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // webBrowser
            // 
            this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser.Location = new System.Drawing.Point(0, 0);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(1277, 619);
            this.webBrowser.TabIndex = 6;
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // tm
            // 
            this.tm.Interval = 1;
            this.tm.Tick += new System.EventHandler(this.tm_Tick);
            // 
            // tmBack
            // 
            this.tmBack.Interval = 1;
            this.tmBack.Tick += new System.EventHandler(this.tmBack_Tick);
            // 
            // btnFb
            // 
            this.btnFb.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnFb.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnFb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFb.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnFb.ForeColor = System.Drawing.Color.Black;
            this.btnFb.Location = new System.Drawing.Point(378, 37);
            this.btnFb.Name = "btnFb";
            this.btnFb.Size = new System.Drawing.Size(73, 30);
            this.btnFb.TabIndex = 12;
            this.btnFb.Text = "Facebook";
            this.btnFb.UseVisualStyleBackColor = false;
            this.btnFb.Click += new System.EventHandler(this.btnFb_Click);
            // 
            // btn9gag
            // 
            this.btn9gag.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn9gag.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btn9gag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn9gag.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn9gag.ForeColor = System.Drawing.Color.Black;
            this.btn9gag.Location = new System.Drawing.Point(453, 37);
            this.btn9gag.Name = "btn9gag";
            this.btn9gag.Size = new System.Drawing.Size(73, 30);
            this.btn9gag.TabIndex = 13;
            this.btn9gag.Text = "9gag";
            this.btn9gag.UseVisualStyleBackColor = false;
            this.btn9gag.Click += new System.EventHandler(this.btn9gag_Click);
            // 
            // btnTwitch
            // 
            this.btnTwitch.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnTwitch.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnTwitch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTwitch.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnTwitch.ForeColor = System.Drawing.Color.Black;
            this.btnTwitch.Location = new System.Drawing.Point(528, 37);
            this.btnTwitch.Name = "btnTwitch";
            this.btnTwitch.Size = new System.Drawing.Size(73, 30);
            this.btnTwitch.TabIndex = 14;
            this.btnTwitch.Text = "Twitch";
            this.btnTwitch.UseVisualStyleBackColor = false;
            this.btnTwitch.Click += new System.EventHandler(this.btnTwitch_Click);
            // 
            // btnYahoo
            // 
            this.btnYahoo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnYahoo.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnYahoo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYahoo.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnYahoo.ForeColor = System.Drawing.Color.Black;
            this.btnYahoo.Location = new System.Drawing.Point(604, 37);
            this.btnYahoo.Name = "btnYahoo";
            this.btnYahoo.Size = new System.Drawing.Size(73, 30);
            this.btnYahoo.TabIndex = 16;
            this.btnYahoo.Text = "Yahoo";
            this.btnYahoo.UseVisualStyleBackColor = false;
            this.btnYahoo.Click += new System.EventHandler(this.btnYahoo_Click);
            // 
            // txtHttps
            // 
            this.txtHttps.AutoSize = true;
            this.txtHttps.BackColor = System.Drawing.Color.White;
            this.txtHttps.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtHttps.ForeColor = System.Drawing.Color.Green;
            this.txtHttps.Location = new System.Drawing.Point(100, 42);
            this.txtHttps.Name = "txtHttps";
            this.txtHttps.Size = new System.Drawing.Size(38, 13);
            this.txtHttps.TabIndex = 19;
            this.txtHttps.Text = "label1";
            // 
            // txtNavigate
            // 
            this.txtNavigate.AutoCompleteCustomSource.AddRange(new string[] {
            "9gag.com",
            "facebook.com"});
            this.txtNavigate.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtNavigate.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtNavigate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.txtNavigate.Location = new System.Drawing.Point(144, 40);
            this.txtNavigate.Name = "txtNavigate";
            this.txtNavigate.Size = new System.Drawing.Size(201, 21);
            this.txtNavigate.TabIndex = 21;
            this.txtNavigate.Click += new System.EventHandler(this.txtNavigate_Click);
            this.txtNavigate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNavigate_KeyDown);
            this.txtNavigate.Leave += new System.EventHandler(this.txtNavigate_Leave);
            this.txtNavigate.MouseEnter += new System.EventHandler(this.txtNavigate_MouseEnter);
            this.txtNavigate.MouseLeave += new System.EventHandler(this.txtNavigate_MouseLeave);
            // 
            // homePanel
            // 
            this.homePanel.Location = new System.Drawing.Point(0, 0);
            this.homePanel.Name = "homePanel";
            this.homePanel.Size = new System.Drawing.Size(200, 100);
            this.homePanel.TabIndex = 0;
            // 
            // btnNavigate
            // 
            this.btnNavigate.BackColor = System.Drawing.Color.Gainsboro;
            this.btnNavigate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnNavigate.FlatAppearance.BorderSize = 0;
            this.btnNavigate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavigate.Font = new System.Drawing.Font("Segoe UI Black", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnNavigate.ForeColor = System.Drawing.Color.White;
            this.btnNavigate.Location = new System.Drawing.Point(316, 34);
            this.btnNavigate.Name = "btnNavigate";
            this.btnNavigate.Size = new System.Drawing.Size(35, 32);
            this.btnNavigate.TabIndex = 4;
            this.btnNavigate.Text = "GO";
            this.btnNavigate.UseVisualStyleBackColor = false;
            this.btnNavigate.Click += new System.EventHandler(this.btnNavigate_Click);
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.White;
            this.btnHome.BackgroundImage = global::AirBrowser.Properties.Resources.btnHome;
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.ForeColor = System.Drawing.Color.Black;
            this.btnHome.Location = new System.Drawing.Point(64, 34);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(32, 32);
            this.btnHome.TabIndex = 20;
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            this.btnHome.MouseEnter += new System.EventHandler(this.btnHome_MouseEnter);
            this.btnHome.MouseLeave += new System.EventHandler(this.btnHome_MouseLeave);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(135)))), ((int)(((byte)(220)))));
            this.btnBack.BackgroundImage = global::AirBrowser.Properties.Resources.blueButton;
            this.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnBack.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnBack.Location = new System.Drawing.Point(0, 34);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(34, 32);
            this.btnBack.TabIndex = 1;
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnForward
            // 
            this.btnForward.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnForward.BackgroundImage = global::AirBrowser.Properties.Resources.btnForward;
            this.btnForward.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnForward.FlatAppearance.BorderSize = 0;
            this.btnForward.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnForward.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnForward.ForeColor = System.Drawing.Color.Black;
            this.btnForward.Location = new System.Drawing.Point(34, 34);
            this.btnForward.Name = "btnForward";
            this.btnForward.Size = new System.Drawing.Size(30, 32);
            this.btnForward.TabIndex = 2;
            this.btnForward.UseVisualStyleBackColor = false;
            this.btnForward.Click += new System.EventHandler(this.btnForward_Click);
            this.btnForward.MouseEnter += new System.EventHandler(this.btnForward_MouseEnter);
            this.btnForward.MouseLeave += new System.EventHandler(this.btnForward_MouseLeave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(93, 34);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(225, 32);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // picGradient
            // 
            this.picGradient.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picGradient.BackgroundImage = global::AirBrowser.Properties.Resources.bar1;
            this.picGradient.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picGradient.Location = new System.Drawing.Point(0, 30);
            this.picGradient.Name = "picGradient";
            this.picGradient.Size = new System.Drawing.Size(1277, 39);
            this.picGradient.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picGradient.TabIndex = 17;
            this.picGradient.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1276, 703);
            this.Controls.Add(this.btnNavigate);
            this.Controls.Add(this.txtNavigate);
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.txtHttps);
            this.Controls.Add(this.btnYahoo);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnForward);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnFb);
            this.Controls.Add(this.btnTwitch);
            this.Controls.Add(this.btn9gag);
            this.Controls.Add(this.picGradient);
            this.Controls.Add(this.tabControl);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(692, 106);
            this.Name = "Form1";
            this.Text = "Bricksplorer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picGradient)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

       



        #endregion
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnForward;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer tm;
        private System.Windows.Forms.Timer tmBack;
        private System.Windows.Forms.Button btnFb;
        private System.Windows.Forms.Button btnTwitch;
        private System.Windows.Forms.Button btn9gag;
        private System.Windows.Forms.Button btnYahoo;
        private System.Windows.Forms.PictureBox picGradient;
        private System.Windows.Forms.Label txtHttps;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.ComboBox txtNavigate;
        private System.Windows.Forms.FlowLayoutPanel homePanel;
        private System.Windows.Forms.Button btnNavigate;
    }
}

