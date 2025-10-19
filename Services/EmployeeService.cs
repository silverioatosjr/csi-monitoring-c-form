using CSIEmployeeMonitoringSystem.ApiParser;
using CSIEmployeeMonitoringSystem.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSIEmployeeMonitoringSystem.Services
{
    class EmployeeService: BaseClass
    {
        public EmployeeService(string _apiKey, string _apiUrl) : base(_apiKey, _apiUrl)
        {}

        public async Task<APIMessageParser> SaveEmployee(EmployeePost payload)
        {
            try
            {
                string jsonContent = JsonConvert.SerializeObject(payload);
                using (var content = new StringContent(jsonContent, UnicodeEncoding.UTF8, "application/json"))
                {
                    
                    HttpResponseMessage response = await client.PostAsync(apiUrl + "/employees", content);
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

        public async Task<APIEmployeesGetParser> GetEmployeesList()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl + "/employees");
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

        public string formatDgvTaxCellValue(DeductionList deduction)
        {
            string value = "";
            if (null != deduction)
            {
                if (null != deduction.tax)
                {
                    return deduction.tax.monthlySalary.baseAmount.ToString();
                }
            }

            return value;
        }

        public string formatDgvPagibigCellValue(DeductionList deduction)
        {
            string value = "";
            if (null != deduction)
            {
                if (null != deduction.pagibig)
                {
                    return deduction.pagibig.amount.ToString();
                }
            }

            return value;
        }
        public string formatDgvPhilhealthCellValue(DeductionList deduction)
        {
            string value = "";
            if (null != deduction)
            {
                if (null != deduction.philhealth)
                {
                    return deduction.philhealth.percent.ToString();
                }
            }

            return value;
        }

        public string formatDgvSssCellValue(DeductionList deduction)
        {
            string value = "";
            if (null != deduction)
            {
                if (null != deduction.sss)
                {
                    return deduction.sss.amount.ToString();
                }
            }

            return value;
        }
    }
}
