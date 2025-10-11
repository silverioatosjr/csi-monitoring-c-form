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

namespace CSIEmployeeMonitoringSystem
{
    public partial class frmMain : Form
    {
        private frmLogin frmLogin = new frmLogin();
        public frmMain()
        {
            InitializeComponent();
            
        }

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                frmLogin.ShowDialog();
            }
             
        }
    }
}
