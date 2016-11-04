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
    class MyEventArgs : EventArgs
    {
        public int index;
    }

    

    partial class TabPanel
    {
        
        int ind = 0;
        int a = 0;
        
        private void TmSlide_Tick(object sender, EventArgs e)
        {


            if (a <= tabWidth)
            {
                tabs[ind].Location = new Point(tabs[ind].Location.X + 10, tabs[ind].Location.Y);
                a++;
            }
            else tmSlide.Enabled = false;
           


            
        }

       
    }
}
