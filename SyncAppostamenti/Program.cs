using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SyncAppostamenti
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = true;
            Application.Run(new Form1());
        }
    }
}
