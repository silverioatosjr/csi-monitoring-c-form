namespace CSIEmployeeMonitoringSystem.Forms.Employee
{
    partial class frmEmployeesList
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
            this.dgvEmployeesList = new System.Windows.Forms.DataGridView();
            this._id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hourlyRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.basicSalary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.designation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sss = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pagibig = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.philhealth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployeesList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvEmployeesList
            // 
            this.dgvEmployeesList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployeesList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._id,
            this.fullName,
            this.code,
            this.hourlyRate,
            this.basicSalary,
            this.designation,
            this.employeeStatus,
            this.tax,
            this.sss,
            this.pagibig,
            this.philhealth});
            this.dgvEmployeesList.Location = new System.Drawing.Point(13, 65);
            this.dgvEmployeesList.Margin = new System.Windows.Forms.Padding(4);
            this.dgvEmployeesList.MultiSelect = false;
            this.dgvEmployeesList.Name = "dgvEmployeesList";
            this.dgvEmployeesList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmployeesList.Size = new System.Drawing.Size(1145, 539);
            this.dgvEmployeesList.TabIndex = 0;
            // 
            // _id
            // 
            this._id.HeaderText = "Id";
            this._id.Name = "_id";
            this._id.Visible = false;
            // 
            // fullName
            // 
            this.fullName.HeaderText = "NAME";
            this.fullName.Name = "fullName";
            this.fullName.Width = 250;
            // 
            // code
            // 
            this.code.HeaderText = "CODE";
            this.code.Name = "code";
            // 
            // hourlyRate
            // 
            this.hourlyRate.HeaderText = "HOURLY RATE";
            this.hourlyRate.Name = "hourlyRate";
            this.hourlyRate.Width = 130;
            // 
            // basicSalary
            // 
            this.basicSalary.FillWeight = 150F;
            this.basicSalary.HeaderText = "MONTHLY SALARY";
            this.basicSalary.Name = "basicSalary";
            this.basicSalary.Width = 160;
            // 
            // designation
            // 
            this.designation.HeaderText = "DESIGNATION";
            this.designation.Name = "designation";
            this.designation.Width = 120;
            // 
            // employeeStatus
            // 
            this.employeeStatus.HeaderText = "CONTRACT";
            this.employeeStatus.Name = "employeeStatus";
            this.employeeStatus.Width = 120;
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
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(1038, 24);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(123, 33);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Employees List";
            // 
            // frmEmployeesList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 621);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.dgvEmployeesList);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEmployeesList";
            this.Text = "Employees List";
            this.Load += new System.EventHandler(this.frmEmployeesList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployeesList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEmployeesList;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridViewTextBoxColumn _id;
        private System.Windows.Forms.DataGridViewTextBoxColumn fullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn code;
        private System.Windows.Forms.DataGridViewTextBoxColumn hourlyRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn basicSalary;
        private System.Windows.Forms.DataGridViewTextBoxColumn designation;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn tax;
        private System.Windows.Forms.DataGridViewTextBoxColumn sss;
        private System.Windows.Forms.DataGridViewTextBoxColumn pagibig;
        private System.Windows.Forms.DataGridViewTextBoxColumn philhealth;
        private System.Windows.Forms.Label label1;
    }
}