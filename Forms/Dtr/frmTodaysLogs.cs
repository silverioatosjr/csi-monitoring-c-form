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
    public partial class frmTodaysLogs : Form
    {
        private string apiKey = Program.xApiKey;
        private string apiUrl = Program.serverUrl;
        private DtrService dtrService;
        public frmTodaysLogs()
        {
            InitializeComponent();
            btnRefresh.Click += BtnRefresh_Click;
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            GetTodayDtr();
        }

        private void frmTodaysLogs_Load(object sender, EventArgs e)
        {
            dtrService = new DtrService(apiKey, apiUrl);
            GetTodayDtr();
        }
        private async void GetTodayDtr()
        {
            var response = await dtrService.GetTodayDtrs();
            dgvCurrenDtr.Rows.Clear();

            if (null != response)
            {
                foreach (DTR d in response.data)
                {
                    DateTime dateTimeIn = DateTime.Parse(d.timeIn);
                    DateTime dateTimeOut = DateTime.Parse(d.timeOut);
                    string timeIn = dateTimeIn.ToString("h:mm tt", CultureInfo.InvariantCulture);
                    string timeOut = dateTimeOut.ToString("h:mm tt", CultureInfo.InvariantCulture);
                    dgvCurrenDtr.Rows.Add(
                        $"{d.employee.firstName} {d.employee.lastName}",
                        d.schedule?.subject, timeIn, timeOut, d.hoursRendered.ToString("0.##")
                    );
                }
            }
        }
    }
}
