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
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmGeneratePayroll_Load(object sender, EventArgs e)
        {
            payrollService = new PayrollService(Program.xApiKey, Program.serverUrl);
            ResetDateFilter();
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
