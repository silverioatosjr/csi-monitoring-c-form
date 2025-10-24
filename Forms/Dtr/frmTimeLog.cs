using CSIEmployeeMonitoringSystem.Forms.Biometric;
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
    public partial class frmTimeLog : Form
    {
        private InputFilter inputs;
        private frmBiometricVerification frmBiometricVerification;
        private EmployeeService employeeService;
        private DtrService dtrService;
        public string fingerPrint;
        private string employeeId;
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
                    employeeId = response.data._id;
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

        private async void OpenBiometric()
        {
            if(frmBiometricVerification == null)
            {
                frmBiometricVerification = new frmBiometricVerification();
                frmBiometricVerification._sender = this;
            }
            if(frmBiometricVerification.ShowDialog() == DialogResult.OK)
            {
                //Save the dtr
                var employee = new DTRVerfication();
                employee.employee = employeeId;
                var response = await dtrService.SaveDtr(employee);
                if(null != response)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                } else
                {
                    MessageBox.Show("Failed to log time", "Log Time", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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
            dtrService = new DtrService(Program.xApiKey, Program.serverUrl);
            txtCode.Text = string.Empty;
            isMatched = false;
            fingerPrint = string.Empty;
            employeeId = string.Empty;
        }
    }
}
