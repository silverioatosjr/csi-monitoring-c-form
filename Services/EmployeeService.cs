using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSIEmployeeMonitoringSystem.Services
{
    class EmployeeService
    {
        public EmployeeService(string _apiKey, string _apiUrl)
        {
            apiKey = _apiKey;
            apiUrl = _apiUrl;
        }

        private string apiKey { get; set; }
        private string apiUrl { get; set; }
    }
}
