using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSIEmployeeMonitoringSystem.Forms.Schedules
{
    public partial class frmParentSchedules : Form
    {
        private frmAddSchedule frmAddSchedule;
        private frmUpdateSchedule frmUpdateSchedule;
        private frmUploadSchedules frmUploadSchedules;
        public frmParentSchedules()
        {
            InitializeComponent();
            btnDeleteSchedules.Click += BtnDeleteSchedules_Click;
            btnDeleteSchedule.Click += BtnDeleteSchedule_Click;
            btnUpdateSchedule.Click += BtnUpdateSchedule_Click;
            btnAddSchedule.Click += BtnAddSchedule_Click;
            btnUploadXLSFile.Click += BtnUploadXLSFile_Click;
        }

        private void BtnUploadXLSFile_Click(object sender, EventArgs e)
        {
            frmUploadSchedules = new frmUploadSchedules();
            frmUploadSchedules.ShowDialog();
        }

        private void BtnAddSchedule_Click(object sender, EventArgs e)
        {
            frmAddSchedule = new frmAddSchedule();
            frmAddSchedule.ShowDialog();
        }

        private void BtnUpdateSchedule_Click(object sender, EventArgs e)
        {
            frmUpdateSchedule = new frmUpdateSchedule();
            frmUpdateSchedule.ShowDialog();
        }

        private void BtnDeleteSchedule_Click(object sender, EventArgs e)
        {
            
        }

        private void BtnDeleteSchedules_Click(object sender, EventArgs e)
        {
            
        }
    }
}
