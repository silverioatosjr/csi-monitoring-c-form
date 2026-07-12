using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSIEmployeeMonitoringSystem.Models
{
    class AddDTRTeaching
    {
       public string instructor { get; set; }
        public string scheduleId { get; set; }
        public float hour { get; set; }
        public DateTime date { get; set; }
    }
}
