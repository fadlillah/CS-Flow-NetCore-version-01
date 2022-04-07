using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CS_Flow.Manager;
using CS_Flow.Models;

namespace CS_Flow.UI
{
    public partial class UIWorkFlowForm : Form
    {
        public UIWorkFlowForm()
        {
            InitializeComponent();
            searchBoxPlaceHolder();
        }

        //Start Search Box Place Holder
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
        //End Search Box Place Holder

        private void WorkFlowForm_Load(object sender, EventArgs e)
        {
            loadDataAll();
        }

        private void loadDataAll()
        {
            btnShowAll.BackColor = ColorTranslator.FromHtml("#26324A");
            btnStandBy.BackColor = ColorTranslator.FromHtml("#242726");
            btnInProgress.BackColor = ColorTranslator.FromHtml("#242726");
            btnInterrupted.BackColor = ColorTranslator.FromHtml("#242726");
            btnCompleted.BackColor = ColorTranslator.FromHtml("#242726");

            FillingBatchManager fillingBatchManager = new FillingBatchManager();
            var fillingBatches = fillingBatchManager.getAll();
            dgvFlow.Rows.Clear();

            foreach (FillingBatch fillingBatch in fillingBatches)
            {
                dgvFlow.Rows.Add(fillingBatch.order_id, fillingBatch.truck, fillingBatch.product, fillingBatch.preset, fillingBatch.filling_point, fillingBatch.pin);
            }

        }

        private void loadDataStandby()
        {
            btnShowAll.BackColor = ColorTranslator.FromHtml("#242726");
            btnStandBy.BackColor = ColorTranslator.FromHtml("#26324A");
            btnInProgress.BackColor = ColorTranslator.FromHtml("#242726");
            btnInterrupted.BackColor = ColorTranslator.FromHtml("#242726");
            btnCompleted.BackColor = ColorTranslator.FromHtml("#242726");
            
            FillingBatchManager fillingBatchManager = new FillingBatchManager();
            var fillingBatches = fillingBatchManager.getStandBy();
            dgvFlow.Rows.Clear();
            
            foreach (FillingBatch fillingBatch in fillingBatches)
            {
                dgvFlow.Rows.Add(fillingBatch.order_id, fillingBatch.truck, fillingBatch.product, fillingBatch.preset, fillingBatch.filling_point, fillingBatch.pin);
            }
        }

        private void loadDataInProgress()
        {
            btnShowAll.BackColor = ColorTranslator.FromHtml("#242726");
            btnStandBy.BackColor = ColorTranslator.FromHtml("#242726");
            btnInProgress.BackColor = ColorTranslator.FromHtml("#26324A");
            btnInterrupted.BackColor = ColorTranslator.FromHtml("#242726");
            btnCompleted.BackColor = ColorTranslator.FromHtml("#242726");
            
            FillingBatchManager fillingBatchManager = new FillingBatchManager();
            var fillingBatches = fillingBatchManager.getInProgress();
            dgvFlow.Rows.Clear();
            
            foreach (FillingBatch fillingBatch in fillingBatches)
            {
                dgvFlow.Rows.Add(fillingBatch.order_id, fillingBatch.truck, fillingBatch.product, fillingBatch.preset, fillingBatch.filling_point, fillingBatch.pin);
            }
        }

        private void loadDatainterrupted()
        {
            btnShowAll.BackColor = ColorTranslator.FromHtml("#242726");
            btnStandBy.BackColor = ColorTranslator.FromHtml("#242726");
            btnInProgress.BackColor = ColorTranslator.FromHtml("#242726");
            btnInterrupted.BackColor = ColorTranslator.FromHtml("#26324A");
            btnCompleted.BackColor = ColorTranslator.FromHtml("#242726");
            
            FillingBatchManager fillingBatchManager = new FillingBatchManager();
            var fillingBatches = fillingBatchManager.getInterupted();
            dgvFlow.Rows.Clear();
            
            foreach (FillingBatch fillingBatch in fillingBatches)
            {
                dgvFlow.Rows.Add(fillingBatch.order_id, fillingBatch.truck, fillingBatch.product, fillingBatch.preset, fillingBatch.filling_point, fillingBatch.pin);
            }
        }

        private void loadDataCompleted()
        {
            btnShowAll.BackColor = ColorTranslator.FromHtml("#242726");
            btnStandBy.BackColor = ColorTranslator.FromHtml("#242726");
            btnInProgress.BackColor = ColorTranslator.FromHtml("#242726");
            btnInterrupted.BackColor = ColorTranslator.FromHtml("#242726");
            btnCompleted.BackColor = ColorTranslator.FromHtml("#26324A");
            
            FillingBatchManager fillingBatchManager = new FillingBatchManager();
            var fillingBatches = fillingBatchManager.getStandBy();
            dgvFlow.Rows.Clear();
            
            foreach (FillingBatch fillingBatch in fillingBatches)
            {
                dgvFlow.Rows.Add(fillingBatch.order_id, fillingBatch.truck, fillingBatch.product, fillingBatch.preset, fillingBatch.filling_point, fillingBatch.pin);
            }
        }

        private void dgvFlow_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try 
            {
                if (dgvFlow.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    dgvFlow.CurrentRow.Selected = true;
                }
            }
            catch
            {

            }
           
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            
            loadDataAll();
        }

        private void btnStandBy_Click(object sender, EventArgs e)
        {
            
            loadDataStandby();
        }

        private void btnInProgress_Click(object sender, EventArgs e)
        {
            
            loadDataInProgress();
        }

        private void btnInterrupted_Click(object sender, EventArgs e)
        {
            
            loadDatainterrupted();
        }

        private void btnCompleted_Click(object sender, EventArgs e)
        {
            loadDataCompleted();
        }

        
    }
}
