using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AirBrowser
{
    partial class TabPanel 
    {
        private int position = 0;
        private int index = 0;
        public int tabWidth = 200;
        private int rmPosition = 0;
        public  int indexOfSelectedButton = 0;
        public int indexOfSelectedPage = 0;
        private bool isMouseUp;
        private int newLocation_X;
        public List<Button> tabs = new List<Button>();
        public List<Button> removeButtons = new List<Button>();
        public List<Button> pages = new List<Button>();
        public List<Button> rmPages = new List<Button>();
        public Button btnAddNewTab = new Button();
        public event EventHandler NewTab_Click_Done = delegate { };
        public event EventHandler NewTab_MouseUp_Done = delegate { };
        public event EventHandler RmNewTab_Click_Done = delegate { };
        public int maxTabs = 5;
        public int formWidth = 1000;
        

       public TabPanel ()
        {
            btnAddNewTab.Size = new Size(30, 31);
            btnAddNewTab.BackgroundImage = AirBrowser.Properties.Resources.addButton;
            btnAddNewTab.FlatStyle = FlatStyle.Flat;
            btnAddNewTab.FlatAppearance.BorderSize = 0;
            btnAddNewTab.BringToFront();
            btnAddNewTab.Location = new Point(0, -1);
            btnAddNewTab.MouseEnter += BtnAddNewTab_MouseEnter;
            btnAddNewTab.MouseLeave += BtnAddNewTab_MouseLeave;
            rmPosition = tabWidth - 19;
        }

        private void SelectTab (object sender)
        {
            Button button = sender as Button;
            indexOfSelectedButton = tabs.IndexOf(button);
            indexOfSelectedPage = pages.IndexOf(button);
            ChangeButtonStyleToBackground(indexOfSelectedButton);
        }

        private void BtnAddNewTab_MouseLeave(object sender, EventArgs e)
        {
            btnAddNewTab.BackgroundImage = Properties.Resources.addButton;
        }

        private void BtnAddNewTab_MouseEnter(object sender, EventArgs e)
        {
            btnAddNewTab.BackgroundImage = Properties.Resources.addButtonHighlight;
        }

        public Button add_btnAddNewTab ()
        {
            return btnAddNewTab;
        }

        public Button addNewRmTab ()
        {
            Button rmNewTab = new Button();
            rmNewTab.Size = new Size(15, 15);
            rmNewTab.BackgroundImage = Properties.Resources.PanelBtnRemove;
            rmNewTab.TextAlign = ContentAlignment.MiddleLeft;
            rmNewTab.FlatStyle = FlatStyle.Flat;
            rmNewTab.FlatAppearance.BorderSize = 0;
            rmNewTab.BackColor = Color.OrangeRed;
            rmNewTab.Location = new Point(rmPosition, 8);
            removeButtons.Add(rmNewTab);
            rmNewTab.MouseEnter += RmNewTab_MouseEnter;
            rmNewTab.MouseLeave += RmNewTab_MouseLeave;
            rmPages.Add(rmNewTab);
            rmPosition += tabWidth;
            rmNewTab.Click += RmNewTab_Click;
            return rmNewTab;
        }

        private void RmNewTab_MouseLeave(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (removeButtons.IndexOf(button) != indexOfSelectedButton)
                button.BackgroundImage = AirBrowser.Properties.Resources.btnRemovepanelBackground;
            else button.BackgroundImage = AirBrowser.Properties.Resources.PanelBtnRemove;
        }

        private void RmNewTab_MouseEnter(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (removeButtons.IndexOf(button) != indexOfSelectedButton)
                button.BackgroundImage = AirBrowser.Properties.Resources.btnRemovepanelHighlightBackground;
            else button.BackgroundImage = AirBrowser.Properties.Resources.btnRemovepanelHighlight;

        }

        public int removeFromStaticList = 0;
        public int removeFromNonStaticList = 0;
        public void RmNewTab_Click(object sender, EventArgs e)
        {
            if (tabs.Count - 1 > 0)
            {
                Button button = sender as Button;
                fillTabs();
                removeFromStaticList = rmPages.IndexOf(button);
                removeFromNonStaticList = removeButtons.IndexOf(button);
                this.RmNewTab_Click_Done(this, new EventArgs());
            }
        }
        
        public Button addNewTab(string _tag)
        {
            Button newTab = new Button();
            newTab.Tag = _tag;
            newTab.Text = (_tag == "Google") ? "New Tab" : "Home Tab";
            newTab.BackgroundImage = AirBrowser.Properties.Resources.selectedTab;
            newTab.Size = new Size(tabWidth, 31);
            newTab.TextAlign = ContentAlignment.MiddleLeft;
            newTab.FlatStyle = FlatStyle.Flat;
            newTab.FlatAppearance.BorderSize = 0;
            newTab.Location = new Point(position, -1);
            newTab.Click += NewTab_Click;
            newTab.MouseEnter += NewTab_MouseEnter;
            newTab.MouseLeave += NewTab_MouseLeave;
            newTab.MouseUp += NewTab_MouseUp;
            newTab.MouseMove += NewTab_MouseMove;
            newTab.MouseDown += NewTab_MouseDown;
            tabs.Add(newTab);
            pages.Add(newTab);
            newTab.BringToFront();
            indexOfSelectedButton = tabs.Count - 1;
            position = position + tabWidth;
            index++;
            ChangeButtonStyleToBackground(tabs.IndexOf(newTab));
            btnAddNewTab.Location = new Point(position, 0);

            fillTabs();

                return newTab;
        }

        public void fillTabs ()
        {
            if (tabs.Count * 200 + 30 >= formWidth) tabWidth = formWidth/ (tabs.Count+1);
            else tabWidth = 200;
            Reposition();
        }
        

        public void NewTab_Click(object sender, EventArgs e)
        {
            SelectTab(sender);
            this.NewTab_Click_Done(this, new EventArgs());
        }
        
        public void Reposition()
        {
            for (int i = 0; i < tabs.Count; i++)
            {
                tabs[i].Location = new Point(i * tabWidth, tabs[i].Location.Y);
                tabs[i].Size = new Size(tabWidth, tabs[i].Size.Height);
                
                removeButtons[i].Location = new Point((tabWidth-19)+ i* tabWidth, removeButtons[i].Location.Y);
                removeButtons[i].BringToFront();
            }
            btnAddNewTab.Location = new Point(tabs.Count * tabWidth, btnAddNewTab.Location.Y);
            position = tabs[tabs.Count-1].Location.X+tabWidth;
            rmPosition = removeButtons[tabs.Count-1].Location.X + tabWidth;
        }
        
        private void swap(List<Button> list, List<Button> list2 , int indexA, int indexB)
        {
            Button tmp = list[indexB];
            list[indexB] = list[indexA];
            list[indexA] = tmp;

            Button tmp2 = list2[indexB];
            list2[indexB] = list2[indexA];
            list2[indexA] = tmp2;

            if (indexA > indexB)
            {
                 list[indexA].Location = new Point(list[indexA].Location.X + tabWidth, list[indexA].Location.Y);
                 removeButtons[indexA].Location = new Point(list[indexA].Location.X + (tabWidth-19), list[indexA].Location.Y + 8);
            }
            else
            {
                 list[indexA].Location = new Point(list[indexA].Location.X - tabWidth, list[indexA].Location.Y);
                 removeButtons[indexA].Location = new Point(list[indexA].Location.X + (tabWidth-19), list[indexA].Location.Y + 8);
            }
         }

        public void ChangeButtonStyleToBackground(int index)
        {
            for (int i = 0; i < tabs.Count; i++)
            {
                if (i != index)
                {
                    tabs[i].BackgroundImage = AirBrowser.Properties.Resources.unselectedTab;
                    removeButtons[i].BackgroundImage = AirBrowser.Properties.Resources.btnRemovepanelBackground;
                    tabs[i].ForeColor = Color.DimGray;
                }
                else
                {
                    tabs[i].BackgroundImage = AirBrowser.Properties.Resources.selectedTab;
                    removeButtons[i].BackgroundImage = AirBrowser.Properties.Resources.PanelBtnRemove;
                    tabs[i].ForeColor = Color.Black;
                }
            }
        }

        int mousePosition = 0;
        private void NewTab_MouseDown(object sender, MouseEventArgs e)
        {
            mousePosition = e.Location.X;
            Button button = sender as Button;
            SelectTab(sender);
            btnAddNewTab.Visible = false;
            button.BringToFront();
            removeButtons[tabs.IndexOf(button)].BringToFront();
            isMouseUp = true;
        }

        private void NewTab_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseUp)
            {     
                Button button = sender as Button;
                button.Location = new Point(button.Location.X + e.Location.X - mousePosition, button.Location.Y);
                removeButtons[tabs.IndexOf(button)].Location = new Point(button.Location.X + (tabWidth - 19), button.Location.Y + 8);

                if (tabs.IndexOf(button) != 0)
                  {
                      if (button.Location.X < ((Button)tabs[tabs.IndexOf(button) - 1]).Location.X + (tabWidth / 2))
                      {
                          swap(tabs, removeButtons, tabs.IndexOf(button), tabs.IndexOf(button) - 1);
                      }
                  }

                if (tabs.IndexOf(button) != tabs.Count - 1)
                {
                    if ((button.Location.X > ((Button)tabs[tabs.IndexOf(button) + 1]).Location.X))
                    {
                          swap(tabs, removeButtons, tabs.IndexOf(button), tabs.IndexOf(button) + 1);
                    }
                }
            }
        }

        private void NewTab_MouseUp(object sender, MouseEventArgs e)
        {
            mousePosition = 0;
            btnAddNewTab.Visible = true;
            isMouseUp = false;
            Button button = sender as Button;
            SelectTab(sender);
            newLocation_X = tabWidth * tabs.IndexOf(button);
            button.Location = new Point(newLocation_X, button.Location.Y);
            removeButtons[tabs.IndexOf(button)].Location = new Point(button.Location.X + (tabWidth - 19), button.Location.Y + 8);
            for (int i = 0; i < removeButtons.Count; i++) removeButtons[i].BringToFront();
            this.NewTab_MouseUp_Done(this, new EventArgs());
        }

        private void NewTab_MouseLeave(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (indexOfSelectedButton != tabs.IndexOf(button))
            {
                button.BackgroundImage = AirBrowser.Properties.Resources.unselectedTab;
            }
        }

        private void NewTab_MouseEnter(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (indexOfSelectedButton != tabs.IndexOf(button))
            {
                button.BackgroundImage = AirBrowser.Properties.Resources.unselectedTabHighlight;
            }
        }
    }
}
