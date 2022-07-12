using CS_Flow.Manager;
using CS_Flow.Models;
using System.Threading;
namespace CS_Flow.UI
{
    public partial class MainForm : Form
    {
        //Field Object CS_Flow
        private FillingBatchManager _fillingBatchManager;
        private List<FillingBatch> _fillingBatches;
        private List<FillingPointDetail> _fillingPointDetails;
        private static FillingPointDetailManager fillingPointDetailManager;
        private TransactionManager _transactionManager;
        private ModbusServerManager _modbusServer;

        //Field Object Toolbox blue print
        private Button currentButton;
        private int TempIndex;
        private Form activeForm;
        private static Button ButtonClose;

        //Field Activation
        bool mouseDown;
        private Point lastLocation;

        //thread
        private static Thread _ThreadBC;
        private static Thread _ThreadLoading;
        private static Thread _RealTimeLoaded;
        private static Thread _TheadGateIn;


        //rest server
        private RestServerManager restServer;
        private string gateInURL = @"http://127.0.0.1:8088/";

        public MainForm()
        {
            InitializeComponent();
            //includeForm<UIWorkFlowForm>();
            OpenChildForm(new UIWorkFlowForm(), btnWorkFlow);
            
            btnWorkFlow.BackColor = ColorTranslator.FromHtml("#f5f5f5");
            _fillingBatchManager = new FillingBatchManager();
            _fillingBatches = new List<FillingBatch>();
            _fillingPointDetails = new List<FillingPointDetail>();
            _transactionManager = new TransactionManager();
            _modbusServer = new ModbusServerManager();
            ButtonClose = this.btnClose;
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
        private void Reset()
        {
            fillingPointDetailManager = new FillingPointDetailManager();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            Reset();
            this.FormBorderStyle = FormBorderStyle.None;
            btnGraphical.Enabled = false;
            btnGraphical.Visible = false;
            loadFillingPoint();
            tm_ack.Enabled = true;            
            //
            Sliding();

            //rest Server
            
            //start thread
            

        }
        private void startRestServer()
        {
            restServer = new RestServerManager(gateInURL);
            restServer.startConnection();
            _TheadGateIn = new Thread(t => restServer.realtimeListening());
            _TheadGateIn.Start();
        }
        public static void startAll()
        {
            ButtonClose.Visible = true;
            _ThreadBC = new Thread(t => fillingPointDetailManager.updateConnection());
            _ThreadLoading = new Thread(t => fillingPointDetailManager.updateDataBC());
            _RealTimeLoaded = new Thread(t => fillingPointDetailManager.realTimeLoaded());            
            _ThreadBC.Start();
            _ThreadLoading.Start();
            _RealTimeLoaded.Start();
            
        }
        public static void StopAll()
        {
            if (_ThreadBC.Join(TimeSpan.FromSeconds(3)) || _ThreadLoading.Join(TimeSpan.FromSeconds(3)) || _RealTimeLoaded.Join(TimeSpan.FromSeconds(3)))
            {
                _ThreadBC.Interrupt();
                _ThreadLoading.Interrupt();
                _RealTimeLoaded.Interrupt();
            }
            ButtonClose.Visible = false;
            //_ThreadBC.Abort();
            fillingPointDetailManager.stopBC();
            //_ThreadLoading.Abort();
            //_RealTimeLoaded.Abort();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            tm_ack.Enabled = false;
            StopAll();
            _TheadGateIn.Abort();
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
        #region Button MenuBar
        private void btnSettings_Click(object sender, EventArgs e)
        {
            OpenChildForm(new UISettingsForm(), sender);
        }

        private void btnGraphical_Click(object sender, EventArgs e)
        {
            OpenChildForm(new UIGraphicalForm(), sender);
        }

        private void btnEventLog_Click(object sender, EventArgs e)
        {
            OpenChildForm(new UIEventLogForm(), sender);
        }

        private void btnMeterReading_Click(object sender, EventArgs e)
        {
            OpenChildForm(new UIMeterReadingForm(), sender);
        }

        private void btnFillingPoint_Click(object sender, EventArgs e)
        {
            OpenChildForm(new UIFillingPointForm(), sender);
            UIFillingPointForm.loadDataFillingPoint(_fillingPointDetails);
        }

        private void btnTransaction_Click(object sender, EventArgs e)
        {
            OpenChildForm(new UITransactionForm(), sender);
        }

        private void btnWorkFlow_Click(object sender, EventArgs e)
        {
            OpenChildForm(new UIWorkFlowForm(), sender);
        }
        #endregion 
        private void LoadDataAll()
        {
            FillingBatchManager fillingBatchManager = new FillingBatchManager();
            _fillingBatches = fillingBatchManager.getAll();
            
        }
        private void updateTableFillingPoint()
        {
            UIFillingPointForm.dataFillingPoint.Rows.Clear();

        }
        //Realtime timer
        private void tm_ack_Tick(object sender, EventArgs e)
        {
            //fillingPointDetailManager.updateConnection();
            List<FillingPointDetail> fpds = new List<FillingPointDetail>();
            fpds = fillingPointDetailManager.GetFillingPointDetails();
            if (currentButton.Name == "btnFillingPoint")
            {
                realTimeFillingPoint();
            }
            else if (currentButton.Name == "btnTransaction")
            {
                loadTransaction();
            }
            else if (currentButton.Name == "btnWorkFlow")
            {
                
                UIWorkFlowForm.realtimeWorkFlow(fpds);
            }

            _modbusServer.UpdateValue(fpds);

            //updateTableFillingPoint();
            //var activeBt = currentButton;
            //var activeFm = activeForm;
        }
        
        private void ActiveButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton !=(Button)btnSender)
                {
                    DisableButton();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = ColorTranslator.FromHtml("#f5f5f5");
                    currentButton.Font = new System.Drawing.Font("Lato", 12.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    currentButton.ForeColor = ColorTranslator.FromHtml("#1e2632");
                    if (currentButton.Name == "btnWorkFlow")
                    {
                        currentButton.Image = Properties.Resources.icWorkFlow_dark;
                    }                   
                    else if (currentButton.Name == "btnTransaction")
                    {
                        currentButton.Image = Properties.Resources.icTransaction_dark;
                    }
                    else if (currentButton.Name == "btnFillingPoint")
                    {
                        currentButton.Image = Properties.Resources.icFillingPoint_dark;
                    }
                    else if (currentButton.Name == "btnMeterReading")
                    {
                        currentButton.Image = Properties.Resources.icMeterReading_dark;
                    }
                    else if (currentButton.Name == "btnEventLog")
                    {
                        currentButton.Image = Properties.Resources.icEventLog_dark;
                    }
                    else if (currentButton.Name == "btnGraphical")
                    {
                        currentButton.Image = Properties.Resources.icGraphics_dark;
                    }
                    else if (currentButton.Name == "btnSettings")
                    {
                        currentButton.Image = Properties.Resources.icSettings_dark;
                    }
                }    
                
                
            }
        }
        private void DisableButton()
        {
            foreach (Control previousBtn in pnSideBar.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    Button bt = (Button)previousBtn;
                    bt.BackColor = ColorTranslator.FromHtml("#1E2632");
                    bt.Font = new System.Drawing.Font("Lato", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    bt.ForeColor = ColorTranslator.FromHtml("#f5f5f5");
                    if (bt.Name == "btnWorkFlow")
                    {
                        bt.Image = Properties.Resources.icWorkFlow;
                    }
                    else if (bt.Name == "btnTransaction")
                    {
                        bt.Image = Properties.Resources.icTransaction;
                    }
                    else if (bt.Name == "btnFillingPoint")
                    {
                        bt.Image = Properties.Resources.icFillingPoint;
                    }
                    else if (bt.Name == "btnMeterReading")
                    {
                        bt.Image = Properties.Resources.icMeterReading;
                    }
                    else if (bt.Name == "btnEventLog")
                    {
                        bt.Image = Properties.Resources.icEventLog;
                    }
                    else if (bt.Name == "btnGraphical")
                    {
                        bt.Image = Properties.Resources.icGraphics;
                    }
                    else if (bt.Name == "btnSettings")
                    {
                        bt.Image = Properties.Resources.icSettings;
                    }
                }
            }
        }
        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
                activeForm.Close();
            ActiveButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.pnContent.Controls.Add(childForm);
            this.pnContent.Dock = DockStyle.Fill;
            this.pnContent.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            
        }
        #region Filling Point Controll
        private void loadFillingPoint()
        {
            fillingPointDetailManager = new FillingPointDetailManager();
            fillingPointDetailManager.Init();
            _fillingPointDetails = fillingPointDetailManager.GetFillingPointDetails();
        }
        private void realTimeFillingPoint()
        {
            if (_fillingPointDetails != null)
            {
                for(int inc=0; inc < _fillingPointDetails.Count; inc++)
                {
                    UIFillingPointForm.updateFillingPoint(inc, _fillingPointDetails[inc].Status, (int)_fillingPointDetails[inc].RealtimeLoaded);
                }
            }
        }
        #endregion

        #region Transaction
        private void loadTransaction()
        {
            List<Transaction> tss = _transactionManager.getOnLoaded();
            UITransactionForm.loadDataTransaction(tss);
        }
        #endregion
        private void Sliding()
        {
            int destinationX = (Screen.PrimaryScreen.WorkingArea.Width / 2) - (this.Width / 2);
            int destinationY = Screen.PrimaryScreen.WorkingArea.Height - this.Height;

            Point newLocation = new Point(destinationX, destinationY + this.Height);

            new Thread(new ThreadStart(() =>
            {
                do
                {
                    // this line needs to be executed in the UI thread, hence we use Invoke
                    this.Invoke(new Action(() => { this.Location = newLocation; }));

                    newLocation = new Point(destinationX, newLocation.Y - 1);
                    Thread.Sleep(100);
                }
                while (newLocation != new Point(destinationX, destinationY));
            })).Start();
        }
    }
}