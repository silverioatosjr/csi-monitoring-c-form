using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSIEmployeeMonitoringSystem.Forms.Dtr
{
    public partial class frmLogMessage : Form
    {
        public string message = string.Empty;
        public frmLogMessage()
        {
            InitializeComponent();
            btnOk.Click += BtnOk_Click;
            timer1.Tick += Timer1_Tick;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            this.Invoke(new Action(delegate ()
            {
                timer1.Enabled = false;
                this.Close();
            }));
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            this.Close();
        }

        private void frmLogMessage_Load(object sender, EventArgs e)
        {
            label1.Text = message;
            btnOk.Focus();
            timer1.Interval = 2000;
            timer1.Enabled = true;
        }

        private void frmLogMessage_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Enabled = false;
        }

        private void frmLogMessage_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Enabled = false;
        }
    }
}
