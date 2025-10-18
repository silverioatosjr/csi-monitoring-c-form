using CSIEmployeeMonitoringSystem.Forms.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSIEmployeeMonitoringSystem.Forms.Employee;
using CSIEmployeeMonitoringSystem.Services;
using CSIEmployeeMonitoringSystem.Forms.Schedules;

namespace CSIEmployeeMonitoringSystem
{
    public partial class frmMain : Form
    {
        private frmLogin frmLogin;
        private frmAddSchedules frmAddSchedules;
        private frmRegistration frmRegistrationForm = new frmRegistration();
        private ConnectionService connectionService;
        private frmEmployeesList frmEmployeesList = new frmEmployeesList();
        public string userRole;
        public frmMain()
        {
            InitializeComponent();
            
            mnuEmployeeRegistration.Click += MnuEmployeeRegistration_Click;
            mnuConnectToServer.Click += MnuConnectToServer_Click;
            mnuEmployeesList.Click += MnuEmployeesList_Click;
            mnuCloseWindow.Click += MnuCloseWindow_Click;
            mnuLogin.Click += MnuLogin_Click;
            mnuAddSchedule.Click += MnuAddSchedule_Click;
        }

        private void MnuAddSchedule_Click(object sender, EventArgs e)
        {
            if (frmAddSchedules == null)
            {
                frmAddSchedules = new frmAddSchedules();
                frmAddSchedules.MdiParent = this;
                //frmEmployeesList.WindowState = FormWindowState.Maximized;
                frmAddSchedules.Show();
            }
            else if (frmAddSchedules.WindowState == FormWindowState.Minimized)
            {
                frmAddSchedules.WindowState = FormWindowState.Maximized;
            }
            frmAddSchedules.BringToFront();
        }

        private void MnuLogin_Click(object sender, EventArgs e)
        {
            if(mnuLogin.Text == "Login")
            {
                if (frmLogin == null)
                {
                    frmLogin = new frmLogin();
                    frmLogin._sender = this;
                }

                frmLogin.ShowDialog();
                SetUserAccessPrivilege();
                if(userRole!= string.Empty)
                    mnuLogin.Text = "Logout";
            } else
            {
                userRole = "";
                mnuLogin.Text = "Login";
                SetUserAccessPrivilege();
            }
        }

        private void MnuCloseWindow_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MnuEmployeesList_Click(object sender, EventArgs e)
        {
            if (!frmEmployeesList.Created)
            {
                frmEmployeesList = new frmEmployeesList();
                frmEmployeesList.MdiParent = this;
                //frmEmployeesList.WindowState = FormWindowState.Maximized;
                frmEmployeesList.Show();
            }
            else if (frmEmployeesList.WindowState == FormWindowState.Minimized)
            {
                frmEmployeesList.WindowState = FormWindowState.Maximized;
            }
            frmEmployeesList.BringToFront();
        }

        private void MnuConnectToServer_Click(object sender, EventArgs e)
        {
            CheckApiConnection();
        }

        private async void CheckApiConnection()
        {
            Cursor = Cursors.WaitCursor;
            var con = await connectionService.APIConnection();
            if(null == con)
            {
                mnuConnectToServer.Enabled = true;
                mnuConnectToServer.Text = "Connect to Server";
                MessageBox.Show("Unable to connect to API. Please check your network connection", "Service error", MessageBoxButtons.OK);
            } else
            {
                mnuConnectToServer.Enabled = false;
                mnuConnectToServer.Text = "Connected to Server";
            }
            Cursor = Cursors.Arrow;
        }

        private void MnuEmployeeRegistration_Click(object sender, EventArgs e)
        {
            if (!frmRegistrationForm.Created)
            {
                frmRegistrationForm = new frmRegistration();
                frmRegistrationForm.MdiParent = this;
                //frmRegistrationForm.WindowState = FormWindowState.Maximized;
                frmRegistrationForm.Show();
            }
            else if (frmRegistrationForm.WindowState == FormWindowState.Minimized)
            {
                frmRegistrationForm.WindowState = FormWindowState.Maximized;
            }
            frmRegistrationForm.BringToFront();
        }

        private void DisableAllButtons()
        {
            mnuEmployees.Enabled = false;
            mnuSchedule.Enabled = false;
            mnuDtr.Enabled = false;
            mnuPayroll.Enabled = false;
            mnuPrint.Enabled = false;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //DisableAllButtons();
            connectionService = new ConnectionService(Program.serverUrl);
            CheckApiConnection();
            userRole = "";
        }

        private void SetUserAccessPrivilege()
        {
            if(userRole == "administrator")
            {
                mnuEmployees.Enabled = true;
                mnuSchedule.Enabled = true;
                mnuDtr.Enabled = true;
                mnuPayroll.Enabled = true;
                mnuPrint.Enabled = true;
                mnuEmployeeRegistration.Enabled = true;
                mnuDtrList.Enabled = true;
            }
            else if(userRole == string.Empty)
            {
                DisableAllButtons();
            }
            else
            {
                mnuEmployees.Enabled = false;
                mnuSchedule.Enabled = false;
                mnuDtr.Enabled = true;
                mnuPayroll.Enabled = false;
                mnuPrint.Enabled = false;
                mnuEmployeeRegistration.Enabled = false;
                mnuDtrList.Enabled = false;
            }
        }
    }
}
