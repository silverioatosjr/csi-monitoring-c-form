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
    class SssService
    {
        public SssService(string _apiKey, string _apiUrl)
        {
            apiKey = _apiKey;
            apiUrl = _apiUrl;
        }

        private string apiKey { get; set; }
        private string apiUrl { get; set; }
        public async Task<APISssResponseParser> GetSssList()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add("x-api-key",apiKey);
                string contentType = "application/json";
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(contentType));
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
