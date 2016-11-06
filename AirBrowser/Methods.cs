using CefSharp.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AirBrowser
{
    public partial class Form1 : Form
    {
      
        private void ShowValidUrl()
        {
            string shortenUrl = "";
            string adress = Convert.ToString( ((ChromiumWebBrowser)tabChrome.SelectedTab.Controls[0]).Address);
            if ( adress.Contains("https"))
            {
                shortenUrl = adress.Remove(0, 8);
                txtHttps.Text = "https://";
                txtHttps.Location = new Point(103, 43);
            }
            else if (adress.Contains("http")) {
                shortenUrl = adress.Remove(0, 7);
                txtHttps.Text = "http://";
                txtHttps.Location = new Point(107, 43);
            }
            txtNavigate.Text = shortenUrl;
            tabChrome.Focus();
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