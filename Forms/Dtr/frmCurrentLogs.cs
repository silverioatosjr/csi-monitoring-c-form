using CSIEmployeeMonitoringSystem.Models;
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
    public partial class frmCurrentLogs : Form
    {
        private string apiKey = Program.xApiKey;
        private string apiUrl = Program.serverUrl;
        private DtrService dtrService;
        public frmCurrentLogs()
        {
            InitializeComponent();
            timerDtrTemp.Tick += timerDtrTemp_Tick;
        }

        private async void GetDtrTemp()
        {
            var response = await dtrService.GetDtrTempList();
            dgvDtr.Rows.Clear();

            if (null != response)
            {
                foreach (DtrTemp d in response.data)
                {
                    dgvDtr.Rows.Add(
                        $"{d.employee.firstName} {d.employee.lastName}",
                        d.schedule != null ? d.schedule.subject : "",
                        d.time,
                        d.schedule != null ? d.schedule.room : ""
                    );
                }
            }
        }

        private void frmCurrentLogs_Load(object sender, EventArgs e)
        {
            dtrService = new DtrService(apiKey, apiUrl);
            timerDtrTemp.Stop();
            GetDtrTemp();
            timerDtrTemp.Start();
        }
        private void timerDtrTemp_Tick(object sender, EventArgs e)
        {
            this.Invoke(new Action(delegate () {
                GetDtrTemp();
            }));
        }

        private void frmCurrentLogs_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
    }
}
