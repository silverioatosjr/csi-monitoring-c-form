using CSIEmployeeMonitoringSystem.ApiParser;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CSIEmployeeMonitoringSystem.Services
{
    class PhilhealthService: BaseClass
    {
        public PhilhealthService(string _apiKey, string _apiUrl) : base(_apiKey, _apiUrl)
        {}

        public async Task<APIPhilhealthResponseParser> GetPhilhealthList()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl + "/philhealth");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                APIPhilhealthResponseParser res = JsonConvert.DeserializeObject<APIPhilhealthResponseParser>(responseBody);
                return res;
            }
            catch
            {
                return null;
            }

        }
    }
}
