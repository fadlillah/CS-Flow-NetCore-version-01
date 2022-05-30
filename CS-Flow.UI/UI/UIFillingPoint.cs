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
using CS_Flow.Manager;

namespace CS_Flow.UI
{
    public partial class UIFillingPointForm : Form
    {
        public static Form formFillingPoint;
        public static DataGridView dataFillingPoint;
        public static List<FillingPointDetail> _fillingPointDetails;
        public static FillingPointDetailManager _FillingPointDetailManager;

        //
        public static DataGridView dataGridFillingPoint;
        public UIFillingPointForm()
        {
           InitializeComponent();
            formFillingPoint = this;
            dataFillingPoint = this.dgvFilling;
            _fillingPointDetails = new List<FillingPointDetail>();
            _FillingPointDetailManager = new FillingPointDetailManager();
            dataGridFillingPoint = this.dgvFilling;
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

        private void FillingPoint_Load(object sender, EventArgs e)
        {

        }

        public static void loadDataFillingPoint(List<FillingPointDetail> fillingPoints)
        {
            dataGridFillingPoint.Rows.Clear();
            if (fillingPoints != null)
            {
                foreach (FillingPointDetail fp in fillingPoints)
                {
                    dataGridFillingPoint.Rows.Add(fp.name, fp.Product, fp.Status, fp.Flowrate, fp.tank_temperature, fp.LiquidPressure, fp.LiquidDensity, fp.LiquidTotalizer, fp.Batch, fp.Preset, fp.Today, fp.SafetyCircuit1, fp.SafetyCircuit2);
                }
            }
            
        }
        public static void updateFillingPoint(int index, string Status, int Temp)
        {
            try
            {
                dataGridFillingPoint.Rows[index].Cells[2].Value = Status;
                dataGridFillingPoint.Rows[index].Cells[3].Value = Temp;
                dataGridFillingPoint.Update();
            }
            catch
            {

            }
            
        }

    }
}
