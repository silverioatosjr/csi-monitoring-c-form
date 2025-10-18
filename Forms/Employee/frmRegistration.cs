using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using CSIEmployeeMonitoringSystem.Services;
using CSIEmployeeMonitoringSystem.Models;
using CSIEmployeeMonitoringSystem.Forms.Biometric;
using DPUruNet;
using System.Threading;
using System.Drawing.Imaging;

namespace CSIEmployeeMonitoringSystem.Forms.Employee
{
    public partial class frmRegistration : Form
    {
        private string apiKey = Program.xApiKey;
        private string apiUrl = Program.serverUrl;
        private SssService sssService;
        private PagibigService pagibigService;
        private TaxService taxService;
        private PhilhealthService philhealthService;
        private EmployeeService employeeService;
        private string fingerPrint;
        private InputFilter inputs;
        public frmRegistration()
        {
            InitializeComponent();
            btnRegister.Click += BtnRegister_Click;
            btnScan.Click += BtnScan_Click;
            btnCancel.Click += BtnCancel_Click;
            txtHourlyRate.TextChanged += txt_TextChanged;
            txtHourlyRate.LostFocus += txt_LostFocus;
            txtHourlyRate.GotFocus += txt_GotFocus;
            txtBasicSalary.TextChanged += txt_TextChanged;
            txtBasicSalary.LostFocus += txt_LostFocus;
            txtBasicSalary.GotFocus += txt_GotFocus;
            
        }

        private void txt_LostFocus(object sender, EventArgs e)
        {
            if(((TextBox)sender).Text == string.Empty)
            {
                ((TextBox)sender).Text = "0";
            }
        }

        private void txt_TextChanged(object sender, EventArgs e)
        {
            inputs.Filter((TextBox)sender);
        }

        private void txt_GotFocus(object sender, EventArgs e)
        {
            if (sender.GetType().Name == "TextBox")
            {
                ((TextBox)sender).Text = (((TextBox)sender).Text == "0") ? "" : ((TextBox)sender).Text;
                ((TextBox)sender).SelectionStart = ((TextBox)sender).TextLength;
            }
        }

        public List<Fmd> preenrollmentFmds;
        

        private async void LoadSssList()
        {
            Cursor = Cursors.WaitCursor;
            var data = await sssService.GetSssList();
            List<KeyValuePair<string, string>> items = new List<KeyValuePair<string, string>>();
            items.Add(new KeyValuePair<string, string>("<<Select>>", ""));
            if (null != data)
            {
                foreach(Sss s in data.data)
                {
                    items.Add(new KeyValuePair<string, string>($"{s.bracket} ({s.amount})", s._id));
                }
            }
            optSSS.DataSource = items;
            optSSS.DisplayMember = "Key";
            optSSS.ValueMember = "Value";
            Cursor = Cursor = Cursors.Arrow;
        }

        private async void LoadPagibigList()
        {
            Cursor = Cursors.WaitCursor;
            var data = await pagibigService.GetPagibigList();
            List<KeyValuePair<string, string>> items = new List<KeyValuePair<string, string>>();
            items.Add(new KeyValuePair<string, string>("<<Select>>", ""));
            if (null != data)
            {
                foreach (Pagibig p in data.data)
                {
                    items.Add(new KeyValuePair<string, string>($"{p.percent} ({p.amount})", p._id));
                }
            }
            optPagibig.DataSource = items;
            optPagibig.DisplayMember = "Key";
            optPagibig.ValueMember = "Value";
            Cursor = Cursors.Arrow;
        }

        private async void LoadPhilhealthList()
        {
            Cursor = Cursors.WaitCursor;
            var data = await philhealthService.GetPhilhealthList();
            List<KeyValuePair<string, string>> items = new List<KeyValuePair<string, string>>();
            items.Add(new KeyValuePair<string, string>("<<Select>>", ""));
            if (null != data)
            {
                foreach (Philhealth t in data.data)
                {
                    items.Add(new KeyValuePair<string, string>($"{t.percent}", t._id));
                }
            }
            optPhilhealth.DataSource = items;
            optPhilhealth.DisplayMember = "Key";
            optPhilhealth.ValueMember = "Value";
            Cursor = Cursors.Arrow;
        }

        private async void LoadTaxList()
        {
            Cursor = Cursors.WaitCursor;
            var data = await taxService.GetTaxList();
            List<KeyValuePair<string, string>> items = new List<KeyValuePair<string, string>>();
            items.Add(new KeyValuePair<string, string>("<<Select>>", ""));
            if (null != data)
            {
                foreach (Tax t in data.data)
                {
                    items.Add(new KeyValuePair<string, string>($"{t.bracket} ({t.monthlySalary.baseAmount})", t._id));
                }
            }
            optTax.DataSource = items;
            optTax.DisplayMember = "Key";
            optTax.ValueMember = "Value";
            Cursor = Cursors.Arrow;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            resetInputFields();
        }

