using CSIEmployeeMonitoringSystem.ApiParser;
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
    class InstructorService:BaseClass
    {
        public InstructorService(string _apiKey, string _apiUrl):base(_apiKey, _apiUrl)
        {}

        public async Task<APIEmployeesGetParser> GetInstructors()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl + "/instructors");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                APIEmployeesGetParser res = JsonConvert.DeserializeObject<APIEmployeesGetParser>(responseBody);
                return res;
            }
            catch(Exception e)
            {
                return null;
            }
        }

        public async Task<APIEmployeesGetParser> GetCollegeInstructors()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl + "/instructors/college");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                APIEmployeesGetParser res = JsonConvert.DeserializeObject<APIEmployeesGetParser>(responseBody);
                return res;
            }
            catch
            {
                return null;
            }
        }

        public async Task<APIEmployeesGetParser> GetSeniorHighInstructors()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl + "/instructors/senior-high");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                APIEmployeesGetParser res = JsonConvert.DeserializeObject<APIEmployeesGetParser>(responseBody);
                return res;
            }
            catch
            {
                return null;
            }
        }
    }
}
