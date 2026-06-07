using CSIEmployeeMonitoringSystem.Forms.Biometric;
using CSIEmployeeMonitoringSystem.Forms.Employee;
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
        private frmBiometricVerification frmBiometricVerification;
        private frmRegistration frmRegistrationForm = new frmRegistration();
        private string apiKey = Program.xApiKey;
        private string apiUrl = Program.serverUrl;
        private EmployeeService employeeService;
        private ConnectionService connectionService;
        public List<Models.Employee> employees;
        public bool isMatched;
        public string employeeId;
        public string fullName;
        private DtrService dtrService;
        public frmDTR()
        {
            InitializeComponent();
            btnLogTime.Click += BtnLogTime_Click;
            mnuLoggedIn.Click += MnuLoggedIn_Click;
            mnuTodaysLogs.Click += MnuTodaysLogs_Click;
            btnLogTime.KeyDown += FrmDTR_KeyDown;
            timer1.Tick += Timer1_Tick;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            this.Invoke(new Action(delegate () {
                CheckApiConnection();
            }));
        }

        private void FrmDTR_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F2)
            {
                if (!frmRegistrationForm.Created)
                {
                    frmRegistrationForm = new frmRegistration();
                }
                if(frmRegistrationForm.ShowDialog() == DialogResult.OK)
                {
                    GetEmployeesWithBiometrics();
                }
            }
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

        private async void OpenBiometric()
        {
            if (frmBiometricVerification == null)
            {
                frmBiometricVerification = new frmBiometricVerification();
                frmBiometricVerification._sender = this;
            }
            if (frmBiometricVerification.ShowDialog() == DialogResult.OK)
            {
                //Save the dtr
                var employee = new DTRVerfication();
                employee.employee = employeeId;
                employee.building = Program.building;
                var response = await dtrService.SaveDtr(employee);
                if (null != response)
                {
                    MessageBox.Show($"{fullName}\nStatus: {response.message}", "Log Time", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    isMatched = false;
                    employeeId = String.Empty;
                    fullName = String.Empty;
                }
                else
                {
                    MessageBox.Show("Failed to log time", "Log Time", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void BtnLogTime_Click(object sender, EventArgs e)
        {
            OpenBiometric();
        }
        
        private async void GetEmployeesWithBiometrics()
        {
            var response = await employeeService.GetEmployeesWithBiometrics();
            if(null != response)
            {
                employees = response.data;
                
            } else
            {
                MessageBox.Show(response.ToString());
            }
        }
        private void frmDTR_Load(object sender, EventArgs e)
        {
            employeeService = new EmployeeService(apiKey, apiUrl);
            mnuViewLogs.Enabled = false;
            connectionService = new ConnectionService(apiKey, apiUrl);
            CheckApiConnection();
            dtrService = new DtrService(Program.xApiKey, Program.serverUrl);
            isMatched = false;
            employeeId = String.Empty;
            fullName = String.Empty;
            groupBox1.Left = (this.ClientSize.Width - groupBox1.Width) / 2;
            groupBox1.Top = (this.ClientSize.Height - groupBox1.Height) / 2;
            groupBox1.Anchor = AnchorStyles.None;
            timer1.Interval = (1000 * 60) * 5;
            timer1.Enabled = false;
        }

        private async void CheckApiConnection()
        {
            Cursor = Cursors.WaitCursor;
            btnLogTime.Enabled = false;
            var con = await connectionService.APIConnection();
            if (null == con)
            {
                if (MessageBox.Show("Unable to connect to API. Please check your network connection", "Service error", MessageBoxButtons.OK) == DialogResult.OK)
                {
                    Cursor = Cursors.WaitCursor;
                    CheckApiConnection();
                    Cursor = Cursors.Arrow;
                    timer1.Enabled = false;
                    mnuViewLogs.Enabled = false;
                }
            } else
            {
                btnLogTime.Enabled = true;
                GetEmployeesWithBiometrics();
                mnuViewLogs.Enabled = true;
                btnLogTime.Focus();
                timer1.Enabled = true;
            }
            Cursor = Cursors.Arrow;
        }
    }
}
