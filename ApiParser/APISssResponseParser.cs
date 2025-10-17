using CSIEmployeeMonitoringSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSIEmployeeMonitoringSystem.ApiParser
{
    class APISssResponseParser
    {
        public string message { get; set; }
        public List<Sss> data { get; set; }
    }
}