        private frmBiometricCapturer _capture;
        private void BtnScan_Click(object sender, EventArgs e)
        {
            if (_capture == null)
            {
                _capture = new frmBiometricCapturer();
                _capture._sender = this;
            }

            _capture.ShowDialog();
            picFingerprint.Image = ((PictureBox)_capture.Controls["pbFingerprint"]).Image;
            if(null != preenrollmentFmds)
            {
                fingerPrint = Fmd.SerializeXml(preenrollmentFmds[2]);
                preenrollmentFmds.Clear();
            }
            //_capture.Dispose();
            _capture = null;
        }

        private async void BtnRegister_Click(object sender, EventArgs e)
        {
            //if all required fields are filled up
            if(inputValidator())
            {
                if (MessageBox.Show("Click Ok to continue.", "Employee Registration", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    EmployeePost employee = new EmployeePost();
                    //Deduction deduction = new Deduction();
                    if (optTax.SelectedValue.ToString() != string.Empty)
                        employee.deduction.tax = optTax.SelectedValue.ToString();
                    if(optSSS.SelectedValue.ToString() != string.Empty)
                        employee.deduction.sss = optSSS.SelectedValue.ToString();
                    if (optPagibig.SelectedValue.ToString() != string.Empty)
                        employee.deduction.pagibig = optPagibig.SelectedValue.ToString();
                    if (optPhilhealth.SelectedValue.ToString() != string.Empty)
                        employee.deduction.philhealth = optPhilhealth.SelectedValue.ToString();
                
                    employee.biometric = fingerPrint;
                    employee.firstName = txtFirstName.Text;
                    employee.lastName = txtLastName.Text;
                    employee.code = txtCode.Text;
                    employee.basicSalary = float.Parse(txtBasicSalary.Text);
                    employee.hourlyRate = float.Parse(txtHourlyRate.Text);
                    employee.designation = optDesignation.SelectedValue.ToString();
                    employee.employmentStatus = optEmployeeStatus.SelectedValue.ToString();
                    //employee.deduction = deduction;
                    var data = await employeeService.SaveEmployee(employee);

                    resetInputFields();
                    GenerateRandomNumber();
                }
            } else
            {
                MessageBox.Show("Fill in all the required (*) fields", "Employee Registration", MessageBoxButtons.OK);
            }
        }

        private bool inputValidator()
        {
            var hasEmpty = false;
            if( optDesignation.SelectedIndex > 0 &&
                optEmployeeStatus.SelectedIndex > 0 &&
                txtFirstName.Text.Trim() != string.Empty &&
                txtLastName.Text.Trim() != string.Empty &&
                fingerPrint != string.Empty )
            {
                hasEmpty = true;
            }
            return hasEmpty;
        }

        private void resetInputFields()
        {
            GenerateRandomNumber();
            optDesignation.SelectedIndex = 0;
            txtBasicSalary.Text = "0";
            txtFirstName.Text = "";
            txtHourlyRate.Text = "0";
            txtLastName.Text = "";
            optEmployeeStatus.SelectedIndex = 0;
            optPagibig.SelectedIndex = 0;
            optPhilhealth.SelectedIndex = 0;
            optSSS.SelectedIndex = 0;
            optTax.SelectedIndex = 0;
            picFingerprint.Image = null;
            fingerPrint = string.Empty;
        }
        private void EmployeeStatus()
        {
            List<KeyValuePair<string, string>> items = new List<KeyValuePair<string, string>>();
            items.Add(new KeyValuePair<string, string>("<<Select>>", ""));
            items.Add(new KeyValuePair<string, string>("Regular", "regular"));
            items.Add(new KeyValuePair<string, string>("Full-time", "full_time"));
            items.Add(new KeyValuePair<string, string>("Part-time", "part_time"));
            optEmployeeStatus.DataSource = items;
            optEmployeeStatus.DisplayMember = "Key";
            optEmployeeStatus.ValueMember = "Value";
        }

        private void EmployeeDesignation()
        {
            List<KeyValuePair<string, string>> items = new List<KeyValuePair<string, string>>();
            items.Add(new KeyValuePair<string, string>("<<Select>>", ""));
            items.Add(new KeyValuePair<string, string>("College", "college"));
            items.Add(new KeyValuePair<string, string>("Senior High", "senior_high"));
            items.Add(new KeyValuePair<string, string>("Both", "both"));
            items.Add(new KeyValuePair<string, string>("Others", "other"));
            optDesignation.DataSource = items;
            optDesignation.DisplayMember = "Key";
            optDesignation.ValueMember = "Value";
        }

        private void GenerateRandomNumber()
        {
            Random generator = new Random();
            txtCode.Text = generator.Next(0, 1000000).ToString("D6");
        }

        
        private void frmRegistration_Load(object sender, EventArgs e)
        {
            EmployeeStatus();
            GenerateRandomNumber();
            EmployeeDesignation();
            sssService = new SssService(apiKey, apiUrl);
            pagibigService = new PagibigService(apiKey, apiUrl);
            taxService = new TaxService(apiKey, apiUrl);
            philhealthService = new PhilhealthService(apiKey, apiUrl);
            employeeService = new EmployeeService(apiKey, apiUrl);
            LoadSssList();
            LoadPagibigList();
            LoadPhilhealthList();
            LoadTaxList();
            inputs = new InputFilter();
            txtBasicSalary.Text = "0";
            txtHourlyRate.Text = "0";
            fingerPrint = string.Empty;
        }
        
    }
}
