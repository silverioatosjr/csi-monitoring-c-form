using CSIEmployeeMonitoringSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSIEmployeeMonitoringSystem.ApiParser
{
    class APIEmployeesGetParser
    {
        public string message { get; set; }
        public List<EmployeesGet> data { get; set; }
    }
}
