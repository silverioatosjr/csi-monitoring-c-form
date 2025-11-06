namespace CSIEmployeeMonitoringSystem.Forms.Dtr
{
    partial class frmCurrentLogs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCurrentLogs));
            this.dgvDtr = new System.Windows.Forms.DataGridView();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.room = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timerDtrTemp = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDtr)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDtr
            // 
            this.dgvDtr.AllowUserToAddRows = false;
            this.dgvDtr.AllowUserToDeleteRows = false;
            this.dgvDtr.AllowUserToResizeColumns = false;
            this.dgvDtr.AllowUserToResizeRows = false;
            this.dgvDtr.BackgroundColor = System.Drawing.Color.LightSteelBlue;
            this.dgvDtr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDtr.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.subject,
            this.time,
            this.room});
            this.dgvDtr.Enabled = false;
            this.dgvDtr.Location = new System.Drawing.Point(24, 25);
            this.dgvDtr.Name = "dgvDtr";
            this.dgvDtr.ReadOnly = true;
            this.dgvDtr.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDtr.Size = new System.Drawing.Size(735, 433);
            this.dgvDtr.TabIndex = 2;
            // 
            // name
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name.DefaultCellStyle = dataGridViewCellStyle1;
            this.name.HeaderText = "EMPLOYEE";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 230;
            // 
            // subject
            // 
            this.subject.HeaderText = "SUBJECT";
            this.subject.Name = "subject";
            this.subject.ReadOnly = true;
            this.subject.Width = 260;
            // 
            // time
            // 
            this.time.HeaderText = "TIME";
            this.time.Name = "time";
            this.time.ReadOnly = true;
            // 
            // room
            // 
            this.room.HeaderText = "ROOM";
            this.room.Name = "room";
            this.room.ReadOnly = true;
            // 
            // timerDtrTemp
            // 
            this.timerDtrTemp.Interval = 30000;
            // 
            // frmCurrentLogs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 485);
            this.Controls.Add(this.dgvDtr);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCurrentLogs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Current Logs";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmCurrentLogs_FormClosed);
            this.Load += new System.EventHandler(this.frmCurrentLogs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDtr)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDtr;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn subject;
        private System.Windows.Forms.DataGridViewTextBoxColumn time;
        private System.Windows.Forms.DataGridViewTextBoxColumn room;
        private System.Windows.Forms.Timer timerDtrTemp;
    }
}