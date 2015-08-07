using System;
using System.Globalization;
using System.Windows.Forms;

namespace CAESAR
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
            Application.Run(new frmCrypto());
        }
    }
}
