using CSIEmployeeMonitoringSystem.ApiParser;
using CSIEmployeeMonitoringSystem.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CSIEmployeeMonitoringSystem.Services
{
    class ScheduleService: BaseClass
    {
        public ScheduleService(string _apiKey, string _apiUrl): base(_apiKey, _apiUrl) { }

        public async Task<APISchedulesParser> GetSchedules()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl + "/schedules");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                APISchedulesParser res = JsonConvert.DeserializeObject<APISchedulesParser>(responseBody);
                return res;
            }
            catch
            {
                return null;
            }
        }
        public async Task<APIScheduleParser> GetSchedule(string id)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl + $"/schedules/{id}");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                APIScheduleParser res = JsonConvert.DeserializeObject<APIScheduleParser>(responseBody);
                return res;
            }
            catch
            {
                return null;
            }
        }
        public async Task<APIMessageParser> PostSchedules(Schedules payload)
        {
            try
            {
                string jsonContent = JsonConvert.SerializeObject(payload);
                using (var content = new StringContent(jsonContent, UnicodeEncoding.UTF8, "application/json"))
                {

                    HttpResponseMessage response = await client.PostAsync(apiUrl + "/schedules/array-list", content);
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
        public async Task<APIMessageParser> PostSchedule(Schedule payload)
        {
            try
            {
                string jsonContent = JsonConvert.SerializeObject(payload);
                using (var content = new StringContent(jsonContent, UnicodeEncoding.UTF8, "application/json"))
                {

                    HttpResponseMessage response = await client.PostAsync(apiUrl + "/schedules", content);
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

        public async Task<APIMessageParser> UpdateSchedule(string id, Schedule payload)
        {
            try
            {
                string jsonContent = JsonConvert.SerializeObject(payload);
                using (var content = new StringContent(jsonContent, UnicodeEncoding.UTF8, "application/json"))
                {
                    
                    HttpResponseMessage response = await client.PutAsync(apiUrl + $"/schedules/{id}", content);
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

        public async Task<APIMessageParser> DeleteSchedules()
        {
            try
            {
                
                HttpResponseMessage response = await client.DeleteAsync(apiUrl + $"/schedules/all/schedules");
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
        public async Task<APIMessageParser> DeleteSchedule(string id)
        {
            try
            {

                HttpResponseMessage response = await client.DeleteAsync(apiUrl + $"/schedules/{id}");
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

        public async Task<APIMessageParser> DeleteSchedulesByInstructor(string id)
        {
            try
            {

                HttpResponseMessage response = await client.DeleteAsync(apiUrl + $"/schedules/by-instructor/{id}");
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
