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
    class TabPanel 
    {
        public int position = 0;
        int index = 0;
        public int tabWidth = 200;
        public  int indexOfSelectedButton = 1;
        public int indexOfSelectedPage = 0;
        bool isMouseUp;
        bool isHomeTabOpened = false;
        int newLocation_X;
        public string tag = "";
        public List<Button> tabs = new List<Button>();
        public List<Button> pages = new List<Button>();
        public Button btnAddNewTab = new Button();
        public Button pointer = new Button();

        public event EventHandler NewTab_Click_Done = delegate { };

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


        public Button addNewTab(string _tag)
        {

            Button newTab = new Button();
            newTab.Tag = _tag;
            newTab.Text = (!isHomeTabOpened) ? "New Tab" : "Home Tab";
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
            
            return newTab;
        }

        public void NewTab_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            indexOfSelectedButton = tabs.IndexOf(button);
            indexOfSelectedPage = pages.IndexOf(button);
            ChangeButtonStyleToBackground(indexOfSelectedButton);
            this.NewTab_Click_Done(this, new EventArgs());

        }

        public void Reposition()
        {
            for (int i = 0; i < tabs.Count; i++)
                tabs[i].Location = new Point(i * tabWidth, tabs[i].Location.Y);
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

        public void ChangeButtonStyleToBackground(int index)
        {
            for (int i = 0; i < tabs.Count; i++)
            {
                if (i != index)
                {
                    tabs[i].BackgroundImage = AirBrowser.Properties.Resources.unselectedTab;
                    tabs[i].ForeColor = Color.DimGray;
                }
                else
                {
                    tabs[i].BackgroundImage = AirBrowser.Properties.Resources.selectedTab;
                    tabs[i].ForeColor = Color.Black;
                }
            }
        }

        private void NewTab_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseUp = true;
        }

        private void NewTab_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseUp)
            {

                Button button = sender as Button;
                newLocation_X = (tabWidth * (tabs.IndexOf(button) + 1));
                button.BringToFront();
                button.Location = new Point(button.Location.X + e.Location.X - (tabWidth / 2), button.Location.Y);

                for (int i = 0; i < tabs.Count; i++)
                    if (button.Location.X < tabs[i].Location.X + (tabWidth / 2))
                    {
                        swap(tabs, tabs.IndexOf(button), i);
                        break;
                    }

                for (int i = tabs.Count - 1; i > 0; --i)
                    if ((button.Location.X > tabs[i].Location.X) && tabs.IndexOf(button) < i)
                    {
                        swap(tabs, i, tabs.IndexOf(button));
                        break;
                    }
            }
        }

        private void NewTab_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseUp = false;
            Button button = sender as Button;
            newLocation_X = tabWidth * tabs.IndexOf(button);
            button.Location = new Point(newLocation_X, button.Location.Y);
        }

        private void NewTab_MouseLeave(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (indexOfSelectedButton != tabs.IndexOf(button))
                button.BackgroundImage = AirBrowser.Properties.Resources.unselectedTab;
        }

        private void NewTab_MouseEnter(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (indexOfSelectedButton != tabs.IndexOf(button))
                button.BackgroundImage = AirBrowser.Properties.Resources.unselectedTabHighlight;
        }

       
    }
}
