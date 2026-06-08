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
    public partial class frmPassword : Form
    {
        public frmPassword()
        {
            InitializeComponent();
            btnOk.Click += BtnOk_Click;

        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if(txtPassword.Text.Trim() == "CSI@2026!")
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void frmPassword_Load(object sender, EventArgs e)
        {
            txtPassword.Focus();
        }
    }
}
