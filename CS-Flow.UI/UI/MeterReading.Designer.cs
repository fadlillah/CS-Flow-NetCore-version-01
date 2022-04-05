namespace CS_Flow.UI
{
    partial class MeterReadingForm
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
            this.btnSearch = new System.Windows.Forms.Button();
            this.pnSplitterSearchBar = new System.Windows.Forms.Panel();
            this.pnBtnSearch = new System.Windows.Forms.Panel();
            this.rtbSearch = new System.Windows.Forms.RichTextBox();
            this.pnSearchBox = new System.Windows.Forms.Panel();
            this.pnSearch = new System.Windows.Forms.Panel();
            this.pnTable = new System.Windows.Forms.Panel();
            this.dgvMeter = new System.Windows.Forms.DataGridView();
            this.FillingPoint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Order = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StopTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartTotalizerLq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StopTotalizerLq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartTotalizerVp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StopTotalixerVp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Loaded = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoadedCoriolis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnBtnSearch.SuspendLayout();
            this.pnSearchBox.SuspendLayout();
            this.pnSearch.SuspendLayout();
            this.pnTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMeter)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(74)))));
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Lato", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this.btnSearch.Location = new System.Drawing.Point(0, 0);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 30);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // pnSplitterSearchBar
            // 
            this.pnSplitterSearchBar.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnSplitterSearchBar.Location = new System.Drawing.Point(695, 0);
            this.pnSplitterSearchBar.Name = "pnSplitterSearchBar";
            this.pnSplitterSearchBar.Size = new System.Drawing.Size(5, 30);
            this.pnSplitterSearchBar.TabIndex = 5;
            // 
            // pnBtnSearch
            // 
            this.pnBtnSearch.Controls.Add(this.btnSearch);
            this.pnBtnSearch.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnBtnSearch.Location = new System.Drawing.Point(700, 0);
            this.pnBtnSearch.Name = "pnBtnSearch";
            this.pnBtnSearch.Size = new System.Drawing.Size(100, 30);
            this.pnBtnSearch.TabIndex = 4;
            // 
            // rtbSearch
            // 
            this.rtbSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(74)))));
            this.rtbSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbSearch.Font = new System.Drawing.Font("Lato", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rtbSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this.rtbSearch.Location = new System.Drawing.Point(25, 5);
            this.rtbSearch.Multiline = false;
            this.rtbSearch.Name = "rtbSearch";
            this.rtbSearch.Size = new System.Drawing.Size(670, 20);
            this.rtbSearch.TabIndex = 0;
            this.rtbSearch.Text = "Type Here ...";
            // 
            // pnSearchBox
            // 
            this.pnSearchBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(74)))));
            this.pnSearchBox.Controls.Add(this.rtbSearch);
            this.pnSearchBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnSearchBox.Location = new System.Drawing.Point(0, 0);
            this.pnSearchBox.Name = "pnSearchBox";
            this.pnSearchBox.Padding = new System.Windows.Forms.Padding(25, 5, 0, 5);
            this.pnSearchBox.Size = new System.Drawing.Size(695, 30);
            this.pnSearchBox.TabIndex = 3;
            // 
            // pnSearch
            // 
            this.pnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(39)))), ((int)(((byte)(38)))));
            this.pnSearch.Controls.Add(this.pnSearchBox);
            this.pnSearch.Controls.Add(this.pnSplitterSearchBar);
            this.pnSearch.Controls.Add(this.pnBtnSearch);
            this.pnSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.pnSearch.Location = new System.Drawing.Point(0, 0);
            this.pnSearch.Margin = new System.Windows.Forms.Padding(0);
            this.pnSearch.Name = "pnSearch";
            this.pnSearch.Size = new System.Drawing.Size(800, 30);
            this.pnSearch.TabIndex = 6;
            // 
            // pnTable
            // 
            this.pnTable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(39)))), ((int)(((byte)(38)))));
            this.pnTable.Controls.Add(this.dgvMeter);
            this.pnTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnTable.Location = new System.Drawing.Point(0, 30);
            this.pnTable.Margin = new System.Windows.Forms.Padding(0);
            this.pnTable.Name = "pnTable";
            this.pnTable.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.pnTable.Size = new System.Drawing.Size(800, 420);
            this.pnTable.TabIndex = 7;
            // 
            // dgvMeter
            // 
            this.dgvMeter.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.dgvMeter.AllowUserToAddRows = false;
            this.dgvMeter.AllowUserToDeleteRows = false;
            this.dgvMeter.AllowUserToResizeColumns = false;
            this.dgvMeter.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Lato", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dgvMeter.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMeter.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(74)))));
            this.dgvMeter.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMeter.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvMeter.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(74)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Lato", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(74)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMeter.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMeter.ColumnHeadersHeight = 50;
            this.dgvMeter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvMeter.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FillingPoint,
            this.Order,
            this.StartTime,
            this.StopTime,
            this.StartTotalizerLq,
            this.StopTotalizerLq,
            this.StartTotalizerVp,
            this.StopTotalixerVp,
            this.Loaded,
            this.LoadedCoriolis});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(74)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Lato Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(43)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMeter.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvMeter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMeter.EnableHeadersVisualStyles = false;
            this.dgvMeter.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(74)))));
            this.dgvMeter.Location = new System.Drawing.Point(0, 20);
            this.dgvMeter.Margin = new System.Windows.Forms.Padding(0);
            this.dgvMeter.MultiSelect = false;
            this.dgvMeter.Name = "dgvMeter";
            this.dgvMeter.ReadOnly = true;
            this.dgvMeter.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(74)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Lato Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMeter.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvMeter.RowHeadersVisible = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(74)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Lato", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(43)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMeter.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvMeter.RowTemplate.Height = 40;
            this.dgvMeter.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMeter.Size = new System.Drawing.Size(800, 400);
            this.dgvMeter.TabIndex = 1;
            // 
            // FillingPoint
            // 
            this.FillingPoint.FillWeight = 200F;
            this.FillingPoint.HeaderText = "Filling Point";
            this.FillingPoint.Name = "FillingPoint";
            this.FillingPoint.ReadOnly = true;
            this.FillingPoint.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FillingPoint.Width = 200;
            // 
            // Order
            // 
            this.Order.FillWeight = 150F;
            this.Order.HeaderText = "Order";
            this.Order.Name = "Order";
            this.Order.ReadOnly = true;
            this.Order.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Order.Width = 150;
            // 
            // StartTime
            // 
            this.StartTime.FillWeight = 150F;
            this.StartTime.HeaderText = "Start Time";
            this.StartTime.Name = "StartTime";
            this.StartTime.ReadOnly = true;
            this.StartTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.StartTime.Width = 150;
            // 
            // StopTime
            // 
            this.StopTime.FillWeight = 150F;
            this.StopTime.HeaderText = "Stop Time";
            this.StopTime.Name = "StopTime";
            this.StopTime.ReadOnly = true;
            this.StopTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.StopTime.Width = 150;
            // 
            // StartTotalizerLq
            // 
            this.StartTotalizerLq.FillWeight = 150F;
            this.StartTotalizerLq.HeaderText = "Start Totalizer (Lq)";
            this.StartTotalizerLq.Name = "StartTotalizerLq";
            this.StartTotalizerLq.ReadOnly = true;
            this.StartTotalizerLq.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.StartTotalizerLq.Width = 150;
            // 
            // StopTotalizerLq
            // 
            this.StopTotalizerLq.HeaderText = "Stop Totalizer (Lq)";
            this.StopTotalizerLq.Name = "StopTotalizerLq";
            this.StopTotalizerLq.ReadOnly = true;
            this.StopTotalizerLq.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.StopTotalizerLq.Width = 150;
            // 
            // StartTotalizerVp
            // 
            this.StartTotalizerVp.HeaderText = "Start Totalixer (Vp)";
            this.StartTotalizerVp.Name = "StartTotalizerVp";
            this.StartTotalizerVp.ReadOnly = true;
            this.StartTotalizerVp.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // StopTotalixerVp
            // 
            this.StopTotalixerVp.HeaderText = "Stop Totalixer (Vp)";
            this.StopTotalixerVp.Name = "StopTotalixerVp";
            this.StopTotalixerVp.ReadOnly = true;
            this.StopTotalixerVp.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Loaded
            // 
            this.Loaded.HeaderText = "Loaded";
            this.Loaded.Name = "Loaded";
            this.Loaded.ReadOnly = true;
            this.Loaded.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Loaded.Width = 150;
            // 
            // LoadedCoriolis
            // 
            this.LoadedCoriolis.HeaderText = "Loaded Coriolis";
            this.LoadedCoriolis.Name = "LoadedCoriolis";
            this.LoadedCoriolis.ReadOnly = true;
            this.LoadedCoriolis.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // MeterReadingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnTable);
            this.Controls.Add(this.pnSearch);
            this.Name = "MeterReadingForm";
            this.Text = "MeterReading";
            this.Load += new System.EventHandler(this.MeterReadingForm_Load);
            this.pnBtnSearch.ResumeLayout(false);
            this.pnSearchBox.ResumeLayout(false);
            this.pnSearch.ResumeLayout(false);
            this.pnTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMeter)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Button btnSearch;
        private Panel pnSplitterSearchBar;
        private Panel pnBtnSearch;
        private RichTextBox rtbSearch;
        private Panel pnSearchBox;
        private Panel pnSearch;
        //private DataGridViewTextBoxColumn FillingPoint;
        private DataGridViewTextBoxColumn Order;
        private DataGridViewTextBoxColumn StartTime;
        private DataGridViewTextBoxColumn StopTime;
        private DataGridViewTextBoxColumn StartTotalizerLq;
        private DataGridViewTextBoxColumn StopTotalizerLq;
        private DataGridViewTextBoxColumn StartTotalizerVp;
        private DataGridViewTextBoxColumn StopTotalizerVp;
        private Panel pnTable;
        private DataGridView dgvMeter;
        private DataGridViewTextBoxColumn FillingPoint;
        private DataGridViewTextBoxColumn StopTotalixerVp;
        private DataGridViewTextBoxColumn Loaded;
        private DataGridViewTextBoxColumn LoadedCoriolis;
    }
}