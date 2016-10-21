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

        class ColoredCombo : ComboBox
        {
            private const int WM_PAINT = 0xF;
            private int buttonWidth = SystemInformation.HorizontalScrollBarArrowWidth;
            protected override void WndProc(ref Message m)
            {
                base.WndProc(ref m);
                if (m.Msg == WM_PAINT)
                {
                    using (var g = Graphics.FromHwnd(Handle))
                    {
                        using (var p = new Pen(Color.White))
                        {
                            //g.DrawRectangle(p, 0, 0, Width+9, Height-1);
                            g.DrawLine(p,0, 0, 0, Height);
                        }
                    }
                }
            }
        }

        // Variables
        static int pos = 0;
        int index = 0;
        int tabWidth = 200;
        List<Button> buttons = new List<Button>();
        List<Button> pages = new List<Button>();
        int indexOfSelectedButton = 0;
        bool isMouseUp = false;
        int newLocationX;
        WebBrowser webTab = null;
        int location;
        bool isHomeTabOpened = false;


        private void Form1_Load(object sender, EventArgs e) {
            location = btnNavigate.Location.X + 4;
            btnFlowAddNewTab_Click(sender, e);                 // Create new (first) tab
            tabControl.Controls.RemoveAt(0);                   // Removes first tab, because of some bugs
            txtHttps.Text = "https://";
            // Hide original tabs buttons
            tabControl.Appearance = TabAppearance.FlatButtons;
            tabControl.ItemSize = new Size(0, 1);
            tabControl.SizeMode = TabSizeMode.Fixed;
            //
            btnFlowAddNewTab.MouseEnter += BtnFlowAddNewTab_MouseEnter;
            btnFlowAddNewTab.MouseLeave += BtnFlowAddNewTab_MouseLeave;
            btnBack.MouseEnter += BtnBack_MouseEnter;
            btnBack.MouseLeave += BtnBack_MouseLeave;
            btnNavigate.MouseEnter += BtnNavigate_MouseEnter;
            btnNavigate.MouseLeave += BtnNavigate_MouseLeave;
            
            

        }

        

        private void BtnNavigate_MouseLeave(object sender, EventArgs e)
        {
            Button button = sender as Button;
            button.BackgroundImage = AirBrowser.Properties.Resources.blueButton;
        }

        private void BtnNavigate_MouseEnter(object sender, EventArgs e)
        {
            Button button = sender as Button;
            button.BackgroundImage = AirBrowser.Properties.Resources.blueButtonHighlight;
        }

        private void BtnBack_MouseLeave(object sender, EventArgs e)
        {
            Button button = sender as Button;
            button.BackgroundImage = AirBrowser.Properties.Resources.blueButton;
        }

        private void BtnBack_MouseEnter(object sender, EventArgs e)
        {
            Button button = sender as Button;
            button.BackgroundImage = AirBrowser.Properties.Resources.blueButtonHighlight;
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

        private void btnFlowAddNewTab_Click(object sender, EventArgs e) {
            
            TabPage tab = new TabPage();
            tabControl.Controls.Add(tab);
            tabControl.SelectTab(tabControl.TabCount - 1);
            webTab = new WebBrowser() { ScriptErrorsSuppressed = true };
            webTab.Parent = tab;
            webTab.Dock = DockStyle.Fill;
            webTab.Navigate("https://google.com");
            txtNavigate.Text = "www.google.com";

            addNewTabToBar();

        }

        private void addNewTabToBar ()
        {
            Button newButton = new Button();
            newButton.Name = index.ToString();
            newButton.Text = (!isHomeTabOpened) ? "New Tab" : "Home Tab";
            newButton.BackgroundImage = AirBrowser.Properties.Resources.selectedTab;
            newButton.Size = new Size(tabWidth, 31);
            newButton.TextAlign = ContentAlignment.MiddleLeft;
            newButton.FlatStyle = FlatStyle.Flat;
            newButton.FlatAppearance.BorderSize = 0;
            newButton.Location = new Point(pos, -1);
            newButton.Click += NewButton_Click;
            newButton.MouseEnter += NewButton_MouseEnter;
            newButton.MouseLeave += NewButton_MouseLeave;
            newButton.MouseUp += NewButton_MouseUp;
            newButton.MouseMove += NewButton_MouseMove;
            newButton.MouseDown += NewButton_MouseDown;
            buttons.Add(newButton);
            pages.Add(newButton);
            Controls.Add(newButton);
            newButton.BringToFront();
            indexOfSelectedButton = buttons.Count - 1;
            pos = pos + tabWidth;
            index++;
            ChangeButtonStyleToBackground(buttons.IndexOf(newButton));
            btnFlowAddNewTab.Location = new Point(pos, btnFlowAddNewTab.Location.Y);
            
            
                webTab.DocumentCompleted += WebTab_DocumentCompleted;
                webTab.DocumentTitleChanged += WebTab_DocumentTitleChanged;
            
            
        }

        private void NewButton_MouseLeave(object sender, EventArgs e) {

            Button button = sender as Button;
            if (indexOfSelectedButton != buttons.IndexOf(button))
                button.BackgroundImage = AirBrowser.Properties.Resources.unselectedTab;
        }

        private void NewButton_MouseEnter(object sender, EventArgs e) {
           
            Button button = sender as Button;
            if (indexOfSelectedButton != buttons.IndexOf(button)) 
                button.BackgroundImage = AirBrowser.Properties.Resources.unselectedTabHighlight;
        }

        private void WebTab_DocumentTitleChanged(object sender, EventArgs e)
        {
            buttons[indexOfSelectedButton].Text = ((WebBrowser)tabControl.SelectedTab.Controls[0]).Document.Title;
        }

        private void NewButton_MouseDown(object sender, MouseEventArgs e) {
            isMouseUp = true;
        }

        private void swap(List<Button> list, int indexA, int indexB) {

            Button tmp = list[indexB];
            list[indexB] = list[indexA];
            list[indexA] = tmp;

            for (int i = 0; i < list.Count; i++) {
                if (i != indexA)
                    list[i].Location = new Point(i * tabWidth, list[i].Location.Y);
            }
        }

        private void NewButton_MouseMove(object sender, MouseEventArgs e) {
            if (isMouseUp) {

                Button button = sender as Button;
                newLocationX = (tabWidth * (buttons.IndexOf(button) + 1));
                button.BringToFront();
                button.Location = new Point(button.Location.X + e.Location.X - (tabWidth/2), button.Location.Y);

                for (int i = 0; i < buttons.Count; i++) 
                    if (button.Location.X < buttons[i].Location.X + (tabWidth / 2)) {
                        swap(buttons, buttons.IndexOf(button), i);
                        break;
                    }

                for (int i = buttons.Count - 1; i > 0; --i)
                    if ((button.Location.X > buttons[i].Location.X) && buttons.IndexOf(button) < i) {
                        swap(buttons, i, buttons.IndexOf(button));
                        break;
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
            tabControl.SelectedIndex = pages.IndexOf(button);
            indexOfSelectedButton = buttons.IndexOf(button);

            if (tabControl.SelectedTab.Controls[0] == webBrowser) ShowValidUrl();
            ChangeButtonStyleToBackground(buttons.IndexOf(button));
         
        }


        private void ChangeButtonStyleToBackground(int index)
        {
            for (int i = 0; i < buttons.Count; i++)
            {
                if (i != index)
                {
                    buttons[i].BackgroundImage = AirBrowser.Properties.Resources.unselectedTab;
                    buttons[i].ForeColor = Color.DimGray;
                }
                else
                {
                    buttons[i].BackgroundImage = AirBrowser.Properties.Resources.selectedTab;
                    buttons[i].ForeColor = Color.Black;
                }
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
            buttons[indexOfSelectedButton].Text = ((WebBrowser)tabControl.SelectedTab.Controls[0]).Document.Title;

            ShowValidUrl();
            tabControl.Focus();
            
        }

       
        private void Reposition ()
        {
            for (int i = 0; i < buttons.Count; i++)
                buttons[i].Location = new Point(i * tabWidth, buttons[i].Location.Y);
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            if (tabControl.TabPages.Count-1 > 0)
            {
                pos = pos - tabWidth;
                int removeIndex = tabControl.SelectedIndex;
               
                Controls.Remove(pages[removeIndex]);
                buttons.Remove(pages[removeIndex]);
                pages.RemoveAt(removeIndex);
                Reposition();
                btnFlowAddNewTab.Location = new Point(btnFlowAddNewTab.Location.X - tabWidth, btnFlowAddNewTab.Location.Y);
                tabControl.TabPages.RemoveAt(removeIndex);
                tabControl.SelectTab(tabControl.TabPages.Count-1);
                ChangeButtonStyleToBackground(buttons.Count - 1);

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

        // Animation

        private void tm_Tick(object sender, EventArgs e)
        {
            int speed = 10;
            if (btnNavigate.Location.X > location+200) tm.Enabled = false;
            else
            {
                btnNavigate.Location = new Point(btnNavigate.Location.X+speed, btnNavigate.Location.Y);
                
                button1.Location = new Point(button1.Location.X+speed, button1.Location.Y);
                pictureBox1.Width += speed;
                txtNavigate.Width += speed;
            }
            
        }
        
        private void tmBack_Tick(object sender, EventArgs e)
        {
            int speed = 10;
            
            if (btnNavigate.Location.X < location) tmBack.Enabled = false;
            else
            {
                btnNavigate.Location = new Point(btnNavigate.Location.X-speed, btnNavigate.Location.Y);
                
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

        private void BtnFlowAddNewTab_MouseLeave(object sender, EventArgs e)
        {
            Button button = sender as Button;
            button.BackgroundImage = AirBrowser.Properties.Resources.addButton;
        }

        private void BtnFlowAddNewTab_MouseEnter(object sender, EventArgs e)
        {
            Button button = sender as Button;
            button.BackgroundImage = AirBrowser.Properties.Resources.addButtonHighlight;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            isHomeTabOpened = true;
            TabPage homeTab = new TabPage();
            tabControl.Controls.Add(homeTab);
            tabControl.SelectTab(tabControl.TabCount - 1);
            addNewTabToBar();
            
            HomeLayout(homeTab);
            isHomeTabOpened = false;

        }

        int buttonSize = 150;
        
        //FlowLayoutPanel homePanel = new FlowLayoutPanel();
        private void HomeLayout (TabPage parentTab)
        {
            // Layout of the Home Tab

            
            homePanel.Parent = parentTab;
            homePanel.Size = new Size(3*buttonSize+18, 3 * buttonSize + 18);
            homePanel.Location = new Point(this.Size.Width/2-(3 * buttonSize + 18) /2, 80);
            homePanel.Anchor = AnchorStyles.Top;
            
            for (int i = 0; i < 9; ++i)
            {
                Button button = new Button();
                button.Size = new Size(buttonSize, buttonSize);
                button.Tag = i;
                homePanel.Controls.Add(button);
            }
            


        }

        private void txtNavigate_Leave_1(object sender, EventArgs e)
        {
            tmBack.Enabled = true;
        }

        private void txtNavigate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                WebBrowser web = tabControl.SelectedTab.Controls[0] as WebBrowser;
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

