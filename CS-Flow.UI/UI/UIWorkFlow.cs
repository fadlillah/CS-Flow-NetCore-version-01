﻿using System;
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
        public static Form instanceWorkflow;
        public static DataGridView dataWorkflow;
        public static Button currentBtnWorkFlow;
        public List<FillingBatch> _fillingBatches;
        private FillingBatchManager _fillingBatchManager;
        public UIWorkFlowForm()
        {
            InitializeComponent();
            searchBoxPlaceHolder();
            instanceWorkflow = this;
            dataWorkflow = this.dgvFlow;
            currentBtnWorkFlow = new Button();
            _fillingBatches = new List<FillingBatch>();

        }
        private void WorkFlowForm_Load(object sender, EventArgs e)
        {
            ActiveButtonWorkFlow(btnShowAll);
            _fillingBatchManager = new FillingBatchManager();
            _fillingBatches = _fillingBatchManager.getAll();
            loadDataWorkFlow(_fillingBatches);
            
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
       
        public void loadDataWorkFlow(List<FillingBatch> fillingBatches)
        {
            int cnt = 0;
            dataWorkflow.Rows.Clear();
            Color rowColor = new Color();
            foreach (FillingBatch fillingBatch in fillingBatches)
            {
                string status = "";
                if (fillingBatch.status == 0)
                {
                    status = "Standby";
                    rowColor = Color.White;
                    cmsFlow.Enabled = true;
                }
                else if(fillingBatch.status == 1)
                {
                    status = "Authorized";
                    rowColor = Color.LightGoldenrodYellow;
                    cmsFlow.Enabled = false;

                }
                else if(fillingBatch.status == 2)
                {
                    status = "In Progress";
                    rowColor = Color.LightGreen;
                    cmsFlow.Enabled = false;
                }
                else if (fillingBatch.status == 3)
                {
                    status = "Interrupted";
                    rowColor = Color.IndianRed;
                    cmsFlow.Enabled = false;
                }
                else if (fillingBatch.status == 4)
                {
                    status = "Completed";
                    rowColor = Color.DeepSkyBlue;
                    cmsFlow.Enabled = false;
                }
                else if (fillingBatch.status == 5)
                {
                    status = "Gate Out";
                    rowColor = Color.MediumPurple;
                    cmsFlow.Enabled = false;
                }
                
                dataWorkflow.Rows.Add(status, fillingBatch.order_id, fillingBatch.truck, fillingBatch.product, fillingBatch.preset, fillingBatch.filling_point, fillingBatch.pin);
                dataWorkflow.Rows[cnt].Cells[0].Style.BackColor = rowColor;
                
                //dataWorkflow.Rows[cnt].ba
                cnt++;
            }

        }
        public static void realtimeWorkFlow(List<FillingPointDetail> fpds)
        {
            FillingBatchManager fillingBatchManager = new FillingBatchManager();
            List<FillingBatch> fillingBatches = new List<FillingBatch>();
            int cnt;
            if (currentBtnWorkFlow.Name == "btnShowAll")
            {
                fillingBatches = fillingBatchManager.getAll();
            }
            else if (currentBtnWorkFlow.Name == "btnInProgress")
            {
                fillingBatches = fillingBatchManager.getInProgress();
            }
            if (fillingBatches.Count > 0)
            {
                cnt = 0;
                foreach(FillingBatch fb in fillingBatches)
                {
                    int dataLoaded = 0;
                    FillingPointDetail fillingPointDetail = new FillingPointDetail();
                    if (fb.status == 2){
                        fillingPointDetail = fpds.Where(x => x.name == fb.filling_point).FirstOrDefault();
                        if (fillingPointDetail != null)
                        {
                            dataLoaded = fillingPointDetail.RealtimeLoaded;
                        }
                    }                 
                    
                    try
                    {
                        dataWorkflow.Rows[cnt].Cells[7].Value = dataLoaded;
                    }
                    catch
                    {

                    }
                    cnt++;  
                }
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
        //

        //Button control Workflow
        private void ActiveButtonWorkFlow(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentBtnWorkFlow != (Button)btnSender)
                {
                    DisableButton();
                    currentBtnWorkFlow = (Button)btnSender;
                    currentBtnWorkFlow.BackColor = ColorTranslator.FromHtml("#1e2632");
                    currentBtnWorkFlow.Font = new System.Drawing.Font("Lato", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    currentBtnWorkFlow.ForeColor = ColorTranslator.FromHtml("#f5f5f5");

                }
            }
        }
        private void DisableButton()
        {
            foreach (Control previousBtn in pnRow2.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = ColorTranslator.FromHtml("#f5f5f5");
                    previousBtn.Font = new System.Drawing.Font("Lato", 9.7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    previousBtn.ForeColor = ColorTranslator.FromHtml("#1e2632");
                }
            }
        }
        private void btnShowAll_Click(object sender, EventArgs e)
        {
            ActiveButtonWorkFlow(sender);
            FillingBatchManager fillingBatchManager = new FillingBatchManager();
            _fillingBatches = fillingBatchManager.getAll();
            loadDataWorkFlow(_fillingBatches);
        }

        private void btnStandBy_Click(object sender, EventArgs e)
        {
            FillingBatchManager fillingBatchManager = new FillingBatchManager();
            ActiveButtonWorkFlow(sender);
            _fillingBatches = fillingBatchManager.getStandBy();
            loadDataWorkFlow(_fillingBatches);
        }

        private void btnInProgress_Click(object sender, EventArgs e)
        {
            FillingBatchManager fillingBatchManager = new FillingBatchManager();
            ActiveButtonWorkFlow(sender);
            _fillingBatches = fillingBatchManager.getInProgress();
            loadDataWorkFlow(_fillingBatches);
        }

        private void btnInterrupted_Click(object sender, EventArgs e)
        {
            FillingBatchManager fillingBatchManager = new FillingBatchManager();
            ActiveButtonWorkFlow(sender);
            _fillingBatches = fillingBatchManager.getInterupted();
            loadDataWorkFlow(_fillingBatches);
        }

        private void btnCompleted_Click(object sender, EventArgs e)
        {
            FillingBatchManager fillingBatchManager = new FillingBatchManager();
            ActiveButtonWorkFlow(sender);
            _fillingBatches = fillingBatchManager.getCompleted();
            loadDataWorkFlow(_fillingBatches);
        }
        public void updateWorkFlow()
        {
            FillingBatchManager fillingBatchManager = new FillingBatchManager();
            if (currentBtnWorkFlow.Name == "btnShowAll")
            {
                _fillingBatches = fillingBatchManager.getAll();
                loadDataWorkFlow(_fillingBatches);
            }
            else if (currentBtnWorkFlow.Name == "btnStandBy")
            {
                _fillingBatches = fillingBatchManager.getStandBy();
                loadDataWorkFlow(_fillingBatches);
            }
            else if (currentBtnWorkFlow.Name == "btnInProgress")
            {
                _fillingBatches = fillingBatchManager.getInProgress();
                loadDataWorkFlow(_fillingBatches);
            }
            else if (currentBtnWorkFlow.Name == "btnInterrupted")
            {
                _fillingBatches = fillingBatchManager.getInterupted();
                loadDataWorkFlow(_fillingBatches);
            }
            else if (currentBtnWorkFlow.Name == "btnCompleted")
            {
                _fillingBatches = fillingBatchManager.getInProgress();
                loadDataWorkFlow(_fillingBatches);
            }

        }

        private void dgvFlow_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void dgvFlow_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmsFlow_Opening(object sender, CancelEventArgs e)
        {
            int selectedRow = dgvFlow.SelectedRows[0].Index;
            
            string truckName = dgvFlow.Rows[selectedRow].Cells["Truck"].Value.ToString();
            string assignTo = dgvFlow.Rows[selectedRow].Cells["AssignTo"].Value.ToString();

            tsTruck.Text = truckName;

            if (assignTo == "FS-1")
            {
                tsFS1.Visible = false;
                tsFS2.Visible = true;
                tsFS3.Visible = true;
            }
            else if (assignTo == "FS-2")
            {
                tsFS1.Visible = true;
                tsFS2.Visible = false;
                tsFS3.Visible = true;
            }
            else if (assignTo == "FS-3")
            {
                tsFS1.Visible = true;
                tsFS2.Visible = true;
                tsFS3.Visible = false;
            }
        }

        private void tsFS1_Click(object sender, EventArgs e)
        {
            int selectedRow = dgvFlow.SelectedRows[0].Index;
            string OrderId = dgvFlow.Rows[selectedRow].Cells["Order"].Value.ToString();
            string FpName = tsFS1.Text;
            _fillingBatchManager.UpdateByFillingPoint(OrderId, FpName);
            updateWorkFlow();
            //dgvFlow.Rows[selectedRow].Cells["AssignTo"].Value = tsFS1.Text;
        }

        private void tsFS2_Click(object sender, EventArgs e)
        {
            int selectedRow = dgvFlow.SelectedRows[0].Index;
            string OrderId = dgvFlow.Rows[selectedRow].Cells["Order"].Value.ToString();
            string FpName = tsFS2.Text;
            _fillingBatchManager.UpdateByFillingPoint(OrderId, FpName);
            updateWorkFlow();
            //dgvFlow.Rows[selectedRow].Cells["AssignTo"].Value = tsFS2.Text;
        }

        private void tsFS3_Click(object sender, EventArgs e)
        {
            int selectedRow = dgvFlow.SelectedRows[0].Index;
            string OrderId = dgvFlow.Rows[selectedRow].Cells["Order"].Value.ToString();
            string FpName = tsFS3.Text;
            _fillingBatchManager.UpdateByFillingPoint(OrderId, FpName);
            updateWorkFlow();
            // dgvFlow.Rows[selectedRow].Cells["AssignTo"].Value = tsFS3.Text;
        }
    }
}
