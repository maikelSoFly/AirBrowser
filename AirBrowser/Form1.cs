
using CefSharp;
using CefSharp.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AirBrowser
{

    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        // Variables
      
        WebBrowser webTab = null;
        int location;
        int buttonSize = 150;
        TabPanel panel = new TabPanel();

    
        ChromiumWebBrowser chrome;

        private void Form1_Load(object sender, EventArgs e) {

            CefSettings settings = new CefSettings();
            Cef.Initialize(settings);
            //  webTab1 = new ChromiumWebBrowser("https://youtube.com");
            //chromePanel.Controls.Add(webTab1);
            // webTab1.Dock = DockStyle.Fill;
            //var page = new ChromiumWebBrowser("https://google.com");
           // var tab = new TabPage();
           // tab.Controls.Add(page);
           // page.Dock = DockStyle.Fill;
            //tabChrome.Controls.Add(tab);
           

            //tabControl.Controls.RemoveAt(0);
           // tabChrome.Controls.RemoveAt(0);
            location = btnNavigate.Location.X + 4;
            Controls.Add(panel.add_btnAddNewTab());
            BtnAddNewTab_Click(sender, e);              
            txtHttps.Text = "https://";
            // Hide original tabs buttons
            //tabChrome.Appearance = TabAppearance.FlatButtons;
            tabChrome.ItemSize = new Size(0, 1);
            //tabChrome.SizeMode = TabSizeMode.Fixed;
            //
            tabChrome.SendToBack();
            panel.btnAddNewTab.Click += BtnAddNewTab_Click;
            btnBack.MouseEnter += BtnBack_MouseEnter;
            btnBack.MouseLeave += BtnBack_MouseLeave;
            
            panel.NewTab_Click_Done += new EventHandler(On_NewTab_Click_Done);
            panel.NewTab_MouseUp_Done += new EventHandler(On_NewTab_MouseUp_Done);
            panel.RmNewTab_Click_Done += new EventHandler(On_RmNewTab_Click_Done);
           // webBrowser.WebBrowserShortcutsEnabled = true;
        }

        void On_RmNewTab_Click_Done(object sender, EventArgs e)
        {
            if (tabChrome.TabPages.Count - 1 > 0)
            {
                int removeFromStaticList = panel.removeFromStaticList;
                int removeFromNonStaticList = panel.removeFromNonStaticList;
                Controls.Remove(panel.removeButtons[removeFromNonStaticList]);
                Controls.Remove(panel.tabs[removeFromNonStaticList]);
                tabChrome.TabPages.RemoveAt(removeFromStaticList);
                panel.tabs.RemoveAt(removeFromNonStaticList);
                panel.rmPages.RemoveAt(removeFromStaticList);
                panel.pages.RemoveAt(removeFromStaticList);
                panel.removeButtons.RemoveAt(removeFromNonStaticList);

                if (removeFromNonStaticList < panel.indexOfSelectedButton)
                {
                    panel.indexOfSelectedButton -= 1;
                }
                else
                {
                    panel.indexOfSelectedButton = panel.tabs.Count - 1;
                }

                panel.ChangeButtonStyleToBackground(panel.indexOfSelectedButton);
                panel.Reposition();
                panel.btnAddNewTab.Location = new Point(panel.btnAddNewTab.Location.X - panel.tabWidth, panel.btnAddNewTab.Location.Y);
            }
        }

        void On_NewTab_MouseUp_Done(object sender, EventArgs e) 
        {
            tabChrome.SelectedIndex = panel.indexOfSelectedPage;
            Form1_SizeChanged(sender, e);
             ShowValidUrl();
        }

        void On_NewTab_Click_Done(object sender, EventArgs e) 
        {
            Button button = sender as Button;
            tabChrome.SelectedIndex = panel.indexOfSelectedPage;
            Form1_SizeChanged(sender, e);
            ShowValidUrl();
        }

        private void BtnAddNewTab_Click(object sender, EventArgs e)
        {
           
            //TabPage tab = new TabPage();
            
           
            
           // var chrome = new ChromiumWebBrowser("https://youtube.com");
            //webTab = new WebBrowser() { ScriptErrorsSuppressed = true };
            //tab.Controls.Add(chrome);
            //tabControl.Controls.Add(tab);

           // tabControl.SelectTab(tabControl.TabCount - 1);
            var page = new ChromiumWebBrowser("https://google.com");
            page.Dock = DockStyle.Fill;
            var tab = new TabPage();
            page.Parent = tab;
            
            tabChrome.Controls.Add(tab);
            tabChrome.SelectTab(tabChrome.TabCount - 1);

            page.TitleChanged += Page_TitleChanged;
            //webTab.Dock = DockStyle.Fill;
            //webTab.Navigate("https://google.com");
            txtNavigate.Text = "www.google.com";
            Controls.Add(panel.addNewRmTab());
            Controls.Add(panel.addNewTab("normal"));
            //webTab.DocumentCompleted += WebTab_DocumentCompleted;
           //webTab.DocumentTitleChanged += WebTab_DocumentTitleChanged;
        }

        private void Page_TitleChanged(object sender, TitleChangedEventArgs e)
        {
            this.Invoke(new MethodInvoker(() =>
            {
                panel.tabs[panel.indexOfSelectedButton].Text = e.Title;
            }));
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ChromiumWebBrowser web = tabChrome.SelectedTab.Controls[0] as ChromiumWebBrowser;
            if (web != null)
            {
                if (web.CanGoBack)
                    web.Back();
            }
        }
        
        private void btnForward_Click(object sender, EventArgs e)
        {
            var web = tabChrome.SelectedTab.Controls[0] as ChromiumWebBrowser;
            if (web != null)
            {
                if (web.CanGoForward)
                    web.Forward();
            }
        }

        private void btnNavigate_Click(object sender, EventArgs e)
        {
            var web = tabChrome.SelectedTab.Controls[0] as ChromiumWebBrowser;
            if (web != null)
            {
                web.Load(txtNavigate.Text);
            }
        }
       
       // private void WebTab_DocumentTitleChanged(object sender, EventArgs e)
       // {
         //  panel.tabs[panel.indexOfSelectedButton].Text = ((WebBrowser)tabControl.SelectedTab.Controls[0]).Document.Title;
      //  }
   
       // private void WebTab_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        //{
        //    panel.tabs[panel.indexOfSelectedButton].Text = ((WebBrowser)tabControl.SelectedTab.Controls[0]).Document.Title;
        //    ShowValidUrl();
        //    tabControl.Focus();
      //  }

        private void txtNavigate_Click(object sender, EventArgs e)
        {
            txtNavigate.SelectionStart = 0;
            txtNavigate.SelectionLength = txtNavigate.Text.Length;
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            location = btnNavigate.Location.X+4;
            buttonSize = this.Size.Width / 9;
            homePanel.Size = new Size(3 * buttonSize + 18, 3 * buttonSize + 18);
            homePanel.Location = new Point(this.Size.Width / 2 - (3 * buttonSize + 18) / 2 -9, 80);

            foreach (Button cls in homePanel.Controls)
            {
                cls.Size = new Size(buttonSize, buttonSize);
            }
        }

        private void btn9gag_Click(object sender, EventArgs e)
        {
           // ((WebBrowser)tabControl.SelectedTab.Controls[0]).Navigate("http://9gag.com");
        }

        private void btnTwitch_Click(object sender, EventArgs e)
        {
           // ((WebBrowser)tabControl.SelectedTab.Controls[0]).Navigate("http://twitch.tv");
        }

        private void btnFb_Click(object sender, EventArgs e)
        {
           // ((WebBrowser)tabControl.SelectedTab.Controls[0]).Navigate("https://facebook.com");
        }

        private void btnYahoo_Click(object sender, EventArgs e)
        {
            //((WebBrowser)tabControl.SelectedTab.Controls[0]).Navigate("https://yahoo.com");
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            TabPage homeTab = new TabPage();
            //tabControl.Controls.Add(homeTab);
            //tabControl.SelectTab(tabControl.TabCount - 1);
           // webTab = new WebBrowser { ScriptErrorsSuppressed = true };
            webTab.Parent = homeTab;
           webTab.Dock = DockStyle.Fill;
            webTab.Url = null;
            Controls.Add(panel.addNewRmTab());
            Controls.Add(panel.addNewTab("home"));
            HomeLayout(homeTab);
            webTab.Visible = false;
            ShowValidUrl();
        }

        private void txtNavigate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var web = tabChrome.SelectedTab.Controls[0] as ChromiumWebBrowser;
                web.Visible = true;
                if (web != null)
                {
                    web.Load(txtNavigate.Text);
                }
                txtNavigate.Items.Add(txtNavigate.Text);
                txtNavigate.AutoCompleteCustomSource.Add(txtNavigate.Text);
            }
        } 
    }
}

