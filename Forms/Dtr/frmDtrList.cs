using CSIEmployeeMonitoringSystem.Models;
using CSIEmployeeMonitoringSystem.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSIEmployeeMonitoringSystem.Forms.Dtr
{
    public partial class frmDtrList : Form
    {
        private EmployeeService employeeService;
        private DtrService dtrService;
        private frmDtrDetails frmDtrDetails = new frmDtrDetails();
        private PrintService printService;
        public string dtrId;
        public frmDtrList()
        {
            InitializeComponent();
            btnReset.Click += BtnReset_Click;
            btnSearch.Click += BtnSearch_Click;
            btnClose.Click += BtnClose_Click;
            btnPrint.Click += BtnPrint_Click;
            btnDtrDetails.Click += BtnDtrDetails_Click;
            dgvDtrs.CellClick += DgvDtrs_CellClick;
            dgvDtrs.MouseClick += DgvDtrs_MouseClick;
            mnuViewDetails.Click += MnuViewDetails_Click;
            mnuDelete.Click += MnuDelete_Click;
        }

        private void MnuDelete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to delete?", "Dtr", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Cursor = Cursors.WaitCursor;
                DeleteDtr();
                GetDtrs();
                Cursor = Cursors.Arrow;
            }
        }
        private async void DeleteDtr()
        {
            var response = await dtrService.DeleteDtr(dtrId);
            if(null != response)
            {
                MessageBox.Show("Dtr has been deleted.", "Dtr", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtrId = string.Empty;

            } else
            {
                MessageBox.Show("Unable to delete Dtr.", "Dtr", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MnuViewDetails_Click(object sender, EventArgs e)
        {
            if (!frmDtrDetails.Created)
            {
                frmDtrDetails = new frmDtrDetails();
            }
            frmDtrDetails.dtrId = dtrId;
            if (frmDtrDetails.ShowDialog() == DialogResult.OK)
            {
                dtrId = string.Empty;
                GetDtrs();
                btnDtrDetails.Enabled = false;
            }
        }

        private void DgvDtrs_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                int currentMouseOverRow = dgvDtrs.HitTest(e.X, e.Y).RowIndex;
                if (currentMouseOverRow >= 0)
                {
                    dgvDtrs.Rows[currentMouseOverRow].Selected = true;
                    dtrId = dgvDtrs.Rows[currentMouseOverRow].Cells[0].Value.ToString();
                    contextMenu.Show(dgvDtrs, new Point(e.X, e.Y));
                    btnDtrDetails.Enabled = true;
                }

            }
        }

        private void DgvDtrs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                dtrId = dgvDtrs.Rows[e.RowIndex].Cells[0].Value.ToString();
                btnDtrDetails.Enabled = true;
            }
        }

        private void BtnDtrDetails_Click(object sender, EventArgs e)
        {
            MnuViewDetails_Click(sender, e);
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Click OK to continue...", "Print DTRs", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                printDtr.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("dtrs", 816, 1056);
                printDtrDialog.Document = printDtr;
                printDtrDialog.Document.Print();
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            if (optEmployees.SelectedIndex != 0)
            {
                optEmployees.SelectedIndex = 0;
            }
            ResetDateFilter();
            GetDtrs();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if(dtpFrom.Value > dtpTo.Value)
            {
                MessageBox.Show("Invalid date range.\nThe EndDate should always greater than the StartDate.", "Filter", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetDateFilter();
            } else
            {
                Cursor = Cursors.WaitCursor;
                GetDtrs();
                Cursor = Cursors.Arrow;
           }
        }
        private void ResetDateFilter()
        {
            DateTime d = DateTime.Today;
            dtpFrom.Value = d;
            dtpTo.Value = d;
        }

        private void frmDtrList_Load(object sender, EventArgs e)
        {
            employeeService = new EmployeeService(Program.xApiKey, Program.serverUrl);
            dtrService = new DtrService(Program.xApiKey, Program.serverUrl);
            printService = new PrintService();
            ResetDateFilter();
            dtrId = string.Empty;
            btnDtrDetails.Enabled = false;
            btnPrint.Enabled = false;
            GetEmployees();
            //Thread.Sleep(500);
            //GetDtrs();
        }

        private async void GetEmployees()
        {
            var response = await employeeService.GetEmployeesList();
            if (null != response)
            {
                List<KeyValuePair<string, string>> items = new List<KeyValuePair<string, string>>();
                items.Add(new KeyValuePair<string, string>("<<Select Employee>>", ""));
                if (null != response)
                {
                    foreach (EmployeesList i in response.data)
                    {
                        items.Add(new KeyValuePair<string, string>($"{i.firstName} {i.lastName} ({i.code})", i._id));
                    }
                }
                optEmployees.DataSource = items;
                optEmployees.DisplayMember = "Key";
                optEmployees.ValueMember = "Value";
            }
        }
        private async void GetDtrs()
        {
            if(optEmployees.SelectedIndex == 0)
            {
                var payload = new DtrGetDateRange();
                payload.dateFrom = dtpFrom.Value;
                payload.dateTo = dtpTo.Value;
                var response = await dtrService.GetDtrs(payload);
                if(null != response)
                {
                    PopulateDgv(response.data);
                }
            } else
            {
                var payload = new DtrGetWithEmployee();
                payload.dateFrom = dtpFrom.Value;
                payload.dateTo = dtpTo.Value;
                payload.employee = optEmployees.SelectedValue.ToString();
                var response = await dtrService.GetEmployeeDtrs(payload);
                if (null != response)
                {
                    PopulateDgv(response.data);
                }
            }
        }

        private void PopulateDgv(List<DTR> dtrs)
        {
            dgvDtrs.Rows.Clear();
            btnDtrDetails.Enabled = false;
            if(dtrs.Count>0)
            {
                btnPrint.Enabled = true;
            } else
            {
                btnPrint.Enabled = false;
            }
            foreach (DTR d in dtrs)
            {
                dgvDtrs.Rows.Add(
                    d._id, $"{d.employee.firstName} {d.employee.lastName}",
                    d.subjectCode, d.timeIn, d.timeOut, d.hoursRendered,
                    d.day, DateTime.Parse(d.date).ToString("MM/dd/yyyy")
                );
            }
            
        }

        private void printDtr_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            printService.PrintDtrs(e, dgvDtrs);
        }
    }
}
