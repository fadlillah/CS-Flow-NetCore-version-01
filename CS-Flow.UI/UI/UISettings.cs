using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS_Flow.UI
{
    public partial class UISettingsForm : Form
    {
        private Button currentButton;
        private Form activeForm;

        public UISettingsForm()
        {
            InitializeComponent();
            OpenChildForm(new Settings_tab.UISystem_Settings(), btnSystem);
        }

        private void DisableButton()
        {
            foreach (Control previousBtn in pnRow1.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    Button bt = (Button)previousBtn;
                    bt.BackColor = ColorTranslator.FromHtml("#f5f5f5");
                    bt.Font = new System.Drawing.Font("Lato", 9.7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    bt.ForeColor = ColorTranslator.FromHtml("#1E2632");
                }
            }
        }

        private void ActiveButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = ColorTranslator.FromHtml("#1E2632");
                    currentButton.Font = new System.Drawing.Font("Lato", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    currentButton.ForeColor = ColorTranslator.FromHtml("#f5f5f5");
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
            this.pnCard.Controls.Add(childForm);
            this.pnCard.Dock = DockStyle.Fill;
            this.pnCard.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {

        }

        private void btnSystem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Settings_tab.UISystem_Settings(), sender);
        }

        private void btnFillingPoint_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Settings_tab.UIFillingPoint_Settings(), sender);
        }

        private void btnVisual_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Settings_tab.UIVisual_Settings(), sender);
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Settings_tab.UIAbout_Settings(), sender);
        }
    }
}
