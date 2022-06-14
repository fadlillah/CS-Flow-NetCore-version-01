using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CS_Flow.Models;

namespace CS_Flow.UI
{
    public partial class UITransactionForm : Form
    {
        public static DataGridView dataTransaction;
        public UITransactionForm()
        {
            InitializeComponent();
            searchBoxPlaceHolder();
            dataTransaction = this.dgvTransaction;
        }

        private void searchBoxPlaceHolder()
        {
            rtbSearch.Text = "Type Here ...";
            rtbSearch.ForeColor = ColorTranslator.FromHtml("#4B5465");
        }

        private void rtbSearch_Enter(object sender, EventArgs e)
        {
            if (rtbSearch.Text == "Type Here ...")
            {
                rtbSearch.Text = "";
                rtbSearch.ForeColor = ColorTranslator.FromHtml("#fafafa");
            }
        }

        private void rtbSearch_Leave(object sender, EventArgs e)
        {
            if (rtbSearch.Text.Trim() == "")
            {
                rtbSearch.Text = "Type Here ...";
                rtbSearch.ForeColor = ColorTranslator.FromHtml("#221F1F");
            }
        }

        private void TransactionForm_Load(object sender, EventArgs e)
        {

        }
        #region Load to Table
        public static void loadDataTransaction(List<Transaction> transactions)
        {
            Color rowColor = new Color();
            dataTransaction.Rows.Clear();
            foreach (Transaction ts in transactions)
            {
                string status = "";
                if (ts.status == 0)
                {
                    status = "Standby";
                    rowColor = Color.White;
                }
                else if (ts.status == 1)
                {
                    status = "Authorized";
                    rowColor = Color.LightGoldenrodYellow;
                }
                else if (ts.status == 2)
                {
                    status = "In Progress";
                    rowColor = Color.LightGreen;
                }
                else if (ts.status == 3)
                {
                    status = "Interrupted";
                    rowColor = Color.IndianRed;
                }
                else if (ts.status == 4)
                {
                    status = "Completed";
                    rowColor = Color.DeepSkyBlue;
                }
                else if (ts.status == 5)
                {
                    status = "Gate Out";
                    rowColor = Color.MediumPurple;
                }
                dataTransaction.Rows.Add(ts.batch_id,status, ts.product, ts.filling_point, ts.preset,ts.preset, ts.str_gatein_timestamp, ts.str_gateout_timestamp);
            }
        }
        #endregion
    }
}