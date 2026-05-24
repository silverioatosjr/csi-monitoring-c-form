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
        private WorkBook book;
        private ScheduleService scheduleService;
        public frmUploadSchedules()
        {
            InitializeComponent();
            btnCancel.Click += BtnCancel_Click;
            btnSelectFile.Click += BtnSelectFile_Click;
            btnUpload.Click += BtnUpload_Click;
        }

        private async void BtnUpload_Click(object sender, EventArgs e)
        {
            if(null != book)
            {
                try
                {
                    btnUpload.Enabled = false;
                    btnCancel.Enabled = false;
                    btnSelectFile.Enabled = false;
                    Cursor = Cursors.WaitCursor;
                    bool uploadSuccess = true;
                    foreach (WorkSheet sheet in book.WorkSheets)
                    {
                        List<SchedulesData> schedules = scheduleService.ParseSchedules(sheet);
                        string employeeCode = scheduleService.GetEmployeeCodeFromWorkSheet(sheet);
                        bool response = await PostSchedules(schedules, employeeCode);
                        if(!response)
                        {
                            MessageBox.Show("Error during upload", "Schedules upload", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            uploadSuccess = false;
                            break;
                        }                  
                    }
                    Cursor = Cursors.Arrow;
                    if(uploadSuccess)
                    {
                        MessageBox.Show("Schedules successfully uploaded", "Schedules upload", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
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

        private async Task<bool> PostSchedules(List<SchedulesData> schedules, string employeeCode)
        {
            SchedulesPostData payload = new SchedulesPostData();
            payload.employeeCode = employeeCode;
            payload.schedules = schedules;
            var response = await scheduleService.PostSchedules(payload);
            return (null != response);
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
                    book = WorkBook.Load(selectedFilePath);
                    lblFilename.Text = selectedFilePath;
                    bool hasError = false;
                    foreach (WorkSheet sheet in book.WorkSheets)
                    {
                        var errors  = scheduleService.ExcelValidator(sheet);
                        if(errors != string.Empty)
                        {
                            MessageBox.Show(errors, "Error File Content", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            btnUpload.Enabled = false;
                            selectedFilePath = string.Empty;
                            lblFilename.Text = string.Empty;
                            hasError = true;
                            break;
                        }
                        
                    }
                    if(!hasError)
                    {
                        MessageBox.Show("Click the Upload File button to upload schedules.", "Subjects Schedule", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        btnUpload.Enabled = true;
                    }

                    Cursor = Cursors.Arrow;

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
            book = null;
            scheduleService = new ScheduleService(Program.xApiKey, Program.serverUrl);
        }
    }
}
