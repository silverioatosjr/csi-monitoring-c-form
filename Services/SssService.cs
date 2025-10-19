using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Net.Http;
using CSIEmployeeMonitoringSystem.ApiParser;

namespace CSIEmployeeMonitoringSystem.Services
{
    class SssService: BaseClass
    {
        public SssService(string _apiKey, string _apiUrl) : base(_apiKey, _apiUrl)
        {}

        public async Task<APISssResponseParser> GetSssList()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl + "/sss");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                APISssResponseParser res = JsonConvert.DeserializeObject<APISssResponseParser>(responseBody);
                return res;
            } catch
            {
                return null;
            }
            
        }   
    }
}
