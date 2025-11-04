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
        public List<SchedulePost> ParseSchedules(WorkSheet sheet)
        {
            List<SchedulePost> schedules = new List<SchedulePost>();
            try
            {
              foreach (var row in sheet.Rows.Skip(1))
                {
                    SchedulePost sched = new SchedulePost();
                    int counter = 0;
                    foreach (Cell cell in row)
                    {
                        if (counter == 0)
                            sched.subjectCode = cell.Value.ToString();
                        else if (counter == 1)
                            sched.subject = cell.Value.ToString();
                        else if (counter == 2)
                            sched.course = cell.Value.ToString();
                        else if (counter == 3)
                            sched.day = cell.Value.ToString();
                        else if (counter == 4)
                            sched.startTime = FormatTime(cell.Value.ToString());
                        else if (counter == 5)
                            sched.endTime = FormatTime(cell.Value.ToString());
                        else if (counter == 6)
                            sched.room = cell.Value.ToString();
                        else if (counter == 7)
                            sched.semester = cell.Value.ToString();
                        else if (counter == 8)
                            sched.schoolYear = cell.Value.ToString();
                        else if (counter == 9)
                            sched.instructor = cell.Value.ToString();
                        counter++;
                    }
                    schedules.Add(sched);
                }
                

            }catch
            {

            }

            return schedules;
        }
        public string ExcelValidator(WorkSheet sheet)
        {
            string errors = string.Empty;
            if (sheet["A1"].Value.ToString() != "Code")
                errors = errors + "Error on A1: Code Column header\n";
            if (sheet["B1"].Value.ToString() != "Subject")
                errors = errors + "Error on B1: Subject Column header\n";
            if (sheet["C1"].Value.ToString() != "Course")
                errors = errors + "Error on C1: Course Column header\n";
            if (sheet["D1"].Value.ToString() != "Day")
                errors = errors + "Error on D1: Day Column header\n";
            if (sheet["E1"].Value.ToString() != "Start Time")
                errors = errors + "Error on E1: Start Time Column header\n";
            if (sheet["F1"].Value.ToString() != "End Time")
                errors = errors + "Error on F1: End Time Column header\n";
            if (sheet["G1"].Value.ToString() != "Room")
                errors = errors + "Error on G1: Room Column header\n";
            if (sheet["H1"].Value.ToString() != "Semester")
                errors = errors + "Error on H1: Semester Column header\n";
            if (sheet["I1"].Value.ToString() != "School Year")
                errors = errors + "Error on I1: School Year Column header\n";
            if (sheet["J1"].Value.ToString() != "Instructor Id")
                errors = errors + "Error on J1: Instructor Id Column header\n";
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
            int rowCounter = 2;
            foreach (var row in sheet.Rows.Skip(1))
            {
                int counter = 0;
                foreach (Cell cell in row)
                {
                    if (counter == 0)
                    {
                        if (cell.Value.ToString() == string.Empty)
                        {
                            errors = errors + $"Error on row {rowCounter} - Code: {cell.Value.ToString()}\n";
                        }
                    } else if (counter == 1)
                    {
                        if (cell.Value.ToString() == string.Empty)
                        {
                            errors = errors + $"Error on row {rowCounter} - Subject: {cell.Value.ToString()}\n";
                        }
                    }
                    else if (counter == 2)
                    {
                        if (cell.Value.ToString() == string.Empty)
                        {
                            errors = errors + $"Error on row {rowCounter} - Course: {cell.Value.ToString()}\n";
                        }
                    } else if (counter == 3)
                    {
                        if (!IsValidDay(cell.Value.ToString()))
                        {
                            errors = errors + $"Error on row {rowCounter} - Day: {cell.Value.ToString()}\n";
                        }
                    } else if(counter == 4)
                    {
                        if (cell.Value.ToString() != string.Empty)
                            if(!IsValidTime(cell.Value.ToString())) {
                                errors = errors + $"Error on row {rowCounter} - Start Time: {cell.Value.ToString()}\n";
                            }
                    }
                    else if(counter == 5)
                    {
                        if(cell.Value.ToString() != string.Empty)
                            if (!IsValidTime(cell.Value.ToString()))
                            {
                                errors = errors + $"Error on row {rowCounter} - End Time: {cell.Value.ToString()}\n";
                            }
                    }
                    else if (counter == 6)
                    {
                        if (cell.Value.ToString() == string.Empty)
                        {
                            errors = errors + $"Error on row {rowCounter} - Room: {cell.Value.ToString()}\n";
                        }
                    }
                    else if (counter == 7)
                    {
                        if (!IsValidSemester(cell.Value.ToString()) || cell.Value.ToString() == string.Empty)
                        {
                            errors = errors + $"Error on row {rowCounter} - Semester: {cell.Value.ToString()}\n";
                        }
                    }
                    else if (counter == 8)
                    {
                        if (cell.Value.ToString() == string.Empty)
                        {
                            errors = errors + $"Error on row {rowCounter} - School Year: {cell.Value.ToString()}\n";
                        }
                    } else if (counter == 9)
                    {
                        if (!IsValidMongoId(cell.Value.ToString()) || cell.Value.ToString() == string.Empty)
                        {
                            errors = errors + $"Error on row {rowCounter} - Instructor Id: {cell.Value.ToString()}\n";
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
            string[] semesters = { "first", "second", "senior" };
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
