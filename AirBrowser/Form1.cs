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

        int location;
        int buttonSize = 150;
        TabPanel panel = new TabPanel();
        

        private void Form1_Load(object sender, EventArgs e) {

            CefSettings settings = new CefSettings();
            Cef.Initialize(settings);
            panel.formWidth = this.Size.Width;
            
            location = btnNavigate.Location.X + 4;
            Controls.Add(panel.add_btnAddNewTab());
            BtnAddNewTab_Click(sender, e);              
            txtHttps.Text = "https://";
            tabChrome.ItemSize = new Size(0, 1);
            tabChrome.SendToBack();
            panel.btnAddNewTab.Click += BtnAddNewTab_Click;
            btnBack.MouseEnter += BtnBack_MouseEnter;
            btnBack.MouseLeave += BtnBack_MouseLeave;
            panel.formWidth = this.Size.Width;
            panel.maxTabs = (this.Size.Width / panel.tabWidth)-1;
            panel.NewTab_Click_Done += new EventHandler(On_NewTab_Click_Done);
            panel.NewTab_MouseUp_Done += new EventHandler(On_NewTab_MouseUp_Done);
            panel.RmNewTab_Click_Done += new EventHandler(On_RmNewTab_Click_Done);
        }

        void On_RmNewTab_Click_Done(object sender, EventArgs e)
        {
            if (tabChrome.TabPages.Count - 1 > 0)
            {
                
                int removeFromStaticList = panel.removeFromStaticList;
                int removeFromNonStaticList = panel.removeFromNonStaticList;
              
                Controls.Remove(panel.removeButtons[removeFromNonStaticList]);
                Controls.Remove(panel.tabs[removeFromNonStaticList]);
                panel.tabs.RemoveAt(removeFromNonStaticList);
                panel.rmPages.RemoveAt(removeFromStaticList);
                panel.pages.RemoveAt(removeFromStaticList);
                panel.removeButtons.RemoveAt(removeFromNonStaticList);
                tabChrome.TabPages[removeFromStaticList].Dispose();

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
            var page = new ChromiumWebBrowser("https://google.com");
            
            page.Dock = DockStyle.Fill;
            var tab = new TabPage();
            tab.Tag = "Google";
            page.Parent = tab;
            tabChrome.TabPages.Add(tab);
            page.Tag = tabChrome.TabCount - 1;
            tabChrome.SelectTab(tabChrome.TabCount - 1);
            page.TitleChanged += Page_TitleChanged;
            page.AddressChanged += Page_AddressChanged;
            txtNavigate.Text = "www.google.com";
            Controls.Add(panel.addNewRmTab());
            Controls.Add(panel.addNewTab("Google"));
        }

        private void Page_AddressChanged(object sender, AddressChangedEventArgs e)
        {
            this.Invoke(new MethodInvoker(() =>
            {
                ShowValidUrl();
            }));
        }
        string title = "";
        int space = 0;
        private void Page_TitleChanged(object sender, TitleChangedEventArgs e)
        {
            ChromiumWebBrowser web = sender as ChromiumWebBrowser;
            int index = tabChrome.TabPages.IndexOf((TabPage)web.Parent);

            this.Invoke(new MethodInvoker(() =>
            {
                panel.pages[index].Tag = e.Title;
                panel.pages[index].Text = fitTitle(e.Title);
            }));
        }

        private string fitTitle (string e)
        {
            title = e;
            space = (int)(panel.tabWidth * 0.135 -4);
            if (title.Length > space)
            {
                title = title.Remove(space);
                title = title.Insert(space, "...");
            }
            return title;
            
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
 
        private void txtNavigate_Click(object sender, EventArgs e)
        {
            txtNavigate.SelectionStart = 0;
            txtNavigate.SelectionLength = txtNavigate.Text.Length;
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            panel.formWidth = this.Size.Width;
            panel.fillTabs();
            
            for (int i = 0; i < panel.tabs.Count; i++)
            {
                panel.tabs[i].Text = fitTitle(panel.tabs[i].Tag.ToString());
            }


            //location = btnNavigate.Location.X+4;
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
            //webTab.Parent = homeTab;
          // webTab.Dock = DockStyle.Fill;
           // webTab.Url = null;
            Controls.Add(panel.addNewRmTab());
            Controls.Add(panel.addNewTab("home"));
            HomeLayout(homeTab);
           // webTab.Visible = false;
            //ShowValidUrl();
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

