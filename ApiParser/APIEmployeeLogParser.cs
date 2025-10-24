using CSIEmployeeMonitoringSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSIEmployeeMonitoringSystem.ApiParser
{
    class APIEmployeeLogParser
    {
        public string message { get; set; }
        public bool isAllowed { get; set; }
        public Employee data { get; set; }
    }
}
