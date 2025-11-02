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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSIEmployeeMonitoringSystem.Forms.Schedules
{
    public partial class frmUpdateSchedule : Form
    {
        private InstructorService instructorService;
        private ScheduleService scheduleService;
        public string scheduleId;
        public frmUpdateSchedule()
        {
            InitializeComponent();
            btnCancel.Click += BtnCancel_Click;
            btnUpdate.Click += BtnUpdate_Click;
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (InputValidator())
            {
                MessageBox.Show("Fill in all the required (*) fields", "Update Employee", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("Click OK to continue.", "Update Schedule", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    UpdateSchedule();
                    BtnCancel_Click(sender, e);
                }
            }
        }

        private async void UpdateSchedule()
        {
            SchedulePost payload = new SchedulePost();
            payload.day = optDay.SelectedValue.ToString();
            if (chkOpenTime.Checked)
            {
                payload.startTime = "";
                payload.endTime = "";
            }
            else
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

            var data = await scheduleService.UpdateSchedule(scheduleId, payload);
            if (null != data)
            {
                MessageBox.Show("Schedule has been updated", "Update Schedule", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
            }
            else
            {
                MessageBox.Show("Unable to update schedule", "Update Schedule", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private async void GetSchedule()
        {
            var data = await scheduleService.GetSchedule(scheduleId);
            if(null != data)
            {
                optInstructor.SelectedValue = data.data.instructor._id;
                optDay.SelectedValue = data.data.day;
                optSemester.SelectedValue = data.data.semester;
                txtRoom.Text = data.data.room;
                txtSchoolYear.Text = data.data.schoolYear;
                txtSubject.Text = data.data.subject;
                txtSubjectCode.Text = data.data.subjectCode;
                txtCourse.Text = data.data.course;
                if(data.data.endTime == string.Empty)
                {
                    chkOpenTime.Checked = true;
                } else
                {
                    string format = "HH:mm"; // The exact format of the timeString
                    dtEndTime.Value = DateTime.ParseExact(data.data.endTime, format, CultureInfo.InvariantCulture);
                    dtStartTime.Value = DateTime.ParseExact(data.data.startTime, format, CultureInfo.InvariantCulture);
                }
            }
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

        private void frmUpdateSchedule_Load(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            instructorService = new InstructorService(Program.xApiKey, Program.serverUrl);
            scheduleService = new ScheduleService(Program.xApiKey, Program.serverUrl);
            GetInstructors();
            GetDays();
            GetSemesters();
            Thread.Sleep(1000);
            GetSchedule();
            Cursor = Cursors.Arrow;
        }

        private void frmUpdateSchedule_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
