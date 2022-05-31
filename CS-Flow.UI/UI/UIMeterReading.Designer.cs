namespace CS_Flow.UI
{
    partial class UIMeterReadingForm
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
            this.dgvMeter = new System.Windows.Forms.DataGridView();
            this.fillingPoint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.order = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stopTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startTotalizerLq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stopTotalizerLq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startTotalizerVp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loaded = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loadedCoriolis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnRow1.SuspendLayout();
            this.pnSearchBox.SuspendLayout();
            this.pnBtnSearch.SuspendLayout();
            this.pnRow2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMeter)).BeginInit();
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
            this.pnRow1.TabIndex = 3;
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
            this.pnRow2.Controls.Add(this.dgvMeter);
            this.pnRow2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnRow2.Location = new System.Drawing.Point(0, 40);
            this.pnRow2.Margin = new System.Windows.Forms.Padding(0);
            this.pnRow2.Name = "pnRow2";
            this.pnRow2.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.pnRow2.Size = new System.Drawing.Size(800, 410);
            this.pnRow2.TabIndex = 5;
            // 
            // dgvMeter
            // 
            this.dgvMeter.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.dgvMeter.AllowUserToAddRows = false;
            this.dgvMeter.AllowUserToDeleteRows = false;
            this.dgvMeter.AllowUserToResizeColumns = false;
            this.dgvMeter.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Lato", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(38)))), ((int)(((byte)(50)))));
            this.dgvMeter.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMeter.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMeter.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvMeter.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMeter.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvMeter.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Lato", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(156)))), ((int)(((byte)(175)))));
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(156)))), ((int)(((byte)(175)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMeter.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMeter.ColumnHeadersHeight = 50;
            this.dgvMeter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvMeter.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fillingPoint,
            this.order,
            this.startTime,
            this.stopTime,
            this.startTotalizerLq,
            this.stopTotalizerLq,
            this.startTotalizerVp,
            this.loaded,
            this.loadedCoriolis});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Lato Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(38)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(43)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMeter.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvMeter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMeter.EnableHeadersVisualStyles = false;
            this.dgvMeter.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvMeter.Location = new System.Drawing.Point(0, 20);
            this.dgvMeter.Margin = new System.Windows.Forms.Padding(0);
            this.dgvMeter.MultiSelect = false;
            this.dgvMeter.Name = "dgvMeter";
            this.dgvMeter.ReadOnly = true;
            this.dgvMeter.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Lato Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(156)))), ((int)(((byte)(175)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMeter.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvMeter.RowHeadersVisible = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Lato", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(38)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(38)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMeter.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvMeter.RowTemplate.Height = 40;
            this.dgvMeter.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMeter.Size = new System.Drawing.Size(800, 390);
            this.dgvMeter.TabIndex = 0;
            // 
            // fillingPoint
            // 
            this.fillingPoint.HeaderText = "Filling Point";
            this.fillingPoint.Name = "fillingPoint";
            this.fillingPoint.ReadOnly = true;
            // 
            // order
            // 
            this.order.HeaderText = "Order";
            this.order.Name = "order";
            this.order.ReadOnly = true;
            // 
            // startTime
            // 
            this.startTime.HeaderText = "Start Time";
            this.startTime.Name = "startTime";
            this.startTime.ReadOnly = true;
            // 
            // stopTime
            // 
            this.stopTime.HeaderText = "Stop Time";
            this.stopTime.Name = "stopTime";
            this.stopTime.ReadOnly = true;
            // 
            // startTotalizerLq
            // 
            this.startTotalizerLq.HeaderText = "Start Totalizer [Lq]";
            this.startTotalizerLq.Name = "startTotalizerLq";
            this.startTotalizerLq.ReadOnly = true;
            // 
            // stopTotalizerLq
            // 
            this.stopTotalizerLq.HeaderText = "Stop Totalizer [Lq]";
            this.stopTotalizerLq.Name = "stopTotalizerLq";
            this.stopTotalizerLq.ReadOnly = true;
            // 
            // startTotalizerVp
            // 
            this.startTotalizerVp.HeaderText = "Start Totalizer [Vp]";
            this.startTotalizerVp.Name = "startTotalizerVp";
            this.startTotalizerVp.ReadOnly = true;
            // 
            // loaded
            // 
            this.loaded.HeaderText = "Loaded";
            this.loaded.Name = "loaded";
            this.loaded.ReadOnly = true;
            // 
            // loadedCoriolis
            // 
            this.loadedCoriolis.HeaderText = "Loaded Coriolis";
            this.loadedCoriolis.Name = "loadedCoriolis";
            this.loadedCoriolis.ReadOnly = true;
            // 
            // UIMeterReadingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnRow2);
            this.Controls.Add(this.pnRow1);
            this.Name = "UIMeterReadingForm";
            this.Text = "MeterReading";
            this.Load += new System.EventHandler(this.MeterReadingForm_Load);
            this.Enter += new System.EventHandler(this.rtbSearch_Enter);
            this.Leave += new System.EventHandler(this.rtbSearch_Leave);
            this.pnRow1.ResumeLayout(false);
            this.pnSearchBox.ResumeLayout(false);
            this.pnBtnSearch.ResumeLayout(false);
            this.pnRow2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMeter)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DataGridViewTextBoxColumn StopTotalizerVp;
        private Panel pnRow1;
        private Panel pnSearchBox;
        private RichTextBox rtbSearch;
        private Panel pnSplitterSearchBar;
        private Panel pnBtnSearch;
        private Button btnSearch;
        private Panel pnRow2;
        private DataGridView dgvMeter;
        private DataGridViewTextBoxColumn fillingPoint;
        private DataGridViewTextBoxColumn order;
        private DataGridViewTextBoxColumn startTime;
        private DataGridViewTextBoxColumn stopTime;
        private DataGridViewTextBoxColumn startTotalizerLq;
        private DataGridViewTextBoxColumn stopTotalizerLq;
        private DataGridViewTextBoxColumn startTotalizerVp;
        private DataGridViewTextBoxColumn loaded;
        private DataGridViewTextBoxColumn loadedCoriolis;
    }
}