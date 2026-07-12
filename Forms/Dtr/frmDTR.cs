using CSIEmployeeMonitoringSystem.Forms.Biometric;
using CSIEmployeeMonitoringSystem.Forms.Employee;
using CSIEmployeeMonitoringSystem.Forms.Schedules;
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
        private frmParentSchedules frmParentSchedules = new frmParentSchedules();
        private frmLogMessage frmLogMessage = new frmLogMessage();
        private frmTodaysLogs frmTodaysLogs = new frmTodaysLogs();
        private frmBiometricVerification frmBiometricVerification;
        private frmRegistration frmRegistrationForm = new frmRegistration();
        private frmEmployeesList frmEmployeesList = new frmEmployeesList();
        private frmPassword frmPassword = new frmPassword();
        private string apiKey = Program.xApiKey;
        private string apiUrl = Program.serverUrl;
        private EmployeeService employeeService;
        private ConnectionService connectionService;
        public List<Models.Employee> employees;
        private frmDtrList frmDtrList = new frmDtrList();
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
            mnuClose.Click += MnuClose_Click;
            mnuViewDTR.Click += MnuViewDTR_Click;
            timer2.Tick += Timer2_Tick;
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            if(btnLogTime.BackColor == Color.MediumBlue)
            {
                btnLogTime.BackColor = Color.Navy;
            } else
            {
                btnLogTime.BackColor = Color.MediumBlue;
            }
        }

        private void MnuViewDTR_Click(object sender, EventArgs e)
        {
            if(!frmDtrList.Created)
            {
                frmDtrList = new frmDtrList();
            }
            frmDtrList.ShowDialog();
        }

        private void MnuClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            //this.Invoke(new Action(delegate () {
            //    CheckApiConnection();
            //}));
        }

        private async void FrmDTR_KeyDown(object sender, KeyEventArgs e)
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
            } else if(e.KeyCode == Keys.F1)
            {
                if (!frmPassword.Created)
                {
                    frmPassword = new frmPassword();
                }
                if(frmPassword.ShowDialog() == DialogResult.OK)
                {
                    frmEmployeesList.ShowDialog();
                }
            } else if (e.KeyCode == Keys.F5)
            {
                if (!frmPassword.Created)
                {
                    frmPassword = new frmPassword();
                }
                if (frmPassword.ShowDialog() == DialogResult.OK)
                {
                    var response = await dtrService.LogoutDtrs();
                    if(response != null)
                    {
                        MessageBox.Show("All forgotten logs, terminated", "Logs", MessageBoxButtons.OK);
                    }
                }
            } else if(e.KeyCode == Keys.F4)
            {
                if(!frmParentSchedules.Created)
                {
                    frmParentSchedules = new frmParentSchedules();
                }
                frmParentSchedules.ShowDialog();
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
                    if (!frmLogMessage.Created)
                    {
                        frmLogMessage = new frmLogMessage();
                    }
                    frmLogMessage.message = $"{fullName}\n\n{response.message}";
                    frmLogMessage.ShowDialog();
                    isMatched = false;
                    employeeId = String.Empty;
                    fullName = String.Empty;
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
            mnuViewDTR.Enabled = false;
            viewDTRsToolStripMenuItem.Enabled = false;
            connectionService = new ConnectionService(apiKey, apiUrl);
            CheckApiConnection();
            btnLogTime.BackColor = Color.MediumBlue;
            dtrService = new DtrService(Program.xApiKey, Program.serverUrl);
            isMatched = false;
            employeeId = String.Empty;
            fullName = String.Empty;
            panel1.Left = (this.ClientSize.Width - panel1.Width) / 2;
            panel1.Top = (this.ClientSize.Height - panel1.Height) / 2;
            panel1.Anchor = AnchorStyles.None;
            timer1.Interval = (1000 * 60) * 5;
            timer1.Enabled = false;
            timer2.Interval = 2000;
            timer2.Enabled = false;
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
                    mnuViewDTR.Enabled = false;
                    timer2.Enabled = false;
                    btnLogTime.Enabled = false;
                    viewDTRsToolStripMenuItem.Enabled = false;
                }
            } else
            {
                btnLogTime.Enabled = true;
                GetEmployeesWithBiometrics();
                mnuViewLogs.Enabled = true;
                btnLogTime.Focus();
                timer1.Enabled = true;
                mnuViewDTR.Enabled = true;
                timer2.Enabled = true;
                viewDTRsToolStripMenuItem.Enabled = true;
            }
            Cursor = Cursors.Arrow;
        }
    }
}
