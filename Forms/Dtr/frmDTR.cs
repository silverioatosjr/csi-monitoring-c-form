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
    public partial class frmDTR : Form
    {
        private frmTimeLog frmTimeLog = new frmTimeLog();
        private frmLoggedIn frmLoggedIn = new frmLoggedIn();
        private frmTodaysLogs frmTodaysLogs = new frmTodaysLogs();
        private string apiKey = Program.xApiKey;
        private string apiUrl = Program.serverUrl;
        private EmployeeService employeeService;
        private ConnectionService connectionService;
        public frmDTR()
        {
            InitializeComponent();
            btnLogTime.Click += BtnLogTime_Click;
            mnuLoggedIn.Click += MnuLoggedIn_Click;
            mnuTodaysLogs.Click += MnuTodaysLogs_Click;
        }

        private void MnuTodaysLogs_Click(object sender, EventArgs e)
        {
            if (!frmTodaysLogs.Created)
            {
                frmTodaysLogs = new frmTodaysLogs();
            }
            frmTodaysLogs.ShowDialog();
        }

        private void MnuLoggedIn_Click(object sender, EventArgs e)
        {
            if (!frmLoggedIn.Created)
            {
                frmLoggedIn = new frmLoggedIn();
            }
            frmLoggedIn.ShowDialog();
        }

        private void BtnLogTime_Click(object sender, EventArgs e)
        {
            if(!frmTimeLog.Created)
            {
                frmTimeLog = new frmTimeLog();
            }
            frmTimeLog.ShowDialog();
        }
        
        private void frmDTR_Load(object sender, EventArgs e)
        {
            employeeService = new EmployeeService(apiKey, apiUrl);
            mnuViewLogs.Enabled = false;
            connectionService = new ConnectionService(apiKey, apiUrl);
            CheckApiConnection();
        }

        private async void CheckApiConnection()
        {
            Cursor = Cursors.WaitCursor;
            //btnLogTime.Enabled = false;
            var con = await connectionService.APIConnection();
            if (null == con)
            {
                if (MessageBox.Show("Unable to connect to API. Please check your network connection", "Service error", MessageBoxButtons.OK) == DialogResult.OK)
                {
                    Cursor = Cursors.WaitCursor;
                    CheckApiConnection();
                    Cursor = Cursors.Arrow;
                }
            } else
            {
                btnLogTime.Enabled = true;
                mnuViewLogs.Enabled = true;
                btnLogTime.Focus();
            }
            Cursor = Cursors.Arrow;
        }
    }
}
