namespace CS_Flow.UI.Settings_tab
{
    partial class UIVisual_Settings
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
            this.pnBackground = new System.Windows.Forms.Panel();
            this.pnListCheckBox = new System.Windows.Forms.Panel();
            this.pnBgListCheckbox = new System.Windows.Forms.Panel();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.pnBtnControl = new System.Windows.Forms.Panel();
            this.btnRename = new System.Windows.Forms.Button();
            this.btnMoveUp = new System.Windows.Forms.Button();
            this.btnMoveDown = new System.Windows.Forms.Button();
            this.pnListBox = new System.Windows.Forms.Panel();
            this.pnBgListBox = new System.Windows.Forms.Panel();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.pnBackground.SuspendLayout();
            this.pnListCheckBox.SuspendLayout();
            this.pnBgListCheckbox.SuspendLayout();
            this.pnBtnControl.SuspendLayout();
            this.pnListBox.SuspendLayout();
            this.pnBgListBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnBackground
            // 
            this.pnBackground.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(38)))), ((int)(((byte)(50)))));
            this.pnBackground.Controls.Add(this.pnListCheckBox);
            this.pnBackground.Controls.Add(this.pnBtnControl);
            this.pnBackground.Controls.Add(this.pnListBox);
            this.pnBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnBackground.Location = new System.Drawing.Point(0, 0);
            this.pnBackground.Name = "pnBackground";
            this.pnBackground.Size = new System.Drawing.Size(800, 450);
            this.pnBackground.TabIndex = 1;
            // 
            // pnListCheckBox
            // 
            this.pnListCheckBox.Controls.Add(this.pnBgListCheckbox);
            this.pnListCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnListCheckBox.Location = new System.Drawing.Point(200, 0);
            this.pnListCheckBox.Name = "pnListCheckBox";
            this.pnListCheckBox.Size = new System.Drawing.Size(600, 420);
            this.pnListCheckBox.TabIndex = 5;
            // 
            // pnBgListCheckbox
            // 
            this.pnBgListCheckbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(21)))), ((int)(((byte)(27)))));
            this.pnBgListCheckbox.Controls.Add(this.checkedListBox1);
            this.pnBgListCheckbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnBgListCheckbox.Location = new System.Drawing.Point(0, 0);
            this.pnBgListCheckbox.Name = "pnBgListCheckbox";
            this.pnBgListCheckbox.Padding = new System.Windows.Forms.Padding(5);
            this.pnBgListCheckbox.Size = new System.Drawing.Size(600, 420);
            this.pnBgListCheckbox.TabIndex = 1;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(21)))), ((int)(((byte)(27)))));
            this.checkedListBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkedListBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBox1.Font = new System.Drawing.Font("Lato", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkedListBox1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "id|id",
            "order_id|Order",
            "batch_id|Batch",
            "status_string|Status",
            "product|Product",
            "filling_point|Assign To",
            "preset|Preset",
            "pin|PIN"});
            this.checkedListBox1.Location = new System.Drawing.Point(5, 5);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(590, 410);
            this.checkedListBox1.TabIndex = 0;
            // 
            // pnBtnControl
            // 
            this.pnBtnControl.Controls.Add(this.btnRename);
            this.pnBtnControl.Controls.Add(this.btnMoveUp);
            this.pnBtnControl.Controls.Add(this.btnMoveDown);
            this.pnBtnControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnBtnControl.Location = new System.Drawing.Point(200, 420);
            this.pnBtnControl.Margin = new System.Windows.Forms.Padding(0);
            this.pnBtnControl.Name = "pnBtnControl";
            this.pnBtnControl.Size = new System.Drawing.Size(600, 30);
            this.pnBtnControl.TabIndex = 4;
            // 
            // btnRename
            // 
            this.btnRename.AutoSize = true;
            this.btnRename.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(50)))), ((int)(((byte)(65)))));
            this.btnRename.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRename.FlatAppearance.BorderSize = 0;
            this.btnRename.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRename.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnRename.Location = new System.Drawing.Point(200, 0);
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(200, 30);
            this.btnRename.TabIndex = 1;
            this.btnRename.Text = "Rename";
            this.btnRename.UseVisualStyleBackColor = false;
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.AutoSize = true;
            this.btnMoveUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(50)))), ((int)(((byte)(65)))));
            this.btnMoveUp.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMoveUp.FlatAppearance.BorderSize = 0;
            this.btnMoveUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoveUp.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnMoveUp.Location = new System.Drawing.Point(400, 0);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(200, 30);
            this.btnMoveUp.TabIndex = 2;
            this.btnMoveUp.Text = "Move Up";
            this.btnMoveUp.UseVisualStyleBackColor = false;
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.AutoSize = true;
            this.btnMoveDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(50)))), ((int)(((byte)(65)))));
            this.btnMoveDown.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnMoveDown.FlatAppearance.BorderSize = 0;
            this.btnMoveDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoveDown.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnMoveDown.Location = new System.Drawing.Point(0, 0);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(200, 30);
            this.btnMoveDown.TabIndex = 0;
            this.btnMoveDown.Text = "Move Down";
            this.btnMoveDown.UseVisualStyleBackColor = false;
            // 
            // pnListBox
            // 
            this.pnListBox.Controls.Add(this.pnBgListBox);
            this.pnListBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnListBox.Location = new System.Drawing.Point(0, 0);
            this.pnListBox.Name = "pnListBox";
            this.pnListBox.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.pnListBox.Size = new System.Drawing.Size(200, 450);
            this.pnListBox.TabIndex = 3;
            // 
            // pnBgListBox
            // 
            this.pnBgListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(21)))), ((int)(((byte)(27)))));
            this.pnBgListBox.Controls.Add(this.listBox1);
            this.pnBgListBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnBgListBox.Location = new System.Drawing.Point(0, 0);
            this.pnBgListBox.Name = "pnBgListBox";
            this.pnBgListBox.Padding = new System.Windows.Forms.Padding(5);
            this.pnBgListBox.Size = new System.Drawing.Size(190, 157);
            this.pnBgListBox.TabIndex = 3;
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(21)))), ((int)(((byte)(27)))));
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.Font = new System.Drawing.Font("Lato", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listBox1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Items.AddRange(new object[] {
            "Transaction",
            "Filling Point",
            "Stand By",
            "In Progress",
            "Interrupted",
            "Completed"});
            this.listBox1.Location = new System.Drawing.Point(5, 5);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(180, 147);
            this.listBox1.TabIndex = 2;
            // 
            // UIVisual_Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnBackground);
            this.Name = "UIVisual_Settings";
            this.Text = "UIVisual_Settings";
            this.Load += new System.EventHandler(this.UIVisual_Settings_Load);
            this.pnBackground.ResumeLayout(false);
            this.pnListCheckBox.ResumeLayout(false);
            this.pnBgListCheckbox.ResumeLayout(false);
            this.pnBtnControl.ResumeLayout(false);
            this.pnBtnControl.PerformLayout();
            this.pnListBox.ResumeLayout(false);
            this.pnBgListBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel pnBackground;
        private Panel pnListCheckBox;
        private CheckedListBox checkedListBox1;
        private Panel pnBtnControl;
        private Button btnMoveDown;
        private Panel pnListBox;
        private ListBox listBox1;
        private Button btnMoveUp;
        private Button btnRename;
        private Panel pnBgListCheckbox;
        private Panel pnBgListBox;
    }
}