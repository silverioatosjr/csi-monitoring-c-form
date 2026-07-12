namespace CSIEmployeeMonitoringSystem.Forms.Dtr
{
    partial class frmManualTeaching
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManualTeaching));
            this.optInstructor = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvSchedules = new System.Windows.Forms.DataGridView();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvDTR = new System.Windows.Forms.DataGridView();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnDeleteDTR = new System.Windows.Forms.Button();
            this.btnUpdateDTR = new System.Windows.Forms.Button();
            this.btnAddDTR = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuAddDTR = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedules)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDTR)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // optInstructor
            // 
            this.optInstructor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.optInstructor.FormattingEnabled = true;
            this.optInstructor.Location = new System.Drawing.Point(87, 39);
            this.optInstructor.Name = "optInstructor";
            this.optInstructor.Size = new System.Drawing.Size(540, 24);
            this.optInstructor.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvSchedules);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.optInstructor);
            this.groupBox1.Location = new System.Drawing.Point(23, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(650, 577);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Schedules";
            // 
            // dgvSchedules
            // 
            this.dgvSchedules.AllowUserToAddRows = false;
            this.dgvSchedules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSchedules.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column12,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dgvSchedules.Location = new System.Drawing.Point(23, 84);
            this.dgvSchedules.MultiSelect = false;
            this.dgvSchedules.Name = "dgvSchedules";
            this.dgvSchedules.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSchedules.Size = new System.Drawing.Size(604, 463);
            this.dgvSchedules.TabIndex = 11;
            // 
            // Column12
            // 
            this.Column12.HeaderText = "ID";
            this.Column12.Name = "Column12";
            this.Column12.Visible = false;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "SUBJECT";
            this.Column1.Name = "Column1";
            this.Column1.Width = 250;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "START";
            this.Column2.Name = "Column2";
            this.Column2.Width = 90;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "END";
            this.Column3.Name = "Column3";
            this.Column3.Width = 90;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "DAY";
            this.Column4.Name = "Column4";
            this.Column4.Width = 130;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "HOUR";
            this.Column5.Name = "Column5";
            this.Column5.Width = 50;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Instructor";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvDTR);
            this.groupBox2.Location = new System.Drawing.Point(692, 23);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(702, 577);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "DTR";
            // 
            // dgvDTR
            // 
            this.dgvDTR.AllowUserToAddRows = false;
            this.dgvDTR.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDTR.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column11,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10});
            this.dgvDTR.Location = new System.Drawing.Point(24, 42);
            this.dgvDTR.MultiSelect = false;
            this.dgvDTR.Name = "dgvDTR";
            this.dgvDTR.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDTR.Size = new System.Drawing.Size(654, 505);
            this.dgvDTR.TabIndex = 12;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "ID";
            this.Column11.Name = "Column11";
            this.Column11.Visible = false;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "SUBJECT";
            this.Column6.Name = "Column6";
            this.Column6.Width = 250;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "DATE";
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.HeaderText = "RENDERED";
            this.Column8.Name = "Column8";
            // 
            // Column9
            // 
            this.Column9.HeaderText = "IN";
            this.Column9.Name = "Column9";
            this.Column9.Width = 80;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "OUT";
            this.Column10.Name = "Column10";
            this.Column10.Width = 80;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnDeleteDTR);
            this.groupBox3.Controls.Add(this.btnUpdateDTR);
            this.groupBox3.Controls.Add(this.btnAddDTR);
            this.groupBox3.Location = new System.Drawing.Point(23, 623);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1371, 97);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Controls";
            // 
            // btnDeleteDTR
            // 
            this.btnDeleteDTR.BackColor = System.Drawing.Color.IndianRed;
            this.btnDeleteDTR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteDTR.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDeleteDTR.Location = new System.Drawing.Point(1154, 31);
            this.btnDeleteDTR.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeleteDTR.Name = "btnDeleteDTR";
            this.btnDeleteDTR.Size = new System.Drawing.Size(193, 42);
            this.btnDeleteDTR.TabIndex = 16;
            this.btnDeleteDTR.Text = "Delete Selected DTR";
            this.btnDeleteDTR.UseVisualStyleBackColor = false;
            // 
            // btnUpdateDTR
            // 
            this.btnUpdateDTR.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnUpdateDTR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateDTR.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnUpdateDTR.Location = new System.Drawing.Point(950, 31);
            this.btnUpdateDTR.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdateDTR.Name = "btnUpdateDTR";
            this.btnUpdateDTR.Size = new System.Drawing.Size(187, 42);
            this.btnUpdateDTR.TabIndex = 15;
            this.btnUpdateDTR.Text = "Update Selected DTR";
            this.btnUpdateDTR.UseVisualStyleBackColor = false;
            // 
            // btnAddDTR
            // 
            this.btnAddDTR.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnAddDTR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddDTR.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAddDTR.Location = new System.Drawing.Point(23, 31);
            this.btnAddDTR.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddDTR.Name = "btnAddDTR";
            this.btnAddDTR.Size = new System.Drawing.Size(336, 42);
            this.btnAddDTR.TabIndex = 14;
            this.btnAddDTR.Text = "Add New DTR From Selected Schedule";
            this.btnAddDTR.UseVisualStyleBackColor = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAddDTR});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(120, 26);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEdit,
            this.mnuDelete});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(108, 48);
            // 
            // mnuAddDTR
            // 
            this.mnuAddDTR.Name = "mnuAddDTR";
            this.mnuAddDTR.Size = new System.Drawing.Size(119, 22);
            this.mnuAddDTR.Text = "Add DTR";
            // 
            // mnuEdit
            // 
            this.mnuEdit.Name = "mnuEdit";
            this.mnuEdit.Size = new System.Drawing.Size(107, 22);
            this.mnuEdit.Text = "Edit";
            // 
            // mnuDelete
            // 
            this.mnuDelete.Name = "mnuDelete";
            this.mnuDelete.Size = new System.Drawing.Size(107, 22);
            this.mnuDelete.Text = "Delete";
            // 
            // frmManualTeaching
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1416, 742);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManualTeaching";
            this.Text = "Manual Entry Teaching Staffs";
            this.Load += new System.EventHandler(this.frmManualTeaching_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedules)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDTR)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox optInstructor;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvSchedules;
        private System.Windows.Forms.DataGridView dgvDTR;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnDeleteDTR;
        private System.Windows.Forms.Button btnUpdateDTR;
        private System.Windows.Forms.Button btnAddDTR;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuAddDTR;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem mnuEdit;
        private System.Windows.Forms.ToolStripMenuItem mnuDelete;
    }
}