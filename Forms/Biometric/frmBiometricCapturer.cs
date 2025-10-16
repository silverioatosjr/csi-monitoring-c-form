using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DPFP;
using DPFP.Capture;
using CSIEmployeeMonitoringSystem.Forms.Employee;

namespace CSIEmployeeMonitoringSystem.Forms.Biometric
{
    public partial class frmBiometricCapturer : Form, DPFP.Capture.EventHandler
    {
        DPFP.Capture.Capture Capturer;
        public frmBiometricCapturer()
        {
            InitializeComponent();
            btnScan.Click += BtnScan_Click;
        }

        private void BtnScan_Click(object sender, EventArgs e)
        {
            biometricTimer.Interval = 1000;
            biometricTimer.Start();
        }

        protected void SetStatus(string status)
        {
           lblStatus.Text = status;
        }

        protected virtual void Init()
        {
            try
            {
                Capturer = new DPFP.Capture.Capture();
                if(null != Capturer)
                {
                    Capturer.EventHandler = this;
                } else
                {
                    SetStatus("STATUS: Can't initiate capture");
                }

            } catch
            {
                MessageBox.Show("Unable to initialize capture operation", "Fingerprint Reader");
            }
        }

        protected virtual void Process(DPFP.Sample sample)
        {
            DrawPicture(ConvertToBitmap(sample));
        }

        private void DrawPicture(Bitmap bitmap)
        {
            this.Invoke(new Function(delegate()
            {
                picFinger.Image = new Bitmap(bitmap, picFinger.Size);
            }));
        }

        protected void Start()
        {
            if(null != Capturer)
            {
                try
                {
                    Capturer.StartCapture();
                    SetStatus("STATUS: Ready to scan your fingerprint");
                } catch(Exception ex)
                {
                    SetStatus(ex.Message);
                }
            }
        }

        protected void Stop()
        {
            if (null != Capturer)
            {
                try
                {
                    Capturer.StopCapture();
                }
                catch
                {
                    SetStatus("Unable to terminate scanner");
                }
            }
        }

        protected DPFP.FeatureSet ExtractFeatures(DPFP.Sample sample, DPFP.Processing.DataPurpose purpose)
        {
            DPFP.Processing.FeatureExtraction extractor = new DPFP.Processing.FeatureExtraction();
            DPFP.Capture.CaptureFeedback feedback = DPFP.Capture.CaptureFeedback.None;
            DPFP.FeatureSet features = new FeatureSet();
            if(feedback == DPFP.Capture.CaptureFeedback.Good)
            {
                return features;
            } else
            {
                return null;
            }
        }

        protected Bitmap ConvertToBitmap(DPFP.Sample sample)
        {
            DPFP.Capture.SampleConversion Converter = new SampleConversion();
            Bitmap bitmap = null;
            Converter.ConvertToPicture(sample, ref bitmap);
            return bitmap;
        }


        public void OnComplete(object Capture, string ReaderSerialNumber, Sample Sample)
        {
            
        }

        public void OnFingerGone(object Capture, string ReaderSerialNumber)
        {
            
        }

        public void OnFingerTouch(object Capture, string ReaderSerialNumber)
        {
            
        }

        public void OnReaderConnect(object Capture, string ReaderSerialNumber)
        {
            
        }

        public void OnReaderDisconnect(object Capture, string ReaderSerialNumber)
        {
            
        }

        public void OnSampleQuality(object Capture, string ReaderSerialNumber, CaptureFeedback CaptureFeedback)
        {
            
        }

        private void frmBiometricCapturer_FormClosing(object sender, FormClosingEventArgs e)
        {
            Stop();
        }

        private void biometricTimer_Tick(object sender, EventArgs e)
        {
            Init();
            Start();
           
        }
    }
}
