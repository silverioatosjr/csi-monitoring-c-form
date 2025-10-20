using CSIEmployeeMonitoringSystem.Models;
using CSIEmployeeMonitoringSystem.Services;
using IronXL;
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
    public partial class frmUploadSchedules : Form
    {
        private WorkSheet sheet;
        private ScheduleService scheduleService;
        public frmUploadSchedules()
        {
            InitializeComponent();
            btnCancel.Click += BtnCancel_Click;
            btnSelectFile.Click += BtnSelectFile_Click;
            btnUpload.Click += BtnUpload_Click;
        }

        private void BtnUpload_Click(object sender, EventArgs e)
        {
            if(null != sheet)
            {
                try
                {
                    btnUpload.Enabled = false;
                    btnCancel.Enabled = false;
                    btnSelectFile.Enabled = false;
                    Cursor = Cursors.WaitCursor;
                    List<SchedulePost> schedules = scheduleService.ParseSchedules(sheet);
                    PostSchedules(schedules);
                }
                catch
                {

                }finally
                {
                    btnUpload.Enabled = true;
                    btnCancel.Enabled = false;
                    btnSelectFile.Enabled = false;
                    Cursor = Cursors.Arrow;
                }

            }
        }

        private async void PostSchedules(List<SchedulePost> schedules)
        {
            SchedulesPostData payload = new SchedulesPostData();
            payload.schedules = schedules;
            var response = await scheduleService.PostSchedules(payload);
            if(null!= response)
            {
                MessageBox.Show("Schedules has been successfully uploaded", "Upload Schedule",MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            } else
            {
                MessageBox.Show("Failed to upload schedules", "Upload Schedule", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSelectFile_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Excel file (*.xls, *.xlsx)| *.xls;*.xlsx";
            openFileDialog.Title = "Select Subjects Schedule file";
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Cursor = Cursors.WaitCursor;
                    string selectedFilePath = openFileDialog.FileName;
                    WorkBook workbook = WorkBook.Load(selectedFilePath);
                    lblFilename.Text = selectedFilePath;
                    sheet = workbook.WorkSheets.First();

                    var errors  = scheduleService.ExcelValidator(sheet);
                    Cursor = Cursors.Arrow;
                    if(errors != string.Empty)
                    {
                        MessageBox.Show(errors, "Error File Content", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        btnUpload.Enabled = false;
                        selectedFilePath = string.Empty;
                        lblFilename.Text = string.Empty;
                    } else
                    {
                        MessageBox.Show("Click the Upload File button to upload schedules.", "Subjects Schedule", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        btnUpload.Enabled = true;
                    }

                }catch (Exception err)
                {
                    MessageBox.Show(err.Message, "Error Reading Excel File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


                btnUpload.Enabled = true;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void frmUploadSchedules_Load(object sender, EventArgs e)
        {
            btnUpload.Enabled = false;
            lblFilename.Text = string.Empty;
            sheet = null;
            scheduleService = new ScheduleService(Program.xApiKey, Program.serverUrl);
        }
    }
}
