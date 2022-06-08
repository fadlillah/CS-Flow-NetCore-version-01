namespace CS_Flow.UI
{
    partial class UIWorkFlowForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnRow1 = new System.Windows.Forms.Panel();
            this.pnSearchBox = new System.Windows.Forms.Panel();
            this.rtbSearch = new System.Windows.Forms.RichTextBox();
            this.pnSplitterSearchBar = new System.Windows.Forms.Panel();
            this.pnBtnSearch = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.pnRow2 = new System.Windows.Forms.Panel();
            this.btnCompleted = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnInterrupted = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnInProgress = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnStandBy = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.pnRow3 = new System.Windows.Forms.Panel();
            this.dgvFlow = new System.Windows.Forms.DataGridView();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Order = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Truck = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Preset = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AssignTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Loaded = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsFlow = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsTruck = new System.Windows.Forms.ToolStripMenuItem();
            this.tsSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.tsTerminate = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMoveTo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsFS1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsFS2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsFS3 = new System.Windows.Forms.ToolStripMenuItem();
            this.pnRow1.SuspendLayout();
            this.pnSearchBox.SuspendLayout();
            this.pnBtnSearch.SuspendLayout();
            this.pnRow2.SuspendLayout();
            this.pnRow3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFlow)).BeginInit();
            this.cmsFlow.SuspendLayout();
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
            this.pnRow1.TabIndex = 0;
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
            this.rtbSearch.Enter += new System.EventHandler(this.rtbSearch_Enter);
            this.rtbSearch.Leave += new System.EventHandler(this.rtbSearch_Leave);
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
            this.pnRow2.Controls.Add(this.btnCompleted);
            this.pnRow2.Controls.Add(this.panel6);
            this.pnRow2.Controls.Add(this.btnInterrupted);
            this.pnRow2.Controls.Add(this.panel5);
            this.pnRow2.Controls.Add(this.btnInProgress);
            this.pnRow2.Controls.Add(this.panel4);
            this.pnRow2.Controls.Add(this.btnStandBy);
            this.pnRow2.Controls.Add(this.panel3);
            this.pnRow2.Controls.Add(this.btnShowAll);
            this.pnRow2.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnRow2.Location = new System.Drawing.Point(0, 40);
            this.pnRow2.Margin = new System.Windows.Forms.Padding(0);
            this.pnRow2.Name = "pnRow2";
            this.pnRow2.Padding = new System.Windows.Forms.Padding(30, 15, 0, 15);
            this.pnRow2.Size = new System.Drawing.Size(800, 60);
            this.pnRow2.TabIndex = 1;
            // 
            // btnCompleted
            // 
            this.btnCompleted.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(38)))), ((int)(((byte)(50)))));
            this.btnCompleted.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCompleted.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCompleted.FlatAppearance.BorderSize = 0;
            this.btnCompleted.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompleted.Font = new System.Drawing.Font("Lato", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCompleted.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnCompleted.Location = new System.Drawing.Point(510, 15);
            this.btnCompleted.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.btnCompleted.Name = "btnCompleted";
            this.btnCompleted.Size = new System.Drawing.Size(110, 30);
            this.btnCompleted.TabIndex = 13;
            this.btnCompleted.Text = "Completed";
            this.btnCompleted.UseVisualStyleBackColor = false;
            this.btnCompleted.Click += new System.EventHandler(this.btnCompleted_Click);
            // 
            // panel6
            // 
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(500, 15);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(10, 30);
            this.panel6.TabIndex = 12;
            // 
            // btnInterrupted
            // 
            this.btnInterrupted.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(38)))), ((int)(((byte)(50)))));
            this.btnInterrupted.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInterrupted.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnInterrupted.FlatAppearance.BorderSize = 0;
            this.btnInterrupted.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInterrupted.Font = new System.Drawing.Font("Lato", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnInterrupted.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnInterrupted.Location = new System.Drawing.Point(390, 15);
            this.btnInterrupted.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.btnInterrupted.Name = "btnInterrupted";
            this.btnInterrupted.Size = new System.Drawing.Size(110, 30);
            this.btnInterrupted.TabIndex = 11;
            this.btnInterrupted.Text = "Interrupted";
            this.btnInterrupted.UseVisualStyleBackColor = false;
            this.btnInterrupted.Click += new System.EventHandler(this.btnInterrupted_Click);
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(380, 15);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(10, 30);
            this.panel5.TabIndex = 10;
            // 
            // btnInProgress
            // 
            this.btnInProgress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(38)))), ((int)(((byte)(50)))));
            this.btnInProgress.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInProgress.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnInProgress.FlatAppearance.BorderSize = 0;
            this.btnInProgress.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInProgress.Font = new System.Drawing.Font("Lato", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnInProgress.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnInProgress.Location = new System.Drawing.Point(270, 15);
            this.btnInProgress.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.btnInProgress.Name = "btnInProgress";
            this.btnInProgress.Size = new System.Drawing.Size(110, 30);
            this.btnInProgress.TabIndex = 9;
            this.btnInProgress.Text = "In Progress";
            this.btnInProgress.UseVisualStyleBackColor = false;
            this.btnInProgress.Click += new System.EventHandler(this.btnInProgress_Click);
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(260, 15);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(10, 30);
            this.panel4.TabIndex = 8;
            // 
            // btnStandBy
            // 
            this.btnStandBy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(38)))), ((int)(((byte)(50)))));
            this.btnStandBy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStandBy.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnStandBy.FlatAppearance.BorderSize = 0;
            this.btnStandBy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStandBy.Font = new System.Drawing.Font("Lato", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnStandBy.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnStandBy.Location = new System.Drawing.Point(150, 15);
            this.btnStandBy.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.btnStandBy.Name = "btnStandBy";
            this.btnStandBy.Size = new System.Drawing.Size(110, 30);
            this.btnStandBy.TabIndex = 7;
            this.btnStandBy.Text = "Stand By";
            this.btnStandBy.UseVisualStyleBackColor = false;
            this.btnStandBy.Click += new System.EventHandler(this.btnStandBy_Click);
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(140, 15);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(10, 30);
            this.panel3.TabIndex = 6;
            // 
            // btnShowAll
            // 
            this.btnShowAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(38)))), ((int)(((byte)(50)))));
            this.btnShowAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShowAll.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnShowAll.FlatAppearance.BorderSize = 0;
            this.btnShowAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowAll.Font = new System.Drawing.Font("Lato", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnShowAll.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnShowAll.Location = new System.Drawing.Point(30, 15);
            this.btnShowAll.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(110, 30);
            this.btnShowAll.TabIndex = 5;
            this.btnShowAll.Text = "Show All";
            this.btnShowAll.UseVisualStyleBackColor = false;
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // pnRow3
            // 
            this.pnRow3.Controls.Add(this.dgvFlow);
            this.pnRow3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnRow3.Location = new System.Drawing.Point(0, 100);
            this.pnRow3.Margin = new System.Windows.Forms.Padding(0);
            this.pnRow3.Name = "pnRow3";
            this.pnRow3.Size = new System.Drawing.Size(800, 350);
            this.pnRow3.TabIndex = 2;
            // 
            // dgvFlow
            // 
            this.dgvFlow.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.dgvFlow.AllowUserToAddRows = false;
            this.dgvFlow.AllowUserToDeleteRows = false;
            this.dgvFlow.AllowUserToResizeColumns = false;
            this.dgvFlow.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Lato", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(38)))), ((int)(((byte)(50)))));
            this.dgvFlow.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvFlow.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFlow.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvFlow.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvFlow.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvFlow.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Lato", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(156)))), ((int)(((byte)(175)))));
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(156)))), ((int)(((byte)(175)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvFlow.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvFlow.ColumnHeadersHeight = 50;
            this.dgvFlow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvFlow.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.status,
            this.Order,
            this.Truck,
            this.Product,
            this.Preset,
            this.AssignTo,
            this.Pin,
            this.Loaded});
            this.dgvFlow.ContextMenuStrip = this.cmsFlow;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Lato Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(38)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(43)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFlow.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvFlow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFlow.EnableHeadersVisualStyles = false;
            this.dgvFlow.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.dgvFlow.Location = new System.Drawing.Point(0, 0);
            this.dgvFlow.Margin = new System.Windows.Forms.Padding(0);
            this.dgvFlow.MultiSelect = false;
            this.dgvFlow.Name = "dgvFlow";
            this.dgvFlow.ReadOnly = true;
            this.dgvFlow.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Lato Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(156)))), ((int)(((byte)(175)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFlow.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvFlow.RowHeadersVisible = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Lato", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(38)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(38)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFlow.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvFlow.RowTemplate.Height = 40;
            this.dgvFlow.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFlow.Size = new System.Drawing.Size(800, 350);
            this.dgvFlow.TabIndex = 0;
            this.dgvFlow.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFlow_CellClick);
            this.dgvFlow.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFlow_CellContentClick);
            this.dgvFlow.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvFlow_CellFormatting);
            // 
            // status
            // 
            this.status.HeaderText = "Status";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            // 
            // Order
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Order.DefaultCellStyle = dataGridViewCellStyle3;
            this.Order.FillWeight = 200F;
            this.Order.HeaderText = "Order";
            this.Order.Name = "Order";
            this.Order.ReadOnly = true;
            this.Order.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Truck
            // 
            this.Truck.FillWeight = 150F;
            this.Truck.HeaderText = "Truck";
            this.Truck.Name = "Truck";
            this.Truck.ReadOnly = true;
            this.Truck.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Product
            // 
            this.Product.FillWeight = 150F;
            this.Product.HeaderText = "Product";
            this.Product.Name = "Product";
            this.Product.ReadOnly = true;
            this.Product.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Preset
            // 
            this.Preset.FillWeight = 150F;
            this.Preset.HeaderText = "Preset";
            this.Preset.Name = "Preset";
            this.Preset.ReadOnly = true;
            this.Preset.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // AssignTo
            // 
            this.AssignTo.FillWeight = 150F;
            this.AssignTo.HeaderText = "Assign To";
            this.AssignTo.Name = "AssignTo";
            this.AssignTo.ReadOnly = true;
            this.AssignTo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Pin
            // 
            this.Pin.HeaderText = "PIN";
            this.Pin.Name = "Pin";
            this.Pin.ReadOnly = true;
            this.Pin.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Loaded
            // 
            this.Loaded.HeaderText = "Loaded";
            this.Loaded.Name = "Loaded";
            this.Loaded.ReadOnly = true;
            this.Loaded.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // cmsFlow
            // 
            this.cmsFlow.BackColor = System.Drawing.SystemColors.Control;
            this.cmsFlow.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsTruck,
            this.tsSeparator,
            this.tsTerminate,
            this.tsMoveTo});
            this.cmsFlow.Name = "contextMenuStrip1";
            this.cmsFlow.Size = new System.Drawing.Size(190, 98);
            this.cmsFlow.Opening += new System.ComponentModel.CancelEventHandler(this.cmsFlow_Opening);
            // 
            // tsTruck
            // 
            this.tsTruck.Enabled = false;
            this.tsTruck.Name = "tsTruck";
            this.tsTruck.Size = new System.Drawing.Size(189, 22);
            this.tsTruck.Text = "BE2893AX";
            // 
            // tsSeparator
            // 
            this.tsSeparator.Name = "tsSeparator";
            this.tsSeparator.Size = new System.Drawing.Size(186, 6);
            // 
            // tsTerminate
            // 
            this.tsTerminate.Name = "tsTerminate";
            this.tsTerminate.Size = new System.Drawing.Size(189, 22);
            this.tsTerminate.Text = "Terminate Transaction";
            // 
            // tsMoveTo
            // 
            this.tsMoveTo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsFS1,
            this.tsFS2,
            this.tsFS3});
            this.tsMoveTo.Name = "tsMoveTo";
            this.tsMoveTo.Size = new System.Drawing.Size(189, 22);
            this.tsMoveTo.Text = "Move To";
            // 
            // tsFS1
            // 
            this.tsFS1.Name = "tsFS1";
            this.tsFS1.Size = new System.Drawing.Size(180, 22);
            this.tsFS1.Text = "FS-1";
            this.tsFS1.Click += new System.EventHandler(this.tsFS1_Click);
            // 
            // tsFS2
            // 
            this.tsFS2.Name = "tsFS2";
            this.tsFS2.Size = new System.Drawing.Size(180, 22);
            this.tsFS2.Text = "FS-2";
            this.tsFS2.Click += new System.EventHandler(this.tsFS2_Click);
            // 
            // tsFS3
            // 
            this.tsFS3.Name = "tsFS3";
            this.tsFS3.Size = new System.Drawing.Size(180, 22);
            this.tsFS3.Text = "FS-3";
            this.tsFS3.Click += new System.EventHandler(this.tsFS3_Click);
            // 
            // UIWorkFlowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(39)))), ((int)(((byte)(38)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnRow3);
            this.Controls.Add(this.pnRow2);
            this.Controls.Add(this.pnRow1);
            this.Name = "UIWorkFlowForm";
            this.Text = "WorkFlow";
            this.Load += new System.EventHandler(this.WorkFlowForm_Load);
            this.pnRow1.ResumeLayout(false);
            this.pnSearchBox.ResumeLayout(false);
            this.pnBtnSearch.ResumeLayout(false);
            this.pnRow2.ResumeLayout(false);
            this.pnRow3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFlow)).EndInit();
            this.cmsFlow.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel pnRow1;
        private Panel pnRow2;
        private Panel pnRow3;
        private Button btnSearch;
        private DataGridView dgvFlow;
        private Button btnStandBy;
        private Panel panel3;
        private Button btnShowAll;
        private Button btnCompleted;
        private Panel panel6;
        private Button btnInterrupted;
        private Panel panel5;
        private Button btnInProgress;
        private Panel panel4;
        private Panel pnSearchBox;
        private RichTextBox rtbSearch;
        private Panel pnSplitterSearchBar;
        private Panel pnBtnSearch;
        private DataGridViewTextBoxColumn status;
        private DataGridViewTextBoxColumn Order;
        private DataGridViewTextBoxColumn Truck;
        private DataGridViewTextBoxColumn Product;
        private DataGridViewTextBoxColumn Preset;
        private DataGridViewTextBoxColumn AssignTo;
        private DataGridViewTextBoxColumn Pin;
        private DataGridViewTextBoxColumn Loaded;
        private ContextMenuStrip cmsFlow;
        private ToolStripSeparator tsSeparator;
        private ToolStripMenuItem tsTerminate;
        private ToolStripMenuItem tsMoveTo;
        private ToolStripMenuItem tsFS1;
        private ToolStripMenuItem tsFS2;
        private ToolStripMenuItem tsFS3;
        private ToolStripMenuItem tsTruck;
    }
}