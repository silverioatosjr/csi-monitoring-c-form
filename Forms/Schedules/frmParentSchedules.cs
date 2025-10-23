using CSIEmployeeMonitoringSystem.Models;
using CSIEmployeeMonitoringSystem.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSIEmployeeMonitoringSystem.Forms.Schedules
{
    public partial class frmParentSchedules : Form
    {
        private frmAddSchedule frmAddSchedule;
        private frmUpdateSchedule frmUpdateSchedule;
        private frmUploadSchedules frmUploadSchedules;
        private ScheduleService scheduleService;
        private InstructorService instructorService;
        public frmParentSchedules()
        {
            InitializeComponent();
            btnDeleteSchedules.Click += BtnDeleteSchedules_Click;
            btnDeleteSchedule.Click += BtnDeleteSchedule_Click;
            btnUpdateSchedule.Click += BtnUpdateSchedule_Click;
            btnAddSchedule.Click += BtnAddSchedule_Click;
            btnUploadXLSFile.Click += BtnUploadXLSFile_Click;
            btnReset.Click += BtnReset_Click;
            btnClose.Click += BtnClose_Click;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            optInstructor.SelectedIndex = 0;
            GetSchedules();
        }

        private void BtnUploadXLSFile_Click(object sender, EventArgs e)
        {
            frmUploadSchedules = new frmUploadSchedules();
            if(frmUploadSchedules.ShowDialog() == DialogResult.OK)
            {
                GetSchedules();
            }
        }

        private void BtnAddSchedule_Click(object sender, EventArgs e)
        {
            frmAddSchedule = new frmAddSchedule();
            if(frmAddSchedule.ShowDialog() == DialogResult.OK)
            {
                GetSchedules();
            }
        }

        private void BtnUpdateSchedule_Click(object sender, EventArgs e)
        {
            frmUpdateSchedule = new frmUpdateSchedule();
            frmUpdateSchedule.ShowDialog();
        }

        private void BtnDeleteSchedule_Click(object sender, EventArgs e)
        {
            
        }

        private void BtnDeleteSchedules_Click(object sender, EventArgs e)
        {
            
        }

        private async void GetSchedules()
        {
            var response = await scheduleService.GetSchedules();
            dgvSubjectSchedules.Rows.Clear();
            if (null != response)
            {
                foreach (Schedule s in response.data)
                {
                    dgvSubjectSchedules.Rows.Add(s._id, s.instructor._id, $"{s.instructor.firstName} {s.instructor.lastName}", s.subjectCode, s.subject, s.startTime, s.endTime, s.day, s.room, s.semester, s.schoolYear);
                }
            }
        }
        private async void GetInstructors()
        {
            var response = await instructorService.GetInstructors();
            if (null != response)
            {
                List<KeyValuePair<string, string>> items = new List<KeyValuePair<string, string>>();
                items.Add(new KeyValuePair<string, string>("<<Select Instructor>>", ""));
                if (null != response)
                {
                    foreach (EmployeesList i in response.data)
                    {
                        items.Add(new KeyValuePair<string, string>($"{i.firstName} {i.lastName} ({i.code})", i._id));
                    }
                }
                optInstructor.DataSource = items;
                optInstructor.DisplayMember = "Key";
                optInstructor.ValueMember = "Value";
            }
        }

        private void frmParentSchedules_Load(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            scheduleService = new ScheduleService(Program.xApiKey, Program.serverUrl);
            GetSchedules();
            instructorService = new InstructorService(Program.xApiKey, Program.serverUrl);
            GetInstructors();
            btnUpdateSchedule.Enabled = false;
            btnDeleteSchedule.Enabled = false;

            Cursor = Cursors.Arrow;
        }
    }
}
