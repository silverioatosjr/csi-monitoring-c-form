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
            //LoadSssList();
        }

        private async void LoadSssList()
        {
            var data = await sssService.GetSssList();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            
        }

        private void BtnScan_Click(object sender, EventArgs e)
        {
            
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            MessageBox.Show(optEmployeeStatus.SelectedValue.ToString());
            GenerateRandomNumber();
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
    }
}
