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
            this.picFinger = new System.Windows.Forms.PictureBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.biometricTimer = new System.Windows.Forms.Timer(this.components);
            this.btnScan = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picFinger)).BeginInit();
            this.SuspendLayout();
            // 
            // picFinger
            // 
            this.picFinger.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picFinger.Location = new System.Drawing.Point(24, 26);
            this.picFinger.Name = "picFinger";
            this.picFinger.Size = new System.Drawing.Size(169, 119);
            this.picFinger.TabIndex = 0;
            this.picFinger.TabStop = false;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(21, 151);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(40, 13);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "Status:";
            // 
            // biometricTimer
            // 
            this.biometricTimer.Tick += new System.EventHandler(this.biometricTimer_Tick);
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
            this.ClientSize = new System.Drawing.Size(219, 221);
            this.Controls.Add(this.btnScan);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.picFinger);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBiometricCapturer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Biometric";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBiometricCapturer_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.picFinger)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picFinger;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Timer biometricTimer;
        private System.Windows.Forms.Button btnScan;
    }
}