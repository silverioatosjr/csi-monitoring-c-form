namespace CSIEmployeeMonitoringSystem
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.mnuMainStrip = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuConnectToServer = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLogin = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCloseWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEmployees = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEmployeeRegistration = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEmployeesList = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSchedule = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddSchedule = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDtr = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCurrentDtr = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDtrHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPayroll = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCurrentPayroll = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuArchivedPayroll = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUsersManual = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.mnuMainStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuMainStrip
            // 
            this.mnuMainStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.mnuEmployees,
            this.mnuSchedule,
            this.mnuDtr,
            this.mnuPayroll,
            this.helpToolStripMenuItem});
            this.mnuMainStrip.Location = new System.Drawing.Point(0, 0);
            this.mnuMainStrip.Name = "mnuMainStrip";
            this.mnuMainStrip.Size = new System.Drawing.Size(1350, 24);
            this.mnuMainStrip.TabIndex = 0;
            this.mnuMainStrip.Text = "csiMainMenu";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuConnectToServer,
            this.mnuLogin,
            this.mnuCloseWindow});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(63, 20);
            this.toolStripMenuItem1.Text = "Window";
            // 
            // mnuConnectToServer
            // 
            this.mnuConnectToServer.Name = "mnuConnectToServer";
            this.mnuConnectToServer.Size = new System.Drawing.Size(168, 22);
            this.mnuConnectToServer.Text = "Connect to Server";
            // 
            // mnuLogin
            // 
            this.mnuLogin.Name = "mnuLogin";
            this.mnuLogin.Size = new System.Drawing.Size(168, 22);
            this.mnuLogin.Text = "Login";
            // 
            // mnuCloseWindow
            // 
            this.mnuCloseWindow.Name = "mnuCloseWindow";
            this.mnuCloseWindow.Size = new System.Drawing.Size(168, 22);
            this.mnuCloseWindow.Text = "Close";
            // 
            // mnuEmployees
            // 
            this.mnuEmployees.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEmployeeRegistration,
            this.mnuEmployeesList});
            this.mnuEmployees.Name = "mnuEmployees";
            this.mnuEmployees.Size = new System.Drawing.Size(76, 20);
            this.mnuEmployees.Text = "Employees";
            // 
            // mnuEmployeeRegistration
            // 
            this.mnuEmployeeRegistration.Name = "mnuEmployeeRegistration";
            this.mnuEmployeeRegistration.Size = new System.Drawing.Size(137, 22);
            this.mnuEmployeeRegistration.Text = "Registration";
            // 
            // mnuEmployeesList
            // 
            this.mnuEmployeesList.Name = "mnuEmployeesList";
            this.mnuEmployeesList.Size = new System.Drawing.Size(137, 22);
            this.mnuEmployeesList.Text = "List";
            // 
            // mnuSchedule
            // 
            this.mnuSchedule.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAddSchedule});
            this.mnuSchedule.Name = "mnuSchedule";
            this.mnuSchedule.Size = new System.Drawing.Size(72, 20);
            this.mnuSchedule.Text = "Schedules";
            // 
            // mnuAddSchedule
            // 
            this.mnuAddSchedule.Name = "mnuAddSchedule";
            this.mnuAddSchedule.Size = new System.Drawing.Size(169, 22);
            this.mnuAddSchedule.Text = "Subjects Schedule";
            // 
            // mnuDtr
            // 
            this.mnuDtr.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCurrentDtr,
            this.mnuDtrHistory});
            this.mnuDtr.Name = "mnuDtr";
            this.mnuDtr.Size = new System.Drawing.Size(39, 20);
            this.mnuDtr.Text = "DTR";
            // 
            // mnuCurrentDtr
            // 
            this.mnuCurrentDtr.Name = "mnuCurrentDtr";
            this.mnuCurrentDtr.Size = new System.Drawing.Size(152, 22);
            this.mnuCurrentDtr.Text = "Current";
            // 
            // mnuDtrHistory
            // 
            this.mnuDtrHistory.Name = "mnuDtrHistory";
            this.mnuDtrHistory.Size = new System.Drawing.Size(152, 22);
            this.mnuDtrHistory.Text = "List";
            // 
            // mnuPayroll
            // 
            this.mnuPayroll.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCurrentPayroll,
            this.mnuArchivedPayroll});
            this.mnuPayroll.Name = "mnuPayroll";
            this.mnuPayroll.Size = new System.Drawing.Size(55, 20);
            this.mnuPayroll.Text = "Payroll";
            // 
            // mnuCurrentPayroll
            // 
            this.mnuCurrentPayroll.Name = "mnuCurrentPayroll";
            this.mnuCurrentPayroll.Size = new System.Drawing.Size(121, 22);
            this.mnuCurrentPayroll.Text = "Current";
            // 
            // mnuArchivedPayroll
            // 
            this.mnuArchivedPayroll.Name = "mnuArchivedPayroll";
            this.mnuArchivedPayroll.Size = new System.Drawing.Size(121, 22);
            this.mnuArchivedPayroll.Text = "Archived";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuUsersManual});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // mnuUsersManual
            // 
            this.mnuUsersManual.Name = "mnuUsersManual";
            this.mnuUsersManual.Size = new System.Drawing.Size(148, 22);
            this.mnuUsersManual.Text = "User\'s Manual";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 687);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1350, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 709);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.mnuMainStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnuMainStrip;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Computer Systems Institute";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.mnuMainStrip.ResumeLayout(false);
            this.mnuMainStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuMainStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuCloseWindow;
        private System.Windows.Forms.ToolStripMenuItem mnuLogin;
        private System.Windows.Forms.ToolStripMenuItem mnuEmployees;
        private System.Windows.Forms.ToolStripMenuItem mnuEmployeeRegistration;
        private System.Windows.Forms.ToolStripMenuItem mnuEmployeesList;
        private System.Windows.Forms.ToolStripMenuItem mnuSchedule;
        private System.Windows.Forms.ToolStripMenuItem mnuAddSchedule;
        private System.Windows.Forms.ToolStripMenuItem mnuDtr;
        private System.Windows.Forms.ToolStripMenuItem mnuCurrentDtr;
        private System.Windows.Forms.ToolStripMenuItem mnuDtrHistory;
        private System.Windows.Forms.ToolStripMenuItem mnuPayroll;
        private System.Windows.Forms.ToolStripMenuItem mnuArchivedPayroll;
        private System.Windows.Forms.ToolStripMenuItem mnuCurrentPayroll;
        private System.Windows.Forms.ToolStripMenuItem mnuConnectToServer;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuUsersManual;
    }
}

