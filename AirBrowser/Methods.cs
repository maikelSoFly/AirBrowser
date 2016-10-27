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
        private void addNewTabToBar()
        {
            indexOfSelectedButton = 1;
            Button newButton = new Button();
            newButton.Name = index.ToString();
            newButton.Tag = "home";
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
            indexOfSelectedButton = buttons.Count -1;
            pos = pos + tabWidth;
            index++;
            ChangeButtonStyleToBackground(buttons.IndexOf(newButton));
            btnFlowAddNewTab.Location = new Point(pos, btnFlowAddNewTab.Location.Y);


            webTab.DocumentCompleted += WebTab_DocumentCompleted;
            webTab.DocumentTitleChanged += WebTab_DocumentTitleChanged;


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

        private void ShowValidUrl()
        {
            string fullUrL = Convert.ToString(((WebBrowser)tabControl.SelectedTab.Controls[0]).Url);
            string shortenUrl = fullUrL.Remove(0, 7);
            txtNavigate.Text = shortenUrl;
        }

        private void Reposition()
        {
            for (int i = 0; i < buttons.Count; i++)
                buttons[i].Location = new Point(i * tabWidth, buttons[i].Location.Y);
        }

        private void HomeLayout(TabPage parentTab)
        {
            // Layout of the Home Tab


            homePanel.Parent = parentTab;
            homePanel.Size = new Size(3 * buttonSize + 18, 3 * buttonSize + 18);
            homePanel.Location = new Point(this.Size.Width / 2 - (3 * buttonSize + 18) / 2, 80);
            homePanel.Anchor = AnchorStyles.Top;

            for (int i = 0; i < 9; ++i)
            {
                Button button = new Button();
                button.Size = new Size(buttonSize, buttonSize);
                button.Tag = i;
                homePanel.Controls.Add(button);

            }



        }
    }
}