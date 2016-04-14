using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace CAESAR
{
    internal static class Program
    {
        [DllImport("kernel32.dll")]
        private static extern bool AttachConsole(int dwProcessId);

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                AttachConsole(-1);

                var encryptFiles = File.ReadLines(args[0]).Where(line => line.Contains("e!")).Select(line => line.Substring(line.IndexOf('!') + 1));
                var decryptFiles = File.ReadLines(args[0]).Where(line => line.Contains("d!")).Select(line => line.Substring(line.IndexOf('!') + 1));

                foreach (var f in encryptFiles) Console.Write($"Encrypting: {f}\n");
                foreach (var f in decryptFiles) Console.Write($"Decrypting: {f}\n");
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
