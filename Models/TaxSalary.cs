using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSIEmployeeMonitoringSystem.Models
{
    class TaxSalary
    {
        public float maxLimit { get; set; }
        public float minLimit { get; set; }
        public float baseAmount { get; set; }
        public float percent { get; set; }
    }
}
