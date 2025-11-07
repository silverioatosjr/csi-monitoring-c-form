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

        }
    }
}
