using CSIEmployeeMonitoringSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSIEmployeeMonitoringSystem.ApiParser
{
    class APIPagibigResponseParser
    {
        public string message { get; set; }
        public List<Pagibig> data { get; set; }
    }
}
