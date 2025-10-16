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
            this.picFinger = new System.Windows.Forms.PictureBox();
            this.lblStatus = new System.Windows.Forms.Label();
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
            // frmBiometricCapturer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(219, 187);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.picFinger);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBiometricCapturer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Biometric";
            ((System.ComponentModel.ISupportInitialize)(this.picFinger)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picFinger;
        private System.Windows.Forms.Label lblStatus;
    }
}