using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DotNetEnv;
using CSIEmployeeMonitoringSystem.Forms.Dtr;

namespace CSIEmployeeMonitoringSystem
{
    static class Program
    {
        public static string xApiKey = "";
        public static string serverUrl = "";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Env.TraversePath().Load();
            xApiKey = "x2TUlfsc09tGoetyBo4p8HT3zi";//Environment.GetEnvironmentVariable("X_API_KEY");
            serverUrl = "http://localhost:3004/api";//Environment.GetEnvironmentVariable("SERVER_URL");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmDTR()); //frmMain()
        }
    }
}
