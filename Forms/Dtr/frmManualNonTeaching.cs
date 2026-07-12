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
    public partial class frmManualNonTeaching : Form
    {
        private frmAddDTR frmAddDTR;
        private frmEditDTR frmEditDTR;
        private EmployeeService employeeService;
        private DtrService dtrService;
        private string dtrId;
        private string staffId;
        private string renderedHour = "0";
        public frmManualNonTeaching()
        {
            InitializeComponent();
            btnAddDTR.Click += BtnAddDTR_Click;
            btnDeleteDTR.Click += BtnDeleteDTR_Click;
            btnUpdateDTR.Click += BtnUpdateDTR_Click;
            mnuEdit.Click += BtnUpdateDTR_Click;
            mnuDelete.Click += BtnDeleteDTR_Click;
            dgvDTR.CellClick += DgvDTR_CellClick;
            dgvDTR.MouseClick += DgvDTR_MouseClick;
            optNonTeachingStaff.TextChanged += OptNonTeachingStaff_TextChanged;
        }

        private void OptNonTeachingStaff_TextChanged(object sender, EventArgs e)
        {
            if (optNonTeachingStaff.SelectedValue.ToString() != string.Empty)
            {
                staffId = optNonTeachingStaff.SelectedValue.ToString();
                GetDTRs(staffId);
                btnAddDTR.Enabled = true;
            } else
            {
                btnAddDTR.Enabled = false;
                btnDeleteDTR.Enabled = false;
                btnUpdateDTR.Enabled = false;
                dgvDTR.Rows.Clear();
            }
        }

        private async void GetDTRs(string staffId)
        {
            Cursor = Cursors.WaitCursor;
            var response = await dtrService.GetEmployeeActiveDtrs(staffId);
            dgvDTR.Rows.Clear();
            if (null != response)
            {
                foreach (DTR d in response.data)
                {
                    dgvDTR.Rows.Add(d._id, d.date, d.timeIn, d.timeOut, d.hoursRendered);
                }
            }
            else
            {
                btnDeleteDTR.Enabled = false;
                btnUpdateDTR.Enabled = false;
            }
            Cursor = Cursors.Arrow;
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
                    renderedHour = dgvDTR.Rows[currentMouseOverRow].Cells[4].Value.ToString();
                    contextMenuStrip1.Show(dgvDTR, new Point(e.X, e.Y));
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
                renderedHour = dgvDTR.Rows[e.RowIndex].Cells[4].Value.ToString();
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
                if (response != null)
                {
                    GetDTRs(staffId);
                    MessageBox.Show("DTR has been updated", "DTR Update", MessageBoxButtons.OK);
                }
                btnUpdateDTR.Enabled = false;
                btnDeleteDTR.Enabled = false;
            }
        }
        private async void BtnDeleteDTR_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure?","Delete", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                var response = await dtrService.DeleteDtr(dtrId);
                if (response != null)
                {
                    GetDTRs(staffId);
                    MessageBox.Show("DTR has been deleted", "DTR Delete", MessageBoxButtons.OK);
                    btnUpdateDTR.Enabled = false;
                    btnDeleteDTR.Enabled = false;
                }
            }
        }

        private async void BtnAddDTR_Click(object sender, EventArgs e)
        {
            frmAddDTR = new frmAddDTR();
            if (frmAddDTR.ShowDialog() == DialogResult.OK)
            {
                AddDTRNonTeaching payload = new AddDTRNonTeaching();
                payload.date = frmAddDTR.date;
                payload.hour = float.Parse(frmAddDTR.renderedHour);
                payload.employee = staffId;
                
                var response = await dtrService.PostManualNonTeachingDTR(payload);
                if (response != null)
                {
                    MessageBox.Show("DTR successfully added", "Add DTR", MessageBoxButtons.OK);
                    GetDTRs(staffId);
                }
            }
        }

        private void frmManualNonTeaching_Load(object sender, EventArgs e)
        {
            employeeService = new EmployeeService(Program.xApiKey, Program.serverUrl);
            dtrService = new DtrService(Program.xApiKey, Program.serverUrl);
            optNonTeachingStaff.DisplayMember = "Key";
            optNonTeachingStaff.ValueMember = "Value";
            GetNonTeachingStaffs();
            dtrId = string.Empty;
            staffId = string.Empty;
        }
        private async void GetNonTeachingStaffs()
        {
            Cursor = Cursors.WaitCursor;
            var response = await employeeService.GetNonTeachingStaffs();
            if (null != response)
            {
                List<KeyValuePair<string, string>> items = new List<KeyValuePair<string, string>>();
                items.Add(new KeyValuePair<string, string>("<<Select Staff>>", ""));
                if (null != response)
                {
                    foreach (EmployeesList i in response.data)
                    {
                        items.Add(new KeyValuePair<string, string>($"{i.firstName} {i.lastName}", i._id));
                    }
                }
                optNonTeachingStaff.DataSource = items;
                
            }
            Cursor = Cursors.Arrow;
        }
    }
}
