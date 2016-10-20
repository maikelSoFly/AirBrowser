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
            this.txtNavigate = new System.Windows.Forms.TextBox();
            this.btnForward = new System.Windows.Forms.Button();
            this.btnNavigate = new System.Windows.Forms.Button();
            this.btnNewTab = new System.Windows.Forms.Button();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.flpTabPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.txtHttps = new System.Windows.Forms.TextBox();
            this.tm = new System.Windows.Forms.Timer(this.components);
            this.tmBack = new System.Windows.Forms.Timer(this.components);
            this.btnFb = new System.Windows.Forms.Button();
            this.btn9gag = new System.Windows.Forms.Button();
            this.btnTwitch = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnBack = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.ItemSize = new System.Drawing.Size(100, 0);
            this.tabControl.Location = new System.Drawing.Point(-4, 42);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1285, 653);
            this.tabControl.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.webBrowser);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(1277, 627);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // webBrowser
            // 
            this.webBrowser.Location = new System.Drawing.Point(0, 1);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(1270, 579);
            this.webBrowser.TabIndex = 6;
            // 
            // txtNavigate
            // 
            this.txtNavigate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.txtNavigate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNavigate.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtNavigate.Location = new System.Drawing.Point(112, 28);
            this.txtNavigate.Name = "txtNavigate";
            this.txtNavigate.Size = new System.Drawing.Size(149, 15);
            this.txtNavigate.TabIndex = 3;
            this.txtNavigate.Click += new System.EventHandler(this.txtNavigate_Click);
            this.txtNavigate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNavigate_KeyPress);
            this.txtNavigate.Leave += new System.EventHandler(this.txtNavigate_Leave);
            this.txtNavigate.MouseEnter += new System.EventHandler(this.txtNavigate_MouseEnter);
            this.txtNavigate.MouseLeave += new System.EventHandler(this.txtNavigate_MouseLeave);
            // 
            // btnForward
            // 
            this.btnForward.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnForward.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnForward.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnForward.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnForward.Location = new System.Drawing.Point(34, 23);
            this.btnForward.Name = "btnForward";
            this.btnForward.Size = new System.Drawing.Size(30, 24);
            this.btnForward.TabIndex = 2;
            this.btnForward.Text = ">";
            this.btnForward.UseVisualStyleBackColor = false;
            this.btnForward.Click += new System.EventHandler(this.btnForward_Click);
            // 
            // btnNavigate
            // 
            this.btnNavigate.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnNavigate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnNavigate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavigate.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnNavigate.Location = new System.Drawing.Point(262, 23);
            this.btnNavigate.Name = "btnNavigate";
            this.btnNavigate.Size = new System.Drawing.Size(35, 24);
            this.btnNavigate.TabIndex = 4;
            this.btnNavigate.Text = "GO";
            this.btnNavigate.UseVisualStyleBackColor = false;
            this.btnNavigate.Click += new System.EventHandler(this.btnNavigate_Click);
            // 
            // btnNewTab
            // 
            this.btnNewTab.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnNewTab.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnNewTab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewTab.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnNewTab.Location = new System.Drawing.Point(296, 23);
            this.btnNewTab.Name = "btnNewTab";
            this.btnNewTab.Size = new System.Drawing.Size(46, 24);
            this.btnNewTab.TabIndex = 5;
            this.btnNewTab.Text = "+";
            this.btnNewTab.UseVisualStyleBackColor = false;
            this.btnNewTab.Click += new System.EventHandler(this.btnNewTab_Click);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // flpTabPanel
            // 
            this.flpTabPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpTabPanel.Location = new System.Drawing.Point(5, -1);
            this.flpTabPanel.Margin = new System.Windows.Forms.Padding(1);
            this.flpTabPanel.Name = "flpTabPanel";
            this.flpTabPanel.Size = new System.Drawing.Size(1216, 25);
            this.flpTabPanel.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(341, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(32, 24);
            this.button1.TabIndex = 9;
            this.button1.Text = "x";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtHttps
            // 
            this.txtHttps.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.txtHttps.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtHttps.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtHttps.ForeColor = System.Drawing.Color.Green;
            this.txtHttps.Location = new System.Drawing.Point(71, 28);
            this.txtHttps.Name = "txtHttps";
            this.txtHttps.Size = new System.Drawing.Size(39, 15);
            this.txtHttps.TabIndex = 11;
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
            this.btnFb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.btnFb.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnFb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFb.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnFb.Location = new System.Drawing.Point(378, 25);
            this.btnFb.Name = "btnFb";
            this.btnFb.Size = new System.Drawing.Size(73, 22);
            this.btnFb.TabIndex = 12;
            this.btnFb.Text = "Facebook";
            this.btnFb.UseVisualStyleBackColor = false;
            this.btnFb.Click += new System.EventHandler(this.btnFb_Click);
            // 
            // btn9gag
            // 
            this.btn9gag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.btn9gag.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btn9gag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn9gag.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn9gag.Location = new System.Drawing.Point(453, 25);
            this.btn9gag.Name = "btn9gag";
            this.btn9gag.Size = new System.Drawing.Size(73, 22);
            this.btn9gag.TabIndex = 13;
            this.btn9gag.Text = "9gag";
            this.btn9gag.UseVisualStyleBackColor = false;
            this.btn9gag.Click += new System.EventHandler(this.btn9gag_Click);
            // 
            // btnTwitch
            // 
            this.btnTwitch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.btnTwitch.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnTwitch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTwitch.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnTwitch.Location = new System.Drawing.Point(528, 25);
            this.btnTwitch.Name = "btnTwitch";
            this.btnTwitch.Size = new System.Drawing.Size(73, 22);
            this.btnTwitch.TabIndex = 14;
            this.btnTwitch.Text = "Twitch";
            this.btnTwitch.UseVisualStyleBackColor = false;
            this.btnTwitch.Click += new System.EventHandler(this.btnTwitch_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(1216, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menuStrip1.Size = new System.Drawing.Size(58, 24);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.historyToolStripMenuItem,
            this.findToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // historyToolStripMenuItem
            // 
            this.historyToolStripMenuItem.Name = "historyToolStripMenuItem";
            this.historyToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.historyToolStripMenuItem.Text = "History";
            // 
            // findToolStripMenuItem
            // 
            this.findToolStripMenuItem.Name = "findToolStripMenuItem";
            this.findToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.findToolStripMenuItem.Text = "Find";
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(135)))), ((int)(((byte)(220)))));
            this.btnBack.BackgroundImage = global::AirBrowser.Properties.Resources.backArrow1;
            this.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnBack.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnBack.Location = new System.Drawing.Point(0, 19);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(36, 32);
            this.btnBack.TabIndex = 1;
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.pictureBox1.Location = new System.Drawing.Point(59, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(203, 24);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1276, 691);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.txtHttps);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.flpTabPanel);
            this.Controls.Add(this.btnNewTab);
            this.Controls.Add(this.btnNavigate);
            this.Controls.Add(this.btnForward);
            this.Controls.Add(this.txtNavigate);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnFb);
            this.Controls.Add(this.btnTwitch);
            this.Controls.Add(this.btn9gag);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Bricksplorer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

      

        #endregion
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.TextBox txtNavigate;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnForward;
        private System.Windows.Forms.Button btnNavigate;
        private System.Windows.Forms.Button btnNewTab;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.FlowLayoutPanel flpTabPanel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtHttps;
        private System.Windows.Forms.Timer tm;
        private System.Windows.Forms.Timer tmBack;
        private System.Windows.Forms.Button btnFb;
        private System.Windows.Forms.Button btnTwitch;
        private System.Windows.Forms.Button btn9gag;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem historyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findToolStripMenuItem;
    }
}

