using CSIEmployeeMonitoringSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSIEmployeeMonitoringSystem.ApiParser
{
    class APIEmployeesWithBiometricsParser
    {
        public string message { get; set; }
        public List<Employee> data { get; set; }
    }
}
