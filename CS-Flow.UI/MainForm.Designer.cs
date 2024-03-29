﻿namespace CS_Flow.UI
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnSideBar = new System.Windows.Forms.Panel();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnGraphical = new System.Windows.Forms.Button();
            this.btnEventLog = new System.Windows.Forms.Button();
            this.btnMeterReading = new System.Windows.Forms.Button();
            this.btnFillingPoint = new System.Windows.Forms.Button();
            this.btnTransaction = new System.Windows.Forms.Button();
            this.btnWorkFlow = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnTopBar = new System.Windows.Forms.Panel();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnWindowSize = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnContent = new System.Windows.Forms.Panel();
            this.tm_ack = new System.Windows.Forms.Timer(this.components);
            this.pnSideBar.SuspendLayout();
            this.panel4.SuspendLayout();
            this.pnTopBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnSideBar
            // 
            this.pnSideBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(38)))), ((int)(((byte)(50)))));
            this.pnSideBar.Controls.Add(this.btnSettings);
            this.pnSideBar.Controls.Add(this.btnGraphical);
            this.pnSideBar.Controls.Add(this.btnEventLog);
            this.pnSideBar.Controls.Add(this.btnMeterReading);
            this.pnSideBar.Controls.Add(this.btnFillingPoint);
            this.pnSideBar.Controls.Add(this.btnTransaction);
            this.pnSideBar.Controls.Add(this.btnWorkFlow);
            this.pnSideBar.Controls.Add(this.panel4);
            this.pnSideBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnSideBar.Location = new System.Drawing.Point(0, 0);
            this.pnSideBar.Name = "pnSideBar";
            this.pnSideBar.Size = new System.Drawing.Size(180, 480);
            this.pnSideBar.TabIndex = 0;
            // 
            // btnSettings
            // 
            this.btnSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSettings.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Font = new System.Drawing.Font("Lato", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSettings.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnSettings.Image = global::CS_Flow.Properties.Resources.icSettings;
            this.btnSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSettings.Location = new System.Drawing.Point(0, 430);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnSettings.Size = new System.Drawing.Size(180, 50);
            this.btnSettings.TabIndex = 9;
            this.btnSettings.Text = "    Settings";
            this.btnSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnGraphical
            // 
            this.btnGraphical.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGraphical.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGraphical.FlatAppearance.BorderSize = 0;
            this.btnGraphical.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGraphical.Font = new System.Drawing.Font("Lato", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnGraphical.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnGraphical.Image = global::CS_Flow.Properties.Resources.icGraphics;
            this.btnGraphical.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGraphical.Location = new System.Drawing.Point(0, 350);
            this.btnGraphical.Name = "btnGraphical";
            this.btnGraphical.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnGraphical.Size = new System.Drawing.Size(180, 50);
            this.btnGraphical.TabIndex = 7;
            this.btnGraphical.Text = "    Graphical";
            this.btnGraphical.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGraphical.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGraphical.UseVisualStyleBackColor = true;
            this.btnGraphical.Click += new System.EventHandler(this.btnGraphical_Click);
            // 
            // btnEventLog
            // 
            this.btnEventLog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEventLog.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEventLog.FlatAppearance.BorderSize = 0;
            this.btnEventLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEventLog.Font = new System.Drawing.Font("Lato", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnEventLog.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnEventLog.Image = global::CS_Flow.Properties.Resources.icEventLog;
            this.btnEventLog.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEventLog.Location = new System.Drawing.Point(0, 300);
            this.btnEventLog.Name = "btnEventLog";
            this.btnEventLog.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnEventLog.Size = new System.Drawing.Size(180, 50);
            this.btnEventLog.TabIndex = 6;
            this.btnEventLog.Text = "    Event Log";
            this.btnEventLog.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEventLog.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEventLog.UseVisualStyleBackColor = true;
            this.btnEventLog.Click += new System.EventHandler(this.btnEventLog_Click);
            // 
            // btnMeterReading
            // 
            this.btnMeterReading.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMeterReading.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMeterReading.FlatAppearance.BorderSize = 0;
            this.btnMeterReading.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMeterReading.Font = new System.Drawing.Font("Lato", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnMeterReading.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnMeterReading.Image = global::CS_Flow.Properties.Resources.icMeterReading;
            this.btnMeterReading.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMeterReading.Location = new System.Drawing.Point(0, 250);
            this.btnMeterReading.Name = "btnMeterReading";
            this.btnMeterReading.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnMeterReading.Size = new System.Drawing.Size(180, 50);
            this.btnMeterReading.TabIndex = 5;
            this.btnMeterReading.Text = "    Meter Reading";
            this.btnMeterReading.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMeterReading.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMeterReading.UseVisualStyleBackColor = true;
            this.btnMeterReading.Click += new System.EventHandler(this.btnMeterReading_Click);
            // 
            // btnFillingPoint
            // 
            this.btnFillingPoint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFillingPoint.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFillingPoint.FlatAppearance.BorderSize = 0;
            this.btnFillingPoint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFillingPoint.Font = new System.Drawing.Font("Lato", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnFillingPoint.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnFillingPoint.Image = global::CS_Flow.Properties.Resources.icFillingPoint;
            this.btnFillingPoint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFillingPoint.Location = new System.Drawing.Point(0, 200);
            this.btnFillingPoint.Name = "btnFillingPoint";
            this.btnFillingPoint.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnFillingPoint.Size = new System.Drawing.Size(180, 50);
            this.btnFillingPoint.TabIndex = 4;
            this.btnFillingPoint.Text = "    Filling Point";
            this.btnFillingPoint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFillingPoint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFillingPoint.UseVisualStyleBackColor = true;
            this.btnFillingPoint.Click += new System.EventHandler(this.btnFillingPoint_Click);
            // 
            // btnTransaction
            // 
            this.btnTransaction.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTransaction.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTransaction.FlatAppearance.BorderSize = 0;
            this.btnTransaction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransaction.Font = new System.Drawing.Font("Lato", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnTransaction.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnTransaction.Image = global::CS_Flow.Properties.Resources.icTransaction;
            this.btnTransaction.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTransaction.Location = new System.Drawing.Point(0, 150);
            this.btnTransaction.Name = "btnTransaction";
            this.btnTransaction.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnTransaction.Size = new System.Drawing.Size(180, 50);
            this.btnTransaction.TabIndex = 3;
            this.btnTransaction.Text = "    Transaction";
            this.btnTransaction.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTransaction.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTransaction.UseVisualStyleBackColor = true;
            this.btnTransaction.Click += new System.EventHandler(this.btnTransaction_Click);
            // 
            // btnWorkFlow
            // 
            this.btnWorkFlow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWorkFlow.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnWorkFlow.FlatAppearance.BorderSize = 0;
            this.btnWorkFlow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWorkFlow.Font = new System.Drawing.Font("Lato", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnWorkFlow.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnWorkFlow.Image = global::CS_Flow.Properties.Resources.icWorkFlow;
            this.btnWorkFlow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnWorkFlow.Location = new System.Drawing.Point(0, 100);
            this.btnWorkFlow.Name = "btnWorkFlow";
            this.btnWorkFlow.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnWorkFlow.Size = new System.Drawing.Size(180, 50);
            this.btnWorkFlow.TabIndex = 2;
            this.btnWorkFlow.Text = "    Work Flow";
            this.btnWorkFlow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnWorkFlow.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnWorkFlow.UseVisualStyleBackColor = true;
            this.btnWorkFlow.Click += new System.EventHandler(this.btnWorkFlow_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(180, 100);
            this.panel4.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bebas Neue", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(35, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 41);
            this.label1.TabIndex = 0;
            this.label1.Text = "CS-Flow";
            // 
            // pnTopBar
            // 
            this.pnTopBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(38)))), ((int)(((byte)(50)))));
            this.pnTopBar.Controls.Add(this.btnMinimize);
            this.pnTopBar.Controls.Add(this.btnWindowSize);
            this.pnTopBar.Controls.Add(this.btnClose);
            this.pnTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTopBar.Location = new System.Drawing.Point(180, 0);
            this.pnTopBar.Name = "pnTopBar";
            this.pnTopBar.Padding = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.pnTopBar.Size = new System.Drawing.Size(592, 40);
            this.pnTopBar.TabIndex = 1;
            // 
            // btnMinimize
            // 
            this.btnMinimize.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Image = global::CS_Flow.Properties.Resources.icMinimize;
            this.btnMinimize.Location = new System.Drawing.Point(497, 5);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(30, 30);
            this.btnMinimize.TabIndex = 2;
            this.btnMinimize.UseMnemonic = false;
            this.btnMinimize.UseVisualStyleBackColor = true;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnWindowSize
            // 
            this.btnWindowSize.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnWindowSize.FlatAppearance.BorderSize = 0;
            this.btnWindowSize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWindowSize.Image = global::CS_Flow.Properties.Resources.icRestoreDown;
            this.btnWindowSize.Location = new System.Drawing.Point(527, 5);
            this.btnWindowSize.Name = "btnWindowSize";
            this.btnWindowSize.Size = new System.Drawing.Size(30, 30);
            this.btnWindowSize.TabIndex = 1;
            this.btnWindowSize.UseMnemonic = false;
            this.btnWindowSize.UseVisualStyleBackColor = true;
            this.btnWindowSize.Click += new System.EventHandler(this.btnWindowSize_Click);
            // 
            // btnClose
            // 
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::CS_Flow.Properties.Resources.icClose;
            this.btnClose.Location = new System.Drawing.Point(557, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(30, 30);
            this.btnClose.TabIndex = 0;
            this.btnClose.UseMnemonic = false;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnContent
            // 
            this.pnContent.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnContent.ForeColor = System.Drawing.SystemColors.ControlText;
            this.pnContent.Location = new System.Drawing.Point(180, 40);
            this.pnContent.Name = "pnContent";
            this.pnContent.Size = new System.Drawing.Size(592, 440);
            this.pnContent.TabIndex = 2;
            // 
            // tm_ack
            // 
            this.tm_ack.Tick += new System.EventHandler(this.tm_ack_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(772, 480);
            this.Controls.Add(this.pnContent);
            this.Controls.Add(this.pnTopBar);
            this.Controls.Add(this.pnSideBar);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseUp);
            this.pnSideBar.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.pnTopBar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel pnSideBar;
        private Button btnWorkFlow;
        private Panel panel4;
        private Label label1;
        private Panel pnTopBar;
        private Panel pnContent;
        private Button btnSettings;
        private Button btnGraphical;
        private Button btnEventLog;
        private Button btnMeterReading;
        private Button btnFillingPoint;
        private Button btnTransaction;
        private Button btnMinimize;
        private Button btnWindowSize;
        private Button btnClose;
        private System.Windows.Forms.Timer tm_ack;
    }
}