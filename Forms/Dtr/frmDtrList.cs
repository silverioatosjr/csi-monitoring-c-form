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
    public partial class frmDtrList : Form
    {
        private EmployeeService employeeService;
        public string dtrId;
        public frmDtrList()
        {
            InitializeComponent();
            btnReset.Click += BtnReset_Click;
            btnSearch.Click += BtnSearch_Click;
            btnClose.Click += BtnClose_Click;
            btnPrint.Click += BtnPrint_Click;
            btnDtrDetails.Click += BtnDtrDetails_Click;
        }

        private void BtnDtrDetails_Click(object sender, EventArgs e)
        {
            
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            
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
                if (optEmployees.SelectedValue.ToString() == string.Empty)
                {
                }
                else
                {
                }
                Cursor = Cursors.Arrow;
           }
        }
        private void ResetDateFilter()
        {
            DateTime d = DateTime.Today;
            DateTime dF = new DateTime(d.Year, d.Day <= 15 ? 1 : 16, d.Month);
            dtpFrom.Value = DateTime.Parse(dF.ToString("dd/MM/yyyy"));
            dtpTo.Value = d;
        }

        private void frmDtrList_Load(object sender, EventArgs e)
        {
            employeeService = new EmployeeService(Program.xApiKey, Program.serverUrl);
            ResetDateFilter();
            dtrId = string.Empty;
            btnDtrDetails.Enabled = false;
            btnPrint.Enabled = false;
            GetEmployees();
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

        
    }
}
