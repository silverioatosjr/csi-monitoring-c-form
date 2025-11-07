using CSIEmployeeMonitoringSystem.Models.Payroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSIEmployeeMonitoringSystem.ApiParser.PayrollParser
{
    class APIPayrollGetParser
    {
        public string message { get; set; }
        public PayrollData data { get; set; }
    }
}
