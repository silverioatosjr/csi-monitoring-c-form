namespace CSIEmployeeMonitoringSystem.Forms.Schedules
{
    partial class frmParentSchedules
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmParentSchedules));
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.grpControls = new System.Windows.Forms.GroupBox();
            this.btnDeleteSchedule = new System.Windows.Forms.Button();
            this.btnUpdateSchedule = new System.Windows.Forms.Button();
            this.btnAddSchedule = new System.Windows.Forms.Button();
            this.btnDeleteSchedules = new System.Windows.Forms.Button();
            this.btnUploadXLSFile = new System.Windows.Forms.Button();
            this.grpSchedules = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.optInstructor = new System.Windows.Forms.ComboBox();
            this.dgvSubjectSchedules = new System.Windows.Forms.DataGridView();
            this.subjectId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.instructorId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subjectCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.start = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.end = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.day = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.room = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.semester = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.schoolYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpControls.SuspendLayout();
            this.grpSchedules.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubjectSchedules)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "subjectSchedules";
            // 
            // grpControls
            // 
            this.grpControls.Controls.Add(this.btnDeleteSchedule);
            this.grpControls.Controls.Add(this.btnUpdateSchedule);
            this.grpControls.Controls.Add(this.btnAddSchedule);
            this.grpControls.Controls.Add(this.btnDeleteSchedules);
            this.grpControls.Controls.Add(this.btnUploadXLSFile);
            this.grpControls.Location = new System.Drawing.Point(24, 430);
            this.grpControls.Name = "grpControls";
            this.grpControls.Size = new System.Drawing.Size(1025, 108);
            this.grpControls.TabIndex = 6;
            this.grpControls.TabStop = false;
            this.grpControls.Text = "Controls";
            // 
            // btnDeleteSchedule
            // 
            this.btnDeleteSchedule.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteSchedule.Location = new System.Drawing.Point(463, 36);
            this.btnDeleteSchedule.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeleteSchedule.Name = "btnDeleteSchedule";
            this.btnDeleteSchedule.Size = new System.Drawing.Size(127, 42);
            this.btnDeleteSchedule.TabIndex = 10;
            this.btnDeleteSchedule.Text = "Delete Selected Schedule";
            this.btnDeleteSchedule.UseVisualStyleBackColor = true;
            // 
            // btnUpdateSchedule
            // 
            this.btnUpdateSchedule.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateSchedule.Location = new System.Drawing.Point(317, 36);
            this.btnUpdateSchedule.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdateSchedule.Name = "btnUpdateSchedule";
            this.btnUpdateSchedule.Size = new System.Drawing.Size(127, 42);
            this.btnUpdateSchedule.TabIndex = 9;
            this.btnUpdateSchedule.Text = "Update Selected Schedule";
            this.btnUpdateSchedule.UseVisualStyleBackColor = true;
            // 
            // btnAddSchedule
            // 
            this.btnAddSchedule.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddSchedule.Location = new System.Drawing.Point(171, 36);
            this.btnAddSchedule.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddSchedule.Name = "btnAddSchedule";
            this.btnAddSchedule.Size = new System.Drawing.Size(127, 42);
            this.btnAddSchedule.TabIndex = 8;
            this.btnAddSchedule.Text = "Add New Schedule";
            this.btnAddSchedule.UseVisualStyleBackColor = true;
            // 
            // btnDeleteSchedules
            // 
            this.btnDeleteSchedules.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteSchedules.Location = new System.Drawing.Point(872, 36);
            this.btnDeleteSchedules.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeleteSchedules.Name = "btnDeleteSchedules";
            this.btnDeleteSchedules.Size = new System.Drawing.Size(127, 42);
            this.btnDeleteSchedules.TabIndex = 7;
            this.btnDeleteSchedules.Text = "Delete All Schedules";
            this.btnDeleteSchedules.UseVisualStyleBackColor = true;
            // 
            // btnUploadXLSFile
            // 
            this.btnUploadXLSFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUploadXLSFile.Location = new System.Drawing.Point(26, 36);
            this.btnUploadXLSFile.Margin = new System.Windows.Forms.Padding(4);
            this.btnUploadXLSFile.Name = "btnUploadXLSFile";
            this.btnUploadXLSFile.Size = new System.Drawing.Size(127, 42);
            this.btnUploadXLSFile.TabIndex = 6;
            this.btnUploadXLSFile.Text = "Upload New Schedules";
            this.btnUploadXLSFile.UseVisualStyleBackColor = true;
            // 
            // grpSchedules
            // 
            this.grpSchedules.Controls.Add(this.label1);
            this.grpSchedules.Controls.Add(this.optInstructor);
            this.grpSchedules.Controls.Add(this.dgvSubjectSchedules);
            this.grpSchedules.Location = new System.Drawing.Point(24, 12);
            this.grpSchedules.Name = "grpSchedules";
            this.grpSchedules.Size = new System.Drawing.Size(1025, 404);
            this.grpSchedules.TabIndex = 7;
            this.grpSchedules.TabStop = false;
            this.grpSchedules.Text = "Schedules";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Filter by Instructor:";
            // 
            // optInstructor
            // 
            this.optInstructor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.optInstructor.FormattingEnabled = true;
            this.optInstructor.Location = new System.Drawing.Point(145, 21);
            this.optInstructor.Name = "optInstructor";
            this.optInstructor.Size = new System.Drawing.Size(270, 24);
            this.optInstructor.TabIndex = 6;
            // 
            // dgvSubjectSchedules
            // 
            this.dgvSubjectSchedules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSubjectSchedules.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.subjectId,
            this.instructorId,
            this.subjectCode,
            this.subject,
            this.start,
            this.end,
            this.day,
            this.room,
            this.semester,
            this.schoolYear});
            this.dgvSubjectSchedules.Location = new System.Drawing.Point(26, 56);
            this.dgvSubjectSchedules.MultiSelect = false;
            this.dgvSubjectSchedules.Name = "dgvSubjectSchedules";
            this.dgvSubjectSchedules.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSubjectSchedules.Size = new System.Drawing.Size(973, 321);
            this.dgvSubjectSchedules.TabIndex = 5;
            // 
            // subjectId
            // 
            this.subjectId.HeaderText = "SUBJECT ID";
            this.subjectId.Name = "subjectId";
            this.subjectId.Visible = false;
            // 
            // instructorId
            // 
            this.instructorId.HeaderText = "INSTRUCTOR ID";
            this.instructorId.Name = "instructorId";
            this.instructorId.Visible = false;
            // 
            // subjectCode
            // 
            this.subjectCode.HeaderText = "CODE";
            this.subjectCode.Name = "subjectCode";
            // 
            // subject
            // 
            this.subject.HeaderText = "SUBJECT";
            this.subject.Name = "subject";
            this.subject.Width = 250;
            // 
            // start
            // 
            this.start.HeaderText = "START";
            this.start.Name = "start";
            // 
            // end
            // 
            this.end.HeaderText = "END";
            this.end.Name = "end";
            // 
            // day
            // 
            this.day.HeaderText = "DAY";
            this.day.Name = "day";
            // 
            // room
            // 
            this.room.HeaderText = "ROOM";
            this.room.Name = "room";
            // 
            // semester
            // 
            this.semester.HeaderText = "SEMESTER";
            this.semester.Name = "semester";
            // 
            // schoolYear
            // 
            this.schoolYear.HeaderText = "SCHOOL YEAR";
            this.schoolYear.Name = "schoolYear";
            this.schoolYear.Width = 130;
            // 
            // frmParentSchedules
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1074, 559);
            this.Controls.Add(this.grpSchedules);
            this.Controls.Add(this.grpControls);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmParentSchedules";
            this.Text = "Subjects Schedule";
            this.grpControls.ResumeLayout(false);
            this.grpSchedules.ResumeLayout(false);
            this.grpSchedules.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubjectSchedules)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.GroupBox grpControls;
        private System.Windows.Forms.Button btnAddSchedule;
        private System.Windows.Forms.Button btnDeleteSchedules;
        private System.Windows.Forms.Button btnUploadXLSFile;
        private System.Windows.Forms.GroupBox grpSchedules;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox optInstructor;
        private System.Windows.Forms.DataGridView dgvSubjectSchedules;
        private System.Windows.Forms.DataGridViewTextBoxColumn subjectId;
        private System.Windows.Forms.DataGridViewTextBoxColumn instructorId;
        private System.Windows.Forms.DataGridViewTextBoxColumn subjectCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn subject;
        private System.Windows.Forms.DataGridViewTextBoxColumn start;
        private System.Windows.Forms.DataGridViewTextBoxColumn end;
        private System.Windows.Forms.DataGridViewTextBoxColumn day;
        private System.Windows.Forms.DataGridViewTextBoxColumn room;
        private System.Windows.Forms.DataGridViewTextBoxColumn semester;
        private System.Windows.Forms.DataGridViewTextBoxColumn schoolYear;
        private System.Windows.Forms.Button btnDeleteSchedule;
        private System.Windows.Forms.Button btnUpdateSchedule;
    }
}