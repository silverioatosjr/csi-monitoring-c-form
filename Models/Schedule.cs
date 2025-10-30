using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSIEmployeeMonitoringSystem.Models
{
    class Schedule
    {
        public string _id { get; set; }
        public string subject { get; set; }
        public string subjectCode { get; set; }
        public Instructor instructor { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }
        public string room { get; set; }
        public string day { get; set; }
        public float unit { get; set; }
        public string schoolYear { get; set; }
        public string semester {get; set; }
    }
}
