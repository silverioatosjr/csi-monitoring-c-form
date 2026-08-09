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
using System.Globalization;
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
        private List<Models.Employee> instructors;
        private frmDtrList frmDtrList = new frmDtrList();
        public bool isMatched;
        public string employeeId;
        public string fullName;
        private DtrService dtrService;
        private int color = 0;
        public frmDTR()
        {
            InitializeComponent();
            btnLogTime.Click += BtnLogTime_Click;
            mnuLoggedIn.Click += MnuLoggedIn_Click;
            mnuTodaysLogs.Click += MnuTodaysLogs_Click;
            btnDailyLogs.Click += MnuTodaysLogs_Click;
            btnLogTime.KeyDown += FrmDTR_KeyDown;
            btnCloseWindow.KeyDown += FrmDTR_KeyDown;
            btnDailyLogs.KeyDown += FrmDTR_KeyDown;
            btnRefresh.KeyDown += FrmDTR_KeyDown;
            btnViewDTR.KeyDown += FrmDTR_KeyDown;
            btnSchedules.KeyDown += FrmDTR_KeyDown;
            timer1.Tick += Timer1_Tick;
            mnuClose.Click += MnuClose_Click;
            btnCloseWindow.Click += MnuClose_Click;
            mnuViewDTR.Click += MnuViewDTR_Click;
            btnViewDTR.Click += MnuViewDTR_Click;
            timer2.Tick += Timer2_Tick;
            btnRefresh.Click += BtnRefresh_Click;
            btnSchedules.Click += BtnSchedules_Click;
            timer3.Tick += Timer3_Tick;
        }

        private void Timer3_Tick(object sender, EventArgs e)
        {
            this.Invoke(new Action(delegate ()
            {
                BtnRefresh_Click(sender, e);
            }));
        }

        private void BtnSchedules_Click(object sender, EventArgs e)
        {
            if (!frmParentSchedules.Created)
            {
                frmParentSchedules = new frmParentSchedules();
            }
            frmParentSchedules.ShowDialog();
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            btnRefresh.Enabled = false;
            Cursor = Cursors.WaitCursor;
            
            foreach (Models.Employee emp in employees.OrderBy(x => Guid.NewGuid()))
            {
                Label lbl = panelLogs.Controls.Find(emp._id, true).FirstOrDefault() as Label;
                if(lbl != null)
                {
                    panelLogs.Controls.Remove(lbl);
                }
            }
            GetInstructorsWithSchedules();
            Cursor = Cursors.Hand;
            btnRefresh.Enabled = true;
        }
        

        private void Timer2_Tick(object sender, EventArgs e)
        {
            if (color == 0) btnLogTime.BackColor = Color.Navy;
            else if (color == 1) btnLogTime.BackColor = Color.MediumBlue;
            else if (color == 2) btnLogTime.BackColor = Color.Maroon;
            else if (color == 3) btnLogTime.BackColor = Color.Gray;
            if(color==3)
            {
                color = 0;
            } else
            {
                color++;
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
            this.Invoke(new Action(delegate ()
            {
                CheckOnlyConnection();
            }));
        }

        private async void GetDtrTemp()
        {
            var response = await dtrService.GetDtrTempList();
        
            if (null != response)
            {
                foreach (DtrTemp d in response.data)
                {
                }
            }
        }
        private async void GetInstructorsWithSchedules()
        {
            Cursor = Cursors.WaitCursor;
            var responseTemp = await dtrService.GetDtrTempList();
            List<DtrTemp> tempDTR = new List<DtrTemp>();
            if (null != responseTemp)
            {
                tempDTR = responseTemp.data;
            }

            var response = await employeeService.GetInstructorsWithSchedules();
            if (response != null)
            {
                
                int locXL = 40;
                int locXR = 450;
                int locXRE = 850;
                int locXREE = 1250;
                int locY = 90;
                int locIncrement = 50;
                int counter = 0;
                
                foreach(EmployeesList e in response.data.OrderBy(x => Guid.NewGuid()))
                {
                    
                    var loggedIn = tempDTR?.Find(d=>d?.employee?._id == e._id);
                    string loggedTime = string.Empty;
                    if (loggedIn!=null)
                    {
                        DateTime dateTime = DateTime.Parse(loggedIn.time);
                        loggedTime = dateTime.ToString("h:mm tt", CultureInfo.InvariantCulture);
                    }

                        if (counter < 10)
                        {
                            CustomLabel(e._id, e.schedules, locXL, locY + (counter * locIncrement), $"{e.firstName} {e.lastName}     {loggedTime}", (loggedIn!=null)?true:false);
                        }
                        else if (counter >= 10 && counter < 20)
                        {
                            CustomLabel(e._id, e.schedules, locXR, locY + ((counter - 10) * locIncrement), $"{e.firstName} {e.lastName}     {loggedTime}", (loggedIn != null) ? true : false);
                        }
                        else if (counter >= 20 && counter < 30)
                        {
                            CustomLabel(e._id, e.schedules, locXRE, locY + ((counter - 20) * locIncrement), $"{e.firstName} {e.lastName}     {loggedTime}", (loggedIn != null) ? true : false);
                        }
                        else
                        {
                            CustomLabel(e._id, e.schedules, locXREE, locY + ((counter - 30) * locIncrement), $"{e.firstName} {e.lastName}     {loggedTime}", (loggedIn != null) ? true : false);
                        }
                    
                    counter++;
                }
            }
            Cursor = Cursors.Default;
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
                btnLogTime.Enabled = false;
                employee.employee = employeeId;
                employee.building = Program.building;
                DateTime timeString = DateTime.Now;
                employee.timeString = timeString.ToString("HH:mm");
                var response = await dtrService.SaveDtr(employee);
                string dateTime = timeString.ToString("h:mm tt", CultureInfo.InvariantCulture);
                if (null != response)
                {
                    if (!frmLogMessage.Created)
                    {
                        frmLogMessage = new frmLogMessage();
                    }
                    frmLogMessage.message = $"{fullName}\n\n{response.message}";
                    frmLogMessage.ShowDialog();
                    isMatched = false;

                    
                    Label lbl = panelLogs.Controls.Find(employeeId, true).FirstOrDefault() as Label;
                    if (response.message.Contains("Logged in") && lbl !=null)
                    {
                        ChangeLabelStatus(lbl, dateTime, fullName, "Logged in");
                    } else if(response.message.Contains("Logout") && lbl != null)
                    {
                        ChangeLabelStatus(lbl, dateTime, fullName, "Logout");
                    }

                    employeeId = String.Empty;
                    fullName = String.Empty;
                }
                btnLogTime.Enabled = true;
                btnLogTime.Focus();
                
            }
        }
        private void ChangeLabelStatus(Label lbl, string time, string name, string status)
        {
            if(status =="Logged in" || status =="Logout")
            {
                lbl.ForeColor = status=="Logged in" ? Color.White : Color.DarkSlateGray;
                lbl.BackColor = status == "Logged in" ? Color.Green : Color.Gray;
                lbl.Text = $"{name.ToUpper()}     {time}";
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
            btnSchedules.Enabled = false;
            viewDTRsToolStripMenuItem.Enabled = false;
            connectionService = new ConnectionService(apiKey, apiUrl);
            CheckApiConnection();
            btnLogTime.BackColor = Color.MediumBlue;
            dtrService = new DtrService(Program.xApiKey, Program.serverUrl);
            isMatched = false;
            employeeId = String.Empty;
            fullName = String.Empty;
            timer1.Interval = (1000 * 60) * 3;
            timer1.Enabled = false;
            timer2.Interval = 2000;
            timer2.Enabled = false;
            timer3.Interval = (1000 * 60) * 30;
            timer3.Enabled = false;
        }

        private void CustomLabel(string id, List<SchedulesData> schedules, int locX, int locY, string name, bool isOnline)
        {
            Label lblTeacher = new Label();
            panelLogs.Controls.Add(lblTeacher);
            lblTeacher.Left = locX;
            lblTeacher.Top = locY;
            lblTeacher.Text = name.ToUpper();
            lblTeacher.Name = $"{id}";
            lblTeacher.ForeColor = isOnline?Color.White:Color.DarkSlateGray;
            lblTeacher.BackColor = isOnline?Color.Green:Color.Gray;
            lblTeacher.AutoSize = false;
            lblTeacher.Cursor = Cursors.Hand;
            lblTeacher.Height = 35;
            lblTeacher.Width = 370;
            lblTeacher.Font = new Font(FontFamily.GenericSansSerif,13, FontStyle.Bold);
            lblTeacher.Padding = new Padding(8);
            string schedList = string.Empty;
            foreach(SchedulesData s in schedules)
            {
                DateTime timeString = DateTime.Now;
                int hTime = int.Parse(timeString.ToString("HH:mm").Split(':')[0]);
                int eTime = 0;
                if (s.endTime != String.Empty)
                {
                    eTime = int.Parse(s.endTime.Split(':')[0]);
                }
                if(hTime<=eTime)
                {
                    DateTime dateTimeStart = DateTime.Parse(s.startTime);
                    string timeStart = dateTimeStart.ToString("h:mm tt", CultureInfo.InvariantCulture);
                    DateTime dateTimeEnd = DateTime.Parse(s.endTime);
                    string timeEnd = dateTimeEnd.ToString("h:mm tt", CultureInfo.InvariantCulture);
                    schedList = $"{schedList}{s.subject}   {timeStart}-{timeEnd}\n";
                }
            }
            toolTipSchedules.SetToolTip(lblTeacher, schedList);
        }
        private async void CheckOnlyConnection()
        {
            Cursor = Cursors.WaitCursor;
            var con = await connectionService.APIConnection();
            if (null == con)
            {
                if (MessageBox.Show("Unable to connect to Server. Please check if server is running", "Service error", MessageBoxButtons.OK) == DialogResult.OK)
                {
                    Cursor = Cursors.WaitCursor;
                    Cursor = Cursors.Arrow;
                    timer1.Enabled = false;
                    timer3.Enabled = false;
                    mnuViewLogs.Enabled = false;
                    btnSchedules.Enabled = false;
                    mnuViewDTR.Enabled = false;
                    btnDailyLogs.Enabled = false;
                    btnRefresh.Enabled = false;
                    btnViewDTR.Enabled = false;
                    timer2.Enabled = false;
                    btnLogTime.Enabled = false;
                    viewDTRsToolStripMenuItem.Enabled = false;
                    CheckOnlyConnection();
                }
            } else
            {
                btnLogTime.Enabled = true;
                mnuViewLogs.Enabled = true;
                btnLogTime.Focus();
                timer1.Enabled = true;
                mnuViewDTR.Enabled = true;
                btnSchedules.Enabled = true;
                btnDailyLogs.Enabled = true;
                btnRefresh.Enabled = true;
                btnViewDTR.Enabled = true;
                timer3.Enabled = true;
                timer2.Enabled = true;
                viewDTRsToolStripMenuItem.Enabled = true;
            }
            Cursor = Cursors.Arrow;
        }
        private async void CheckApiConnection()
        {
            Cursor = Cursors.WaitCursor;
            btnLogTime.Enabled = false;
            var con = await connectionService.APIConnection();
            if (null == con)
            {
                if (MessageBox.Show("Unable to connect to Server. Please check if server is running", "Service error", MessageBoxButtons.OK) == DialogResult.OK)
                {
                    Cursor = Cursors.WaitCursor;
                    Cursor = Cursors.Arrow;
                    timer1.Enabled = false;
                    mnuViewLogs.Enabled = false;
                    btnSchedules.Enabled = false;
                    mnuViewDTR.Enabled = false;
                    btnDailyLogs.Enabled = false;
                    btnRefresh.Enabled = false;
                    btnViewDTR.Enabled = false;
                    timer2.Enabled = false;
                    timer3.Enabled = false;
                    btnLogTime.Enabled = false;
                    viewDTRsToolStripMenuItem.Enabled = false;
                    CheckApiConnection();
                }
            } else
            {
                timer1.Enabled = true;
                GetEmployeesWithBiometrics();
                GetInstructorsWithSchedules();
                btnLogTime.Enabled = true;
                mnuViewLogs.Enabled = true;
                btnSchedules.Enabled = true;
                btnLogTime.Focus();
                mnuViewDTR.Enabled = true;
                btnDailyLogs.Enabled = true;
                btnRefresh.Enabled = true;
                btnViewDTR.Enabled = true;
                timer2.Enabled = true;
                timer3.Enabled = true;
                viewDTRsToolStripMenuItem.Enabled = true;
            }
            Cursor = Cursors.Arrow;
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;

            lblTime.Text = now.ToLongTimeString();
        }
    }
}
