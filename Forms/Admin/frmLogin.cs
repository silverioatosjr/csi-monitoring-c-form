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

namespace CSIEmployeeMonitoringSystem.Forms.Admin
{
    public partial class frmLogin : Form
    {
        private AdminService adminService;
        public frmMain _sender;
        public frmLogin()
        {
            InitializeComponent();
            btnLogin.Click += BtnLogin_Click;
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if(txtUsename.Text.Trim() != string.Empty && txtPassword.Text.Trim() != string.Empty)
            {
                Authenticate();
            } else
            {
                MessageBox.Show("Enter your username and passwrod", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void Authenticate()
        {
            Cursor = Cursors.WaitCursor;
            AuthPost payload = new AuthPost();
            payload.password = txtPassword.Text;
            payload.username = txtUsename.Text;
            var data = await adminService.Authenticate(payload);
            if (null != data)
            {

                _sender.userRole = data.user.role;
                Cursor = Cursors.Arrow;
                this.Invoke(new Action(delegate ()
                {
                    this.Close();
                }));
            } else
            {
                Cursor = Cursors.Arrow;
                MessageBox.Show("Invalid username or password", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            adminService = new AdminService(Program.xApiKey, Program.serverUrl);
            txtPassword.Text = string.Empty;
            txtUsename.Text = string.Empty;
        }

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            //adminService = null;
        }
    }
}
