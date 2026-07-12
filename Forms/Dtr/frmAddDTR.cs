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
    public partial class frmAddDTR : Form
    {
        private InputFilter inputs;
        public DateTime date;
        public string renderedHour = "0";
        public frmAddDTR()
        {
            InitializeComponent();
            btnAdd.Click += BtnAdd_Click;
            btnCancel.Click += BtnCancel_Click;
            txtRenderedHour.TextChanged += txt_TextChanged;
            txtRenderedHour.LostFocus += txt_LostFocus;
            txtRenderedHour.GotFocus += txt_GotFocus;
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if(txtRenderedHour.Text.Trim() != string.Empty || txtRenderedHour.Text.Trim() !="0")
            {
                this.DialogResult = DialogResult.OK;
                date = dtDate.Value;
                renderedHour = txtRenderedHour.Text;
                this.Close();
            } else
            {
                MessageBox.Show("Rendered hour should not be empty or zero", "Add Dtr", MessageBoxButtons.OK);
            }
        }

        private void frmAddNonTeachingDTR_Load(object sender, EventArgs e)
        {
            inputs = new InputFilter();
            txtRenderedHour.Text = renderedHour;
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
                if (((TextBox)sender).Text == "0")
                {
                    ((TextBox)sender).Text = "";
                }
                ((TextBox)sender).SelectionStart = ((TextBox)sender).TextLength;
            }
        }
    }
}
