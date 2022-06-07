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
    public partial class UIFillingPoint_Settings : Form
    {
        public UIFillingPoint_Settings()
        {
            InitializeComponent();
        }

        private void UIFillingPoint_Settings_Load(object sender, EventArgs e)
        {
            //dummy data
            DataTable dt = new DataTable();
            dt.Columns.Add("", typeof(string));
            dt.Columns.Add("", typeof(string));
            dt.Rows.Add("Active", "True");
            dt.Rows.Add("Product", "LPG");
            dt.Rows.Add("Source Tank", "T-102");
            dt.Rows.Add("Tank Density [g/cm3]", "0,56");
            dt.Rows.Add("Tank Temperature [C]", "27");
            dgvFillingPointSettings.DataSource = dt;

            dgvFillingPointSettings.Columns[0].ReadOnly = true;

            treeView1.Width = pnBackground.Width / 3;
        }
    }
}
