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
            var response = await payrollService.GetCurrentPayrolls();
            if(null != response)
            {
               
                PopulateGdv(response.data);
            } else
            {
                btnGeneratePayroll.Enabled = true;
            }
        }

        private void PopulateGdv(List<PayrollData> payrolls)
        {
            dgvCurrentPayroll.Rows.Clear();
            if (payrolls.Count > 0)
            {
                btnPrintAll.Enabled = true;
                btnPrintAll.Cursor = Cursors.Arrow;
                btnGeneratePayroll.Enabled = false;
                btnArchivePayroll.Enabled = true;
                btnDeleteCurrentPayroll.Enabled = true;
            }
            else
            {
                btnPrintAll.Enabled = false;
                btnGeneratePayroll.Enabled = false;
                btnArchivePayroll.Enabled = false;
                btnDeleteCurrentPayroll.Enabled = true;
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
