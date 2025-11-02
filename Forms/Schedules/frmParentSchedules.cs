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
        private frmUpdateSchedule frmUpdateSchedule = new frmUpdateSchedule();
        private frmUploadSchedules frmUploadSchedules;
        private ScheduleService scheduleService;
        private PrintService printService;
        private InstructorService instructorService;
        public string scheduleId;
        public frmParentSchedules()
        {
            InitializeComponent();
            btnDeleteSchedules.Click += BtnDeleteSchedules_Click;
            btnDeleteSchedule.Click += BtnDeleteSchedule_Click;
            btnUpdateSchedule.Click += BtnUpdateSchedule_Click;
            btnAddSchedule.Click += BtnAddSchedule_Click;
            btnUploadXLSFile.Click += BtnUploadXLSFile_Click;
            btnClose.Click += BtnClose_Click;
            dgvSubjectSchedules.CellClick += DgvSubjectSchedules_CellClick;
            dgvSubjectSchedules.MouseClick += DgvSubjectSchedules_MouseClick;
            mnuUpdate.Click += BtnUpdateSchedule_Click;
            mnuDelete.Click += BtnDeleteSchedule_Click;
            btnSearch.Click += BtnSearch_Click;
            btnReset.Click += BtnReset_Click;
            btnPrint.Click += BtnPrint_Click;

        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Click OK to continue...", "Print Schedules", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                printSchedules.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("schedules", 816, 1056);
                printSchedulesDialog.Document = printSchedules;
                printSchedulesDialog.Document.Print();
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (optInstructor.SelectedValue.ToString() == string.Empty)
            {
                GetInstructors();
            }
            else
            {
                GetFilteredInstructors();
            }
            Cursor = Cursors.Arrow;
        }

        
        private async void GetFilteredInstructors()
        {
            if(optInstructor.SelectedValue.ToString() != string.Empty)
            {
                string instructorId = optInstructor.SelectedValue.ToString();
                var response = await scheduleService.GetIntructorSchedules(instructorId);
                dgvSubjectSchedules.Rows.Clear();
                btnPrint.Enabled = false;
                if (null != response)
                {
                    if (response.data.Count > 0)
                    {
                        btnPrint.Enabled = true;
                    }
                    foreach (Schedule s in response.data)
                    {
                        dgvSubjectSchedules.Rows.Add(s._id, s.instructor._id, $"{s.instructor.firstName} {s.instructor.lastName}", s.subjectCode, s.subject, s.startTime, s.endTime, s.day, s.room, s.semester, s.schoolYear);
                    }
                    if (response.data.Count > 0)
                        btnDeleteSchedules.Enabled = true;
                }
            }
        }

        private void DgvSubjectSchedules_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                int currentMouseOverRow = dgvSubjectSchedules.HitTest(e.X, e.Y).RowIndex;
                if (currentMouseOverRow >= 0)
                {
                    dgvSubjectSchedules.Rows[currentMouseOverRow].Selected = true;
                    scheduleId = dgvSubjectSchedules.Rows[currentMouseOverRow].Cells[0].Value.ToString();
                    contextMenuStrip1.Show(dgvSubjectSchedules, new Point(e.X, e.Y));
                    btnUpdateSchedule.Enabled = true;
                    btnDeleteSchedule.Enabled = true;
                }


            }
        }

        private void DgvSubjectSchedules_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                scheduleId = dgvSubjectSchedules.Rows[e.RowIndex].Cells[0].Value.ToString();
                btnUpdateSchedule.Enabled = true;
                btnDeleteSchedule.Enabled = true;
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            if(optInstructor.SelectedIndex != 0)
            {
                optInstructor.SelectedIndex = 0;
                GetSchedules();
            }
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
            if (!frmUpdateSchedule.Created)
            {
                frmUpdateSchedule = new frmUpdateSchedule();
            }
            frmUpdateSchedule.scheduleId = scheduleId;
            btnUpdateSchedule.Enabled = false;
            btnDeleteSchedule.Enabled = false;
            if (frmUpdateSchedule.ShowDialog() == DialogResult.OK)
            {
                scheduleId = string.Empty;
                GetSchedules();
            }
        }

        private void BtnDeleteSchedule_Click(object sender, EventArgs e)
        {
            if(scheduleId != string.Empty)
            {
                if (MessageBox.Show("Click OK to delete the selected schedule", "Delete Schedule", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    Cursor = Cursors.WaitCursor;
                    DeleteSchedule();
                    GetSchedules();
                    btnDeleteSchedule.Enabled = false;
                    btnUpdateSchedule.Enabled = false;
                    scheduleId = string.Empty;
                    Cursor = Cursors.Arrow;
                }
            }
        }

        private async void DeleteSchedule()
        {
            var data = await scheduleService.DeleteSchedule(scheduleId);
            if(null != data)
            {
                MessageBox.Show("Schedule has been deleted", "Delete Schedule", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Unable to delete schedule", "Delete Schedule", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnDeleteSchedules_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Click OK to delete all schedules", "Delete Schedule", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                Cursor = Cursors.WaitCursor;
                DeleteSchedules();
                Cursor = Cursors.Arrow;
            }
            
        }

        private async void DeleteSchedules()
        {
            var data = await scheduleService.DeleteSchedules();
            if(null != data)
            {
                MessageBox.Show("All schedules has been deleted", "Delete Schedule", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetSchedules();
            } else
            {
                MessageBox.Show("Unable to delete schedules", "Delete Schedule", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void GetSchedules()
        {
            Cursor = Cursors.WaitCursor;
            var response = await scheduleService.GetSchedules();
            dgvSubjectSchedules.Rows.Clear();
            btnPrint.Enabled = false;
            if (null != response)
            {
                if(response.data.Count>0)
                {
                    btnPrint.Enabled = true;
                }
                foreach (Schedule s in response.data)
                {
                    dgvSubjectSchedules.Rows.Add(s._id, s.instructor._id, $"{s.instructor.firstName} {s.instructor.lastName}", s.subjectCode, s.subject, s.startTime, s.endTime, s.day, s.room, s.semester, s.schoolYear);
                }
                if(response.data.Count>0)
                    btnDeleteSchedules.Enabled = true;
            }
            Cursor = Cursors.Arrow;
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
            printService = new PrintService();
            GetSchedules();
            instructorService = new InstructorService(Program.xApiKey, Program.serverUrl);
            GetInstructors();
            btnUpdateSchedule.Enabled = false;
            btnDeleteSchedule.Enabled = false;
            btnDeleteSchedules.Enabled = false;
            btnPrint.Enabled = false;
            scheduleId = string.Empty;

            Cursor = Cursors.Arrow;
        }

        private void printSchedules_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            printService.PrintSchedules(e, dgvSubjectSchedules);
        }
    }
}
