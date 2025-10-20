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
        public frmUploadSchedules()
        {
            InitializeComponent();
            btnCancel.Click += BtnCancel_Click;
            btnSelectFile.Click += BtnSelectFile_Click;
        }

        private void BtnSelectFile_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Excel file (*.xls, *.xlsx)| *.xls;*.xlsx";
            openFileDialog.Title = "Select Subjects Schedule file";
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog.FileName;
                lblFilename.Text = selectedFilePath;
                WorkBook workbook = WorkBook.Load(selectedFilePath);
                WorkSheet sheet = workbook.WorkSheets.First();
                MessageBox.Show(sheet["A2"].Value.ToString());
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
        }
    }
}
