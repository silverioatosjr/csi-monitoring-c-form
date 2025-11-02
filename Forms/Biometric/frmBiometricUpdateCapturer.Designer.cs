namespace CSIEmployeeMonitoringSystem.Forms.Biometric
{
    partial class frmBiometricUpdateCapturer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBiometricUpdateCapturer));
            this.btnReload = new System.Windows.Forms.Button();
            this.lblPlaceFinger = new System.Windows.Forms.Label();
            this.pbFingerprint1 = new System.Windows.Forms.PictureBox();
            this.biometricTimer = new System.Windows.Forms.Timer(this.components);
            this.pbFingerprint2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbFingerprint1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFingerprint2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnReload
            // 
            this.btnReload.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReload.Location = new System.Drawing.Point(52, 232);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(221, 41);
            this.btnReload.TabIndex = 5;
            this.btnReload.Text = "Reload Biometrics";
            this.btnReload.UseVisualStyleBackColor = true;
            // 
            // lblPlaceFinger
            // 
            this.lblPlaceFinger.AutoSize = true;
            this.lblPlaceFinger.Location = new System.Drawing.Point(23, 205);
            this.lblPlaceFinger.Name = "lblPlaceFinger";
            this.lblPlaceFinger.Size = new System.Drawing.Size(53, 13);
            this.lblPlaceFinger.TabIndex = 4;
            this.lblPlaceFinger.Text = "STATUS:";
            // 
            // pbFingerprint1
            // 
            this.pbFingerprint1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbFingerprint1.Location = new System.Drawing.Point(26, 56);
            this.pbFingerprint1.Name = "pbFingerprint1";
            this.pbFingerprint1.Size = new System.Drawing.Size(121, 141);
            this.pbFingerprint1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbFingerprint1.TabIndex = 3;
            this.pbFingerprint1.TabStop = false;
            // 
            // pbFingerprint2
            // 
            this.pbFingerprint2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbFingerprint2.Location = new System.Drawing.Point(178, 56);
            this.pbFingerprint2.Name = "pbFingerprint2";
            this.pbFingerprint2.Size = new System.Drawing.Size(121, 141);
            this.pbFingerprint2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbFingerprint2.TabIndex = 6;
            this.pbFingerprint2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Fingerprint1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(175, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Fingerprint2";
            // 
            // frmBiometricUpdateCapturer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 292);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbFingerprint2);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.lblPlaceFinger);
            this.Controls.Add(this.pbFingerprint1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBiometricUpdateCapturer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Biometrics";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmBiometricUpdateCapturer_FormClosed);
            this.Load += new System.EventHandler(this.frmBiometricUpdateCapturer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbFingerprint1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFingerprint2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Label lblPlaceFinger;
        private System.Windows.Forms.PictureBox pbFingerprint1;
        private System.Windows.Forms.Timer biometricTimer;
        private System.Windows.Forms.PictureBox pbFingerprint2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}