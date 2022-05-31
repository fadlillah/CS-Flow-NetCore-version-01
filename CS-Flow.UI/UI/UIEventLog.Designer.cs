namespace CS_Flow.UI
{
    partial class UIEventLogForm
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
            this.pnRow1 = new System.Windows.Forms.Panel();
            this.pnSearchBox = new System.Windows.Forms.Panel();
            this.rtbSearch = new System.Windows.Forms.RichTextBox();
            this.pnSplitterSearchBar = new System.Windows.Forms.Panel();
            this.pnBtnSearch = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.pnRow2 = new System.Windows.Forms.Panel();
            this.dgvLog = new System.Windows.Forms.DataGridView();
            this.timeStamp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.logMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnRow1.SuspendLayout();
            this.pnSearchBox.SuspendLayout();
            this.pnBtnSearch.SuspendLayout();
            this.pnRow2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).BeginInit();
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
            this.pnRow1.TabIndex = 4;
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
            this.pnRow2.Controls.Add(this.dgvLog);
            this.pnRow2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnRow2.Location = new System.Drawing.Point(0, 40);
            this.pnRow2.Margin = new System.Windows.Forms.Padding(0);
            this.pnRow2.Name = "pnRow2";
            this.pnRow2.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.pnRow2.Size = new System.Drawing.Size(800, 410);
            this.pnRow2.TabIndex = 6;
            // 
            // dgvLog
            // 
            this.dgvLog.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.dgvLog.AllowUserToAddRows = false;
            this.dgvLog.AllowUserToDeleteRows = false;
            this.dgvLog.AllowUserToResizeColumns = false;
            this.dgvLog.AllowUserToResizeRows = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Lato", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(38)))), ((int)(((byte)(50)))));
            this.dgvLog.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvLog.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLog.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLog.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvLog.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Lato", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(156)))), ((int)(((byte)(175)))));
            dataGridViewCellStyle7.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(156)))), ((int)(((byte)(175)))));
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLog.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvLog.ColumnHeadersHeight = 50;
            this.dgvLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.timeStamp,
            this.logMessage});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Lato Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(38)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle8.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(43)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLog.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLog.EnableHeadersVisualStyles = false;
            this.dgvLog.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvLog.Location = new System.Drawing.Point(0, 20);
            this.dgvLog.Margin = new System.Windows.Forms.Padding(0);
            this.dgvLog.MultiSelect = false;
            this.dgvLog.Name = "dgvLog";
            this.dgvLog.ReadOnly = true;
            this.dgvLog.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Lato Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(156)))), ((int)(((byte)(175)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLog.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvLog.RowHeadersVisible = false;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Lato", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(38)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(38)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLog.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvLog.RowTemplate.Height = 40;
            this.dgvLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLog.Size = new System.Drawing.Size(800, 390);
            this.dgvLog.TabIndex = 0;
            // 
            // timeStamp
            // 
            this.timeStamp.HeaderText = "Time Stamp";
            this.timeStamp.Name = "timeStamp";
            this.timeStamp.ReadOnly = true;
            // 
            // logMessage
            // 
            this.logMessage.HeaderText = "Log Message";
            this.logMessage.Name = "logMessage";
            this.logMessage.ReadOnly = true;
            // 
            // UIEventLogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnRow2);
            this.Controls.Add(this.pnRow1);
            this.Name = "UIEventLogForm";
            this.Text = "EventLog";
            this.Load += new System.EventHandler(this.EventLogForm_Load);
            this.pnRow1.ResumeLayout(false);
            this.pnSearchBox.ResumeLayout(false);
            this.pnBtnSearch.ResumeLayout(false);
            this.pnRow2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).EndInit();
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
        private DataGridView dgvLog;
        private DataGridViewTextBoxColumn timeStamp;
        private DataGridViewTextBoxColumn logMessage;
    }
}