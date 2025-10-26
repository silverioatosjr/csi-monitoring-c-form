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
                timerDtrTemp.Stop();
                GetDtrTemp();
                timerDtrTemp.Start();
            }
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
                        d.schedule != null? d.schedule.subject:"",
                        d.time,
                        d.schedule != null ? d.schedule.room : ""
                    );
                }
            }
        }

        private void frmDTR_Load(object sender, EventArgs e)
        {
            employeeService = new EmployeeService(apiKey, apiUrl);
            dtrService = new DtrService(apiKey, apiUrl);
            GetDtrTemp();
            timerDtrTemp.Start();

        }


        private void timerDtrTemp_Tick(object sender, EventArgs e)
        {
            this.Invoke(new Action(delegate () {
                GetDtrTemp();
            }));
        }
    }
}
