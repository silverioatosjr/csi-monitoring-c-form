using CSIEmployeeMonitoringSystem.Models;
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
    public partial class frmArchivedPayroll : Form
    {
        private EmployeeService employeeService;
        private PayrollService payrollService;
        public frmArchivedPayroll()
        {
            InitializeComponent();
            btnSearch.Click += BtnSearch_Click;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if(optEmployee.SelectedIndex != 0 && optMonth.SelectedIndex != 0 && optYear.SelectedIndex != 0)
            {
                GetArchivedPayrolls();
            } else
            {
                MessageBox.Show("Select filter.", "Payroll", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void GetArchivedPayrolls()
        {
            ArchivePayroll payload = new ArchivePayroll();
            payload.employee = optEmployee.SelectedValue.ToString();
            payload.month = optMonth.SelectedValue.ToString();
            payload.year = optYear.SelectedValue.ToString();

            var response = await payrollService.GetArchivedPayroll(payload);
            if(null != response)
            {
                PopulateGdv(response.data);
            } else
            {
                MessageBox.Show("Payroll not found", "Payroll", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void PopulateGdv(List<PayrollData> payrolls)
        {
            dgvCurrentPayroll.Rows.Clear();
            foreach (PayrollData p in payrolls)
            {
                dgvCurrentPayroll.Rows.Add(
                    p._id, $"{p.employee.firstName} {p.employee.lastName}",
                    p.month, p.days, p.daysWorked, p.totalHours, p.grossPay, p.netPay,
                    p.tax, p.sss, p.pagibig, p.philhealth
                //d.day, DateTime.Parse(d.date).ToString("MM/dd/yyyy")
                );
            }
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
                        items.Add(new KeyValuePair<string, string>($"{i.firstName} {i.lastName}", i._id));
                    }
                }
                optEmployee.DataSource = items;
                optEmployee.DisplayMember = "Key";
                optEmployee.ValueMember = "Value";
            }
        }

        private void SetMonths()
        {
            List<KeyValuePair<string, string>> items = new List<KeyValuePair<string, string>>();
            items.Add(new KeyValuePair<string, string>("<<Select Month>>", ""));
            items.Add(new KeyValuePair<string, string>("January", "January"));
            items.Add(new KeyValuePair<string, string>("February", "February"));
            items.Add(new KeyValuePair<string, string>("March", "March"));
            items.Add(new KeyValuePair<string, string>("April", "April"));
            items.Add(new KeyValuePair<string, string>("May", "May"));
            items.Add(new KeyValuePair<string, string>("June", "June"));
            items.Add(new KeyValuePair<string, string>("July", "July"));
            items.Add(new KeyValuePair<string, string>("August", "August"));
            items.Add(new KeyValuePair<string, string>("September", "September"));
            items.Add(new KeyValuePair<string, string>("October", "October"));
            items.Add(new KeyValuePair<string, string>("November", "November"));
            items.Add(new KeyValuePair<string, string>("December", "December"));
            optMonth.DataSource = items;
            optMonth.DisplayMember = "Key";
            optMonth.ValueMember = "Value";
        }
        private void SetYears()
        {
            List<KeyValuePair<string, string>> items = new List<KeyValuePair<string, string>>();
            items.Add(new KeyValuePair<string, string>("<<Select Year>>", ""));
            DateTime d = DateTime.Today;
            for(int y=2025; y<= d.Year; y++)
            {
                items.Add(new KeyValuePair<string, string>($"{y}", $"{y}"));
            }
            optYear.DataSource = items;
            optYear.DisplayMember = "Key";
            optYear.ValueMember = "Value";

        }

        private void frmArchivedPayroll_Load(object sender, EventArgs e)
        {
            employeeService = new EmployeeService(Program.xApiKey, Program.serverUrl);
            payrollService = new PayrollService(Program.xApiKey, Program.serverUrl);
            GetEmployees();
            SetMonths();
            SetYears();
        }
    }
}
