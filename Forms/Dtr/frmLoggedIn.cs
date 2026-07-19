using CSIEmployeeMonitoringSystem.Models;
using CSIEmployeeMonitoringSystem.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSIEmployeeMonitoringSystem.Forms.Dtr
{
    public partial class frmLoggedIn : Form
    {
        private string apiKey = Program.xApiKey;
        private string apiUrl = Program.serverUrl;
        private DtrService dtrService;
        public frmLoggedIn()
        {
            InitializeComponent();
            btnRefresh.Click += BtnRefresh_Click;
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            GetDtrTemp();
        }

        private void frmLoggedIn_Load(object sender, EventArgs e)
        {
            dtrService = new DtrService(apiKey, apiUrl);
            GetDtrTemp();
        }
        private async void GetDtrTemp()
        {
            var response = await dtrService.GetDtrTempList();
            dgvDtr.Enabled = true;
            dgvDtr.Rows.Clear();

            if (null != response)
            {
                foreach (DtrTemp d in response.data)
                {
                    DateTime dateTime = DateTime.Parse(d.time);
                    string time12Hour = dateTime.ToString("h:mm tt", CultureInfo.InvariantCulture);
                    dgvDtr.Rows.Add(
                        $"{d.employee.firstName} {d.employee.lastName}",
                        time12Hour,
                        d.building != null ? d.building : "",
                        d.createdAt.Split('T')[0] 
                    );
                }
            }
            dgvDtr.Enabled = false;
        }
    }
}
