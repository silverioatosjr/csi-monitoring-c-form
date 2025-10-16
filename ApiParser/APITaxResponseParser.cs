using CSIEmployeeMonitoringSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSIEmployeeMonitoringSystem.ApiParser
{
    class APITaxResponseParser
    {
        public string message { get; set; }
        public List<TaxData> data { get; set; }
    }
}
