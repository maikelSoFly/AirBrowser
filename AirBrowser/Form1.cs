using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        

        private void Form1_Load(object sender, EventArgs e) {
            tabControl.Controls.RemoveAt(0);
            location = btnNavigate.Location.X + 4;
            Controls.Add(panel.add_btnAddNewTab());
            BtnAddNewTab_Click(sender, e);              
            txtHttps.Text = "https://";
            // Hide original tabs buttons
            tabControl.Appearance = TabAppearance.FlatButtons;
            tabControl.ItemSize = new Size(0, 1);
            tabControl.SizeMode = TabSizeMode.Fixed;
            //
            panel.btnAddNewTab.Click += BtnAddNewTab_Click;
            btnBack.MouseEnter += BtnBack_MouseEnter;
            btnBack.MouseLeave += BtnBack_MouseLeave;
            tabControl.SendToBack();
            panel.NewTab_Click_Done += new EventHandler(On_NewTab_Click_Done);
            panel.NewTab_MouseUp_Done += new EventHandler(On_NewTab_MouseUp_Done);
            panel.RmNewTab_Click_Done += new EventHandler(On_RmNewTab_Click_Done);
            webBrowser.WebBrowserShortcutsEnabled = true;
        }

        void On_RmNewTab_Click_Done(object sender, EventArgs e)
        {
            if (tabControl.TabPages.Count - 1 > 0)
            {
                int removeFromStaticList = panel.removeFromStaticList;
                int removeFromNonStaticList = panel.removeFromNonStaticList;
                Controls.Remove(panel.removeButtons[removeFromNonStaticList]);
                Controls.Remove(panel.tabs[removeFromNonStaticList]);
                tabControl.TabPages.RemoveAt(removeFromStaticList);
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
            tabControl.SelectedIndex = panel.indexOfSelectedPage;
            Form1_SizeChanged(sender, e);
             ShowValidUrl();
        }

        void On_NewTab_Click_Done(object sender, EventArgs e) 
        {
            Button button = sender as Button;
            tabControl.SelectedIndex = panel.indexOfSelectedPage;
            Form1_SizeChanged(sender, e);
            ShowValidUrl();
        }

        private void BtnAddNewTab_Click(object sender, EventArgs e)
        {
            TabPage tab = new TabPage();
            tabControl.Controls.Add(tab);
            tabControl.SelectTab(tabControl.TabCount -1);
            webTab = new WebBrowser() { ScriptErrorsSuppressed = true };
            webTab.Parent = tab;
            webTab.Dock = DockStyle.Fill;
            webTab.Navigate("https://google.com");
            txtNavigate.Text = "www.google.com";
            Controls.Add(panel.addNewRmTab());
            Controls.Add(panel.addNewTab("normal"));
            webTab.DocumentCompleted += WebTab_DocumentCompleted;
            webTab.DocumentTitleChanged += WebTab_DocumentTitleChanged;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            WebBrowser web = tabControl.SelectedTab.Controls[0] as WebBrowser;
            if (web != null)
            {
                if(web.CanGoBack)
                    web.GoBack();
            }
        }
        
        private void btnForward_Click(object sender, EventArgs e)
        {
            WebBrowser web = tabControl.SelectedTab.Controls[0] as WebBrowser;
            if (web != null)
            {
                if (web.CanGoForward)
                    web.GoForward();
            }
        }

        private void btnNavigate_Click(object sender, EventArgs e)
        {
            WebBrowser web = tabControl.SelectedTab.Controls[0] as WebBrowser;
            if (web != null)
            {
                web.Navigate(txtNavigate.Text);
            }
        }
       
        private void WebTab_DocumentTitleChanged(object sender, EventArgs e)
        {
            panel.tabs[panel.indexOfSelectedButton].Text = ((WebBrowser)tabControl.SelectedTab.Controls[0]).Document.Title;
        }
   
        private void WebTab_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            panel.tabs[panel.indexOfSelectedButton].Text = ((WebBrowser)tabControl.SelectedTab.Controls[0]).Document.Title;
            ShowValidUrl();
            tabControl.Focus();
        }

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
            ((WebBrowser)tabControl.SelectedTab.Controls[0]).Navigate("http://9gag.com");
        }

        private void btnTwitch_Click(object sender, EventArgs e)
        {
            ((WebBrowser)tabControl.SelectedTab.Controls[0]).Navigate("http://twitch.tv");
        }

        private void btnFb_Click(object sender, EventArgs e)
        {
            ((WebBrowser)tabControl.SelectedTab.Controls[0]).Navigate("https://facebook.com");
        }

        private void btnYahoo_Click(object sender, EventArgs e)
        {
            ((WebBrowser)tabControl.SelectedTab.Controls[0]).Navigate("https://yahoo.com");
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            TabPage homeTab = new TabPage();
            tabControl.Controls.Add(homeTab);
            tabControl.SelectTab(tabControl.TabCount - 1);
            webTab = new WebBrowser() { ScriptErrorsSuppressed = true };
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
                WebBrowser web = tabControl.SelectedTab.Controls[0] as WebBrowser;
                web.Visible = true;
                if (web != null)
                {
                    web.Navigate(txtNavigate.Text);
                }
                txtNavigate.Items.Add(txtNavigate.Text);
                txtNavigate.AutoCompleteCustomSource.Add(txtNavigate.Text);
            }
        } 
    }
}

