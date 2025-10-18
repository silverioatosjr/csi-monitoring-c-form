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

namespace CSIEmployeeMonitoringSystem.Forms.Employee
{
    public partial class frmEmployeesList : Form
    {
        EmployeeService employeeService;
        private string apiKey = Program.xApiKey;
        private string apiUrl = Program.serverUrl;
        public frmEmployeesList()
        {
            InitializeComponent();
            dgvEmployeesList.CellClick += dgvEmployeesList_CellClick;
            btnRefresh.Click += BtnRefresh_Click;
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            GetEmployees();
        }

        private void frmEmployeesList_Load(object sender, EventArgs e)
        {
            employeeService = new EmployeeService(apiKey, apiUrl);
            GetEmployees();
        }

        private void dgvEmployeesList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                //employee.firstName = dgvEmployeesList.Rows[e.RowIndex].Cells[15].Value.ToString();
                
            }
        }
        private async void GetEmployees()
        {
            var response = await employeeService.GetEmployeesList();
            dgvEmployeesList.Rows.Clear();
            if (null != response)
            {
                foreach (EmployeesList s in response.data)
                {
                    dgvEmployeesList.Rows.Add(
                        s._id, $"{s.firstName} {s.lastName}", 
                        s.code, s.hourlyRate, s.basicSalary, 
                        s.designation, s.employmentStatus,
                        employeeService.formatDgvTaxCellValue(s.deduction),
                        employeeService.formatDgvSssCellValue(s.deduction),
                        employeeService.formatDgvPagibigCellValue(s.deduction),
                        employeeService.formatDgvPhilhealthCellValue(s.deduction)
                    );
                }
            }
        }
        
    }
}
