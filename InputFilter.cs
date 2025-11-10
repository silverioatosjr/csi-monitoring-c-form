using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSIEmployeeMonitoringSystem
{
    class InputFilter
    {
        public void Filter(TextBox txt)
        {
            try
            {
                if (txt.Text == "00")
                {
                    txt.Text = "0";
                    txt.SelectionStart = txt.TextLength;
                }
                else
                {
                    string input = txt.Text;
                    int numChar = input.Count(c => c == '.');
                    for (int i = 0; i < input.Length; i++)
                    {
                        if (!((input[i] == '0') || (input[i] == '1') || (input[i] == '2') || (input[i] == '3')
                                || (input[i] == '4') || (input[i] == '5') || (input[i] == '6') || (input[i] == '7')
                                || (input[i] == '8') || (input[i] == '9') || (input[i] == '.') || (input[i] == '-') || (input[i] == ',')))
                        {
                            string newText = txt.Text.Replace(input[i].ToString(), "");
                            txt.Text = newText;
                            txt.SelectionStart = i;
                            return;
                        }
                        else if (input[i] == '.')
                        {
                            if (numChar > 1)
                            {
                                string newText = input.Remove(i, 1);
                                txt.Text = newText;
                                txt.SelectionStart = i;
                            }
                            else if (input.Length == 1)
                            {
                                string newText = "0.";
                                txt.Text = newText;
                                txt.SelectionStart = txt.TextLength;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void NumberFormatter(TextBox txt)
        {
            string input = txt.Text;
            int numChar = input.Count(c => c == '.');
            if (numChar > 0)
            {
                
            }

            
        }
        public void SeriesFilter(TextBox txt)
        {
            try
            {

                string input = txt.Text;
                for (int i = 0; i < input.Length; i++)
                {
                    if (!((input[i] == '0') || (input[i] == '1') || (input[i] == '2') || (input[i] == '3')
                            || (input[i] == '4') || (input[i] == '5') || (input[i] == '6') || (input[i] == '7')
                            || (input[i] == '8') || (input[i] == '9')))
                    {
                        string newText = txt.Text.Replace(input[i].ToString(), "");
                        txt.Text = newText;
                        txt.SelectionStart = i;
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
