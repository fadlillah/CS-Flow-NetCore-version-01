namespace CS_Flow.UI
{
    partial class UIFillingPointForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnRow1 = new System.Windows.Forms.Panel();
            this.pnSearchBox = new System.Windows.Forms.Panel();
            this.rtbSearch = new System.Windows.Forms.RichTextBox();
            this.pnSplitterSearchBar = new System.Windows.Forms.Panel();
            this.pnBtnSearch = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.pnRow2 = new System.Windows.Forms.Panel();
            this.dgvFilling = new System.Windows.Forms.DataGridView();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flowrate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.temp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.liquidPresure = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.density = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnRow1.SuspendLayout();
            this.pnSearchBox.SuspendLayout();
            this.pnBtnSearch.SuspendLayout();
            this.pnRow2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFilling)).BeginInit();
            this.SuspendLayout();
            // 
            // pnRow1
            // 
            this.pnRow1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnRow1.Controls.Add(this.pnSearchBox);
            this.pnRow1.Controls.Add(this.pnSplitterSearchBar);
            this.pnRow1.Controls.Add(this.pnBtnSearch);
            this.pnRow1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnRow1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.pnRow1.Location = new System.Drawing.Point(0, 0);
            this.pnRow1.Margin = new System.Windows.Forms.Padding(0);
            this.pnRow1.Name = "pnRow1";
            this.pnRow1.Padding = new System.Windows.Forms.Padding(30, 10, 30, 0);
            this.pnRow1.Size = new System.Drawing.Size(800, 40);
            this.pnRow1.TabIndex = 2;
            // 
            // pnSearchBox
            // 
            this.pnSearchBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(38)))), ((int)(((byte)(50)))));
            this.pnSearchBox.Controls.Add(this.rtbSearch);
            this.pnSearchBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnSearchBox.Location = new System.Drawing.Point(30, 10);
            this.pnSearchBox.Name = "pnSearchBox";
            this.pnSearchBox.Padding = new System.Windows.Forms.Padding(25, 7, 0, 5);
            this.pnSearchBox.Size = new System.Drawing.Size(635, 30);
            this.pnSearchBox.TabIndex = 3;
            // 
            // rtbSearch
            // 
            this.rtbSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(38)))), ((int)(((byte)(50)))));
            this.rtbSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbSearch.Font = new System.Drawing.Font("Lato", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rtbSearch.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.rtbSearch.Location = new System.Drawing.Point(25, 7);
            this.rtbSearch.Multiline = false;
            this.rtbSearch.Name = "rtbSearch";
            this.rtbSearch.Size = new System.Drawing.Size(610, 18);
            this.rtbSearch.TabIndex = 0;
            this.rtbSearch.Text = "Type Here ...";
            // 
            // pnSplitterSearchBar
            // 
            this.pnSplitterSearchBar.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnSplitterSearchBar.Location = new System.Drawing.Point(665, 10);
            this.pnSplitterSearchBar.Name = "pnSplitterSearchBar";
            this.pnSplitterSearchBar.Size = new System.Drawing.Size(5, 30);
            this.pnSplitterSearchBar.TabIndex = 5;
            // 
            // pnBtnSearch
            // 
            this.pnBtnSearch.Controls.Add(this.btnSearch);
            this.pnBtnSearch.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnBtnSearch.Location = new System.Drawing.Point(670, 10);
            this.pnBtnSearch.Name = "pnBtnSearch";
            this.pnBtnSearch.Size = new System.Drawing.Size(100, 30);
            this.pnBtnSearch.TabIndex = 4;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(38)))), ((int)(((byte)(50)))));
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Lato", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSearch.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnSearch.Location = new System.Drawing.Point(0, 0);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 30);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // pnRow2
            // 
            this.pnRow2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnRow2.Controls.Add(this.dgvFilling);
            this.pnRow2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnRow2.Location = new System.Drawing.Point(0, 40);
            this.pnRow2.Margin = new System.Windows.Forms.Padding(0);
            this.pnRow2.Name = "pnRow2";
            this.pnRow2.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.pnRow2.Size = new System.Drawing.Size(800, 410);
            this.pnRow2.TabIndex = 4;
            // 
            // dgvFilling
            // 
            this.dgvFilling.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.dgvFilling.AllowUserToAddRows = false;
            this.dgvFilling.AllowUserToDeleteRows = false;
            this.dgvFilling.AllowUserToResizeColumns = false;
            this.dgvFilling.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Lato", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(38)))), ((int)(((byte)(50)))));
            this.dgvFilling.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvFilling.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFilling.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvFilling.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvFilling.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvFilling.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Lato", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(156)))), ((int)(((byte)(175)))));
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(156)))), ((int)(((byte)(175)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvFilling.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvFilling.ColumnHeadersHeight = 50;
            this.dgvFilling.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvFilling.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.Product,
            this.status,
            this.flowrate,
            this.temp,
            this.liquidPresure,
            this.density});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Lato Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(38)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(43)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFilling.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvFilling.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFilling.EnableHeadersVisualStyles = false;
            this.dgvFilling.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvFilling.Location = new System.Drawing.Point(0, 20);
            this.dgvFilling.Margin = new System.Windows.Forms.Padding(0);
            this.dgvFilling.MultiSelect = false;
            this.dgvFilling.Name = "dgvFilling";
            this.dgvFilling.ReadOnly = true;
            this.dgvFilling.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Lato Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(156)))), ((int)(((byte)(175)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFilling.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvFilling.RowHeadersVisible = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Lato", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(38)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(38)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFilling.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvFilling.RowTemplate.Height = 40;
            this.dgvFilling.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFilling.Size = new System.Drawing.Size(800, 390);
            this.dgvFilling.TabIndex = 0;
            // 
            // name
            // 
            this.name.HeaderText = "Name";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // Product
            // 
            this.Product.HeaderText = "product";
            this.Product.Name = "Product";
            this.Product.ReadOnly = true;
            // 
            // status
            // 
            this.status.HeaderText = "Status";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            // 
            // flowrate
            // 
            this.flowrate.HeaderText = "Flow [L/min]";
            this.flowrate.Name = "flowrate";
            this.flowrate.ReadOnly = true;
            // 
            // temp
            // 
            this.temp.HeaderText = "T [Deg C]";
            this.temp.Name = "temp";
            this.temp.ReadOnly = true;
            // 
            // liquidPresure
            // 
            this.liquidPresure.HeaderText = "Liquid Presure [Kg/cm]";
            this.liquidPresure.Name = "liquidPresure";
            this.liquidPresure.ReadOnly = true;
            // 
            // density
            // 
            this.density.HeaderText = "Density";
            this.density.Name = "density";
            this.density.ReadOnly = true;
            // 
            // UIFillingPointForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnRow2);
            this.Controls.Add(this.pnRow1);
            this.Name = "UIFillingPointForm";
            this.Load += new System.EventHandler(this.FillingPoint_Load);
            this.pnRow1.ResumeLayout(false);
            this.pnSearchBox.ResumeLayout(false);
            this.pnBtnSearch.ResumeLayout(false);
            this.pnRow2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFilling)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel pnRow1;
        private Panel pnSearchBox;
        private RichTextBox rtbSearch;
        private Panel pnSplitterSearchBar;
        private Panel pnBtnSearch;
        private Button btnSearch;
        private Panel pnRow2;
        private DataGridView dgvFilling;
        private DataGridViewTextBoxColumn name;
        private DataGridViewTextBoxColumn Product;
        private DataGridViewTextBoxColumn status;
        private DataGridViewTextBoxColumn flowrate;
        private DataGridViewTextBoxColumn temp;
        private DataGridViewTextBoxColumn liquidPresure;
        private DataGridViewTextBoxColumn density;
    }
}