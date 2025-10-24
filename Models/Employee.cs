using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSIEmployeeMonitoringSystem.Models
{
    class Employee
    {
        public string code { get; set; }
        public string _id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string employmentStatus { get; set; }
        public string biometric { get; set; }
        public string designation { get; set; }
        public float hourlyRate { get; set; }
        public float basicSalary { get; set; }
    }
}
