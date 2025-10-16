using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSIEmployeeMonitoringSystem.Models
{
    class TaxData
    {
        public string _id { get; set; }
        public string bracket { get; set; }
        public TaxSalary semiMonthlySalary { get; set; }
        public TaxSalary monthlySalary { get; set; }
    }
}

