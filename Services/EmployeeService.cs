using CSIEmployeeMonitoringSystem.ApiParser;
using CSIEmployeeMonitoringSystem.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSIEmployeeMonitoringSystem.Services
{
    class EmployeeService
    {
        public EmployeeService(string _apiKey, string _apiUrl)
        {
            apiKey = _apiKey;
            apiUrl = _apiUrl;
            client = new HttpClient();
            client.DefaultRequestHeaders.Add("x-api-key", apiKey);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private string apiKey { get; set; }
        private string apiUrl { get; set; }
        private HttpClient client { get; set; }
        public async Task<APIMessageParser> SaveEmployee(EmployeePost payload)
        {
            try
            {
                string jsonContent = JsonConvert.SerializeObject(payload);
                using (var content = new StringContent(jsonContent, UnicodeEncoding.UTF8, "application/json"))
                {
                    
                    HttpResponseMessage response = await client.PostAsync(apiUrl + "/employees", content);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    APIMessageParser res = JsonConvert.DeserializeObject<APIMessageParser>(responseBody);
                    return res;
                }
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}
