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

namespace CSIEmployeeMonitoringSystem.Forms.Dtr
{
    public partial class frmManualTeaching : Form
    {
        private frmAddDTR frmAddDTR;
        private frmEditDTR frmEditDTR;
        private InstructorService instructorService;
        private ScheduleService scheduleService;
        private DtrService dtrService;
        private string dtrId;
        private string scheduleId;
        private string employee;
        private string unit;
        private DateTime date;
        private string renderedHour = "0";
        public frmManualTeaching()
        {
            InitializeComponent();
            btnAddDTR.Click += BtnAddDTR_Click;
            btnDeleteDTR.Click += BtnDeleteDTR_Click;
            btnUpdateDTR.Click += BtnUpdateDTR_Click;
            mnuAddDTR.Click += BtnAddDTR_Click;
            mnuEdit.Click += BtnUpdateDTR_Click;
            mnuDelete.Click += BtnDeleteDTR_Click;
            dgvDTR.CellClick += DgvDTR_CellClick;
            dgvDTR.MouseClick += DgvDTR_MouseClick;
            dgvSchedules.CellClick += DgvSchedules_CellClick;
            dgvSchedules.MouseClick += DgvSchedules_MouseClick;
            optInstructor.TextChanged += OptInstructor_SelectedIndexChanged;
           
        }

        private void OptInstructor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(optInstructor.SelectedValue.ToString() != string.Empty)
            {
                employee = optInstructor.SelectedValue.ToString();
                GetInstructorSchedules(employee);
                GetDTRs(employee);
            } else
            {
                dgvSchedules.Rows.Clear();
                dgvDTR.Rows.Clear();
                btnAddDTR.Enabled = false;
                btnDeleteDTR.Enabled = false;
                btnUpdateDTR.Enabled = false;
            }
        }

        private async void GetInstructorSchedules(string instructorId)
        {
            var response = await scheduleService.GetIntructorSchedules(instructorId);
            dgvSchedules.Rows.Clear();
            if (null != response)
            {
                foreach (Schedule s in response.data)
                {
                    dgvSchedules.Rows.Add(s._id, s.subject, s.startTime, s.endTime, s.day, s.unit);
                }
            } else
            {
                btnAddDTR.Enabled = false;
            }
        }

        private async void GetDTRs(string instructorId)
        {
            Cursor = Cursors.WaitCursor;
            var response = await dtrService.GetEmployeeActiveDtrs(instructorId);
            dgvDTR.Rows.Clear();
            if (null != response)
            {
                foreach (DTR d in response.data)
                {
                    dgvDTR.Rows.Add(d._id,d.schedule?.subject, d.date, d.hoursRendered, d.timeIn, d.timeOut);
                }
            } else
            {
                btnDeleteDTR.Enabled = false;
                btnUpdateDTR.Enabled = false;
            }
            Cursor = Cursors.Arrow;
        }

