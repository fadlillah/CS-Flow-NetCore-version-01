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
    public partial class UISystem_Settings : Form
    {
        private bool startStatus = false;
        public UISystem_Settings()
        {
            InitializeComponent();
        }

        private void UISystem_Settings_Load(object sender, EventArgs e)
        {
           // btnOn.BackColor = ColorTranslator.FromHtml("#1E2632");

            //dummy data
            DataTable dt = new DataTable();
            dt.Columns.Add("", typeof(string));
            dt.Columns.Add("", typeof(string));
            dt.Rows.Add("DBname", "db_csflow");
            dt.Rows.Add("DBpassword", "cs-flow.password");
            dt.Rows.Add("DBuser", "user123");
            dt.Rows.Add("Server Address", "127.0.0.1");
            dgvSystemSettings.DataSource = dt;
            if (startStatus)
            {
                btnOff.BackColor = ColorTranslator.FromHtml("#1E2632");
                btnOn.BackColor = ColorTranslator.FromHtml("#00A5B0");
            }
            else
            {
                btnOff.BackColor = ColorTranslator.FromHtml("#B0002A");
                btnOn.BackColor = ColorTranslator.FromHtml("#1E2632");
            }


            dgvSystemSettings.Columns[0].ReadOnly = true;
        }

        private void btnOff_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure want to turn off the app?", "Turn Off the App", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                btnOff.BackColor = ColorTranslator.FromHtml("#B0002A");

                btnOn.BackColor = ColorTranslator.FromHtml("#1E2632");
                startStatus = true;
                MainForm.StopAll();
            }
            else if (dialogResult == DialogResult.No)
            {
                btnOff.BackColor = ColorTranslator.FromHtml("#1E2632");

                btnOn.BackColor = ColorTranslator.FromHtml("#00A5B0");
                startStatus = false;
            }
            
            
        }

        private void btnOn_Click(object sender, EventArgs e)
        {
            startStatus = true;
            MainForm.startAll();
        }
    }
}
