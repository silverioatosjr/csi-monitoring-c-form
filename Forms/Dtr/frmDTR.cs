using CSIEmployeeMonitoringSystem.Services;
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
    public partial class frmDTR : Form
    {
        private frmTimeLog frmTimeLog = new frmTimeLog();
        private string apiKey = Program.xApiKey;
        private string apiUrl = Program.serverUrl;
        private EmployeeService employeeService;
        private DtrService dtrService;
        public frmDTR()
        {
            InitializeComponent();
            btnLogTime.Click += BtnLogTime_Click;
        }

        private void BtnLogTime_Click(object sender, EventArgs e)
        {
            if(!frmTimeLog.Created)
            {
                frmTimeLog = new frmTimeLog();
            }
            if(frmTimeLog.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Fetch the dtr logs");
            }
        }

        private void frmDTR_Load(object sender, EventArgs e)
        {
            employeeService = new EmployeeService(apiKey, apiUrl);
            dtrService = new DtrService(apiKey, apiUrl);

        }
    }
}
