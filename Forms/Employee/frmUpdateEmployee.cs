using CSIEmployeeMonitoringSystem.Forms.Biometric;
using CSIEmployeeMonitoringSystem.Models;
using CSIEmployeeMonitoringSystem.Services;
using DPUruNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSIEmployeeMonitoringSystem.Forms.Employee
{
    public partial class frmUpdateEmployee : Form
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
        public string employeeId;
        public frmUpdateEmployee()
        {
            InitializeComponent();
            btnUpdate.Click += BtnUpdate_Click;
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
            if (((TextBox)sender).Text == string.Empty)
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
                foreach (Sss s in data.data)
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
        private async void GetEmployeeDetails()
        {
            var data = await employeeService.GetEmployeeDetails(employeeId);
            if(null != data)
            {
                txtCode.Text = data.data.code;
                txtBasicSalary.Text = data.data.basicSalary.ToString();
                txtHourlyRate.Text = data.data.hourlyRate.ToString();
                txtFirstName.Text = data.data.firstName;
                txtLastName.Text = data.data.lastName;
                optDesignation.SelectedValue = data.data.designation;
                fingerPrint = data.data.biometric;
                //var fmdData = Fmd.DeserializeXml(data.data.biometric);
                //picFingerprint.Image = CreateBitmap(fmdData.Bytes, fmdData.Width, fmdData.Height);
                //picFingerprint.Refresh();
                optEmployeeStatus.SelectedValue = data.data.employmentStatus;
                if(data.data.deduction != null)
                {
                    if(data.data.deduction.tax != null)
                    {
                        optTax.SelectedValue = data.data.deduction.tax._id;
                    }
                    if (data.data.deduction.sss != null)
                    {
                        optSSS.SelectedValue = data.data.deduction.sss._id;
                    }
                    if (data.data.deduction.philhealth != null)
                    {
                        optPhilhealth.SelectedValue = data.data.deduction.philhealth._id;
                    }
                    if (data.data.deduction.pagibig != null)
                    {
                        optPagibig.SelectedValue = data.data.deduction.pagibig._id;
                    }
                }
            }
        }
        private Bitmap CreateBitmap(byte[] bytes, int width, int height)
        {
            byte[] rgbBytes = new byte[bytes.Length * 3];

            for (int i = 0; i <= bytes.Length - 1; i++)
            {
                rgbBytes[(i * 3)] = bytes[i];
                rgbBytes[(i * 3) + 1] = bytes[i];
                rgbBytes[(i * 3) + 2] = bytes[i];
            }
            Bitmap bmp = new Bitmap(width, height, PixelFormat.Format24bppRgb);

            BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);

            for (int i = 0; i <= bmp.Height - 1; i++)
            {
                IntPtr p = new IntPtr(data.Scan0.ToInt64() + data.Stride * i);
                System.Runtime.InteropServices.Marshal.Copy(rgbBytes, i * bmp.Width * 3, p, bmp.Width * 3);
            }

            bmp.UnlockBits(data);

            return bmp;
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
                    items.Add(new KeyValuePair<string, string>($"{t.bracket} income", t._id));
                }
            }
            optTax.DataSource = items;
            optTax.DisplayMember = "Key";
            optTax.ValueMember = "Value";
            Cursor = Cursors.Arrow;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private frmBiometricUpdateCapturer _capture;
        private void BtnScan_Click(object sender, EventArgs e)
        {
            if (_capture == null)
            {
                _capture = new frmBiometricUpdateCapturer();
                _capture._sender = this;
            }

            _capture.ShowDialog();
            picFingerprint.Image = ((PictureBox)_capture.Controls["pbFingerprint"]).Image;
            if (null != preenrollmentFmds)
            {
                fingerPrint = Fmd.SerializeXml(preenrollmentFmds[2]);
                preenrollmentFmds.Clear();
            }
            //_capture.Dispose();
            _capture = null;
        }

        private async void BtnUpdate_Click(object sender, EventArgs e)
        {
            //if all required fields are filled up
            if (inputValidator())
            {
                if (MessageBox.Show("Click Ok to continue.", "Employee Update", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    EmployeePost employee = new EmployeePost();
                    Deduction deduction = new Deduction();
                    if (optTax.SelectedValue.ToString() != string.Empty)
                        deduction.tax = optTax.SelectedValue.ToString();
                    if (optSSS.SelectedValue.ToString() != string.Empty)
                        deduction.sss = optSSS.SelectedValue.ToString();
                    if (optPagibig.SelectedValue.ToString() != string.Empty)
                        deduction.pagibig = optPagibig.SelectedValue.ToString();
                    if (optPhilhealth.SelectedValue.ToString() != string.Empty)
                        deduction.philhealth = optPhilhealth.SelectedValue.ToString();

                    employee.biometric = fingerPrint;
                    employee.firstName = txtFirstName.Text;
                    employee.lastName = txtLastName.Text;
                    employee.code = txtCode.Text;
                    employee.basicSalary = float.Parse(txtBasicSalary.Text);
                    employee.hourlyRate = float.Parse(txtHourlyRate.Text);
                    employee.designation = optDesignation.SelectedValue.ToString();
                    employee.employmentStatus = optEmployeeStatus.SelectedValue.ToString();
                    employee.deduction = deduction;
                    var data = await employeeService.UpdateEmployee(employeeId, employee);
                    if (null != data)
                    {
                        MessageBox.Show("Employee details has been updated", "Update Employee", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Dispose();
                        this.Close();
                    } else
                    {
                        MessageBox.Show("Unable to update employee details", "Update Employee", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Fill in all the required (*) fields.\nBasic salary or Hourly rate must have a value", "Update Employee", MessageBoxButtons.OK);
            }
        }

        private bool inputValidator()
        {
            var hasEmpty = false;
            if (optDesignation.SelectedIndex > 0 &&
                optEmployeeStatus.SelectedIndex > 0 &&
                txtFirstName.Text.Trim() != string.Empty &&
                txtLastName.Text.Trim() != string.Empty &&
                fingerPrint != string.Empty && (txtBasicSalary.Text != "0" || txtHourlyRate.Text != "0"))
            {
                hasEmpty = true;
            }
            return hasEmpty;
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
            items.Add(new KeyValuePair<string, string>("Others (e.g.: Registrar)", "other"));
            optDesignation.DataSource = items;
            optDesignation.DisplayMember = "Key";
            optDesignation.ValueMember = "Value";
        }

        private void frmUpdateEmployee_Load(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            EmployeeStatus();
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
            Thread.Sleep(1000);
            GetEmployeeDetails();
            Cursor = Cursors.Arrow;
        }

        private void frmUpdateEmployee_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
    }
}
