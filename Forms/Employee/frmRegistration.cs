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
        
        public frmRegistration()
        {
            InitializeComponent();
            EmployeeStatus();
            GenerateRandomNumber();
            EmployeeDesignation();
            btnRegister.Click += BtnRegister_Click;
            btnScan.Click += BtnScan_Click;
            btnCancel.Click += BtnCancel_Click;
            sssService = new SssService(apiKey, apiUrl);
            pagibigService = new PagibigService(apiKey, apiUrl);
            taxService = new TaxService(apiKey, apiUrl);
            philhealthService = new PhilhealthService(apiKey, apiUrl);
            LoadSssList();
            LoadPagibigList();
            LoadPhilhealthList();
            LoadTaxList();
        }

        private void BtnReloadScanner_Click(object sender, EventArgs e)
        {
            //getReaders();
        }

        private async void LoadSssList()
        {
            var data = await sssService.GetSssList();
            List<KeyValuePair<string, string>> items = new List<KeyValuePair<string, string>>();
            items.Add(new KeyValuePair<string, string>("<<Select>>", ""));
            if (null != data)
            {
                foreach(SssData s in data.data)
                {
                    items.Add(new KeyValuePair<string, string>($"{s.bracket} ({s.amount})", s._id));
                }
            }
            optSSS.DataSource = items;
            optSSS.DisplayMember = "Key";
            optSSS.ValueMember = "Value";
        }

        private async void LoadPagibigList()
        {
            var data = await pagibigService.GetPagibigList();
            List<KeyValuePair<string, string>> items = new List<KeyValuePair<string, string>>();
            items.Add(new KeyValuePair<string, string>("<<Select>>", ""));
            if (null != data)
            {
                foreach (PagibigData p in data.data)
                {
                    items.Add(new KeyValuePair<string, string>($"{p.percent} ({p.amount})", p._id));
                }
            }
            optPagibig.DataSource = items;
            optPagibig.DisplayMember = "Key";
            optPagibig.ValueMember = "Value";
        }

        private async void LoadPhilhealthList()
        {
            var data = await philhealthService.GetPhilhealthList();
            List<KeyValuePair<string, string>> items = new List<KeyValuePair<string, string>>();
            items.Add(new KeyValuePair<string, string>("<<Select>>", ""));
            if (null != data)
            {
                foreach (PhilhealthData t in data.data)
                {
                    items.Add(new KeyValuePair<string, string>($"{t.percent}", t._id));
                }
            }
            optPhilhealth.DataSource = items;
            optPhilhealth.DisplayMember = "Key";
            optPhilhealth.ValueMember = "Value";
        }

        private async void LoadTaxList()
        {
            var data = await taxService.GetTaxList();
            List<KeyValuePair<string, string>> items = new List<KeyValuePair<string, string>>();
            items.Add(new KeyValuePair<string, string>("<<Select>>", ""));
            if (null != data)
            {
                foreach (TaxData t in data.data)
                {
                    items.Add(new KeyValuePair<string, string>($"{t.bracket} ({t.monthlySalary.baseAmount})", t._id));
                }
            }
            optTax.DataSource = items;
            optTax.DisplayMember = "Key";
            optTax.ValueMember = "Value";
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
            }

            _capture.ShowDialog();
            picFingerprint.Image = ((PictureBox)_capture.Controls["pbFingerprint"]).Image;
            _capture.Dispose();
            _capture = null;
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            MessageBox.Show(optEmployeeStatus.SelectedValue.ToString());
            GenerateRandomNumber();
        }

        private void resetInputFields()
        {
            GenerateRandomNumber();
            optDesignation.SelectedIndex = 0;
            txtBasicSalary.Text = "";
            txtFirstName.Text = "";
            txtHourlyRate.Text = "";
            txtLastName.Text = "";
            optEmployeeStatus.SelectedIndex = 0;
            optPagibig.SelectedIndex = 0;
            optPhilhealth.SelectedIndex = 0;
            optSSS.SelectedIndex = 0;
            optTax.SelectedIndex = 0;
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
            optDesignation.DataSource = items;
            optDesignation.DisplayMember = "Key";
            optDesignation.ValueMember = "Value";
        }

        private void GenerateRandomNumber()
        {
            Random generator = new Random();
            txtCode.Text = generator.Next(0, 1000000).ToString("D6");
        }

        //================= BIOMETRICS CODES =========================
        
        
        

        private void frmRegistration_Load(object sender, EventArgs e)
        {
            //getReaders();
        }

        

       

        //================= BIOMETRICS CODES =========================
    }
}
