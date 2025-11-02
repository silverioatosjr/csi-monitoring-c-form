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
using DPUruNet;
using System.Threading;
using System.Drawing.Imaging;

namespace CSIEmployeeMonitoringSystem.Forms.Biometric
{
    public partial class frmBiometricCapturer : Form
    {
        public frmBiometricCapturer()
        {
            InitializeComponent();
            btnReload.Click += BtnClose_Click;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            getReaders();
        }

        public frmRegistration _sender;
        //================== VARIABLES =====================

        //CAPTURE VARIABLES
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
                SendMessage(Actions.UpdateReaderState, value);
            }
        }
        private ReaderCollection _readers;
        private Reader currentReader;
        private enum Actions
        {
            UpdateReaderState,
            SendBitmap,
            SendMessage
        }
        //ENROLL VARIABLES
        private int count;

        //================== VARIABLES END =====================

        private void frmBiometricCapturer_Load(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            getReaders();
            Cursor = Cursors.Arrow;
        }


        public void OnCaptured(CaptureResult captureResult)
        {
            try
            {
                // Check capture quality and throw an error if bad.
                if (!CheckCaptureResult(captureResult))
                {
                    lblPlaceFinger.Text = "Status: Low quality image";
                    return;
                }

                count++;
                // Create bitmap
                

                DataResult<Fmd> resultConversion = FeatureExtraction.CreateFmdFromFid(captureResult.Data, Constants.Formats.Fmd.ANSI);

                
                if (resultConversion.ResultCode != Constants.ResultCode.DP_SUCCESS)
                {
                    Reset = true;
                    throw new Exception(resultConversion.ResultCode.ToString());
                }

                _sender.preenrollmentFmds.Add(resultConversion.Data);
                if(count == 1)
                {
                     foreach (Fid.Fiv fiv in captureResult.Data.Views)
                     {
                         SendMessage(Actions.SendBitmap, CreateBitmap(fiv.RawImage, fiv.Width, fiv.Height));
                     }
                     SendMessage(Actions.SendMessage, "Fingerprint1 was captured.");
                     MessageBox.Show("Place your next finger", "Biometrics", MessageBoxButtons.OK);
             
                } else if (count == 2)
                {
                    
                        foreach (Fid.Fiv fiv in captureResult.Data.Views)
                        {
                            SendMessage(Actions.SendBitmap, CreateBitmap(fiv.RawImage, fiv.Width, fiv.Height));
                        }
                        SendMessage(Actions.SendMessage, "Fingerprint2 was captured.");
                        MessageBox.Show("Fingerprints samples are successfully created", "Biometrics", MessageBoxButtons.OK);
                        this.Invoke(new Action(delegate ()
                        {
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }));
                        
                        return;
                    
                }
            }
            catch (Exception ex)
            {
                // Send error message, then close form
                SendMessage(Actions.SendMessage, "Error:  " + ex.Message);
            }
        }
        public bool CheckCaptureResult(CaptureResult captureResult)
        {
            if (captureResult.Data == null)
            {
                if (captureResult.ResultCode != Constants.ResultCode.DP_SUCCESS)
                {
                    reset = true;
                    lblPlaceFinger.Text = "STATUS: Fingerprint captured.[BAD QUALITY]";
                    throw new Exception(captureResult.ResultCode.ToString());
                }

                // Send message if quality shows fake finger
                if ((captureResult.Quality != Constants.CaptureQuality.DP_QUALITY_CANCELED))
                {
                    lblPlaceFinger.Text = "STATUS: Fingerprint captured.[BAD QUALITY]";
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

        private void frmBiometricCapturer_FormClosed(object sender, FormClosedEventArgs e)
        {
            CancelCaptureAndCloseReader(this.OnCaptured);
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
        private void getReaders()
        {
            _readers = ReaderCollection.GetReaders();
            if (_readers.ToList().Count > 0)
            {
                CurrentReader = _readers[0];
                OpenReader();
                StartCaptureAsync(this.OnCaptured);
                pbFingerprint1.Image = null;
                pbFingerprint2.Image = null;
                _sender.preenrollmentFmds = new List<Fmd>();
                count = 0;
                SendMessage(Actions.SendMessage, "Place a finger on the reader.");
                btnReload.Enabled = false;
            }
            else
            {
                btnReload.Enabled = true;
                lblPlaceFinger.Text = "STATUS: Unable to connect.";
                MessageBox.Show("Please connect the fingerprint reader", "Biometrics", MessageBoxButtons.OK);
            }
        }
        private delegate void SendMessageCallback(Actions action, object payload);
        private void SendMessage(Actions action, object payload)
        {
            try
            {
                if (this.pbFingerprint1.InvokeRequired || this.pbFingerprint2.InvokeRequired)
                {
                    SendMessageCallback d = new SendMessageCallback(SendMessage);
                    this.Invoke(d, new object[] { action, payload });
                }
                else
                {
                    switch (action)
                    {
                        case Actions.SendMessage:
                            lblPlaceFinger.Text=$"STATUS: {(string)payload}";
                            break;
                        case Actions.SendBitmap:
                            if(count == 1)
                            {
                                pbFingerprint1.Image = (Bitmap)payload;
                                pbFingerprint1.Refresh();

                            } else
                            {
                                pbFingerprint2.Image = (Bitmap)payload;
                                pbFingerprint2.Refresh();
                            }
                            break;
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        //=============== ENROLLMENT CODES =================

        //============= ENROLLMENT END CODES ===============
    }
}
