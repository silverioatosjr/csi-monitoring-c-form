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
    class TaxService: BaseClass
    {
        public TaxService(string _apiKey, string _apiUrl) : base(_apiKey, _apiUrl)
        {}

        public async Task<APITaxResponseParser> GetTaxList()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl + "/tax");
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
