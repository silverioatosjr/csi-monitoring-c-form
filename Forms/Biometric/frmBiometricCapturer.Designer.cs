namespace CSIEmployeeMonitoringSystem.Forms.Biometric
{
    partial class frmBiometricCapturer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pbFingerprint = new System.Windows.Forms.PictureBox();
            this.lblPlaceFinger = new System.Windows.Forms.Label();
            this.biometricTimer = new System.Windows.Forms.Timer(this.components);
            this.btnScan = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbFingerprint)).BeginInit();
            this.SuspendLayout();
            // 
            // pbFingerprint
            // 
            this.pbFingerprint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbFingerprint.Location = new System.Drawing.Point(24, 26);
            this.pbFingerprint.Name = "pbFingerprint";
            this.pbFingerprint.Size = new System.Drawing.Size(169, 119);
            this.pbFingerprint.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbFingerprint.TabIndex = 0;
            this.pbFingerprint.TabStop = false;
            // 
            // lblPlaceFinger
            // 
            this.lblPlaceFinger.AutoSize = true;
            this.lblPlaceFinger.Location = new System.Drawing.Point(21, 151);
            this.lblPlaceFinger.Name = "lblPlaceFinger";
            this.lblPlaceFinger.Size = new System.Drawing.Size(40, 13);
            this.lblPlaceFinger.TabIndex = 1;
            this.lblPlaceFinger.Text = "Status:";
            // 
            // btnScan
            // 
            this.btnScan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScan.Location = new System.Drawing.Point(50, 175);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(109, 30);
            this.btnScan.TabIndex = 2;
            this.btnScan.Text = "Start Scanner";
            this.btnScan.UseVisualStyleBackColor = true;
            // 
            // frmBiometricCapturer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 228);
            this.Controls.Add(this.btnScan);
            this.Controls.Add(this.lblPlaceFinger);
            this.Controls.Add(this.pbFingerprint);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBiometricCapturer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Biometrics";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmBiometricCapturer_FormClosed);
            this.Load += new System.EventHandler(this.frmBiometricCapturer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbFingerprint)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbFingerprint;
        private System.Windows.Forms.Label lblPlaceFinger;
        private System.Windows.Forms.Timer biometricTimer;
        private System.Windows.Forms.Button btnScan;
    }
}