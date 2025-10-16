using CSIEmployeeMonitoringSystem.Forms.Admin;
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

namespace CSIEmployeeMonitoringSystem
{
    public partial class frmMain : Form
    {
        private frmLogin frmLogin = new frmLogin();
        private frmRegistration frmRegistrationForm = new frmRegistration();

        public frmMain()
        {
            InitializeComponent();
            mnuEmployeeRegistration.Click += MnuEmployeeRegistration_Click;
        }

        private void MnuEmployeeRegistration_Click(object sender, EventArgs e)
        {
            if (!frmRegistrationForm.Created)
            {
                frmRegistrationForm = new frmRegistration();
                frmRegistrationForm.MdiParent = this;
                //frmRegistrationForm.WindowState = FormWindowState.Maximized;
                frmRegistrationForm.Show();
            }
            else if (frmRegistrationForm.WindowState == FormWindowState.Minimized)
            {
                frmRegistrationForm.WindowState = FormWindowState.Maximized;
            }
            frmRegistrationForm.BringToFront();
        }

        private void generatePayrollToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
