using CSIEmployeeMonitoringSystem.ApiParser;
using CSIEmployeeMonitoringSystem.Models;
using IronXL;
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
        public async Task<APISchedulesParser> GetIntructorSchedules(string id)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl + $"/schedules/by-instructor/{id}");
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
        public async Task<APIMessageParser> PostSchedules(SchedulesPostData payload)
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
        public async Task<APIMessageParser> PostSchedule(SchedulePost payload)
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

        public async Task<APIMessageParser> UpdateSchedule(string id, SchedulePost payload)
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
        public List<SchedulesData> ParseSchedules(WorkSheet sheet)
        {
            List<SchedulesData> schedules = new List<SchedulesData>();
            try
            {
              foreach (var row in sheet.Rows.Skip(4))
                {
                    SchedulesData sched = new SchedulesData();
                    int counter = 0;
                    foreach (Cell cell in row)
                    {
                        if (counter == 0)
                            sched.subject = cell.Value.ToString();
                        else if (counter == 1)
                            sched.day = cell.Value.ToString();
                        else if (counter == 2)
                            sched.startTime = FormatTime(cell.Value.ToString());
                        else if (counter == 3)
                            sched.endTime = FormatTime(cell.Value.ToString());
                        else if (counter == 4)
                            sched.room = cell.Value.ToString();
                        counter++;
                    }
                    schedules.Add(sched);
                }
                

            }catch
            {

            }

            return schedules;
        }
        public string GetEmployeeCodeFromWorkSheet(WorkSheet sheet)
        {
            string code = sheet["B2"].Value.ToString();
            if(code.Length < 6)
                code = $"0{code}";
            return code;
        }
        public string ExcelValidator(WorkSheet sheet)
        {
            string errors = string.Empty;
            if (sheet["A4"].Value.ToString() != "Subject")
                errors = errors + "Error on A4: Subject Column header\n";
            if (sheet["B4"].Value.ToString() != "Day")
                errors = errors + "Error on B4: Day Column header\n";
            if (sheet["C4"].Value.ToString() != "Start Time")
                errors = errors + "Error on C4: Start Time Column header\n";
            if (sheet["D4"].Value.ToString() != "End Time")
                errors = errors + "Error on D4: End Time Column header\n";
            if (sheet["E4"].Value.ToString() != "Room")
                errors = errors + "Error on E4: Room Column header\n";
            if (sheet["B2"].Value.ToString() == string.Empty)
                errors = errors + "Error on B2: Instructor code is required\n";
            /**
             * 0-A CODE
             * 1-B SUBJECT
             * 2-C //DAY ["Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"]
             * 3-D START TIME "00:00"
             * 4-E END TIME "00:00"
             * 5-F ROOM
             * 6-G SEMESTER ["first", "second", "senior"]
             * 7-H SCHOOL YEAR
             * 8-I INSTRUCTOR ID FORMAT 63340dc711243bf8dbf56c39 LENGTH 24 excluded g-z
             */
            int rowCounter = 5;
            foreach (var row in sheet.Rows.Skip(4))
            {
                int counter = 0;
                foreach (Cell cell in row)
                {
                    if (counter == 0)
                    {
                        if (cell.Value.ToString() == string.Empty)
                        {
                            errors = errors + $"Error on row {rowCounter} - Subject: {cell.Value.ToString()}\n";
                        }
                    } else if (counter == 1)
                    {
                        if (cell.Value.ToString() == string.Empty)
                        {
                            errors = errors + $"Error on row {rowCounter} - Day: {cell.Value.ToString()}\n";
                        }
                    }
                    else if (counter == 2)
                    {
                        if (cell.Value.ToString() != string.Empty)
                            if (!IsValidTime(cell.Value.ToString()))
                            {
                                errors = errors + $"Error on row {rowCounter} - Start Time: {cell.Value.ToString()}\n";
                            }
                    } else if (counter == 3)
                    {
                        if (cell.Value.ToString() != string.Empty)
                            if (!IsValidTime(cell.Value.ToString()))
                            {
                                errors = errors + $"Error on row {rowCounter} - End Time: {cell.Value.ToString()}\n";
                            }
                    } else if(counter == 4)
                    {
                        if (cell.Value.ToString() == string.Empty)
                        {
                            errors = errors + $"Error on row {rowCounter} - Room: {cell.Value.ToString()}\n";
                        }
                    }
                    
                    counter++;
                }
                rowCounter++;

            }
            return errors;
        }

        private bool IsValidTime(string timeString)
        {
            DateTime result;
            return DateTime.TryParse(timeString, out result);
        }
        private bool IsValidDay(string day)
        {
            string[] days = {"Monday", "Tuesday","Wednesday","Thursday","Friday","Saturday","Sunday" };
            return days.Any(day.Contains);
        }

        private bool IsValidSemester(string semester)
        {
            string[] semesters = { "First", "Second", "Senior" };
            return semesters.Any(semester.Contains);
        }
        private bool IsValidMongoId(string id)
        {

            foreach (char c in id)
            {
                string validChars = "abcdefABCDEF0123456789 ";
                if (!validChars.Contains(c))
                {
                    return false; 
                }
            }
            return true;
        }
        private string FormatTime(string datetime)
        {
            string formattedTime = "";
            DateTime result;
            if (DateTime.TryParse(datetime, out result))
            {
                DateTime dt = DateTime.Parse(datetime);
                formattedTime = dt.ToString("HH:mm");
            }
            return formattedTime;
        }
    }
}
