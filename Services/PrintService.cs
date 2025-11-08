using CSIEmployeeMonitoringSystem.Models;
using CSIEmployeeMonitoringSystem.Models.Payroll;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSIEmployeeMonitoringSystem.Services
{
    class PrintService
    {
        public PrintService()
        {
            sfC = new StringFormat();
            sfC.Alignment = StringAlignment.Center;
            sfR = new StringFormat();
            sfR.Alignment = StringAlignment.Far;
            sfL = new StringFormat();
            sfL.Alignment = StringAlignment.Near;
            height = 18;
            rowDefaultHeight = 22;
            leftMargin = 48;
            topMargin = 48;
            dtrRowDefaultHeight = 12;
            dtrHeight = 15;
        }
        private StringFormat sfC;
        private StringFormat sfR;
        private StringFormat sfL;
        private int height;
        private int rowDefaultHeight;
        private int dtrRowDefaultHeight;
        private int dtrHeight;
        private int leftMargin;
        private int topMargin;
        public void PrintSchedules(PrintPageEventArgs e, DataGridView dgv)
        {
            // 72 points = 1 inch
            //9 points = 1/8 inch
            //72/2 = 36
            DrawBoldString(e, "TIME", leftMargin, topMargin, 96, height, sfL);
            DrawBoldString(e, "SUBJECT", leftMargin + 96, topMargin, 240, height, sfL);
            DrawBoldString(e, "RM", leftMargin + 336, topMargin, 96, height, sfL);
            DrawBoldString(e, "DAY", leftMargin + 432, topMargin, 48, height, sfL);
            DrawBoldString(e, "INSTRUCTOR", leftMargin + 480, topMargin, 192, height, sfL);
            DrawBoldString(e, "COURSE", leftMargin + 672, topMargin, 144, height, sfL);
            int rowHeight = rowDefaultHeight;
            foreach (DataGridViewRow row in dgv.Rows)
            {
                DrawString(e, $"{row.Cells[6].Value.ToString()}-{row.Cells[7].Value.ToString()}", leftMargin, topMargin+rowHeight, 96, height, sfL);
                DrawString(e, $"({row.Cells[3].Value.ToString()}) {row.Cells[4].Value.ToString()}", leftMargin + 96, topMargin + rowHeight, 240, height, sfL);
                DrawString(e, $"{row.Cells[9].Value.ToString()}", leftMargin + 336, topMargin + rowHeight, 96, height, sfL);
                DrawString(e, $"{row.Cells[8].Value.ToString().Substring(0,3)}", leftMargin + 432, topMargin + rowHeight, 48, height, sfL);
                DrawString(e, $"{row.Cells[2].Value.ToString()}", leftMargin + 480, topMargin + rowHeight, 192, height, sfL);
                DrawString(e, row.Cells[5].Value!=null? row.Cells[5].Value.ToString():"", leftMargin + 672, topMargin + rowHeight, 144, height, sfL);
                rowHeight += rowDefaultHeight;
            }

        }

        public void PrintDtrs(PrintPageEventArgs e, DataGridView dgv)
        {
            // 72 points = 1 inch
            //9 points = 1/8 inch
            //72/2 = 36
            DrawBoldString(e, "EMPLOYEE", leftMargin, topMargin, 192, height, sfL);
            DrawBoldString(e, "CODE", leftMargin + 192, topMargin, 96, height, sfL);
            DrawBoldString(e, "TIME IN", leftMargin + 288, topMargin, 96, height, sfL);
            DrawBoldString(e, "TIME OUT", leftMargin + 384, topMargin, 96, height, sfL);
            DrawBoldString(e, "RENDERED", leftMargin + 480, topMargin, 96, height, sfL);
            DrawBoldString(e, "DAY", leftMargin + 576, topMargin, 96, height, sfL);
            DrawBoldString(e, "DATE", leftMargin + 672, topMargin, 96, height, sfL);
            int rowHeight = rowDefaultHeight;
            foreach (DataGridViewRow row in dgv.Rows)
            {
                DrawString(e, $"{row.Cells[1].Value.ToString()}", leftMargin, topMargin + rowHeight, 192, height, sfL);
                DrawString(e, (row.Cells[2].Value == null) ? "" : row.Cells[2].Value.ToString(), leftMargin + 192, topMargin + rowHeight, 96, height, sfL);
                DrawString(e, row.Cells[3].Value.ToString(), leftMargin + 288, topMargin + rowHeight, 96, height, sfL);
                DrawString(e, row.Cells[4].Value.ToString(), leftMargin + 384, topMargin + rowHeight, 96, height, sfL);
                DrawString(e, row.Cells[5].Value.ToString(), leftMargin + 480, topMargin + rowHeight, 96, height, sfL);
                DrawString(e, row.Cells[6].Value.ToString(), leftMargin + 576, topMargin + rowHeight, 96, height, sfL);
                DrawString(e, row.Cells[7].Value.ToString(), leftMargin + 672, topMargin + rowHeight, 96, height, sfL);
                rowHeight += rowDefaultHeight;
            }

        }

        public void PrintPayroll(PrintPageEventArgs e, PayrollData payroll)
        {
            // 72 points = 1 inch
            //9 points = 1/8 inch
            //72/2 = 36
            int rowHeight = rowDefaultHeight;
            DrawBoldString(e, "COMPUTER SYSTEMS INSTITUTE", 0, topMargin, 816, height, sfC);
            DrawBoldString(e, "F. Imperial St., Kapantawan", 0, topMargin+rowHeight, 816, 22, sfC);
            rowHeight += rowDefaultHeight;
            DrawBoldString(e, "Legazpi City", 0, topMargin + rowHeight, 816, height, sfC);
            rowHeight += 48;
            DrawString(e, $"Name:", leftMargin, topMargin + rowHeight, 52, height, sfL);
            DrawBoldString(e, $"{payroll.employee.lastName}, {payroll.employee.firstName}", leftMargin+52, topMargin + rowHeight, 300, height, sfL);
            rowHeight += 32;
            DrawHeaderString(e, $"DTR", leftMargin, topMargin + rowHeight, 350, height, sfC);
            //Deductions
            DrawHeaderString(e, "DEDUCTIONS", leftMargin+380, topMargin + rowHeight, 350, height, sfC);
            int deduction = rowHeight + 42;
            DrawPayrollString(e, "SSS", leftMargin + 380, topMargin + deduction, 130, dtrHeight, sfL);
            DrawPayrollString(e, ":", leftMargin + 510, topMargin + deduction, 20, dtrHeight, sfL);
            DrawPayrollBoldString(e, payroll.sss.ToString(), leftMargin + 530, topMargin + deduction, 200, dtrHeight, sfR);
            deduction += 22;
            DrawPayrollString(e, "PAGIBIG", leftMargin + 380, topMargin + deduction, 130, dtrHeight, sfL);
            DrawPayrollString(e, ":", leftMargin + 510, topMargin + deduction, 20, dtrHeight, sfL);
            DrawPayrollBoldString(e, payroll.pagibig.ToString(), leftMargin + 530, topMargin + deduction, 200, dtrHeight, sfR);
            deduction += 22;
            DrawPayrollString(e, "PHILHEALTH", leftMargin + 380, topMargin + deduction, 130, dtrHeight, sfL);
            DrawPayrollString(e, ":", leftMargin + 510, topMargin + deduction, 20, dtrHeight, sfL);
            DrawPayrollBoldString(e, payroll.philhealth.ToString(), leftMargin + 530, topMargin + deduction, 200, dtrHeight, sfR);
            deduction += 22;
            DrawPayrollString(e, "TAX", leftMargin + 380, topMargin + deduction, 150, dtrHeight, sfL);
            DrawPayrollString(e, ":", leftMargin + 510, topMargin + deduction, 20, dtrHeight, sfL);
            DrawPayrollBoldString(e, payroll.tax.ToString(), leftMargin + 530, topMargin + deduction, 200, dtrHeight, sfR);
            deduction += 100;
            DrawHeaderString(e, "TOTAL", leftMargin + 380, topMargin + rowHeight, 350, height, sfC);
            deduction += 42;
            DrawPayrollBoldString(e, "GROSS PAY", leftMargin + 380, topMargin + deduction, 150, dtrHeight, sfL);
            DrawPayrollBoldString(e, ":", leftMargin + 510, topMargin + deduction, 20, dtrHeight, sfL);
            DrawPayrollBoldString(e, payroll.grossPay.ToString(), leftMargin + 530, topMargin + deduction, 200, dtrHeight, sfR);
            deduction += 22;
            DrawPayrollBoldString(e, "NET PAY", leftMargin + 380, topMargin + deduction, 150, dtrHeight, sfL);
            DrawPayrollBoldString(e, ":", leftMargin + 510, topMargin + deduction, 20, dtrHeight, sfL);
            DrawPayrollBoldString(e, payroll.netPay.ToString(), leftMargin + 530, topMargin + deduction, 200, dtrHeight, sfR);
            deduction += 42;
            DrawSalaryString(e, $"SALARY: {payroll.netPay}", leftMargin + 380, topMargin + deduction, 350, height, sfC);

            rowHeight += 24;
            DrawPayrollBoldString(e, "TIME IN", leftMargin, topMargin + rowHeight, 70, dtrHeight, sfL);
            DrawPayrollBoldString(e, "TIME OUT", leftMargin + 70, topMargin + rowHeight, 70, dtrHeight, sfL);
            DrawPayrollBoldString(e, "RENDERED", leftMargin + 140, topMargin + rowHeight, 80, dtrHeight, sfL);
            DrawPayrollBoldString(e, "DAY", leftMargin + 220, topMargin + rowHeight, 50, dtrHeight, sfL);
            DrawPayrollBoldString(e, "DATE", leftMargin + 270, topMargin + rowHeight, 70, dtrHeight, sfL);
            rowHeight += 18;
            foreach (var dtr in payroll.dtrs)
            {
                DrawPayrollString(e, dtr.timeIn.ToString(), leftMargin, topMargin + rowHeight, 70, dtrHeight, sfL);
                DrawPayrollString(e, dtr.timeOut.ToString(), leftMargin + 70, topMargin + rowHeight, 70, dtrHeight, sfL);
                DrawPayrollString(e, $"{dtr.hoursRendered.ToString()} hr(s)", leftMargin + 140, topMargin + rowHeight, 80, dtrHeight, sfL);
                DrawPayrollString(e, dtr.day.Substring(0,3), leftMargin + 220, topMargin + rowHeight, 50, dtrHeight, sfL);
                DrawPayrollString(e, dtr.date.ToString(), leftMargin + 270, topMargin + rowHeight, 65, dtrHeight, sfL);
                rowHeight += dtrRowDefaultHeight;
            }

        }

        private void DrawSalaryString(PrintPageEventArgs e, string content, float x, float y, float width, float height, StringFormat sF)
        {
            e.Graphics.DrawRectangle(new Pen(Brushes.Black, 2), x, y, width,40);
            e.Graphics.DrawString(content, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new RectangleF(x, y + 12, width, height), sF);
        }
        private void DrawHeaderString(PrintPageEventArgs e, string content, float x, float y, float width, float height, StringFormat sF)
        {
            e.Graphics.FillRectangle(Brushes.LightGray, x, y, width, height+4);
            e.Graphics.DrawString(content, new Font("Arial", 9, FontStyle.Bold), Brushes.Black, new RectangleF(x, y+5, width, height), sF);
        }
        private void DrawString(PrintPageEventArgs e, string content, float x, float y, float width, float height, StringFormat sF)
        {
            e.Graphics.DrawString(content, new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new RectangleF(x, y, width, height), sF);
        }
        private void DrawBoldString(PrintPageEventArgs e, string content, float x, float y, float width, float height, StringFormat sF)
        {
            e.Graphics.DrawString(content, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new RectangleF(x, y, width, height), sF);
        }

        private void DrawPayrollBoldString(PrintPageEventArgs e, string content, float x, float y, float width, float height, StringFormat sF)
        {
            e.Graphics.DrawString(content, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new RectangleF(x, y, width, height), sF);
        }

        private void DrawPayrollString(PrintPageEventArgs e, string content, float x, float y, float width, float height, StringFormat sF)
        {
            e.Graphics.DrawString(content, new Font("Arial", 8, FontStyle.Regular), Brushes.Black, new RectangleF(x, y, width, height), sF);
        }
    }
}
