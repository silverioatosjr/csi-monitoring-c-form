using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CSIEmployeeMonitoringSystem.Services
{
    class BaseClass
    {
        public BaseClass(string _apiKey, string _apiUrl, string _accessToken = null)
        {
            apiKey = _apiKey;
            apiUrl = _apiUrl;
            accessToken = _accessToken;
            client = new HttpClient();
            client.DefaultRequestHeaders.Add("x-api-key", apiKey);
            client.DefaultRequestHeaders.Add("authorization", $"Bearer {accessToken}");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public string apiKey { get; set; }
        public string apiUrl { get; set; }
        public string accessToken { get; set; }
        public HttpClient client { get; set; }
    }
}
