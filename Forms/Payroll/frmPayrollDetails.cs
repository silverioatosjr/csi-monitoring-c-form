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
    public partial class frmPayrollDetails : Form
    {
        private PayrollService payrollService;
        public string payrollId;
        private const int CP_NOCLOSE_BUTTON = 0x200;
        private InputFilter inputs;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }
        public frmPayrollDetails()
        {
            InitializeComponent();
            btnClose.Click += BtnClose_Click;
            btnUpdate.Click += BtnUpdate_Click;
            txtNetPay.TextChanged += txt_TextChanged;
            txtNetPay.GotFocus += txt_GotFocus;
            txtNetPay.LostFocus += txt_LostFocus;
            txtGrossPay.TextChanged += txt_TextChanged;
            txtGrossPay.GotFocus += txt_GotFocus;
            txtGrossPay.LostFocus += txt_LostFocus;
            txtTax.TextChanged += txt_TextChanged;
            txtTax.GotFocus += txt_GotFocus;
            txtTax.LostFocus += txt_LostFocus;
            txtSSS.TextChanged += txt_TextChanged;
            txtSSS.GotFocus += txt_GotFocus;
            txtSSS.LostFocus += txt_LostFocus;
            txtPagibig.TextChanged += txt_TextChanged;
            txtPagibig.GotFocus += txt_GotFocus;
            txtPagibig.LostFocus += txt_LostFocus;
            txtPhilhealth.TextChanged += txt_TextChanged;
            txtPhilhealth.GotFocus += txt_GotFocus;
            txtPhilhealth.LostFocus += txt_LostFocus;

        }

        private void txt_TextChanged(object sender, EventArgs e)
        {
            inputs.Filter((TextBox)sender);
        }
        private void txt_LostFocus(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text == string.Empty)
            {
                ((TextBox)sender).Text = "0";
            }
        }
        private void txt_GotFocus(object sender, EventArgs e)
        {
            if (sender.GetType().Name == "TextBox")
            {
                ((TextBox)sender).Text = (((TextBox)sender).Text == "0") ? "" : ((TextBox)sender).Text;
                ((TextBox)sender).SelectionStart = ((TextBox)sender).TextLength;
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if(btnUpdate.Text == "Edit")
            {
                btnUpdate.Text = "Update";
                txtGrossPay.Enabled = true;
                txtNetPay.Enabled = true;
                txtPagibig.Enabled = true;
                txtPhilhealth.Enabled = true;
                txtSSS.Enabled = true;
                txtTax.Enabled = true;
            } else
            {
                
                UpdatePayroll();
                btnUpdate.Text = "Edit";
                txtGrossPay.Enabled = false;
                txtNetPay.Enabled = false;
                txtPagibig.Enabled = false;
                txtPhilhealth.Enabled = false;
                txtSSS.Enabled = false;
                txtTax.Enabled = false;
            }
        }

        private async void UpdatePayroll()
        {
            PayrollUpdate payload = new PayrollUpdate();
            payload.grossPay = float.Parse(txtGrossPay.Text);
            payload.netPay = float.Parse(txtNetPay.Text);
            payload.pagibig = float.Parse(txtPagibig.Text);
            payload.philhealth = float.Parse(txtPhilhealth.Text);
            payload.sss = float.Parse(txtSSS.Text);
            payload.tax = float.Parse(txtTax.Text);

            var response = await payrollService.UpdatePayroll(payrollId, payload);
            if(null != response)
            {
                MessageBox.Show("Payroll has been updated.", "Payroll", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else
            {
                MessageBox.Show("Unable to update payroll.", "Payroll", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private async void GetPayroll()
        {
            var response = await payrollService.GetPayroll(payrollId);
            if(null != response)
            {
                txtName.Text = $"{response.data.employee.firstName} {response.data.employee.lastName}";
                txtGrossPay.Text = response.data.grossPay.ToString();
                txtNetPay.Text = response.data.netPay.ToString();
                txtTax.Text = response.data.tax.ToString();
                txtSSS.Text = response.data.sss.ToString();
                txtPagibig.Text = response.data.pagibig.ToString();
                txtPhilhealth.Text = response.data.philhealth.ToString();
            }
        }

        private void frmPayrollDetails_Load(object sender, EventArgs e)
        {
            payrollService = new PayrollService(Program.xApiKey, Program.serverUrl);
            GetPayroll();
            txtName.Enabled = false;
            txtGrossPay.Enabled = false;
            txtNetPay.Enabled = false;
            txtPagibig.Enabled = false;
            txtPhilhealth.Enabled = false;
            txtSSS.Enabled = false;
            txtTax.Enabled = false;
            inputs = new InputFilter();
        }
    }
}
