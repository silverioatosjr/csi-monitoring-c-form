namespace CSIEmployeeMonitoringSystem.Forms.Dtr
{
    partial class frmDTR
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDTR));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.windowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuClose = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewLogs = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLoggedIn = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTodaysLogs = new System.Windows.Forms.ToolStripMenuItem();
            this.viewDTRsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewDTR = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLogTime = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 561);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1274, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.windowToolStripMenuItem,
            this.mnuViewLogs,
            this.viewDTRsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1274, 25);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // windowToolStripMenuItem
            // 
            this.windowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuClose});
            this.windowToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.windowToolStripMenuItem.Name = "windowToolStripMenuItem";
            this.windowToolStripMenuItem.Size = new System.Drawing.Size(71, 21);
            this.windowToolStripMenuItem.Text = "Window";
            // 
            // mnuClose
            // 
            this.mnuClose.Name = "mnuClose";
            this.mnuClose.Size = new System.Drawing.Size(109, 22);
            this.mnuClose.Text = "Close";
            // 
            // mnuViewLogs
            // 
            this.mnuViewLogs.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuLoggedIn,
            this.mnuTodaysLogs});
            this.mnuViewLogs.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuViewLogs.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.mnuViewLogs.Name = "mnuViewLogs";
            this.mnuViewLogs.Size = new System.Drawing.Size(83, 21);
            this.mnuViewLogs.Text = "View Logs";
            // 
            // mnuLoggedIn
            // 
            this.mnuLoggedIn.Name = "mnuLoggedIn";
            this.mnuLoggedIn.Size = new System.Drawing.Size(141, 22);
            this.mnuLoggedIn.Text = "Logged In";
            // 
            // mnuTodaysLogs
            // 
            this.mnuTodaysLogs.Name = "mnuTodaysLogs";
            this.mnuTodaysLogs.Size = new System.Drawing.Size(141, 22);
            this.mnuTodaysLogs.Text = "Daily Logs";
            // 
            // viewDTRsToolStripMenuItem
            // 
            this.viewDTRsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuViewDTR});
            this.viewDTRsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewDTRsToolStripMenuItem.Name = "viewDTRsToolStripMenuItem";
            this.viewDTRsToolStripMenuItem.Size = new System.Drawing.Size(86, 21);
            this.viewDTRsToolStripMenuItem.Text = "View DTRs";
            // 
            // mnuViewDTR
            // 
            this.mnuViewDTR.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuViewDTR.Name = "mnuViewDTR";
            this.mnuViewDTR.Size = new System.Drawing.Size(136, 22);
            this.mnuViewDTR.Text = "View DTR";
            // 
            // btnLogTime
            // 
            this.btnLogTime.BackColor = System.Drawing.Color.MediumBlue;
            this.btnLogTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogTime.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLogTime.Location = new System.Drawing.Point(45, 270);
            this.btnLogTime.Name = "btnLogTime";
            this.btnLogTime.Size = new System.Drawing.Size(228, 69);
            this.btnLogTime.TabIndex = 0;
            this.btnLogTime.Text = "LOG YOUR TIME";
            this.btnLogTime.UseVisualStyleBackColor = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Image = global::CSIEmployeeMonitoringSystem.Properties.Resources.Gemini_Generated_Image_mfnae4mfnae4mfna;
            this.pictureBox2.Location = new System.Drawing.Point(0, 28);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1274, 144);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 100000;
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btnLogTime);
            this.panel1.Location = new System.Drawing.Point(459, 178);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(319, 365);
            this.panel1.TabIndex = 13;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CSIEmployeeMonitoringSystem.Properties.Resources._9187604;
            this.pictureBox1.Location = new System.Drawing.Point(45, 26);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(228, 226);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // frmDTR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(1274, 583);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmDTR";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CSI DTR SYSTEM";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmDTR_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuViewLogs;
        private System.Windows.Forms.ToolStripMenuItem mnuLoggedIn;
        private System.Windows.Forms.ToolStripMenuItem mnuTodaysLogs;
        private System.Windows.Forms.Button btnLogTime;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem windowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuClose;
        private System.Windows.Forms.ToolStripMenuItem viewDTRsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuViewDTR;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}