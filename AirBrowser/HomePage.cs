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
    class HomePage
    {
        public FlowLayoutPanel pageCardPanel = new FlowLayoutPanel();
        int buttonSize = 150;
        int CardsCount = 9;

        public void CreatePanel (int _windowWidth)
        {
            pageCardPanel.Size = new Size(3 * buttonSize + 18, (CardsCount / 3) * buttonSize + (CardsCount / 3) * 6);
            pageCardPanel.Location = new Point(_windowWidth / 2 - (3 * buttonSize + 18) / 2, 80);
            pageCardPanel.Anchor = AnchorStyles.Top;

            for (int i = 0; i < CardsCount; ++i)
            {
                Button button = new Button();
                button.Size = new Size(buttonSize, buttonSize);
                button.Tag = i;
                pageCardPanel.Controls.Add(button);
            }
        }

        
    }
}
