using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS_Flow.UI.Settings_tab
{
    public partial class UIVisual_Settings : Form
    {
        public UIVisual_Settings()
        {
            InitializeComponent();
        }

        private void UIVisual_Settings_Load(object sender, EventArgs e)
        {
            btnMoveUp.Width = pnBtnControl.Width / 3;
            btnMoveDown.Width = pnBtnControl.Width / 3;
            btnRename.Width = pnBtnControl.Width / 3;
            pnListBox.Width = pnBackground.Width / 3;
        }
    }
}
