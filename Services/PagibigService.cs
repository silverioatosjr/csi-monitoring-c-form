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
    class PagibigService: BaseClass
    {
        public PagibigService(string _apiKey, string _apiUrl) : base(_apiKey, _apiUrl)
        {}

        public async Task<APIPagibigResponseParser> GetPagibigList()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl + "/pagibig");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                APIPagibigResponseParser res = JsonConvert.DeserializeObject<APIPagibigResponseParser>(responseBody);
                return res;
            }
            catch
            {
                return null;
            }

        }
    }
}
