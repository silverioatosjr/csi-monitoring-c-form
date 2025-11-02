using CSIEmployeeMonitoringSystem.Models;
using CSIEmployeeMonitoringSystem.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSIEmployeeMonitoringSystem.Forms.Schedules
{
    public partial class frmAddSchedule : Form
    {
        private InstructorService instructorService;
        private ScheduleService scheduleService;
        public frmAddSchedule()
        {
            InitializeComponent();
            btnCancel.Click += BtnCancel_Click;
            btnSave.Click += BtnSave_Click;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if(InputValidator())
            {
                MessageBox.Show("Fill in all the required (*) fields", "Add Employee", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
            {
                if(MessageBox.Show("Click OK to continue.", "Add Schedule", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    PostSchedule();
                }
            }
        }

        private async void PostSchedule()
        {
            SchedulePost payload = new SchedulePost();
            payload.day = optDay.SelectedValue.ToString();
            if(chkOpenTime.Checked)
            {
                payload.startTime = "";
                payload.endTime = "";
            } else
            {
                payload.startTime = dtStartTime.Value.ToString("HH:mm");
                payload.endTime = dtEndTime.Value.ToString("HH:mm");
            }
            payload.instructor = optInstructor.SelectedValue.ToString();
            payload.schoolYear = txtSchoolYear.Text;
            payload.room = txtRoom.Text.Trim();
            payload.semester = optSemester.SelectedValue.ToString();
            payload.subjectCode = txtSubjectCode.Text.Trim();
            payload.subject = txtSubject.Text.Trim();
            payload.course = txtCourse.Text.Trim();

            var data = await scheduleService.PostSchedule(payload);
            if(null != data)
            {
                MessageBox.Show("Schedule has been added", "Add Schedule", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetInputs();
            } else
            {
                MessageBox.Show("Unable to save schedule", "Add Schedule", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        
        private void ResetInputs()
        {
            txtRoom.Text = string.Empty;
            txtSubject.Text = string.Empty;
            txtSubjectCode.Text = string.Empty;
            optDay.SelectedIndex = 0;
            optInstructor.SelectedIndex = 0;
            optSemester.SelectedIndex = 0;
            chkOpenTime.Checked = false;
            txtCourse.Text = string.Empty;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddSchedule_Load(object sender, EventArgs e)
        {
            instructorService = new InstructorService(Program.xApiKey, Program.serverUrl);
            scheduleService = new ScheduleService(Program.xApiKey, Program.serverUrl);
            GetDays();
            GetSemesters();
            GetInstructors();
            txtSchoolYear.Text = $"SY {DateTime.Now.Year}-{DateTime.Now.AddYears(1).Year}";
        }

        private async void GetInstructors()
        {
            var response = await instructorService.GetInstructors();
            List<KeyValuePair<string, string>> items = new List<KeyValuePair<string, string>>();
            items.Add(new KeyValuePair<string, string>("<<Select>>", ""));
            if (null != response)
            {
                if (null != response)
                {
                    foreach (EmployeesList i in response.data)
                    {
                        items.Add(new KeyValuePair<string, string>($"{i.firstName} {i.lastName}", i._id));
                    }
                }
            }
            optInstructor.DataSource = items;
            optInstructor.DisplayMember = "Key";
            optInstructor.ValueMember = "Value";
        }

        private async void GetDays()
        {
            var response = await instructorService.GetInstructors();
            List<KeyValuePair<string, string>> items = new List<KeyValuePair<string, string>>();
            items.Add(new KeyValuePair<string, string>("<<Select>>", ""));
            items.Add(new KeyValuePair<string, string>("Monday", "Monday"));
            items.Add(new KeyValuePair<string, string>("Tuesday", "Tuesday"));
            items.Add(new KeyValuePair<string, string>("Wednesday", "Wednesday"));
            items.Add(new KeyValuePair<string, string>("Thursday", "Thursday"));
            items.Add(new KeyValuePair<string, string>("Friday", "Friday"));
            items.Add(new KeyValuePair<string, string>("Saturday", "Saturday"));
            items.Add(new KeyValuePair<string, string>("Sunday", "Sunday"));

            optDay.DataSource = items;
            optDay.DisplayMember = "Key";
            optDay.ValueMember = "Value";
        }

        private async void GetSemesters()
        {
            var response = await instructorService.GetInstructors();
            List<KeyValuePair<string, string>> items = new List<KeyValuePair<string, string>>();
            items.Add(new KeyValuePair<string, string>("<<Select>>", ""));
            items.Add(new KeyValuePair<string, string>("First Semester", "first"));
            items.Add(new KeyValuePair<string, string>("Second Semester", "second"));
            items.Add(new KeyValuePair<string, string>("Senior High", "senior"));
            
            optSemester.DataSource = items;
            optSemester.DisplayMember = "Key";
            optSemester.ValueMember = "Value";
        }

        private bool InputValidator()
        {
            bool hasError = false;
            if (optDay.SelectedIndex == 0 ||
                optSemester.SelectedIndex == 0 ||
                optInstructor.SelectedIndex == 0 ||
                txtSubject.Text.Trim() == string.Empty ||
                txtSubjectCode.Text.Trim() == string.Empty ||
                txtRoom.Text.Trim() == string.Empty ||
                txtCourse.Text.Trim() == string.Empty)
                
            {
                hasError = true;
            }
            return hasError;
        }

        private void frmAddSchedule_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
