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

namespace CSIEmployeeMonitoringSystem
{
    public partial class frmMain : Form
    {
        private frmLogin frmLogin = new frmLogin();
        private frmRegistration frmRegistrationForm = new frmRegistration();
        private ConnectionService connectionService;
        private bool hasConnection = false;
        public frmMain()
        {
            InitializeComponent();
            connectionService = new ConnectionService(Program.serverUrl);
            CheckApiConnection();
            mnuEmployeeRegistration.Click += MnuEmployeeRegistration_Click;
            mnuConnectToServer.Click += MnuConnectToServer_Click;
        }

        private void MnuConnectToServer_Click(object sender, EventArgs e)
        {
            CheckApiConnection();
        }

        private async void CheckApiConnection()
        {
            var con = await connectionService.APIConnection();
            if(null == con)
            {
                hasConnection = false;
                mnuConnectToServer.Enabled = true;
                MessageBox.Show("Unable to connect to API. Please check your network connection", "Service error", MessageBoxButtons.OK);
            } else
            {
                hasConnection = true;
                mnuConnectToServer.Enabled = false;
            }
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

        private void generatePayrollToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
