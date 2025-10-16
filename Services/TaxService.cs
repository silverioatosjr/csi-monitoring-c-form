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
    class TaxService
    {
        public TaxService(string _apiKey, string _apiUrl)
        {
            apiKey = _apiKey;
            apiUrl = _apiUrl;
        }

        private string apiKey { get; set; }
        private string apiUrl { get; set; }
        public async Task<APITaxResponseParser> GetSssList()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add("x-api-key", apiKey);
                string contentType = "application/json";
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(contentType));
                HttpResponseMessage response = await client.GetAsync(apiUrl + "/sss");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                APITaxResponseParser res = JsonConvert.DeserializeObject<APITaxResponseParser>(responseBody);
                return res;
            }
            catch
            {
                return null;
            }

        }
    }
}
