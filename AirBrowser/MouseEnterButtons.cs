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

       

        private void btnForward_MouseEnter(object sender, EventArgs e)
        {
            btnForward.BackgroundImage = AirBrowser.Properties.Resources.btnForwardHighLight;
        }

        private void btnForward_MouseLeave(object sender, EventArgs e)
        {
            btnForward.BackgroundImage = AirBrowser.Properties.Resources.btnForward;
        }

        private void btnHome_MouseEnter(object sender, EventArgs e)
        {
            btnHome.BackgroundImage = AirBrowser.Properties.Resources.btnHomeHighlight;
        }

        private void btnHome_MouseLeave(object sender, EventArgs e)
        {
            btnHome.BackgroundImage = AirBrowser.Properties.Resources.btnHome;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackgroundImage = AirBrowser.Properties.Resources.btnRemoveHighlight;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackgroundImage = AirBrowser.Properties.Resources.btnRemove;
        }
    }
}
