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
        int tabButtonsCounter = 0;
        int lastSelectedTabButton;

        public Form1()
        {
            InitializeComponent();
        }
    
        void getFavicon ()
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnNewTab_Click(sender, e);                 // Create new (first) tab
            txtHttps.Text = "https://";
            // Hide original tabs buttons
            tabControl.Appearance = TabAppearance.FlatButtons;
            tabControl.ItemSize = new Size(0, 1);
            tabControl.SizeMode = TabSizeMode.Fixed;
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
                txtNavigate.Text = txtNavigate.Text;
            }
        }

        WebBrowser webTab = null;
      
        private void btnNewTab_Click(object sender, EventArgs e)
        {

            foreach (Button ctl in flpTabPanel.Controls)
            {
                if (ctl.TabIndex == lastSelectedTabButton)
                {
                    ctl.BackColor = Color.Gainsboro;
                    ctl.FlatAppearance.BorderColor = Color.Gainsboro;
                }

            }
            TabPage tab = new TabPage();
            tab.Text = "New Tab";
            tabControl.Controls.Add(tab);
            tabControl.SelectTab(tabControl.TabCount-1);
            webTab = new WebBrowser() { ScriptErrorsSuppressed = true };
            webTab.Parent = tab;
            webTab.Dock = DockStyle.Fill;
            webTab.Navigate("https://google.com");
            txtNavigate.Text = "www.google.com";

            //
            // Tab button style
            //
            Button button = new Button();
            button.Name = "tabButton" + tabButtonsCounter++;
            button.Text = "New Tab";
            button.Size = new Size(100, 25);
            button.Margin = new System.Windows.Forms.Padding(0);
            button.Click += Button_Click;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderColor = Color.Silver; 
            button.TextAlign = ContentAlignment.MiddleLeft;
            button.BackColor = Color.White;
            flpTabPanel.Controls.Add(button);
            lastSelectedTabButton = button.TabIndex;
            
            webTab.DocumentCompleted += WebTab_DocumentCompleted;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            foreach (Button ctl in flpTabPanel.Controls)
            {
                if (ctl.TabIndex == lastSelectedTabButton)
                {
                    ctl.BackColor = Color.Gainsboro;
                    ctl.FlatAppearance.BorderColor = Color.Gainsboro;
                }
            }
            
            Button button = sender as Button;
            tabControl.SelectedIndex = button.TabIndex+1;
            button.BackColor = Color.White;
            button.FlatAppearance.BorderColor = Color.Silver;
            lastSelectedTabButton = button.TabIndex;
            string fullUrL = Convert.ToString(((WebBrowser)tabControl.SelectedTab.Controls[0]).Url);
            string shortenUrl = fullUrL.Remove(0, 7);
            txtNavigate.Text = shortenUrl;
            webTab.DocumentTitleChanged += WebTab_DocumentTitleChanged;
        }

        private void WebTab_DocumentTitleChanged(object sender, EventArgs e)
        {
            
            foreach (Control ctl in flpTabPanel.Controls)
            {
              if (tabControl.SelectedIndex.Equals(ctl.TabIndex+1))
               {
                    ctl.Text = webTab.DocumentTitle;
               }
            }
        }

        private void WebTab_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            tabControl.SelectedTab.Text = ((WebBrowser)tabControl.SelectedTab.Controls[0]).DocumentTitle;
            foreach (Control ctl in flpTabPanel.Controls)
            {
                if (tabControl.SelectedIndex.Equals(ctl.TabIndex+1))
                    ctl.Text = ((WebBrowser)tabControl.SelectedTab.Controls[0]).DocumentTitle;
            }
            
            string fullURL = Convert.ToString(((WebBrowser)tabControl.SelectedTab.Controls[0]).Url);
            string shortenURL = fullURL.Remove(0, 7);
            txtNavigate.Text = shortenURL;
            tabControl.Focus();
        }

        private void txtNavigate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                WebBrowser web = tabControl.SelectedTab.Controls[0] as WebBrowser;
                if (web != null)
                {
                    web.Navigate(txtNavigate.Text);
                    txtNavigate.Text = txtNavigate.Text;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tabControl.TabPages.Count -2 > 0)
            {
                int removedIndex = tabControl.SelectedIndex - 1;
                flpTabPanel.Controls.RemoveAt(removedIndex);
                foreach (Control ctl in flpTabPanel.Controls)
                {
                    if (ctl.TabIndex > removedIndex)
                        ctl.TabIndex--;
                }
                tabControl.TabPages.RemoveAt(tabControl.SelectedIndex);
                
                tabControl.SelectTab(tabControl.TabPages.Count-1);
                foreach (Button ctl in flpTabPanel.Controls)
                {
                    if (ctl.TabIndex == flpTabPanel.Controls.Count-1)
                    {
                        ctl.BackColor = Color.White;
                        ctl.FlatAppearance.BorderColor = Color.Silver;
                        lastSelectedTabButton = ctl.TabIndex;
                    }
                } 
            }
        }

        private void txtNavigate_MouseEnter(object sender, EventArgs e)
        {
            tmBack.Enabled = false;
            tm.Enabled = true;
        }

        private void txtNavigate_MouseLeave(object sender, EventArgs e)
        {
            if (txtNavigate.Focused == false)
            {
                tm.Enabled = false;
                tmBack.Enabled = true;
            }
        }

        //
        // Animation
        //

        private void tm_Tick(object sender, EventArgs e)
        {
            int speed = 10;
            if (btnNavigate.Location.X > location+200) tm.Enabled = false;
            else
            {
                btnNavigate.Location = new Point(btnNavigate.Location.X+speed, btnNavigate.Location.Y);
                btnNewTab.Location = new Point(btnNewTab.Location.X+speed, btnNewTab.Location.Y);
                button1.Location = new Point(button1.Location.X+speed, button1.Location.Y);
                pictureBox1.Width += speed;
                txtNavigate.Width += speed;
            }
            
        }

        int location = 262;
        private void tmBack_Tick(object sender, EventArgs e)
        {
            int speed = 10;
            
            if (btnNavigate.Location.X < location) tmBack.Enabled = false;
            else
            {
                btnNavigate.Location = new Point(btnNavigate.Location.X-speed, btnNavigate.Location.Y);
                btnNewTab.Location = new Point(btnNewTab.Location.X-speed, btnNewTab.Location.Y);
                button1.Location = new Point(button1.Location.X-speed, button1.Location.Y);
                pictureBox1.Width -= speed;
                txtNavigate.Width -= speed;
            }

        }

        private void txtNavigate_Leave(object sender, EventArgs e)
        {
            tmBack.Enabled = true;
        }

        private void txtNavigate_Click(object sender, EventArgs e)
        {
            txtNavigate.SelectionStart = 0;
            txtNavigate.SelectionLength = txtNavigate.Text.Length;
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            location = btnNavigate.Location.X;
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

    }
}

