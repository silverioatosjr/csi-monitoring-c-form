using CSIEmployeeMonitoringSystem.Models.Payroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSIEmployeeMonitoringSystem.ApiParser.PayrollParser
{
    class APIPayrollGetsParser
    {
        public string message { get; set; }
        public List<PayrollData> data { get; set; }
    }
}
