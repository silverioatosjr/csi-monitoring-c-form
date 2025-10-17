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
            btnReloadScanner.Click += BtnReloadScanner_Click;
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
            getReaders();
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
                _capture._sender = this;
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
        public Dictionary<int, Fmd> Fmds
        {
            get { return fmds; }
            set { fmds = value; }
        }
        private Dictionary<int, Fmd> fmds = new Dictionary<int, Fmd>();
        private string biometricSerial = null;
        /// <summary>
        /// Reset the UI causing the user to reselect a reader.
        /// </summary>
        public bool Reset
        {
            get { return reset; }
            set { reset = value; }
        }
        private bool reset;
        public Reader CurrentReader
        {
            get { return currentReader; }
            set
            {
                currentReader = value;
                SendMessage(Action.UpdateReaderState, value);
            }
        }
        private ReaderCollection _readers;
        private Reader currentReader;
        private enum Action
        {
            UpdateReaderState
        }
        public bool OpenReader()
        {
            reset = false;
            Constants.ResultCode result = Constants.ResultCode.DP_DEVICE_FAILURE;

            // Open reader
            result = currentReader.Open(Constants.CapturePriority.DP_PRIORITY_COOPERATIVE);

            if (result != Constants.ResultCode.DP_SUCCESS)
            {
                MessageBox.Show("Error:  " + result);
                reset = true;
                return false;
            }

            return true;
        }
        public bool StartCaptureAsync(Reader.CaptureCallback OnCaptured)
        {
            // Activate capture handler
            currentReader.On_Captured += new Reader.CaptureCallback(OnCaptured);

            // Call capture
            if (!CaptureFingerAsync())
            {
                return false;
            }

            return true;
        }
        public bool CaptureFingerAsync()
        {
            try
            {
                GetStatus();

                Constants.ResultCode captureResult = currentReader.CaptureAsync(Constants.Formats.Fid.ANSI, Constants.CaptureProcessing.DP_IMG_PROC_DEFAULT, currentReader.Capabilities.Resolutions[0]);
                if (captureResult != Constants.ResultCode.DP_SUCCESS)
                {
                    reset = true;
                    throw new Exception("" + captureResult);
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:  " + ex.Message);
                return false;
            }
        }
        public void GetStatus()
        {
            Constants.ResultCode result = currentReader.GetStatus();

            if ((result != Constants.ResultCode.DP_SUCCESS))
            {
                if (CurrentReader != null)
                {
                    CurrentReader.Dispose();
                    CurrentReader = null;
                }
                throw new Exception("" + result);
            }

            if ((currentReader.Status.Status == Constants.ReaderStatuses.DP_STATUS_BUSY))
            {
                Thread.Sleep(50);
            }
            else if ((currentReader.Status.Status == Constants.ReaderStatuses.DP_STATUS_NEED_CALIBRATION))
            {
                currentReader.Calibrate();
            }
            else if ((currentReader.Status.Status != Constants.ReaderStatuses.DP_STATUS_READY))
            {
                throw new Exception("Reader Status - " + currentReader.Status.Status);
            }
        }
        private delegate void SendMessageCallback(Action state, object payload);
        private void SendMessage(Action state, object payload)
        {
            if (biometricSerial == string.Empty)
            {
                SendMessageCallback d = new SendMessageCallback(SendMessage);
                this.Invoke(d, new object[] { state, payload });
            }
            else
            {
                switch (state)
                {
                    case Action.UpdateReaderState:
                        if ((Reader)payload != null)
                        {
                            biometricSerial = ((Reader)payload).Description.SerialNumber;
                            btnScan.Enabled = true;
                        }
                        else
                        {
                            biometricSerial = String.Empty;
                            btnScan.Enabled = false;
                        }
                        break;
                    default:
                        break;
                }
            }
        }
        public bool CheckCaptureResult(CaptureResult captureResult)
        {
            if (captureResult.Data == null)
            {
                if (captureResult.ResultCode != Constants.ResultCode.DP_SUCCESS)
                {
                    reset = true;
                    throw new Exception(captureResult.ResultCode.ToString());
                }

                // Send message if quality shows fake finger
                if ((captureResult.Quality != Constants.CaptureQuality.DP_QUALITY_CANCELED))
                {
                    throw new Exception("Quality - " + captureResult.Quality);
                }
                return false;
            }
            return true;
        }
        public Bitmap CreateBitmap(byte[] bytes, int width, int height)
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
        public void CancelCaptureAndCloseReader(Reader.CaptureCallback OnCaptured)
        {
            if (currentReader != null)
            {
                currentReader.CancelCapture();

                // Dispose of reader handle and unhook reader events.
                currentReader.Dispose();

                if (reset)
                {
                    CurrentReader = null;
                }
            }
        }

        private void frmRegistration_Load(object sender, EventArgs e)
        {
            getReaders();
        }

        private void getReaders()
        {
            _readers = ReaderCollection.GetReaders();
            if (_readers.ToList().Count > 0)
            {
                btnScan.Enabled = true;
                biometricSerial=(_readers[0].Description.SerialNumber);
                CurrentReader = _readers[0];
            } else
            {
                btnScan.Enabled = false;
                MessageBox.Show("Please connect the fingerprin reader", "Biometrics", MessageBoxButtons.OK);
            }
        }

       

        //================= BIOMETRICS CODES =========================
    }
}
