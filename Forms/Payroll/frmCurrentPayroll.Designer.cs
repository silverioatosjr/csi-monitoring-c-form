namespace CSIEmployeeMonitoringSystem.Forms.Payroll
{
    partial class frmCurrentPayroll
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCurrentPayroll));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvCurrentPayroll = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.month = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.days = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.daysWorked = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalHours = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grossPay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.netPay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sss = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pagibig = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.philhealth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnGeneratePayroll = new System.Windows.Forms.Button();
            this.btnPrintSelected = new System.Windows.Forms.Button();
            this.btnDeleteCurrentPayroll = new System.Windows.Forms.Button();
            this.btnArchivePayroll = new System.Windows.Forms.Button();
            this.btnViewDetails = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuViewDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.printPayroll = new System.Drawing.Printing.PrintDocument();
            this.printPayrollDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.mnuPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrentPayroll)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvCurrentPayroll);
            this.groupBox1.Location = new System.Drawing.Point(24, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1052, 430);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Current Payroll";
            // 
            // dgvCurrentPayroll
            // 
            this.dgvCurrentPayroll.AllowUserToAddRows = false;
            this.dgvCurrentPayroll.AllowUserToDeleteRows = false;
            this.dgvCurrentPayroll.BackgroundColor = System.Drawing.Color.LightSteelBlue;
            this.dgvCurrentPayroll.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCurrentPayroll.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.employee,
            this.month,
            this.days,
            this.daysWorked,
            this.totalHours,
            this.grossPay,
            this.netPay,
            this.tax,
            this.sss,
            this.pagibig,
            this.philhealth});
            this.dgvCurrentPayroll.Location = new System.Drawing.Point(23, 31);
            this.dgvCurrentPayroll.MultiSelect = false;
            this.dgvCurrentPayroll.Name = "dgvCurrentPayroll";
            this.dgvCurrentPayroll.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCurrentPayroll.ShowEditingIcon = false;
            this.dgvCurrentPayroll.Size = new System.Drawing.Size(1005, 376);
            this.dgvCurrentPayroll.TabIndex = 0;
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.Visible = false;
            // 
            // employee
            // 
            this.employee.HeaderText = "EMPLOYEE";
            this.employee.Name = "employee";
            this.employee.Width = 200;
            // 
            // month
            // 
            this.month.HeaderText = "MONTH";
            this.month.Name = "month";
            this.month.Width = 150;
            // 
            // days
            // 
            this.days.HeaderText = "DAYS";
            this.days.Name = "days";
            // 
            // daysWorked
            // 
            this.daysWorked.HeaderText = "DAYS WORKED";
            this.daysWorked.Name = "daysWorked";
            this.daysWorked.Width = 140;
            // 
            // totalHours
            // 
            this.totalHours.HeaderText = "TOTAL HOURS";
            this.totalHours.Name = "totalHours";
            this.totalHours.Width = 140;
            // 
            // grossPay
            // 
            this.grossPay.HeaderText = "GROSS PAY";
            this.grossPay.Name = "grossPay";
            this.grossPay.Width = 130;
            // 
            // netPay
            // 
            this.netPay.HeaderText = "NET PAY";
            this.netPay.Name = "netPay";
            // 
            // tax
            // 
            this.tax.HeaderText = "TAX";
            this.tax.Name = "tax";
            // 
            // sss
            // 
            this.sss.HeaderText = "SSS";
            this.sss.Name = "sss";
            // 
            // pagibig
            // 
            this.pagibig.HeaderText = "PAGIBIG";
            this.pagibig.Name = "pagibig";
            // 
            // philhealth
            // 
            this.philhealth.HeaderText = "PHILHEALTH";
            this.philhealth.Name = "philhealth";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnGeneratePayroll);
            this.groupBox2.Controls.Add(this.btnPrintSelected);
            this.groupBox2.Controls.Add(this.btnDeleteCurrentPayroll);
            this.groupBox2.Controls.Add(this.btnArchivePayroll);
            this.groupBox2.Controls.Add(this.btnViewDetails);
            this.groupBox2.Controls.Add(this.btnClose);
            this.groupBox2.Location = new System.Drawing.Point(24, 467);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1052, 105);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Controls";
            // 
            // btnGeneratePayroll
            // 
            this.btnGeneratePayroll.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.btnGeneratePayroll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGeneratePayroll.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnGeneratePayroll.Location = new System.Drawing.Point(23, 35);
            this.btnGeneratePayroll.Name = "btnGeneratePayroll";
            this.btnGeneratePayroll.Size = new System.Drawing.Size(127, 42);
            this.btnGeneratePayroll.TabIndex = 18;
            this.btnGeneratePayroll.Text = "Generate Payroll";
            this.btnGeneratePayroll.UseVisualStyleBackColor = false;
            // 
            // btnPrintSelected
            // 
            this.btnPrintSelected.BackColor = System.Drawing.Color.SaddleBrown;
            this.btnPrintSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintSelected.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPrintSelected.Location = new System.Drawing.Point(452, 35);
            this.btnPrintSelected.Name = "btnPrintSelected";
            this.btnPrintSelected.Size = new System.Drawing.Size(127, 42);
            this.btnPrintSelected.TabIndex = 16;
            this.btnPrintSelected.Text = "Print Selected Payroll";
            this.btnPrintSelected.UseVisualStyleBackColor = false;
            // 
            // btnDeleteCurrentPayroll
            // 
            this.btnDeleteCurrentPayroll.BackColor = System.Drawing.Color.Firebrick;
            this.btnDeleteCurrentPayroll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteCurrentPayroll.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDeleteCurrentPayroll.Location = new System.Drawing.Point(756, 35);
            this.btnDeleteCurrentPayroll.Name = "btnDeleteCurrentPayroll";
            this.btnDeleteCurrentPayroll.Size = new System.Drawing.Size(127, 42);
            this.btnDeleteCurrentPayroll.TabIndex = 15;
            this.btnDeleteCurrentPayroll.Text = "Delete Current Payroll";
            this.btnDeleteCurrentPayroll.UseVisualStyleBackColor = false;
            // 
            // btnArchivePayroll
            // 
            this.btnArchivePayroll.BackColor = System.Drawing.Color.DarkKhaki;
            this.btnArchivePayroll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnArchivePayroll.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnArchivePayroll.Location = new System.Drawing.Point(309, 35);
            this.btnArchivePayroll.Name = "btnArchivePayroll";
            this.btnArchivePayroll.Size = new System.Drawing.Size(127, 42);
            this.btnArchivePayroll.TabIndex = 14;
            this.btnArchivePayroll.Text = "Archive Current Payroll";
            this.btnArchivePayroll.UseVisualStyleBackColor = false;
            // 
            // btnViewDetails
            // 
            this.btnViewDetails.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnViewDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewDetails.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnViewDetails.Location = new System.Drawing.Point(166, 35);
            this.btnViewDetails.Name = "btnViewDetails";
            this.btnViewDetails.Size = new System.Drawing.Size(127, 42);
            this.btnViewDetails.TabIndex = 13;
            this.btnViewDetails.Text = "View Details";
            this.btnViewDetails.UseVisualStyleBackColor = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.DarkGreen;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClose.Location = new System.Drawing.Point(901, 35);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(127, 42);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuViewDetails,
            this.mnuPrint});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(138, 48);
            // 
            // mnuViewDetails
            // 
            this.mnuViewDetails.Name = "mnuViewDetails";
            this.mnuViewDetails.Size = new System.Drawing.Size(137, 22);
            this.mnuViewDetails.Text = "View Details";
            // 
            // printPayroll
            // 
            this.printPayroll.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printPayroll_PrintPage);
            // 
            // printPayrollDialog
            // 
            this.printPayrollDialog.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPayrollDialog.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPayrollDialog.ClientSize = new System.Drawing.Size(400, 300);
            this.printPayrollDialog.Enabled = true;
            this.printPayrollDialog.Icon = ((System.Drawing.Icon)(resources.GetObject("printPayrollDialog.Icon")));
            this.printPayrollDialog.Name = "printPayrollDialog";
            this.printPayrollDialog.Visible = false;
            // 
            // mnuPrint
            // 
            this.mnuPrint.Name = "mnuPrint";
            this.mnuPrint.Size = new System.Drawing.Size(137, 22);
            this.mnuPrint.Text = "Print";
            // 
            // frmCurrentPayroll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1099, 595);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCurrentPayroll";
            this.Text = "Payroll";
            this.Load += new System.EventHandler(this.frmCurrentPayroll_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrentPayroll)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgvCurrentPayroll;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn employee;
        private System.Windows.Forms.DataGridViewTextBoxColumn month;
        private System.Windows.Forms.DataGridViewTextBoxColumn days;
        private System.Windows.Forms.DataGridViewTextBoxColumn daysWorked;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalHours;
        private System.Windows.Forms.DataGridViewTextBoxColumn grossPay;
        private System.Windows.Forms.DataGridViewTextBoxColumn netPay;
        private System.Windows.Forms.DataGridViewTextBoxColumn tax;
        private System.Windows.Forms.DataGridViewTextBoxColumn sss;
        private System.Windows.Forms.DataGridViewTextBoxColumn pagibig;
        private System.Windows.Forms.DataGridViewTextBoxColumn philhealth;
        private System.Windows.Forms.Button btnPrintSelected;
        private System.Windows.Forms.Button btnDeleteCurrentPayroll;
        private System.Windows.Forms.Button btnArchivePayroll;
        private System.Windows.Forms.Button btnViewDetails;
        private System.Windows.Forms.Button btnGeneratePayroll;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuViewDetails;
        private System.Drawing.Printing.PrintDocument printPayroll;
        private System.Windows.Forms.PrintPreviewDialog printPayrollDialog;
        private System.Windows.Forms.ToolStripMenuItem mnuPrint;
    }
}