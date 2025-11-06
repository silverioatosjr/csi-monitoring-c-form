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

        public async Task<APIDtrsParser> GetDtrs(DtrGetDateRange payload)
        {
            try
            {
                string jsonContent = JsonConvert.SerializeObject(payload);
                using (var content = new StringContent(jsonContent, UnicodeEncoding.UTF8, "application/json"))
                {

                    HttpResponseMessage response = await client.PostAsync(apiUrl + $"/dtrs/all", content);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    APIDtrsParser res = JsonConvert.DeserializeObject<APIDtrsParser>(responseBody);
                    return res;
                }
            }
            catch
            {
                return null;
            }
        }

        public async Task<APIDtrsParser> GetEmployeeDtrs(DtrGetWithEmployee payload)
        {
            try
            {
                string jsonContent = JsonConvert.SerializeObject(payload);
                using (var content = new StringContent(jsonContent, UnicodeEncoding.UTF8, "application/json"))
                {

                    HttpResponseMessage response = await client.PostAsync(apiUrl + $"/dtrs/employee", content);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    APIDtrsParser res = JsonConvert.DeserializeObject<APIDtrsParser>(responseBody);
                    return res;
                }
            }
            catch
            {
                return null;
            }
        }

        public async Task<APIDtrParser> GetDtr(string id)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl + $"/dtrs/{id}");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                APIDtrParser res = JsonConvert.DeserializeObject<APIDtrParser>(responseBody);
                return res;
            }
            catch
            {
                return null;
            }
        }

        public async Task<APIMessageParser> UpdateDtr(string id, DtrUpdate payload)
        {
            try
            {
                string jsonContent = JsonConvert.SerializeObject(payload);
                using (var content = new StringContent(jsonContent, UnicodeEncoding.UTF8, "application/json"))
                {

                    HttpResponseMessage response = await client.PutAsync(apiUrl + $"/dtrs/{id}", content);
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

        public async Task<APIMessageParser> DeleteDtr(string id)
        {
            try
            {
                HttpResponseMessage response = await client.DeleteAsync(apiUrl + $"/dtrs/{id}");
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

        public async Task<APIMessageParser> ArchivedAllActiveDtrs()
        {
            try
            {
                HttpResponseMessage response = await client.PostAsync(apiUrl + $"/dtrs/archive-active-dtrs", null);
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
