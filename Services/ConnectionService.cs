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
    class ConnectionService
    {
        public ConnectionService(string _apiUrl)
        {
            apiUrl = _apiUrl;
        }

        private string apiUrl { get; set; }
        public async Task<APIMessageParser> APIConnection()
        {
            try
            {
                HttpClient client = new HttpClient();
                string contentType = "application/json";
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(contentType));
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                APIMessageParser res = JsonConvert.DeserializeObject<APIMessageParser>(responseBody);
                return res;
            }
            catch
            {
                return null;
            }

        }
    }
}

