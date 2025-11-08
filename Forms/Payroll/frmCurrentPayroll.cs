using CSIEmployeeMonitoringSystem.Models.Payroll;
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

namespace CSIEmployeeMonitoringSystem.Forms.Payroll
{
    public partial class frmCurrentPayroll : Form
    {
        private frmPayrollDetails frmPayrollDetails = new frmPayrollDetails();
        private frmGeneratePayroll frmGeneratePayroll = new frmGeneratePayroll();
        private PayrollService payrollService;
        private PrintService printService;
        private string payrollId;
        private PayrollData payrollData;
        public frmCurrentPayroll()
        {
            InitializeComponent();
            btnClose.Click += BtnClose_Click;
            btnViewDetails.Click += BtnViewDetails_Click;
            btnGeneratePayroll.Click += BtnGeneratePayroll_Click;
            btnArchivePayroll.Click += BtnArchivePayroll_Click;
            btnDeleteCurrentPayroll.Click += BtnDeleteCurrentPayroll_Click;
            mnuViewDetails.Click += MnuViewDetails_Click;
            dgvCurrentPayroll.CellClick += DgvCurrentPayroll_CellClick;
            dgvCurrentPayroll.MouseClick += DgvCurrentPayroll_MouseClick;
            mnuPrint.Click += MnuPrint_Click;
            btnPrintSelected.Click += MnuPrint_Click;
        }

        private void MnuPrint_Click(object sender, EventArgs e)
        {
            GetPayroll();
            if(MessageBox.Show("Click OK to continue...", "Print Payroll", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {

                printPayroll.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("payroll", 816, 1056);
                printPayrollDialog.Document = printPayroll;
                printPayrollDialog.Document.Print();
            }
        }
        private async void GetPayroll()
        {
            var response = await payrollService.GetPayroll(payrollId);
            if(null != response)
            {
                payrollData = response.data;
            }
        }
        
        private void DgvCurrentPayroll_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                int currentMouseOverRow = dgvCurrentPayroll.HitTest(e.X, e.Y).RowIndex;
                if (currentMouseOverRow >= 0)
                {
                    dgvCurrentPayroll.Rows[currentMouseOverRow].Selected = true;
                    payrollId = dgvCurrentPayroll.Rows[currentMouseOverRow].Cells[0].Value.ToString();
                    contextMenu.Show(dgvCurrentPayroll, new Point(e.X, e.Y));
                    btnViewDetails.Enabled = true;
                    btnPrintSelected.Enabled = true;
                }

            }
        }

        private void DgvCurrentPayroll_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                payrollId = dgvCurrentPayroll.Rows[e.RowIndex].Cells[0].Value.ToString();
                btnViewDetails.Enabled = true;
                btnPrintSelected.Enabled = true;
            }
        }

        private void MnuViewDetails_Click(object sender, EventArgs e)
        {
            if (!frmPayrollDetails.Created)
            {
                frmPayrollDetails = new frmPayrollDetails();
            }
            frmPayrollDetails.payrollId = payrollId;
            if (frmPayrollDetails.ShowDialog() == DialogResult.OK)
            {
                GetCurrentPayrolls();
            }
            payrollId = string.Empty;
            btnViewDetails.Enabled = false;
            btnPrintSelected.Enabled = false;
        }

        private void BtnDeleteCurrentPayroll_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deleting payroll cannot be reverted. Are you sure?", "Payroll", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DeleteParolls();
                GetCurrentPayrolls();
            }
        }
        private async void DeleteParolls()
        {
            var response = await payrollService.DeleteCureentPayroll();
            if (null != response)
            {
                MessageBox.Show("Current payrolls have been deleted.", "Payroll", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void BtnArchivePayroll_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Archiving payroll cannot be reverted. Are you sure?", "Payroll", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ArchiveParolls();
                GetCurrentPayrolls();
            }
        }
        private async void ArchiveParolls()
        {
            var response = await payrollService.ArchiveCurrentPayroll();
            if(null != response)
            {
                MessageBox.Show("Current payrolls have been archived.\nYou can see it in the archived window", "Payroll", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else
            {
                MessageBox.Show("Unable to archived payroll.", "Payroll", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BtnGeneratePayroll_Click(object sender, EventArgs e)
        {
            if(frmGeneratePayroll.ShowDialog() == DialogResult.OK)
            {
                GetCurrentPayrolls();
            }
        }

        private async void GetCurrentPayrolls()
        {
            dgvCurrentPayroll.Rows.Clear();
            var response = await payrollService.GetCurrentPayrolls();
            if(null != response)
            {
                Cursor = Cursors.WaitCursor;
                PopulateGdv(response.data);
                Cursor = Cursors.Arrow;
            } else
            {
                btnGeneratePayroll.Enabled = true;
                btnArchivePayroll.Enabled = false;
                btnDeleteCurrentPayroll.Enabled = false;
            }
        }

        private void PopulateGdv(List<PayrollData> payrolls)
        {
            dgvCurrentPayroll.Rows.Clear();
            if (payrolls.Count > 0)
            {
                btnGeneratePayroll.Enabled = false;
                btnArchivePayroll.Enabled = true;
                btnDeleteCurrentPayroll.Enabled = true;
            }
            else
            {
                btnGeneratePayroll.Enabled = true;
                btnArchivePayroll.Enabled = false;
                btnDeleteCurrentPayroll.Enabled = false;
            }

            foreach (PayrollData p in payrolls)
            {
                dgvCurrentPayroll.Rows.Add(
                    p._id, $"{p.employee.firstName} {p.employee.lastName}",
                    p.month, p.days, p.daysWorked, p.totalHours,p.grossPay, p.netPay,
                    p.tax, p.sss, p.pagibig, p.philhealth
                    //d.day, DateTime.Parse(d.date).ToString("MM/dd/yyyy")
                );
            }
        }
        private void BtnViewDetails_Click(object sender, EventArgs e)
        {
            MnuViewDetails_Click(sender, e);
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCurrentPayroll_Load(object sender, EventArgs e)
        {
            payrollService = new PayrollService(Program.xApiKey, Program.serverUrl);
            printService = new PrintService();
            payrollData = new PayrollData();
            btnPrintSelected.Enabled = false;
            btnViewDetails.Enabled = false;
            btnGeneratePayroll.Enabled = false;
            btnDeleteCurrentPayroll.Enabled = false;
            btnArchivePayroll.Enabled = false;
            GetCurrentPayrolls();
            payrollId = string.Empty;
        }

        private void printPayroll_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            printService.PrintPayroll(e, payrollData);
        }
    }
}
