using CS_Flow.Manager;
using CS_Flow.Models;
namespace CS_Flow.UI
{
    public partial class MainForm : Form
    {
        FillingBatchManager _fillingBatchManager = new FillingBatchManager();
        public List<FillingBatch> fillingBatches = new List<FillingBatch>();
        public MainForm()
        {
            InitializeComponent();
            includeForm<WorkFlowForm>();
            btnWorkFlow.BackColor = ColorTranslator.FromHtml("#242726");
        }

        private void includeForm<MiForm>() where MiForm : Form, new()
        {
            Form content;
            content = pnContent.Controls.OfType<MiForm>().FirstOrDefault();
            if (content == null)
            {
                content = new MiForm();
                content.TopLevel = false;
                content.FormBorderStyle = FormBorderStyle.None;
                content.Dock = DockStyle.Fill;
                pnContent.Controls.Add(content);
                pnContent.Tag = content;
                content.Show();
                content.BringToFront();
            }
            else
            {
                content.BringToFront();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnWindowSize_Click(object sender, EventArgs e)
        {
            this.btnWindowSize.Image = Properties.Resources.icMaximize;
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnSideBar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSettings_Click(object sender, EventArgs e)
        {

        }

        private void btnGraphical_Click(object sender, EventArgs e)
        {

        }

        private void btnEventLog_Click(object sender, EventArgs e)
        {

        }

        private void btnMeterReading_Click(object sender, EventArgs e)
        {

        }

        private void btnFillingPoint_Click(object sender, EventArgs e)
        {
            includeForm<FillingPoint>();
            btnWorkFlow.BackColor = ColorTranslator.FromHtml("#26324A");
            btnTransaction.BackColor = ColorTranslator.FromHtml("#26324A");
            btnFillingPoint.BackColor = ColorTranslator.FromHtml("#242726");
            btnMeterReading.BackColor = ColorTranslator.FromHtml("#26324A");
            btnEventLog.BackColor = ColorTranslator.FromHtml("#26324A");
            btnGraphical.BackColor = ColorTranslator.FromHtml("#26324A");
        }

        private void btnTransaction_Click(object sender, EventArgs e)
        {
           // includeForm<FillingPoint>();
            btnWorkFlow.BackColor = ColorTranslator.FromHtml("#26324A");
            btnTransaction.BackColor = ColorTranslator.FromHtml("#242726");
            btnFillingPoint.BackColor = ColorTranslator.FromHtml("#26324A");
            btnMeterReading.BackColor = ColorTranslator.FromHtml("#26324A");
            btnEventLog.BackColor = ColorTranslator.FromHtml("#26324A");
            btnGraphical.BackColor = ColorTranslator.FromHtml("#26324A");
        }

        private void btnWorkFlow_Click(object sender, EventArgs e)
        {
            includeForm<WorkFlowForm>();
            btnWorkFlow.BackColor = ColorTranslator.FromHtml("#242726");
            btnTransaction.BackColor = ColorTranslator.FromHtml("#26324A");
            btnFillingPoint.BackColor = ColorTranslator.FromHtml("#26324A");
            btnMeterReading.BackColor = ColorTranslator.FromHtml("#26324A");
            btnEventLog.BackColor = ColorTranslator.FromHtml("#26324A");
            btnGraphical.BackColor = ColorTranslator.FromHtml("#26324A");

        }

        private void pnContent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pnTopBar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {

        }
        private void LoadDataAll()
        {
            FillingBatchManager fillingBatchManager = new FillingBatchManager();
            fillingBatches = fillingBatchManager.getAll();
            
        }
    }
}