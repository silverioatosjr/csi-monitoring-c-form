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
            rowDefaultHeight = 22;
            leftMargin = 48;
            topMargin = 48;
        }
        private StringFormat sfC;
        private StringFormat sfR;
        private StringFormat sfL;
        private int height;
        private int rowDefaultHeight;
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
                DrawString(e, $"({row.Cells[3].Value.ToString()}){row.Cells[4].Value.ToString()}", leftMargin + 96, topMargin + rowHeight, 240, height, sfL);
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
        private void DrawString(PrintPageEventArgs e, string content, float x, float y, float width, float height, StringFormat sF)
        {
            e.Graphics.DrawString(content, new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new RectangleF(x, y, width, height), sF);
        }
        private void DrawBoldString(PrintPageEventArgs e, string content, float x, float y, float width, float height, StringFormat sF)
        {
            e.Graphics.DrawString(content, new Font("Arial", 11, FontStyle.Bold), Brushes.Black, new RectangleF(x, y, width, height), sF);
        }
    }
}
