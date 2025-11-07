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
        public frmCurrentPayroll()
        {
            InitializeComponent();
            btnClose.Click += BtnClose_Click;
            btnViewDetails.Click += BtnViewDetails_Click;
            btnGeneratePayroll.Click += BtnGeneratePayroll_Click;
            btnArchivePayroll.Click += BtnArchivePayroll_Click;
            btnDeleteCurrentPayroll.Click += BtnDeleteCurrentPayroll_Click;
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
                btnPrintAll.Enabled = false;
            }
        }

        private void PopulateGdv(List<PayrollData> payrolls)
        {
            dgvCurrentPayroll.Rows.Clear();
            if (payrolls.Count > 0)
            {
                btnPrintAll.Enabled = true;
                btnGeneratePayroll.Enabled = false;
                btnArchivePayroll.Enabled = true;
                btnDeleteCurrentPayroll.Enabled = true;
            }
            else
            {
                btnPrintAll.Enabled = false;
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
            if(frmPayrollDetails.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCurrentPayroll_Load(object sender, EventArgs e)
        {
            payrollService = new PayrollService(Program.xApiKey, Program.serverUrl);
            btnPrintAll.Enabled = false;
            btnPrintSelected.Enabled = false;
            btnViewDetails.Enabled = false;
            btnGeneratePayroll.Enabled = false;
            btnDeleteCurrentPayroll.Enabled = false;
            btnArchivePayroll.Enabled = false;
            GetCurrentPayrolls();
        }
    }
}
