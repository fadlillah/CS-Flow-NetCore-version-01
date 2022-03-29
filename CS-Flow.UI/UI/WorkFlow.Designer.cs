namespace CS_Flow.UI
{
    partial class WorkFlowForm
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
            this.pnSearch = new System.Windows.Forms.Panel();
            this.btSearch = new System.Windows.Forms.Button();
            this.rtbSearch = new System.Windows.Forms.RichTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btCompleted = new CS_Flow.UI.csButton();
            this.btInterrupted = new CS_Flow.UI.csButton();
            this.btInProgress = new CS_Flow.UI.csButton();
            this.btStandBy = new CS_Flow.UI.csButton();
            this.btShowAll = new CS_Flow.UI.csButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvFlow = new System.Windows.Forms.DataGridView();
            this.Order = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Truck = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AssignTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Loaded = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnSearch.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFlow)).BeginInit();
            this.SuspendLayout();
            // 
            // pnSearch
            // 
            this.pnSearch.Controls.Add(this.btSearch);
            this.pnSearch.Controls.Add(this.rtbSearch);
            this.pnSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.pnSearch.Location = new System.Drawing.Point(0, 0);
            this.pnSearch.Name = "pnSearch";
            this.pnSearch.Padding = new System.Windows.Forms.Padding(5);
            this.pnSearch.Size = new System.Drawing.Size(800, 50);
            this.pnSearch.TabIndex = 0;
            // 
            // btSearch
            // 
            this.btSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(74)))));
            this.btSearch.Dock = System.Windows.Forms.DockStyle.Right;
            this.btSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btSearch.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btSearch.Location = new System.Drawing.Point(720, 5);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(75, 40);
            this.btSearch.TabIndex = 2;
            this.btSearch.Text = "Search";
            this.btSearch.UseVisualStyleBackColor = false;
            // 
            // rtbSearch
            // 
            this.rtbSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(74)))));
            this.rtbSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbSearch.Location = new System.Drawing.Point(5, 5);
            this.rtbSearch.Margin = new System.Windows.Forms.Padding(3, 3, 50, 3);
            this.rtbSearch.Multiline = false;
            this.rtbSearch.Name = "rtbSearch";
            this.rtbSearch.Size = new System.Drawing.Size(790, 40);
            this.rtbSearch.TabIndex = 0;
            this.rtbSearch.Text = "";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btCompleted);
            this.panel2.Controls.Add(this.btInterrupted);
            this.panel2.Controls.Add(this.btInProgress);
            this.panel2.Controls.Add(this.btStandBy);
            this.panel2.Controls.Add(this.btShowAll);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 50);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(20, 30, 20, 30);
            this.panel2.Size = new System.Drawing.Size(800, 100);
            this.panel2.TabIndex = 1;
            // 
            // btCompleted
            // 
            this.btCompleted.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(74)))));
            this.btCompleted.Dock = System.Windows.Forms.DockStyle.Left;
            this.btCompleted.FlatAppearance.BorderSize = 0;
            this.btCompleted.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCompleted.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btCompleted.ForeColor = System.Drawing.Color.White;
            this.btCompleted.Location = new System.Drawing.Point(620, 30);
            this.btCompleted.Name = "btCompleted";
            this.btCompleted.Size = new System.Drawing.Size(150, 40);
            this.btCompleted.TabIndex = 4;
            this.btCompleted.Text = "Completed";
            this.btCompleted.UseVisualStyleBackColor = false;
            this.btCompleted.Click += new System.EventHandler(this.btCompleted_Click);
            // 
            // btInterrupted
            // 
            this.btInterrupted.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(74)))));
            this.btInterrupted.Dock = System.Windows.Forms.DockStyle.Left;
            this.btInterrupted.FlatAppearance.BorderSize = 0;
            this.btInterrupted.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btInterrupted.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btInterrupted.ForeColor = System.Drawing.Color.White;
            this.btInterrupted.Location = new System.Drawing.Point(470, 30);
            this.btInterrupted.Name = "btInterrupted";
            this.btInterrupted.Size = new System.Drawing.Size(150, 40);
            this.btInterrupted.TabIndex = 3;
            this.btInterrupted.Text = "Interruted";
            this.btInterrupted.UseVisualStyleBackColor = false;
            this.btInterrupted.Click += new System.EventHandler(this.btInterrupted_Click);
            // 
            // btInProgress
            // 
            this.btInProgress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(74)))));
            this.btInProgress.Dock = System.Windows.Forms.DockStyle.Left;
            this.btInProgress.FlatAppearance.BorderSize = 0;
            this.btInProgress.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btInProgress.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btInProgress.ForeColor = System.Drawing.Color.White;
            this.btInProgress.Location = new System.Drawing.Point(320, 30);
            this.btInProgress.Name = "btInProgress";
            this.btInProgress.Size = new System.Drawing.Size(150, 40);
            this.btInProgress.TabIndex = 2;
            this.btInProgress.Text = "In Progress";
            this.btInProgress.UseVisualStyleBackColor = false;
            this.btInProgress.Click += new System.EventHandler(this.btInProgress_Click);
            // 
            // btStandBy
            // 
            this.btStandBy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(74)))));
            this.btStandBy.Dock = System.Windows.Forms.DockStyle.Left;
            this.btStandBy.FlatAppearance.BorderSize = 0;
            this.btStandBy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btStandBy.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btStandBy.ForeColor = System.Drawing.Color.White;
            this.btStandBy.Location = new System.Drawing.Point(170, 30);
            this.btStandBy.Name = "btStandBy";
            this.btStandBy.Size = new System.Drawing.Size(150, 40);
            this.btStandBy.TabIndex = 1;
            this.btStandBy.Text = "Stand By";
            this.btStandBy.UseVisualStyleBackColor = false;
            this.btStandBy.Click += new System.EventHandler(this.btStandBy_Click);
            // 
            // btShowAll
            // 
            this.btShowAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(74)))));
            this.btShowAll.Dock = System.Windows.Forms.DockStyle.Left;
            this.btShowAll.FlatAppearance.BorderSize = 0;
            this.btShowAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btShowAll.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btShowAll.ForeColor = System.Drawing.Color.White;
            this.btShowAll.Location = new System.Drawing.Point(20, 30);
            this.btShowAll.Name = "btShowAll";
            this.btShowAll.Size = new System.Drawing.Size(150, 40);
            this.btShowAll.TabIndex = 0;
            this.btShowAll.Text = "Show All";
            this.btShowAll.UseVisualStyleBackColor = false;
            this.btShowAll.Click += new System.EventHandler(this.btShowAll_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvFlow);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 150);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(800, 300);
            this.panel3.TabIndex = 2;
            // 
            // dgvFlow
            // 
            this.dgvFlow.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.dgvFlow.AllowUserToAddRows = false;
            this.dgvFlow.AllowUserToDeleteRows = false;
            this.dgvFlow.AllowUserToResizeColumns = false;
            this.dgvFlow.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dgvFlow.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvFlow.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(74)))));
            this.dgvFlow.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvFlow.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvFlow.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(74)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(74)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(74)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvFlow.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvFlow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFlow.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Order,
            this.Truck,
            this.Product,
            this.AssignTo,
            this.Column5,
            this.Pin,
            this.Loaded});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvFlow.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvFlow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFlow.EnableHeadersVisualStyles = false;
            this.dgvFlow.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(74)))));
            this.dgvFlow.Location = new System.Drawing.Point(0, 0);
            this.dgvFlow.Name = "dgvFlow";
            this.dgvFlow.ReadOnly = true;
            this.dgvFlow.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(74)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFlow.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvFlow.RowHeadersVisible = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(74)))));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            this.dgvFlow.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvFlow.RowTemplate.Height = 25;
            this.dgvFlow.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFlow.Size = new System.Drawing.Size(800, 300);
            this.dgvFlow.TabIndex = 0;
            this.dgvFlow.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFlow_CellClick);
            // 
            // Order
            // 
            this.Order.FillWeight = 200F;
            this.Order.HeaderText = "Order";
            this.Order.Name = "Order";
            this.Order.ReadOnly = true;
            this.Order.Width = 200;
            // 
            // Truck
            // 
            this.Truck.FillWeight = 150F;
            this.Truck.HeaderText = "Truck";
            this.Truck.Name = "Truck";
            this.Truck.ReadOnly = true;
            this.Truck.Width = 150;
            // 
            // Product
            // 
            this.Product.FillWeight = 150F;
            this.Product.HeaderText = "Product";
            this.Product.Name = "Product";
            this.Product.ReadOnly = true;
            this.Product.Width = 150;
            // 
            // AssignTo
            // 
            this.AssignTo.FillWeight = 150F;
            this.AssignTo.HeaderText = "Preset";
            this.AssignTo.Name = "AssignTo";
            this.AssignTo.ReadOnly = true;
            this.AssignTo.Width = 150;
            // 
            // Column5
            // 
            this.Column5.FillWeight = 150F;
            this.Column5.HeaderText = "Assign To";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 150;
            // 
            // Pin
            // 
            this.Pin.HeaderText = "PIN";
            this.Pin.Name = "Pin";
            this.Pin.ReadOnly = true;
            this.Pin.Width = 150;
            // 
            // Loaded
            // 
            this.Loaded.HeaderText = "Loaded";
            this.Loaded.Name = "Loaded";
            this.Loaded.ReadOnly = true;
            this.Loaded.Width = 150;
            // 
            // WorkFlowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(39)))), ((int)(((byte)(38)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnSearch);
            this.Name = "WorkFlowForm";
            this.Text = "WorkFlow";
            this.Load += new System.EventHandler(this.WorkFlowForm_Load);
            this.pnSearch.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFlow)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel pnSearch;
        private RichTextBox rtbSearch;
        private Panel panel2;
        private Panel panel3;
        private Button btSearch;
        private DataGridView dgvFlow;
        private DataGridViewTextBoxColumn Order;
        private DataGridViewTextBoxColumn Truck;
        private DataGridViewTextBoxColumn Product;
        private DataGridViewTextBoxColumn AssignTo;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Pin;
        private DataGridViewTextBoxColumn Loaded;
        private csButton btCompleted;
        private csButton btInterrupted;
        private csButton btInProgress;
        private csButton btStandBy;
        private csButton btShowAll;
    }
}