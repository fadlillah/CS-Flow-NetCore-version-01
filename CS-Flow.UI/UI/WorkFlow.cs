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
    public partial class WorkFlowForm : Form
    {
        public WorkFlowForm()
        {
            InitializeComponent();
        }

        private void WorkFlowForm_Load(object sender, EventArgs e)
        {
            loadDataAll();
        }
        private void loadDataAll()
        {
            btShowAll.BackColor = ColorTranslator.FromHtml("#26324A");
            btStandBy.BackColor = ColorTranslator.FromHtml("#242726");
            btInProgress.BackColor = ColorTranslator.FromHtml("#242726");
            btInterrupted.BackColor = ColorTranslator.FromHtml("#242726");
            btCompleted.BackColor = ColorTranslator.FromHtml("#242726");
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
            btShowAll.BackColor = ColorTranslator.FromHtml("#242726");
            btStandBy.BackColor = ColorTranslator.FromHtml("#26324A");
            btInProgress.BackColor = ColorTranslator.FromHtml("#242726");
            btInterrupted.BackColor = ColorTranslator.FromHtml("#242726");
            btCompleted.BackColor = ColorTranslator.FromHtml("#242726");
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
            btShowAll.BackColor = ColorTranslator.FromHtml("#242726");
            btStandBy.BackColor = ColorTranslator.FromHtml("#242726");
            btInProgress.BackColor = ColorTranslator.FromHtml("#26324A");
            btInterrupted.BackColor = ColorTranslator.FromHtml("#242726");
            btCompleted.BackColor = ColorTranslator.FromHtml("#242726");
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
            btShowAll.BackColor = ColorTranslator.FromHtml("#242726");
            btStandBy.BackColor = ColorTranslator.FromHtml("#242726");
            btInProgress.BackColor = ColorTranslator.FromHtml("#242726");
            btInterrupted.BackColor = ColorTranslator.FromHtml("#26324A");
            btCompleted.BackColor = ColorTranslator.FromHtml("#242726");
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
            btShowAll.BackColor = ColorTranslator.FromHtml("#242726");
            btStandBy.BackColor = ColorTranslator.FromHtml("#242726");
            btInProgress.BackColor = ColorTranslator.FromHtml("#242726");
            btInterrupted.BackColor = ColorTranslator.FromHtml("#242726");
            btCompleted.BackColor = ColorTranslator.FromHtml("#26324A");
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

        private void btShowAll_Click(object sender, EventArgs e)
        {
            
            loadDataAll();
        }

        private void btStandBy_Click(object sender, EventArgs e)
        {
            
            loadDataStandby();
        }

        private void btInProgress_Click(object sender, EventArgs e)
        {
            
            loadDataInProgress();
        }

        private void btInterrupted_Click(object sender, EventArgs e)
        {
            
            loadDatainterrupted();
        }

        private void btCompleted_Click(object sender, EventArgs e)
        {
            loadDataCompleted();
        }
    }
}
