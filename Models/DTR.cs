using CSIEmployeeMonitoringSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSIEmployeeMonitoringSystem.Models
{
    class DTR
    {
        public string _id { get; set; }
        public Employee employee { get; set; }
        public string subjectCode { get; set; }
        public string timeIn { get; set; }
        public string timeOut { get; set; }
        public float hoursRendered { get; set; }
        public string date { get; set; }
        public string day { get; set; }
    }
}
