using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DotNetEnv;

namespace CSIEmployeeMonitoringSystem
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Env.Load();
            string xApiKey = Environment.GetEnvironmentVariable("X_API_KEY");
            string serverUrl = Environment.GetEnvironmentVariable("SERVER_URL");
            MessageBox.Show(serverUrl);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}
