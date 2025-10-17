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
        }
        public frmRegistration _sender;

       
        protected void SetStatus(string status)
        {
           lblPlaceFinger.Text = status;
        }
        
        private void frmBiometricCapturer_Load(object sender, EventArgs e)
        {
            pbFingerprint.Image = null;

            if (!_sender.OpenReader())
            {
                this.Close();
            }

            if (!_sender.StartCaptureAsync(this.OnCaptured))
            {
                this.Close();
            }
        }


        public void OnCaptured(CaptureResult captureResult)
        {
            try
            {
                // Check capture quality and throw an error if bad.
                if (!_sender.CheckCaptureResult(captureResult))
                {
                    lblPlaceFinger.Text = "Status: Low quality image";
                    return;
                }

                // Create bitmap
                foreach (Fid.Fiv fiv in captureResult.Data.Views)
                {
                    SendMessage(Action.SendBitmap, _sender.CreateBitmap(fiv.RawImage, fiv.Width, fiv.Height));
                }
            }
            catch (Exception ex)
            {
                // Send error message, then close form
                SendMessage(Action.SendMessage, "Error:  " + ex.Message);
            }
        }

        private void frmBiometricCapturer_FormClosed(object sender, FormClosedEventArgs e)
        {
            _sender.CancelCaptureAndCloseReader(this.OnCaptured);
        }
        private enum Action
        {
            SendBitmap,
            SendMessage
        }
        private delegate void SendMessageCallback(Action action, object payload);
        private void SendMessage(Action action, object payload)
        {
            try
            {
                if (this.pbFingerprint.InvokeRequired)
                {
                    SendMessageCallback d = new SendMessageCallback(SendMessage);
                    this.Invoke(d, new object[] { action, payload });
                }
                else
                {
                    switch (action)
                    {
                        case Action.SendMessage:
                            MessageBox.Show((string)payload);
                            break;
                        case Action.SendBitmap:
                            pbFingerprint.Image = (Bitmap)payload;
                            pbFingerprint.Refresh();
                            Close();
                            break;
                    }
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
