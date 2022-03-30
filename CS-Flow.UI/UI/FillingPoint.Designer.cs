namespace CS_Flow.UI
{
    partial class FillingPointForm
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
            this.pnSearch = new System.Windows.Forms.Panel();
            this.pnSearchBox = new System.Windows.Forms.Panel();
            this.rtbSearch = new System.Windows.Forms.RichTextBox();
            this.pnSplitterSearchBar = new System.Windows.Forms.Panel();
            this.pnBtnSearch = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.pnTable = new System.Windows.Forms.Panel();
            this.dgvFlow = new System.Windows.Forms.DataGridView();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Enabled = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tank_Temp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tank_Dens = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FDM_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnSearch.SuspendLayout();
            this.pnSearchBox.SuspendLayout();
            this.pnBtnSearch.SuspendLayout();
            this.pnTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFlow)).BeginInit();
            this.SuspendLayout();
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
            this.pnSearch.TabIndex = 1;
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
            this.rtbSearch.Enter += new System.EventHandler(this.rtbSearch_Enter);
            this.rtbSearch.Leave += new System.EventHandler(this.rtbSearch_Leave);
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
            // pnTable
            // 
            this.pnTable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(39)))), ((int)(((byte)(38)))));
            this.pnTable.Controls.Add(this.dgvFlow);
            this.pnTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnTable.Location = new System.Drawing.Point(0, 30);
            this.pnTable.Margin = new System.Windows.Forms.Padding(0);
            this.pnTable.Name = "pnTable";
            this.pnTable.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.pnTable.Size = new System.Drawing.Size(800, 420);
            this.pnTable.TabIndex = 3;
            // 
            // dgvFlow
            // 
            this.dgvFlow.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.dgvFlow.AllowUserToAddRows = false;
            this.dgvFlow.AllowUserToDeleteRows = false;
            this.dgvFlow.AllowUserToResizeColumns = false;
            this.dgvFlow.AllowUserToResizeRows = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Lato", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dgvFlow.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvFlow.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(74)))));
            this.dgvFlow.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvFlow.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvFlow.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(74)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Lato", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(43)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvFlow.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvFlow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFlow.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Name,
            this.FGroup,
            this.Product,
            this.Enabled,
            this.Tank,
            this.Tank_Temp,
            this.Tank_Dens,
            this.FDM_ID});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(74)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Lato", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(43)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFlow.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvFlow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFlow.EnableHeadersVisualStyles = false;
            this.dgvFlow.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(74)))));
            this.dgvFlow.Location = new System.Drawing.Point(0, 20);
            this.dgvFlow.Margin = new System.Windows.Forms.Padding(0);
            this.dgvFlow.Name = "dgvFlow";
            this.dgvFlow.ReadOnly = true;
            this.dgvFlow.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(74)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Lato Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFlow.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvFlow.RowHeadersVisible = false;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(74)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Lato", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(43)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFlow.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvFlow.RowTemplate.Height = 40;
            this.dgvFlow.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFlow.Size = new System.Drawing.Size(800, 400);
            this.dgvFlow.TabIndex = 0;
            // 
            // Name
            // 
            this.Name.FillWeight = 200F;
            this.Name.HeaderText = "Name";
            this.Name.Name = "Name";
            this.Name.ReadOnly = true;
            this.Name.Width = 200;
            // 
            // FGroup
            // 
            this.FGroup.FillWeight = 150F;
            this.FGroup.HeaderText = "Fgroup";
            this.FGroup.Name = "FGroup";
            this.FGroup.ReadOnly = true;
            this.FGroup.Width = 150;
            // 
            // Product
            // 
            this.Product.FillWeight = 150F;
            this.Product.HeaderText = "Product";
            this.Product.Name = "Product";
            this.Product.ReadOnly = true;
            this.Product.Width = 150;
            // 
            // Enabled
            // 
            this.Enabled.FillWeight = 150F;
            this.Enabled.HeaderText = "Enabled";
            this.Enabled.Name = "Enabled";
            this.Enabled.ReadOnly = true;
            this.Enabled.Width = 150;
            // 
            // Tank
            // 
            this.Tank.FillWeight = 150F;
            this.Tank.HeaderText = "Tank";
            this.Tank.Name = "Tank";
            this.Tank.ReadOnly = true;
            this.Tank.Width = 150;
            // 
            // Tank_Temp
            // 
            this.Tank_Temp.HeaderText = "Tank Temperature";
            this.Tank_Temp.Name = "Tank_Temp";
            this.Tank_Temp.ReadOnly = true;
            this.Tank_Temp.Width = 150;
            // 
            // Tank_Dens
            // 
            this.Tank_Dens.HeaderText = "Tank Density";
            this.Tank_Dens.Name = "Tank_Dens";
            this.Tank_Dens.ReadOnly = true;
            this.Tank_Dens.Width = 150;
            // 
            // FDM_ID
            // 
            this.FDM_ID.HeaderText = "FDM ID";
            this.FDM_ID.Name = "FDM_ID";
            this.FDM_ID.ReadOnly = true;
            // 
            // FillingPointForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnTable);
            this.Controls.Add(this.pnSearch);
            //this.Name = "FillingPointForm";
            this.Text = "FillingPoint";
            this.Load += new System.EventHandler(this.FillingPoint_Load);
            this.pnSearch.ResumeLayout(false);
            this.pnSearchBox.ResumeLayout(false);
            this.pnBtnSearch.ResumeLayout(false);
            this.pnTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFlow)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel pnSearch;
        private Panel pnSearchBox;
        private RichTextBox rtbSearch;
        private Panel pnSplitterSearchBar;
        private Panel pnBtnSearch;
        private Button btnSearch;
        private Panel pnTable;
        private DataGridView dgvFlow;
        private DataGridViewTextBoxColumn Name;
        private DataGridViewTextBoxColumn FGroup;
        private DataGridViewTextBoxColumn Product;
        private DataGridViewTextBoxColumn Enabled;
        private DataGridViewTextBoxColumn Tank;
        private DataGridViewTextBoxColumn Tank_Temp;
        private DataGridViewTextBoxColumn Tank_Dens;
        private DataGridViewTextBoxColumn FDM_ID;
    }
}