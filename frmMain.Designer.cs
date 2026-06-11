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
            this.mnuEmployees = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSchedule = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDtr = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPayroll = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuArchivedPayroll = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUsersManual = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.mnuConnectToServer = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLogin = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuChangePassword = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCloseWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEmployeeRegistration = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEmployeesList = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddSchedule = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCurrentDtr = new System.Windows.Forms.ToolStripMenuItem();
            this.manualEntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTeachingStaffs = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNonTeachingStaffs = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDtrHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCurrentPayroll = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.mnuMainStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // mnuMainStrip
            // 
            this.mnuMainStrip.BackColor = System.Drawing.Color.LightSteelBlue;
            this.mnuMainStrip.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuMainStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.mnuEmployees,
            this.mnuSchedule,
            this.mnuDtr,
            this.mnuPayroll,
            this.helpToolStripMenuItem});
            this.mnuMainStrip.Location = new System.Drawing.Point(0, 0);
            this.mnuMainStrip.Name = "mnuMainStrip";
            this.mnuMainStrip.Size = new System.Drawing.Size(1350, 25);
            this.mnuMainStrip.TabIndex = 0;
            this.mnuMainStrip.Text = "csiMainMenu";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuConnectToServer,
            this.mnuLogin,
            this.mnuChangePassword,
            this.mnuCloseWindow});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(71, 21);
            this.toolStripMenuItem1.Text = "Window";
            // 
            // mnuEmployees
            // 
            this.mnuEmployees.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEmployeeRegistration,
            this.mnuEmployeesList});
            this.mnuEmployees.Name = "mnuEmployees";
            this.mnuEmployees.Size = new System.Drawing.Size(86, 21);
            this.mnuEmployees.Text = "Employees";
            // 
            // mnuSchedule
            // 
            this.mnuSchedule.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAddSchedule});
            this.mnuSchedule.Name = "mnuSchedule";
            this.mnuSchedule.Size = new System.Drawing.Size(81, 21);
            this.mnuSchedule.Text = "Schedules";
            // 
            // mnuDtr
            // 
            this.mnuDtr.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCurrentDtr,
            this.manualEntryToolStripMenuItem,
            this.mnuDtrHistory});
            this.mnuDtr.Name = "mnuDtr";
            this.mnuDtr.Size = new System.Drawing.Size(46, 21);
            this.mnuDtr.Text = "DTR";
            // 
            // mnuPayroll
            // 
            this.mnuPayroll.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCurrentPayroll,
            this.mnuArchivedPayroll});
            this.mnuPayroll.Name = "mnuPayroll";
            this.mnuPayroll.Size = new System.Drawing.Size(63, 21);
            this.mnuPayroll.Text = "Payroll";
            // 
            // mnuArchivedPayroll
            // 
            this.mnuArchivedPayroll.Image = global::CSIEmployeeMonitoringSystem.Properties.Resources.archive;
            this.mnuArchivedPayroll.Name = "mnuArchivedPayroll";
            this.mnuArchivedPayroll.Size = new System.Drawing.Size(152, 22);
            this.mnuArchivedPayroll.Text = "Archived";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuUsersManual});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(49, 21);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // mnuUsersManual
            // 
            this.mnuUsersManual.Name = "mnuUsersManual";
            this.mnuUsersManual.Size = new System.Drawing.Size(162, 22);
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
            // mnuConnectToServer
            // 
            this.mnuConnectToServer.Image = global::CSIEmployeeMonitoringSystem.Properties.Resources.connectServer;
            this.mnuConnectToServer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mnuConnectToServer.Name = "mnuConnectToServer";
            this.mnuConnectToServer.Size = new System.Drawing.Size(186, 22);
            this.mnuConnectToServer.Text = "Connect to Server";
            // 
            // mnuLogin
            // 
            this.mnuLogin.Image = global::CSIEmployeeMonitoringSystem.Properties.Resources.key;
            this.mnuLogin.Name = "mnuLogin";
            this.mnuLogin.Size = new System.Drawing.Size(186, 22);
            this.mnuLogin.Text = "Login";
            // 
            // mnuChangePassword
            // 
            this.mnuChangePassword.Image = global::CSIEmployeeMonitoringSystem.Properties.Resources.password;
            this.mnuChangePassword.Name = "mnuChangePassword";
            this.mnuChangePassword.Size = new System.Drawing.Size(186, 22);
            this.mnuChangePassword.Text = "Change Password";
            // 
            // mnuCloseWindow
            // 
            this.mnuCloseWindow.Image = global::CSIEmployeeMonitoringSystem.Properties.Resources.close;
            this.mnuCloseWindow.Name = "mnuCloseWindow";
            this.mnuCloseWindow.Size = new System.Drawing.Size(186, 22);
            this.mnuCloseWindow.Text = "Close";
            // 
            // mnuEmployeeRegistration
            // 
            this.mnuEmployeeRegistration.Image = global::CSIEmployeeMonitoringSystem.Properties.Resources.register;
            this.mnuEmployeeRegistration.Name = "mnuEmployeeRegistration";
            this.mnuEmployeeRegistration.Size = new System.Drawing.Size(151, 22);
            this.mnuEmployeeRegistration.Text = "Registration";
            // 
            // mnuEmployeesList
            // 
            this.mnuEmployeesList.Image = global::CSIEmployeeMonitoringSystem.Properties.Resources.employeeList;
            this.mnuEmployeesList.Name = "mnuEmployeesList";
            this.mnuEmployeesList.Size = new System.Drawing.Size(151, 22);
            this.mnuEmployeesList.Text = "List";
            // 
            // mnuAddSchedule
            // 
            this.mnuAddSchedule.Image = global::CSIEmployeeMonitoringSystem.Properties.Resources.schedule;
            this.mnuAddSchedule.Name = "mnuAddSchedule";
            this.mnuAddSchedule.Size = new System.Drawing.Size(192, 22);
            this.mnuAddSchedule.Text = "Subjects Schedules";
            // 
            // mnuCurrentDtr
            // 
            this.mnuCurrentDtr.Image = global::CSIEmployeeMonitoringSystem.Properties.Resources.dtr;
            this.mnuCurrentDtr.Name = "mnuCurrentDtr";
            this.mnuCurrentDtr.Size = new System.Drawing.Size(159, 22);
            this.mnuCurrentDtr.Text = "Current";
            // 
            // manualEntryToolStripMenuItem
            // 
            this.manualEntryToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTeachingStaffs,
            this.mnuNonTeachingStaffs});
            this.manualEntryToolStripMenuItem.Image = global::CSIEmployeeMonitoringSystem.Properties.Resources.manual;
            this.manualEntryToolStripMenuItem.Name = "manualEntryToolStripMenuItem";
            this.manualEntryToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.manualEntryToolStripMenuItem.Text = "Manual Entry";
            // 
            // mnuTeachingStaffs
            // 
            this.mnuTeachingStaffs.Image = global::CSIEmployeeMonitoringSystem.Properties.Resources.teacher_icon;
            this.mnuTeachingStaffs.Name = "mnuTeachingStaffs";
            this.mnuTeachingStaffs.Size = new System.Drawing.Size(199, 22);
            this.mnuTeachingStaffs.Text = "Teaching Staffs";
            // 
            // mnuNonTeachingStaffs
            // 
            this.mnuNonTeachingStaffs.Image = global::CSIEmployeeMonitoringSystem.Properties.Resources.nonteaching;
            this.mnuNonTeachingStaffs.Name = "mnuNonTeachingStaffs";
            this.mnuNonTeachingStaffs.Size = new System.Drawing.Size(199, 22);
            this.mnuNonTeachingStaffs.Text = "Non-teaching Staffs";
            // 
            // mnuDtrHistory
            // 
            this.mnuDtrHistory.Image = global::CSIEmployeeMonitoringSystem.Properties.Resources.dtrRecord;
            this.mnuDtrHistory.Name = "mnuDtrHistory";
            this.mnuDtrHistory.Size = new System.Drawing.Size(159, 22);
            this.mnuDtrHistory.Text = "List";
            // 
            // mnuCurrentPayroll
            // 
            this.mnuCurrentPayroll.Image = global::CSIEmployeeMonitoringSystem.Properties.Resources.payroll;
            this.mnuCurrentPayroll.Name = "mnuCurrentPayroll";
            this.mnuCurrentPayroll.Size = new System.Drawing.Size(152, 22);
            this.mnuCurrentPayroll.Text = "Current";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::CSIEmployeeMonitoringSystem.Properties.Resources.csi;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1350, 709);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 709);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.mnuMainStrip);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnuMainStrip;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Computer Systems Institute";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.mnuMainStrip.ResumeLayout(false);
            this.mnuMainStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem mnuChangePassword;
        private System.Windows.Forms.ToolStripMenuItem manualEntryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuTeachingStaffs;
        private System.Windows.Forms.ToolStripMenuItem mnuNonTeachingStaffs;
    }
}

