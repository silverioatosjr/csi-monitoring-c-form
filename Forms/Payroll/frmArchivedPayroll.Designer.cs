namespace CSIEmployeeMonitoringSystem.Forms.Payroll
{
    partial class frmArchivedPayroll
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmArchivedPayroll));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.optYear = new System.Windows.Forms.ComboBox();
            this.optMonth = new System.Windows.Forms.ComboBox();
            this.optEmployee = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
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
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrentPayroll)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.optYear);
            this.groupBox1.Controls.Add(this.optMonth);
            this.groupBox1.Controls.Add(this.optEmployee);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dgvCurrentPayroll);
            this.groupBox1.Location = new System.Drawing.Point(21, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1052, 536);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Archived Payroll";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(514, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Year:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(309, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Month:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(63, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Employee:";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSearch.Location = new System.Drawing.Point(691, 38);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 28);
            this.btnSearch.TabIndex = 16;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // optYear
            // 
            this.optYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.optYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optYear.FormattingEnabled = true;
            this.optYear.Location = new System.Drawing.Point(517, 39);
            this.optYear.Name = "optYear";
            this.optYear.Size = new System.Drawing.Size(154, 26);
            this.optYear.TabIndex = 15;
            // 
            // optMonth
            // 
            this.optMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.optMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optMonth.FormattingEnabled = true;
            this.optMonth.Location = new System.Drawing.Point(312, 39);
            this.optMonth.Name = "optMonth";
            this.optMonth.Size = new System.Drawing.Size(181, 26);
            this.optMonth.TabIndex = 14;
            // 
            // optEmployee
            // 
            this.optEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.optEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optEmployee.FormattingEnabled = true;
            this.optEmployee.Location = new System.Drawing.Point(66, 39);
            this.optEmployee.Name = "optEmployee";
            this.optEmployee.Size = new System.Drawing.Size(224, 26);
            this.optEmployee.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "Filter:";
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
            this.dgvCurrentPayroll.Location = new System.Drawing.Point(23, 73);
            this.dgvCurrentPayroll.MultiSelect = false;
            this.dgvCurrentPayroll.Name = "dgvCurrentPayroll";
            this.dgvCurrentPayroll.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCurrentPayroll.ShowEditingIcon = false;
            this.dgvCurrentPayroll.Size = new System.Drawing.Size(1005, 444);
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
            // frmArchivedPayroll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1095, 575);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmArchivedPayroll";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Payroll Record";
            this.Load += new System.EventHandler(this.frmArchivedPayroll_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrentPayroll)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
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
        private System.Windows.Forms.ComboBox optEmployee;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox optYear;
        private System.Windows.Forms.ComboBox optMonth;
    }
}