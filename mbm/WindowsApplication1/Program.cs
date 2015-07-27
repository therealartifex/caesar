using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsApplication1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            MessageBoxManager.OK = "Alright";
            MessageBoxManager.Cancel = "Noway";
            MessageBoxManager.Register();
            MessageBox.Show("This is a message...", "Test", MessageBoxButtons.OK);
            MessageBox.Show("This is a message...", "Test", MessageBoxButtons.OKCancel, MessageBoxIcon.Hand);
            new OpenFileDialog().ShowDialog();
            MessageBoxManager.Unregister();
        }
    }
}