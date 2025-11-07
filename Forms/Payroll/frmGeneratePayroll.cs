using CSIEmployeeMonitoringSystem.Models.Payroll;
using CSIEmployeeMonitoringSystem.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSIEmployeeMonitoringSystem.Forms.Payroll
{

    public partial class frmGeneratePayroll : Form
    {
        private const int CP_NOCLOSE_BUTTON = 0x200;
        private PayrollService payrollService;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }
        public frmGeneratePayroll()
        {
            InitializeComponent();
            btnClose.Click += BtnClose_Click;
            btnGenerate.Click += BtnGenerate_Click;
            dtpFrom.ValueChanged += DtpFrom_ValueChanged;
        }

        private void DtpFrom_ValueChanged(object sender, EventArgs e)
        {
            var d = DateTime.Parse(dtpFrom.Value.ToString()).Month;
            string[] monthNames = CultureInfo.InvariantCulture.DateTimeFormat.MonthNames;
            optMonth.SelectedItem = monthNames[d - 1];
        }

        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            if (dtpFrom.Value > dtpTo.Value)
            {
                MessageBox.Show("Invalid date range.\nThe EndDate should always greater than the StartDate.", "Filter", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetDateFilter();
            }
            else
            {
                Cursor = Cursors.WaitCursor;
                DisableComponents();
                GeneratePayrolls();
                EnableComponents();
                Cursor = Cursors.Arrow;
            }
        }
        private void DisableComponents()
        {
            btnClose.Enabled = false;
            btnGenerate.Enabled = false;
            optMonth.Enabled = false;
            dtpFrom.Enabled = false;
            dtpTo.Enabled = false;
        }
        private void EnableComponents()
        {
            btnClose.Enabled = true;
            btnGenerate.Enabled = true;
            optMonth.Enabled = true;
            dtpFrom.Enabled = true;
            dtpTo.Enabled = true;
        }

        private async void GeneratePayrolls()
        {
            GeneratePayroll payload = new GeneratePayroll();
            payload.dateFrom = dtpFrom.Value;
            payload.dateTo = dtpTo.Value;
            payload.month = optMonth.SelectedItem.ToString();
            var response = await payrollService.GeneratePayroll(payload);
            if (null != response)
            {
                MessageBox.Show("Payroll has been generated successfully", "Payroll", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Invoke(new Action(delegate() {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }));
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmGeneratePayroll_Load(object sender, EventArgs e)
        {
            payrollService = new PayrollService(Program.xApiKey, Program.serverUrl);
            ResetDateFilter();
            PopulateMonth();
        }

        private void PopulateMonth()
        {
            optMonth.Items.Clear();
            int currentMonth = DateTime.Now.Month;
            string[] monthNames = CultureInfo.InvariantCulture.DateTimeFormat.MonthNames;
            for (int i = 0; i < 12; i++)
            {
                int monthIndex = (currentMonth - 1 + i) % 12;
                optMonth.Items.Add(monthNames[monthIndex]);
            }
            optMonth.SelectedItem = monthNames[currentMonth-1];
        }
        private void ResetDateFilter()
        {
            DateTime d = DateTime.Today;
            DateTime dF = new DateTime(d.Year, d.Day <= 15 ? 1 : 16, d.Month);
            dtpFrom.Value = DateTime.Parse(dF.ToString("dd/MM/yyyy"));
            dtpTo.Value = d;
        }
    }
}
