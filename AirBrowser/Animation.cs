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
        // Animation

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

        private void tm_Tick(object sender, EventArgs e)
        {
            int speed = 10;
            if (btnNavigate.Location.X > location + 200) tm.Enabled = false;
            else
            {
                btnNavigate.Location = new Point(btnNavigate.Location.X + speed, btnNavigate.Location.Y);

               
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
                btnNavigate.Location = new Point(btnNavigate.Location.X - speed, btnNavigate.Location.Y);

                
                pictureBox1.Width -= speed;
                txtNavigate.Width -= speed;
            }

        }

        private void txtNavigate_Leave(object sender, EventArgs e)
        {
            tmBack.Enabled = true;
        }

        private void txtNavigate_Leave_1(object sender, EventArgs e)
        {
            tmBack.Enabled = true;
        }
    }
}