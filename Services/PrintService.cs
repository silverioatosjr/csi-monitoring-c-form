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
            height = 15;
            row = 22;
            leftMargin = 48;
            topMargin = 48;
        }
        private StringFormat sfC;
        private StringFormat sfR;
        private StringFormat sfL;
        private int height;
        private int row;
        private int leftMargin;
        private int topMargin;
        public void PrintSchedules(PrintPageEventArgs e, DataGridView dgv)
        {
            // 72 points = 1 inch
            //9 points = 1/8 inch
            //72/2 = 36
            DrawString(e, "INSTRUCTOR", leftMargin, topMargin, 150, height, sfL);
            DrawString(e, "CODE", leftMargin + 150, topMargin, 100, height, sfL);
            DrawString(e, "SUBJECT", leftMargin + 250, topMargin, 200, height, sfL);
            DrawString(e, "SCHEDULE", leftMargin + 250, topMargin, 200, height, sfL);
            //foreach (DataGridViewRow row in dgv.Rows)
            //{
            //    DrawString(e, row.Cells[2].Value.ToString(),96,96, 200, height, sfL);
            //}

        }
        private void DrawString(PrintPageEventArgs e, string content, float x, float y, float width, float height, StringFormat sF)
        {
            e.Graphics.DrawString(content, new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new RectangleF(x, y, width, height), sF);
        }
    }
}
