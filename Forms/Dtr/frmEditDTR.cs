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
    public partial class frmEditDTR : Form
    {
        private InputFilter inputs;
        public DateTime date = DateTime.Now;
        public string renderedHour = "0";
        public frmEditDTR()
        {
            InitializeComponent();
            btnCancel.Click += BtnCancel_Click;
            btnEdit.Click += BtnEdit_Click;
            txtRenderedHour.TextChanged += txt_TextChanged;
            txtRenderedHour.LostFocus += txt_LostFocus;
            txtRenderedHour.GotFocus += txt_GotFocus;
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            renderedHour = txtRenderedHour.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void frmEditDTR_Load(object sender, EventArgs e)
        {
            inputs = new InputFilter();
            txtRenderedHour.Text = renderedHour;
            dtDate.Value = date;
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
