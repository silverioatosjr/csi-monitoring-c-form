using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSIEmployeeMonitoringSystem.Models
{
    class SchedulePost
    {
        public string subject { get; set; }
        public string subjectCode { get; set; }
        public string instructor { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }
        public string room { get; set; }
        public string day { get; set; }
        public string schoolYear { get; set; }
        public string semester { get; set; }
    }
}
