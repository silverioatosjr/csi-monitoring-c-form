namespace CSIEmployeeMonitoringSystem.Forms.Dtr
{
    partial class frmManualNonTeaching
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManualNonTeaching));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvDTR = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.optNonTeachingStaff = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDeleteDTR = new System.Windows.Forms.Button();
            this.btnUpdateDTR = new System.Windows.Forms.Button();
            this.btnAddDTR = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDTR)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvDTR);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.optNonTeachingStaff);
            this.groupBox1.Location = new System.Drawing.Point(25, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(545, 581);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DTR";
            // 
            // dgvDTR
            // 
            this.dgvDTR.AllowUserToAddRows = false;
            this.dgvDTR.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDTR.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column5,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dgvDTR.Location = new System.Drawing.Point(25, 80);
            this.dgvDTR.MultiSelect = false;
            this.dgvDTR.Name = "dgvDTR";
            this.dgvDTR.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDTR.Size = new System.Drawing.Size(493, 472);
            this.dgvDTR.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Employee";
            // 
            // optNonTeachingStaff
            // 
            this.optNonTeachingStaff.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.optNonTeachingStaff.FormattingEnabled = true;
            this.optNonTeachingStaff.Location = new System.Drawing.Point(98, 35);
            this.optNonTeachingStaff.Name = "optNonTeachingStaff";
            this.optNonTeachingStaff.Size = new System.Drawing.Size(420, 24);
            this.optNonTeachingStaff.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDeleteDTR);
            this.groupBox2.Controls.Add(this.btnUpdateDTR);
            this.groupBox2.Controls.Add(this.btnAddDTR);
            this.groupBox2.Location = new System.Drawing.Point(25, 625);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(545, 97);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Controls";
            // 
            // btnDeleteDTR
            // 
            this.btnDeleteDTR.BackColor = System.Drawing.Color.IndianRed;
            this.btnDeleteDTR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteDTR.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDeleteDTR.Location = new System.Drawing.Point(360, 31);
            this.btnDeleteDTR.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeleteDTR.Name = "btnDeleteDTR";
            this.btnDeleteDTR.Size = new System.Drawing.Size(158, 42);
            this.btnDeleteDTR.TabIndex = 13;
            this.btnDeleteDTR.Text = "Delete Selected DTR";
            this.btnDeleteDTR.UseVisualStyleBackColor = false;
            // 
            // btnUpdateDTR
            // 
            this.btnUpdateDTR.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnUpdateDTR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateDTR.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnUpdateDTR.Location = new System.Drawing.Point(164, 31);
            this.btnUpdateDTR.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdateDTR.Name = "btnUpdateDTR";
            this.btnUpdateDTR.Size = new System.Drawing.Size(183, 42);
            this.btnUpdateDTR.TabIndex = 12;
            this.btnUpdateDTR.Text = "Update Selected DTR";
            this.btnUpdateDTR.UseVisualStyleBackColor = false;
            // 
            // btnAddDTR
            // 
            this.btnAddDTR.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnAddDTR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddDTR.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAddDTR.Location = new System.Drawing.Point(25, 31);
            this.btnAddDTR.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddDTR.Name = "btnAddDTR";
            this.btnAddDTR.Size = new System.Drawing.Size(127, 42);
            this.btnAddDTR.TabIndex = 9;
            this.btnAddDTR.Text = "Add New DTR";
            this.btnAddDTR.UseVisualStyleBackColor = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEdit,
            this.mnuDelete});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(108, 48);
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
            // Column5
            // 
            this.Column5.HeaderText = "id";
            this.Column5.Name = "Column5";
            this.Column5.Visible = false;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "DATE";
            this.Column1.Name = "Column1";
            this.Column1.Width = 150;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "IN";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "OUT";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "RENDERED";
            this.Column4.Name = "Column4";
            // 
            // frmManualNonTeaching
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(597, 742);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManualNonTeaching";
            this.Text = "Manual Entry NonTeaching Staffs";
            this.Load += new System.EventHandler(this.frmManualNonTeaching_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDTR)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvDTR;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox optNonTeachingStaff;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAddDTR;
        private System.Windows.Forms.Button btnUpdateDTR;
        private System.Windows.Forms.Button btnDeleteDTR;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuEdit;
        private System.Windows.Forms.ToolStripMenuItem mnuDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}