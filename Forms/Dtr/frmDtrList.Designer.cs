namespace CSIEmployeeMonitoringSystem.Forms.Dtr
{
    partial class frmDtrList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDtrList));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.dgvDtrs = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subjectCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hoursRendered = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.day = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.optEmployees = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDtrDetails = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuViewDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.printDtr = new System.Drawing.Printing.PrintDocument();
            this.printDtrDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDtrs)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpTo);
            this.groupBox1.Controls.Add(this.dtpFrom);
            this.groupBox1.Controls.Add(this.dgvDtrs);
            this.groupBox1.Controls.Add(this.btnReset);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.optEmployees);
            this.groupBox1.Location = new System.Drawing.Point(20, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1055, 427);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DTR List";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(567, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 16);
            this.label3.TabIndex = 19;
            this.label3.Text = "To:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(391, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 16);
            this.label2.TabIndex = 18;
            this.label2.Text = "From:";
            // 
            // dtpTo
            // 
            this.dtpTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(599, 32);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(114, 24);
            this.dtpTo.TabIndex = 17;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(439, 32);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(114, 24);
            this.dtpFrom.TabIndex = 16;
            // 
            // dgvDtrs
            // 
            this.dgvDtrs.AllowUserToAddRows = false;
            this.dgvDtrs.BackgroundColor = System.Drawing.Color.LightSteelBlue;
            this.dgvDtrs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDtrs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.employee,
            this.subjectCode,
            this.timeIn,
            this.timeOut,
            this.hoursRendered,
            this.day,
            this.date});
            this.dgvDtrs.Location = new System.Drawing.Point(24, 65);
            this.dgvDtrs.MultiSelect = false;
            this.dgvDtrs.Name = "dgvDtrs";
            this.dgvDtrs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDtrs.Size = new System.Drawing.Size(1004, 337);
            this.dgvDtrs.TabIndex = 15;
            // 
            // id
            // 
            this.id.HeaderText = "DTR";
            this.id.Name = "id";
            this.id.Visible = false;
            // 
            // employee
            // 
            this.employee.HeaderText = "EMPLOYEE";
            this.employee.Name = "employee";
            this.employee.Width = 250;
            // 
            // subjectCode
            // 
            this.subjectCode.HeaderText = "CODE";
            this.subjectCode.Name = "subjectCode";
            // 
            // timeIn
            // 
            this.timeIn.HeaderText = "TIME IN";
            this.timeIn.Name = "timeIn";
            // 
            // timeOut
            // 
            this.timeOut.HeaderText = "TIME OUT";
            this.timeOut.Name = "timeOut";
            // 
            // hoursRendered
            // 
            this.hoursRendered.HeaderText = "HOURS RENDERED";
            this.hoursRendered.Name = "hoursRendered";
            this.hoursRendered.Width = 160;
            // 
            // day
            // 
            this.day.HeaderText = "DAY";
            this.day.Name = "day";
            this.day.Width = 150;
            // 
            // date
            // 
            this.date.HeaderText = "DATE";
            this.date.Name = "date";
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.SlateGray;
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnReset.Location = new System.Drawing.Point(851, 30);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(77, 29);
            this.btnReset.TabIndex = 14;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSearch.Location = new System.Drawing.Point(758, 30);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(77, 29);
            this.btnSearch.TabIndex = 13;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "Filters:";
            // 
            // optEmployees
            // 
            this.optEmployees.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.optEmployees.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optEmployees.FormattingEnabled = true;
            this.optEmployees.Location = new System.Drawing.Point(72, 30);
            this.optEmployees.Name = "optEmployees";
            this.optEmployees.Size = new System.Drawing.Size(300, 26);
            this.optEmployees.TabIndex = 11;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDtrDetails);
            this.groupBox2.Controls.Add(this.btnClose);
            this.groupBox2.Controls.Add(this.btnPrint);
            this.groupBox2.Location = new System.Drawing.Point(20, 464);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1055, 105);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Controls";
            // 
            // btnDtrDetails
            // 
            this.btnDtrDetails.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnDtrDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDtrDetails.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDtrDetails.Location = new System.Drawing.Point(23, 37);
            this.btnDtrDetails.Margin = new System.Windows.Forms.Padding(4);
            this.btnDtrDetails.Name = "btnDtrDetails";
            this.btnDtrDetails.Size = new System.Drawing.Size(127, 42);
            this.btnDtrDetails.TabIndex = 15;
            this.btnDtrDetails.Text = "View Details";
            this.btnDtrDetails.UseVisualStyleBackColor = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.DarkGreen;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClose.Location = new System.Drawing.Point(901, 37);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(127, 42);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.OliveDrab;
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPrint.Location = new System.Drawing.Point(170, 37);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(127, 42);
            this.btnPrint.TabIndex = 13;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = false;
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuViewDetails,
            this.mnuDelete});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(138, 48);
            // 
            // mnuViewDetails
            // 
            this.mnuViewDetails.Name = "mnuViewDetails";
            this.mnuViewDetails.Size = new System.Drawing.Size(137, 22);
            this.mnuViewDetails.Text = "View Details";
            // 
            // mnuDelete
            // 
            this.mnuDelete.Name = "mnuDelete";
            this.mnuDelete.Size = new System.Drawing.Size(137, 22);
            this.mnuDelete.Text = "Delete";
            // 
            // printDtr
            // 
            this.printDtr.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDtr_PrintPage);
            // 
            // printDtrDialog
            // 
            this.printDtrDialog.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printDtrDialog.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printDtrDialog.ClientSize = new System.Drawing.Size(400, 300);
            this.printDtrDialog.Enabled = true;
            this.printDtrDialog.Icon = ((System.Drawing.Icon)(resources.GetObject("printDtrDialog.Icon")));
            this.printDtrDialog.Name = "printDtrDialog";
            this.printDtrDialog.Visible = false;
            // 
            // frmDtrList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1100, 591);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDtrList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DTR List";
            this.Load += new System.EventHandler(this.frmDtrList_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDtrs)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox optEmployees;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvDtrs;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDtrDetails;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn employee;
        private System.Windows.Forms.DataGridViewTextBoxColumn subjectCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn hoursRendered;
        private System.Windows.Forms.DataGridViewTextBoxColumn day;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuViewDetails;
        private System.Windows.Forms.ToolStripMenuItem mnuDelete;
        private System.Drawing.Printing.PrintDocument printDtr;
        private System.Windows.Forms.PrintPreviewDialog printDtrDialog;
    }
}