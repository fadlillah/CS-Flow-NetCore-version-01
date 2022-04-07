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
    public partial class UIFillingPointForm : Form
    {
        public UIFillingPointForm()
        {
           InitializeComponent();
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

    }
}
