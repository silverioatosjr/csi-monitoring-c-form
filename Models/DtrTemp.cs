using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSIEmployeeMonitoringSystem.Models
{
    class DtrTemp
    {
        public string _id { get; set; }
        public string time { get; set; }
        public Employee employee { get; set; }
        public Schedule schedule { get; set; } 
    }
}
