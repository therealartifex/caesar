using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CAESAR
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                var encryptFiles = File.ReadLines(args[0]).Where(line => line.Contains("e!")).Select(line => line.Substring(line.IndexOf('!') + 1));

                foreach (var f in encryptFiles)
                {
                    Console.Write($"Encrypting: {f}\n");
                }

            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frmCrypto());
            }
        }
    }
}
