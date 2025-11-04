using CSIEmployeeMonitoringSystem.ApiParser;
using CSIEmployeeMonitoringSystem.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSIEmployeeMonitoringSystem.Services
{
    class DtrService:BaseClass
    {
        public DtrService(string _apiKey, string _apiUrl) : base(_apiKey, _apiUrl)
        { }

        public async Task<APIMessageParser> SaveDtr(DTRVerfication payload)
        {
            try
            {
                string jsonContent = JsonConvert.SerializeObject(payload);
                using (var content = new StringContent(jsonContent, UnicodeEncoding.UTF8, "application/json"))
                {

                    HttpResponseMessage response = await client.PostAsync(apiUrl + $"/dtrs", content);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    APIMessageParser res = JsonConvert.DeserializeObject<APIMessageParser>(responseBody);
                    return res;
                }
            }
            catch
            {
                return null;
            }
        }
        public async Task<APIDtrTempParser> GetDtrTempList()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl + "/dtrs/active/in");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                APIDtrTempParser res = JsonConvert.DeserializeObject<APIDtrTempParser>(responseBody);
                return res;
            }
            catch
            {
                //MessageBox.Show(err.Message);
                return null;
            }

        }
    }
}
