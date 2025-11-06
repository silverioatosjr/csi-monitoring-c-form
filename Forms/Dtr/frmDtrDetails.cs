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
    public partial class frmDtrDetails : Form
    {
        public string dtrId;
        private DtrService dtrService;
        private InputFilter inputs;
        public frmDtrDetails()
        {
            InitializeComponent();
            txtHoursRendered.TextChanged += txt_TextChanged;
            txtHoursRendered.LostFocus += txt_LostFocus;
            txtHoursRendered.GotFocus += txt_GotFocus;
            btnClose.Click += BtnClose_Click;
            btnUpdate.Click += BtnUpdate_Click;
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if(btnUpdate.Text == "Edit")
            {
                btnUpdate.Text = "Update";
                txtHoursRendered.Enabled = true;
            } else
            {
                UpdateDtr();
                btnUpdate.Text = "Edit";
                txtHoursRendered.Enabled = false;
            }
        }

        private async void UpdateDtr()
        {
            DtrUpdate payload = new DtrUpdate();
            payload.hoursRendered = float.Parse(txtHoursRendered.Text);
            var response = await dtrService.UpdateDtr(dtrId, payload);
            if(null != response)
            {
                MessageBox.Show("Dtr has been updated.", "DTR Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else
            {
                MessageBox.Show("Dtr failed to update.", "DTR Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_LostFocus(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text == string.Empty)
            {
                ((TextBox)sender).Text = "0";
            }
        }

        private void txt_TextChanged(object sender, EventArgs e)
        {
            inputs.Filter((TextBox)sender);
        }

        private void txt_GotFocus(object sender, EventArgs e)
        {
            if (sender.GetType().Name == "TextBox")
            {
                ((TextBox)sender).Text = (((TextBox)sender).Text == "0") ? "" : ((TextBox)sender).Text;
                ((TextBox)sender).SelectionStart = ((TextBox)sender).TextLength;
            }
        }
        private void frmDtrDetails_Load(object sender, EventArgs e)
        {
            dtrService = new DtrService(Program.xApiKey, Program.serverUrl);
            inputs = new InputFilter();
            GetDtr();
        }

        private void frmDtrDetails_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }

        private async void GetDtr()
        {
            var response = await dtrService.GetDtr(dtrId);
            if(null != response)
            {
                txtDate.Text = DateTime.Parse(response.data.date).ToString("MM/dd/yyyy");
                txtDay.Text = response.data.day;
                txtTimeIn.Text = response.data.timeIn;
                txtTimeOut.Text = response.data.timeOut;
                txtHoursRendered.Text = response.data.hoursRendered.ToString();
            }
        }
    }
}
