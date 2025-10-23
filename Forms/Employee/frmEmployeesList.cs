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
        frmUpdateEmployee frmUpdateEmployee = new frmUpdateEmployee();
        private string apiKey = Program.xApiKey;
        private string apiUrl = Program.serverUrl;
        public string employeeId;
        public frmEmployeesList()
        {
            InitializeComponent();
            dgvEmployeesList.CellClick += dgvEmployeesList_CellClick;
            dgvEmployeesList.MouseClick += DgvEmployeesList_MouseClick;
            btnRefresh.Click += BtnRefresh_Click;
            deleteToolStripMenuItem.Click += DeleteToolStripMenuItem_Click;
            mnuToolUpdateEmployee.Click += MnuToolUpdateEmployee_Click;
            btnClose.Click += BtnClose_Click;
            btnDeleteEmployee.Click += BtnDeleteEmployee_Click;
            btnUpdateEmployee.Click += BtnUpdateEmployee_Click;
        }

        private void BtnUpdateEmployee_Click(object sender, EventArgs e)
        {
            if(employeeId != string.Empty)
            {
                MnuToolUpdateEmployee_Click(sender, e);
            }
        }

        private void BtnDeleteEmployee_Click(object sender, EventArgs e)
        {
            if (employeeId != string.Empty)
            {
                DeleteToolStripMenuItem_Click(sender, e);
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void MnuToolUpdateEmployee_Click(object sender, EventArgs e)
        {
            if(!frmUpdateEmployee.Created)
            {
                frmUpdateEmployee = new frmUpdateEmployee();
            }
            frmUpdateEmployee.employeeId = employeeId;
            if(frmUpdateEmployee.ShowDialog() == DialogResult.OK)
            {
                employeeId = string.Empty;
                GetEmployees();
                btnUpdateEmployee.Enabled = false;
                btnDeleteEmployee.Enabled = false;
            }
        }

        private async void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("To delete this record, click OK button", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                var data = await employeeService.DeleteEmployee(employeeId);
                if (null != data)
                {
                    MessageBox.Show("Employee has been deleted", "Delete Employee", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    employeeId = string.Empty;
                    GetEmployees();
                    btnUpdateEmployee.Enabled = false;
                    btnDeleteEmployee.Enabled = false;
                } else
                {
                    MessageBox.Show("Unable to delete employee", "Delete Employee", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DgvEmployeesList_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                
                int currentMouseOverRow = dgvEmployeesList.HitTest(e.X, e.Y).RowIndex;
                if (currentMouseOverRow >= 0)
                {
                    dgvEmployeesList.Rows[currentMouseOverRow].Selected = true;
                    employeeId = dgvEmployeesList.Rows[currentMouseOverRow].Cells[0].Value.ToString();
                    contextMenu.Show(dgvEmployeesList, new Point(e.X, e.Y));
                    btnUpdateEmployee.Enabled = true;
                    btnDeleteEmployee.Enabled = true;
                }


            }
            
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            GetEmployees();
        }

        private void frmEmployeesList_Load(object sender, EventArgs e)
        {
            employeeService = new EmployeeService(apiKey, apiUrl);
            employeeId = string.Empty;
            GetEmployees();
            btnUpdateEmployee.Enabled = false;
            btnDeleteEmployee.Enabled = false;
        }

        private void dgvEmployeesList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                employeeId = dgvEmployeesList.Rows[e.RowIndex].Cells[0].Value.ToString();
                btnUpdateEmployee.Enabled = true;
                btnDeleteEmployee.Enabled = true;
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