        private void DgvSchedules_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                int currentMouseOverRow = dgvSchedules.HitTest(e.X, e.Y).RowIndex;
                if (currentMouseOverRow >= 0)
                {
                    dgvSchedules.Rows[currentMouseOverRow].Selected = true;
                    scheduleId = dgvSchedules.Rows[currentMouseOverRow].Cells[0].Value.ToString();
                    unit = dgvSchedules.Rows[currentMouseOverRow].Cells[5].Value.ToString();
                    contextMenuStrip1.Show(dgvSchedules, new Point(e.X, e.Y));
                    btnAddDTR.Enabled = true;
                }
            }
        }

        private void DgvSchedules_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                scheduleId = dgvSchedules.Rows[e.RowIndex].Cells[0].Value.ToString();
                unit = dgvSchedules.Rows[e.RowIndex].Cells[5].Value.ToString();
                btnAddDTR.Enabled = true;
            }
        }

        private void DgvDTR_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int currentMouseOverRow = dgvDTR.HitTest(e.X, e.Y).RowIndex;
                if (currentMouseOverRow >= 0)
                {
                    dgvDTR.Rows[currentMouseOverRow].Selected = true;
                    dtrId = dgvDTR.Rows[currentMouseOverRow].Cells[0].Value.ToString();
                    renderedHour = dgvDTR.Rows[currentMouseOverRow].Cells[3].Value.ToString();
                    contextMenuStrip2.Show(dgvDTR, new Point(e.X, e.Y));
                    btnUpdateDTR.Enabled = true;
                    btnDeleteDTR.Enabled = true;
                }
            }
        }

        private void DgvDTR_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                dtrId = dgvDTR.Rows[e.RowIndex].Cells[0].Value.ToString();
                renderedHour = dgvDTR.Rows[e.RowIndex].Cells[3].Value.ToString();
                btnUpdateDTR.Enabled = true;
                btnDeleteDTR.Enabled = true;
            }
        }

        private async void BtnUpdateDTR_Click(object sender, EventArgs e)
        {
            frmEditDTR = new frmEditDTR();
            frmEditDTR.renderedHour = renderedHour;
            if (frmEditDTR.ShowDialog() == DialogResult.OK)
            {
                DtrUpdate payload = new DtrUpdate();
                payload.hoursRendered = float.Parse(frmEditDTR.renderedHour);
                var response = await dtrService.UpdateDtr(dtrId, payload);
                if(response != null)
                {
                    GetDTRs(employee);
                    MessageBox.Show("DTR has been updated", "DTR Update", MessageBoxButtons.OK);
                }
                btnUpdateDTR.Enabled = false;
                btnDeleteDTR.Enabled = false;
            }
        }

        private async void BtnDeleteDTR_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Delete", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                var response = await dtrService.DeleteDtr(dtrId);
                if(response != null)
                {
                    GetDTRs(employee);
                    MessageBox.Show("DTR has been deleted", "DTR Delete", MessageBoxButtons.OK);
                    btnUpdateDTR.Enabled = false;
                    btnDeleteDTR.Enabled = false;
                }
            }
        }

        private async void BtnAddDTR_Click(object sender, EventArgs e)
        {
            frmAddDTR = new frmAddDTR();
            frmAddDTR.renderedHour = unit;
            if (frmAddDTR.ShowDialog() == DialogResult.OK)
            {
                AddDTRTeaching payload = new AddDTRTeaching();
                payload.date = frmAddDTR.date;
                payload.hour = float.Parse(frmAddDTR.renderedHour);
                payload.instructor = employee;
                payload.scheduleId = scheduleId;

                var response = await dtrService.PostManualTeachingDTR(payload);
                if(response != null)
                {
                    MessageBox.Show("DTR successfully added", "Add DTR", MessageBoxButtons.OK);
                    GetDTRs(employee);
                    btnAddDTR.Enabled = false;
                }
            }
        }

        private void frmManualTeaching_Load(object sender, EventArgs e)
        {
            instructorService = new InstructorService(Program.xApiKey, Program.serverUrl);
            dtrService = new DtrService(Program.xApiKey, Program.serverUrl);
            scheduleService = new ScheduleService(Program.xApiKey, Program.serverUrl);
            optInstructor.DisplayMember = "Key";
            optInstructor.ValueMember = "Value";
            GetInstructors();
            dtrId = string.Empty;
            scheduleId = string.Empty;
            btnAddDTR.Enabled = false;
            btnUpdateDTR.Enabled = false;
            btnDeleteDTR.Enabled = false;
            unit = string.Empty;

        }

        private async void GetInstructors()
        {
            Cursor = Cursors.WaitCursor;
            var response = await instructorService.GetInstructors();
            if (null != response)
            {
                List<KeyValuePair<string, string>> items = new List<KeyValuePair<string, string>>();
                items.Add(new KeyValuePair<string, string>("<<Select Instructor>>", ""));
                if (null != response)
                {
                    foreach (EmployeesList i in response.data)
                    {
                        items.Add(new KeyValuePair<string, string>($"{i.firstName} {i.lastName}", i._id));
                    }
                }
                optInstructor.DataSource = items;
                
            }
            Cursor = Cursors.Arrow;
        }
    }
}
