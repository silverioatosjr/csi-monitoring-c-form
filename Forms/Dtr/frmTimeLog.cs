using CSIEmployeeMonitoringSystem.Forms.Biometric;
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
    public partial class frmTimeLog : Form
    {
        private InputFilter inputs;
        private frmBiometricVerification frmBiometricVerification;
        private EmployeeService employeeService;
        public string fingerPrint;
        public bool isMatched;
        public frmTimeLog()
        {
            InitializeComponent();
            txtCode.TextChanged += txt_TextChanged;
            txtCode.GotFocus += txt_GotFocus;
        }

        private void txt_TextChanged(object sender, EventArgs e)
        {
            inputs.Filter((TextBox)sender);
            if(((TextBox)sender).TextLength == 6)
            {
                ((TextBox)sender).Enabled = false;
                GetEmployeeDetails();
            }
        }

        private async void GetEmployeeDetails()
        {
            var response = await employeeService.GetEmployeeDetailsByCode(txtCode.Text);
            if(null != response)
            {
                if(response.isAllowed)
                {
                    fingerPrint = response.data.biometric;
                    OpenBiometric();

                } else
                {
                    MessageBox.Show(response.message, "Verification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else
            {
                MessageBox.Show("Server error");
            }
        }

        private void OpenBiometric()
        {
            if(frmBiometricVerification == null)
            {
                frmBiometricVerification = new frmBiometricVerification();
                frmBiometricVerification._sender = this;
            }
            frmBiometricVerification.ShowDialog();
            txtCode.Enabled = true;
            txtCode.Text = string.Empty;
        }

        private void txt_GotFocus(object sender, EventArgs e)
        {
            if (sender.GetType().Name == "TextBox")
            {
                ((TextBox)sender).Text = (((TextBox)sender).Text == "0") ? "" : ((TextBox)sender).Text;
                ((TextBox)sender).SelectionStart = ((TextBox)sender).TextLength;
            }
        }

        private void frmTimeLog_Load(object sender, EventArgs e)
        {
            inputs = new InputFilter();
            employeeService = new EmployeeService(Program.xApiKey, Program.serverUrl);
            txtCode.Text = string.Empty;
            isMatched = false;
            fingerPrint = string.Empty;
        }
    }
}
