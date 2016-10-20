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

        static int pos = 0;
        int index = 0;
        int tabWidth = 200;
        List<Button> buttons = new List<Button>();
        List<Button> pages = new List<Button>();
        int indexOfSelectedButton = 0;
        bool isMouseUp = false;
        int newLocationX;

        private void Form1_Load(object sender, EventArgs e)
        {
            btnNewTab_Click(sender, e);                 // Create new (first) tab
            tabControl.Controls.RemoveAt(0);
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
            }
        }

        WebBrowser webTab = null;
      
        private void btnNewTab_Click(object sender, EventArgs e)
        {
            
            

            TabPage tab = new TabPage();
            tabControl.Controls.Add(tab);
            tabControl.SelectTab(tabControl.TabCount-1);
            webTab = new WebBrowser() { ScriptErrorsSuppressed = true };
            webTab.Parent = tab;
            webTab.Dock = DockStyle.Fill;
            webTab.Navigate("https://google.com");
            txtNavigate.Text = "www.google.com";


            // My Panel
            Button newButton = new Button();
            newButton.Name = index.ToString();
           
            newButton.Text = index.ToString();
            newButton.Size = new Size(tabWidth, 29);
            newButton.TextAlign = ContentAlignment.MiddleLeft;
            newButton.FlatStyle = FlatStyle.Flat;
            newButton.FlatAppearance.BorderSize = 0;
            newButton.Location = new Point(pos, 0);
            newButton.Click += NewButton_Click;
            newButton.MouseUp += NewButton_MouseUp;
            newButton.MouseMove += NewButton_MouseMove;
            newButton.MouseDown += NewButton_MouseDown;
            buttons.Add(newButton);
            pages.Add(newButton);
            Controls.Add(newButton);
            
            indexOfSelectedButton = buttons.Count-1;
            pos = pos + tabWidth;
            index++;
            ChangeButtonStyleToBackground(buttons.IndexOf(newButton));

            webTab.DocumentCompleted += WebTab_DocumentCompleted;
            webTab.DocumentTitleChanged += WebTab_DocumentTitleChanged;
        }

        private void WebTab_DocumentTitleChanged(object sender, EventArgs e)
        {
           
            buttons[indexOfSelectedButton].Text = webTab.DocumentTitle;
            
        }

        private void NewButton_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseUp = true;
        }

        private void swap(List<Button> list, int indexA, int indexB)
        {
            Button tmp = list[indexB];
            list[indexB] = list[indexA];
            list[indexA] = tmp;
            for (int i = 0; i < list.Count; i++)
            {
                if (i != indexA)
                    list[i].Location = new Point(i * tabWidth, list[i].Location.Y);
            }
        }

        private void NewButton_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseUp)
            {
                Button button = sender as Button;
                newLocationX = tabWidth * (buttons.IndexOf(button) + 1);
                button.BringToFront();
                button.Location = new Point(button.Location.X + e.Location.X - (tabWidth/2), button.Location.Y);

                for (int i = 0; i < buttons.Count; i++)
                {
                    if (button.Location.X < buttons[i].Location.X + (tabWidth / 2))
                    {
                        swap(buttons, buttons.IndexOf(button), i);
                        break;
                    }

                }
                for (int i = buttons.Count - 1; i > 0; --i)
                {
                    if ((button.Location.X > buttons[i].Location.X) && buttons.IndexOf(button) < i)
                    {
                        swap(buttons, i, buttons.IndexOf(button));
                        break;
                    }
                }
            }
        }

        private void NewButton_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseUp = false;
            Button button = sender as Button;
            newLocationX = tabWidth * buttons.IndexOf(button);
            button.Location = new Point(newLocationX, button.Location.Y);
        }

        private void NewButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            indexOfSelectedButton = buttons.IndexOf(button);
            tabControl.SelectedIndex = pages.IndexOf(button);
            indexOfSelectedButton = buttons.IndexOf(button);
            ShowValidUrl();

            ChangeButtonStyleToBackground(buttons.IndexOf(button));
         
        }

        private void ChangeButtonStyleToBackground(int index)
        {
            for (int i = 0; i < buttons.Count; i++)
            {
                if (i != index)
                    buttons[i].BackColor = Color.Gainsboro;
                else buttons[i].BackColor = Color.White;
            }
        }


        private void ShowValidUrl()
        {
            string fullUrL = Convert.ToString(((WebBrowser)tabControl.SelectedTab.Controls[0]).Url);
            string shortenUrl = fullUrL.Remove(0, 7);
            txtNavigate.Text = shortenUrl;
        }


        private void WebTab_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            tabControl.SelectedTab.Text = ((WebBrowser)tabControl.SelectedTab.Controls[0]).DocumentTitle;
            
            buttons[indexOfSelectedButton].Text = webTab.DocumentTitle;
            
            ShowValidUrl();
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
                }
            }
        }

        private void Reposition ()
        {
            for (int i = 0; i < buttons.Count; i++)
                buttons[i].Location = new Point(i * tabWidth, buttons[i].Location.Y);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pos = pos - tabWidth;
            
            if (tabControl.TabPages.Count-1 > 0)
            {
                int removeIndex = tabControl.SelectedIndex;
               
                Controls.Remove(pages[removeIndex]);
                buttons.Remove(pages[removeIndex]);
                pages.RemoveAt(removeIndex);
                Reposition();

                tabControl.TabPages.RemoveAt(tabControl.SelectedIndex);
                tabControl.SelectTab(tabControl.TabPages.Count-1);
 
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

