namespace CSIEmployeeMonitoringSystem.Forms.Biometric
{
    partial class frmBiometricVerification
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBiometricVerification));
            this.btnReload = new System.Windows.Forms.Button();
            this.lblPlaceFinger = new System.Windows.Forms.Label();
            this.pbFingerprint = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbFingerprint)).BeginInit();
            this.SuspendLayout();
            // 
            // btnReload
            // 
            this.btnReload.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReload.Location = new System.Drawing.Point(24, 312);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(221, 41);
            this.btnReload.TabIndex = 5;
            this.btnReload.Text = "Reload Biometrics";
            this.btnReload.UseVisualStyleBackColor = true;
            // 
            // lblPlaceFinger
            // 
            this.lblPlaceFinger.AutoSize = true;
            this.lblPlaceFinger.Location = new System.Drawing.Point(21, 284);
            this.lblPlaceFinger.Name = "lblPlaceFinger";
            this.lblPlaceFinger.Size = new System.Drawing.Size(53, 13);
            this.lblPlaceFinger.TabIndex = 4;
            this.lblPlaceFinger.Text = "STATUS:";
            // 
            // pbFingerprint
            // 
            this.pbFingerprint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbFingerprint.Location = new System.Drawing.Point(24, 26);
            this.pbFingerprint.Name = "pbFingerprint";
            this.pbFingerprint.Size = new System.Drawing.Size(221, 252);
            this.pbFingerprint.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbFingerprint.TabIndex = 3;
            this.pbFingerprint.TabStop = false;
            // 
            // frmBiometricVerification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(275, 375);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.lblPlaceFinger);
            this.Controls.Add(this.pbFingerprint);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBiometricVerification";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Verification";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmBiometricVerification_FormClosed);
            this.Load += new System.EventHandler(this.frmBiometricVerification_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbFingerprint)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Label lblPlaceFinger;
        private System.Windows.Forms.PictureBox pbFingerprint;
    }
}