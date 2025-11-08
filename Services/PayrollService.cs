using CSIEmployeeMonitoringSystem.ApiParser;
using CSIEmployeeMonitoringSystem.ApiParser.PayrollParser;
using CSIEmployeeMonitoringSystem.Models.Payroll;
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
    class PayrollService: BaseClass
    {
        public PayrollService(string _apiKey, string _apiUrl) : base(_apiKey, _apiUrl)
        { }

        public async Task<APIMessageParser> GeneratePayroll(GeneratePayroll payload)
        {
            try
            {
                string jsonContent = JsonConvert.SerializeObject(payload);
                using (var content = new StringContent(jsonContent, UnicodeEncoding.UTF8, "application/json"))
                {
                    HttpResponseMessage response = await client.PostAsync(apiUrl + $"/payroll/generate-payroll", content);
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

        public async Task<APIPayrollGetsParser> GetArchivedPayroll(ArchivePayroll payload)
        {
            try
            {
                string jsonContent = JsonConvert.SerializeObject(payload);
                using (var content = new StringContent(jsonContent, UnicodeEncoding.UTF8, "application/json"))
                {
                    HttpResponseMessage response = await client.PostAsync(apiUrl + $"/payroll/get-archived-payroll", content);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    APIPayrollGetsParser res = JsonConvert.DeserializeObject<APIPayrollGetsParser>(responseBody);
                    return res;
                }
            }
            catch
            {
                return null;
            }
        }

        public async Task<APIMessageParser> ArchiveCurrentPayroll()
        {
            try
            {
                HttpResponseMessage response = await client.PostAsync(apiUrl + $"/payroll/archive-current-payroll", null);
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

        public async Task<APIMessageParser> UpdatePayroll(string id, PayrollUpdate payload)
        {
            try
            {
                string jsonContent = JsonConvert.SerializeObject(payload);
                using (var content = new StringContent(jsonContent, UnicodeEncoding.UTF8, "application/json"))
                {
                    HttpResponseMessage response = await client.PutAsync(apiUrl + $"/payroll/{id}", content);
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
        public async Task<APIPayrollGetsParser> GetCurrentPayrolls()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl + $"/payroll");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                APIPayrollGetsParser res = JsonConvert.DeserializeObject<APIPayrollGetsParser>(responseBody);
                return res;
            }
            catch(Exception e)
            {
                return null;
            }
        }
        public async Task<APIPayrollGetParser> GetPayroll(string id)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl + $"/payroll/{id}");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                APIPayrollGetParser res = JsonConvert.DeserializeObject<APIPayrollGetParser>(responseBody);
                return res;
            }
            catch
            {
                return null;
            }
        }

        public async Task<APIMessageParser> DeletePayroll(string id)
        {
            try
            {
                HttpResponseMessage response = await client.DeleteAsync(apiUrl + $"/payroll/{id}");
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
        public async Task<APIMessageParser> DeleteCureentPayroll()
        {
            try
            {
                HttpResponseMessage response = await client.DeleteAsync(apiUrl + $"/payroll/delete/current-payroll");
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
