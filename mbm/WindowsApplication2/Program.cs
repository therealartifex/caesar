using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsApplication2
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

            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("ro");


            //Set button text from resources
            MessageBoxManager.OK = LocalResource.OK;
            MessageBoxManager.Cancel = LocalResource.Cancel;
            MessageBoxManager.Retry = LocalResource.Retry;
            MessageBoxManager.Ignore = LocalResource.Ignore;
            MessageBoxManager.Abort = LocalResource.Abort;
            MessageBoxManager.Yes = LocalResource.Yes;
            MessageBoxManager.No = LocalResource.No;

            //Register manager
            MessageBoxManager.Register();


            Application.Run(new Form1());

        }
    }
}