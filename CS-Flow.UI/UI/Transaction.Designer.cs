namespace CS_Flow.UI
{
    partial class TransactionForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnTable = new System.Windows.Forms.Panel();
            this.dgvTransaction = new System.Windows.Forms.DataGridView();
            this.Batch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AssignTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Preset = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Loaded = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GateIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GateOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoadedCoriolis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSearch = new System.Windows.Forms.Button();
            this.pnSplitterSearchBar = new System.Windows.Forms.Panel();
            this.pnBtnSearch = new System.Windows.Forms.Panel();
            this.rtbSearch = new System.Windows.Forms.RichTextBox();
            this.pnSearchBox = new System.Windows.Forms.Panel();
            this.pnSearch = new System.Windows.Forms.Panel();
            this.pnTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransaction)).BeginInit();
            this.pnBtnSearch.SuspendLayout();
            this.pnSearchBox.SuspendLayout();
            this.pnSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnTable
            // 
            this.pnTable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(39)))), ((int)(((byte)(38)))));
            this.pnTable.Controls.Add(this.dgvTransaction);
            this.pnTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnTable.Location = new System.Drawing.Point(0, 30);
            this.pnTable.Margin = new System.Windows.Forms.Padding(0);
            this.pnTable.Name = "pnTable";
            this.pnTable.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.pnTable.Size = new System.Drawing.Size(800, 420);
            this.pnTable.TabIndex = 5;
            // 
            // dgvTransaction
            // 
            this.dgvTransaction.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.dgvTransaction.AllowUserToAddRows = false;
            this.dgvTransaction.AllowUserToDeleteRows = false;
            this.dgvTransaction.AllowUserToResizeColumns = false;
            this.dgvTransaction.AllowUserToResizeRows = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Lato", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dgvTransaction.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvTransaction.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(74)))));
            this.dgvTransaction.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTransaction.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvTransaction.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(74)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Lato", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(74)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTransaction.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvTransaction.ColumnHeadersHeight = 50;
            this.dgvTransaction.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvTransaction.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Batch,
            this.Status,
            this.Product,
            this.AssignTo,
            this.Preset,
            this.Pin,
            this.Loaded,
            this.GateIn,
            this.GateOut,
            this.LoadedCoriolis});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(74)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Lato Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(43)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTransaction.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvTransaction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTransaction.EnableHeadersVisualStyles = false;
            this.dgvTransaction.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(74)))));
            this.dgvTransaction.Location = new System.Drawing.Point(0, 20);
            this.dgvTransaction.Margin = new System.Windows.Forms.Padding(0);
            this.dgvTransaction.MultiSelect = false;
            this.dgvTransaction.Name = "dgvTransaction";
            this.dgvTransaction.ReadOnly = true;
            this.dgvTransaction.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(74)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Lato Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTransaction.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvTransaction.RowHeadersVisible = false;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(74)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Lato", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(43)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTransaction.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvTransaction.RowTemplate.Height = 40;
            this.dgvTransaction.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTransaction.Size = new System.Drawing.Size(800, 400);
            this.dgvTransaction.TabIndex = 0;
            // 
            // Batch
            // 
            this.Batch.FillWeight = 200F;
            this.Batch.HeaderText = "Batch";
            this.Batch.Name = "Batch";
            this.Batch.ReadOnly = true;
            this.Batch.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Batch.Width = 200;
            // 
            // Status
            // 
            this.Status.FillWeight = 150F;
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Status.Width = 150;
            // 
            // Product
            // 
            this.Product.FillWeight = 150F;
            this.Product.HeaderText = "Product";
            this.Product.Name = "Product";
            this.Product.ReadOnly = true;
            this.Product.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Product.Width = 150;
            // 
            // AssignTo
            // 
            this.AssignTo.FillWeight = 150F;
            this.AssignTo.HeaderText = "Assign To";
            this.AssignTo.Name = "AssignTo";
            this.AssignTo.ReadOnly = true;
            this.AssignTo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.AssignTo.Width = 150;
            // 
            // Preset
            // 
            this.Preset.FillWeight = 150F;
            this.Preset.HeaderText = "Preset";
            this.Preset.Name = "Preset";
            this.Preset.ReadOnly = true;
            this.Preset.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Preset.Width = 150;
            // 
            // Pin
            // 
            this.Pin.HeaderText = "PIN";
            this.Pin.Name = "Pin";
            this.Pin.ReadOnly = true;
            this.Pin.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Pin.Width = 150;
            // 
            // Loaded
            // 
            this.Loaded.HeaderText = "Loaded";
            this.Loaded.Name = "Loaded";
            this.Loaded.ReadOnly = true;
            this.Loaded.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Loaded.Width = 150;
            // 
            // GateIn
            // 
            this.GateIn.HeaderText = "Gate In";
            this.GateIn.Name = "GateIn";
            this.GateIn.ReadOnly = true;
            this.GateIn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // GateOut
            // 
            this.GateOut.HeaderText = "Gate Out";
            this.GateOut.Name = "GateOut";
            this.GateOut.ReadOnly = true;
            this.GateOut.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // LoadedCoriolis
            // 
            this.LoadedCoriolis.HeaderText = "Loaded Coriolis";
            this.LoadedCoriolis.Name = "LoadedCoriolis";
            this.LoadedCoriolis.ReadOnly = true;
            this.LoadedCoriolis.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
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
            this.pnSearch.TabIndex = 3;
            // 
            // TransactionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnTable);
            this.Controls.Add(this.pnSearch);
            this.Name = "TransactionForm";
            this.Text = "Transaction";
            this.Load += new System.EventHandler(this.TransactionForm_Load);
            this.pnTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransaction)).EndInit();
            this.pnBtnSearch.ResumeLayout(false);
            this.pnSearchBox.ResumeLayout(false);
            this.pnSearch.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Panel pnTable;
        private DataGridView dgvTransaction;
        private Button btnSearch;
        private Panel pnSplitterSearchBar;
        private Panel pnBtnSearch;
        private RichTextBox rtbSearch;
        private Panel pnSearchBox;
        private Panel pnSearch;
        private DataGridViewTextBoxColumn Batch;
        private DataGridViewTextBoxColumn Status;
        private DataGridViewTextBoxColumn Product;
        private DataGridViewTextBoxColumn AssignTo;
        private DataGridViewTextBoxColumn Preset;
        private DataGridViewTextBoxColumn Pin;
        private DataGridViewTextBoxColumn Loaded;
        private DataGridViewTextBoxColumn GateIn;
        private DataGridViewTextBoxColumn GateOut;
        private DataGridViewTextBoxColumn LoadedCoriolis;
    }
}