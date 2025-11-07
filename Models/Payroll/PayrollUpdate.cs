using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSIEmployeeMonitoringSystem.Models.Payroll
{
    class PayrollUpdate
    {
        public string _id { get; set; }
        public float totalHours { get; set; }
        public float grossPay { get; set; }
        public float netPay { get; set; }
        public float sss { get; set; }
        public float pagibig { get; set; }
        public int days { get; set; } // for non teaching only
        public float daysWorked { get; set; }
        public float daysAbsent { get; set; }
        public float tax { get; set; }
        public float philhealth { get; set; }
        public string month { get; set; }
    }
}
