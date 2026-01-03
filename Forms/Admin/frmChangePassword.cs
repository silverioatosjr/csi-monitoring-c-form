using CSIEmployeeMonitoringSystem.Models.Auth;
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

namespace CSIEmployeeMonitoringSystem.Forms.Admin
{
    public partial class frmChangePassword : Form
    {
        private AdminService adminService;
        public frmChangePassword()
        {
            InitializeComponent();
            btnResetPassword.Click += BtnResetPassword_Click;
        }

        private void BtnResetPassword_Click(object sender, EventArgs e)
        {
            if(txtConfirmPassword.Text.Trim() != txtNewPassword.Text.Trim())
            {
                MessageBox.Show("New Password didn't matched", "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
            {
                
                _ResetPassword();
            }
        }

        private async void _ResetPassword()
        {
            Cursor = Cursors.WaitCursor;
            ResetPassword payload = new ResetPassword();
            payload.password = txtNewPassword.Text.Trim();
            var data = await adminService.ResetPassword(payload);
            if (null != data)
            {
                Cursor = Cursors.Arrow;
                this.Invoke(new Action(delegate ()
                {
                    this.Close();
                }));
            } else
            {
                Cursor = Cursors.Arrow;
                MessageBox.Show("Unable to change password", "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            adminService = new AdminService(Program.xApiKey, Program.serverUrl, Program.accessToken);
        }
    }
}
