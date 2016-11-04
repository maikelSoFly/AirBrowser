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
      
        private void ShowValidUrl()
        {
            string fullUrL = Convert.ToString(((WebBrowser)tabControl.SelectedTab.Controls[0]).Url);
           // string shortenUrl = fullUrL.Remove(0, 7);
            txtNavigate.Text = fullUrL;
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