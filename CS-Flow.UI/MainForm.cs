using CS_Flow.Manager;
using CS_Flow.Models;

namespace CS_Flow.UI
{
    public partial class MainForm : Form
    {
        FillingBatchManager _fillingBatchManager = new FillingBatchManager();
        public List<FillingBatch> fillingBatches = new List<FillingBatch>();

        bool mouseDown;
        private Point lastLocation;

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

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                int dx = e.Location.X - lastLocation.X;
                int dy = e.Location.Y - lastLocation.Y;
                this.Location = new Point(this.Location.X + dx, this.Location.Y + dy);
            }
        }

        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnWindowSize_Click(object sender, EventArgs e)
        {
            

            if (this.WindowState == FormWindowState.Maximized)
            {
                this.btnWindowSize.Image = Properties.Resources.icMaximize;
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.btnWindowSize.Image = Properties.Resources.icRestoreDown;
                this.WindowState = FormWindowState.Maximized;
            }
            
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            includeForm<SettingsForm>();
            btnWorkFlow.BackColor = ColorTranslator.FromHtml("#26324A");
            btnTransaction.BackColor = ColorTranslator.FromHtml("#26324A");
            btnFillingPoint.BackColor = ColorTranslator.FromHtml("#26324A");
            btnMeterReading.BackColor = ColorTranslator.FromHtml("#26324A");
            btnEventLog.BackColor = ColorTranslator.FromHtml("#26324A");
            btnGraphical.BackColor = ColorTranslator.FromHtml("#26324A");
            btnSettings.BackColor = ColorTranslator.FromHtml("#242726");
        }

        private void btnGraphical_Click(object sender, EventArgs e)
        {
            includeForm<GraphicalForm>();
            btnWorkFlow.BackColor = ColorTranslator.FromHtml("#26324A");
            btnTransaction.BackColor = ColorTranslator.FromHtml("#26324A");
            btnFillingPoint.BackColor = ColorTranslator.FromHtml("#26324A");
            btnMeterReading.BackColor = ColorTranslator.FromHtml("#26324A");
            btnEventLog.BackColor = ColorTranslator.FromHtml("#26324A");
            btnGraphical.BackColor = ColorTranslator.FromHtml("#242726");
            btnSettings.BackColor = ColorTranslator.FromHtml("#26324A");
        }

        private void btnEventLog_Click(object sender, EventArgs e)
        {
            includeForm<EventLogForm>();
            btnWorkFlow.BackColor = ColorTranslator.FromHtml("#26324A");
            btnTransaction.BackColor = ColorTranslator.FromHtml("#26324A");
            btnFillingPoint.BackColor = ColorTranslator.FromHtml("#26324A");
            btnMeterReading.BackColor = ColorTranslator.FromHtml("#26324A");
            btnEventLog.BackColor = ColorTranslator.FromHtml("#242726");
            btnGraphical.BackColor = ColorTranslator.FromHtml("#26324A");
            btnSettings.BackColor = ColorTranslator.FromHtml("#26324A");
        }

        private void btnMeterReading_Click(object sender, EventArgs e)
        {
            includeForm<MeterReadingForm>();
            btnWorkFlow.BackColor = ColorTranslator.FromHtml("#26324A");
            btnTransaction.BackColor = ColorTranslator.FromHtml("#26324A");
            btnFillingPoint.BackColor = ColorTranslator.FromHtml("#26324A");
            btnMeterReading.BackColor = ColorTranslator.FromHtml("#242726");
            btnEventLog.BackColor = ColorTranslator.FromHtml("#26324A");
            btnGraphical.BackColor = ColorTranslator.FromHtml("#26324A");
            btnSettings.BackColor = ColorTranslator.FromHtml("#26324A");
        }

        private void btnFillingPoint_Click(object sender, EventArgs e)
        {
            includeForm<FillingPointForm>();
            btnWorkFlow.BackColor = ColorTranslator.FromHtml("#26324A");
            btnTransaction.BackColor = ColorTranslator.FromHtml("#26324A");
            btnFillingPoint.BackColor = ColorTranslator.FromHtml("#242726");
            btnMeterReading.BackColor = ColorTranslator.FromHtml("#26324A");
            btnEventLog.BackColor = ColorTranslator.FromHtml("#26324A");
            btnGraphical.BackColor = ColorTranslator.FromHtml("#26324A");
            btnSettings.BackColor = ColorTranslator.FromHtml("#26324A");
        }

        private void btnTransaction_Click(object sender, EventArgs e)
        {
            includeForm<TransactionForm>();
            btnWorkFlow.BackColor = ColorTranslator.FromHtml("#26324A");
            btnTransaction.BackColor = ColorTranslator.FromHtml("#242726");
            btnFillingPoint.BackColor = ColorTranslator.FromHtml("#26324A");
            btnMeterReading.BackColor = ColorTranslator.FromHtml("#26324A");
            btnEventLog.BackColor = ColorTranslator.FromHtml("#26324A");
            btnGraphical.BackColor = ColorTranslator.FromHtml("#26324A");
            btnSettings.BackColor = ColorTranslator.FromHtml("#26324A");
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
            btnSettings.BackColor = ColorTranslator.FromHtml("#26324A");
        }
        
        private void LoadDataAll()
        {
            FillingBatchManager fillingBatchManager = new FillingBatchManager();
            fillingBatches = fillingBatchManager.getAll();
            
        }

        
    }
}