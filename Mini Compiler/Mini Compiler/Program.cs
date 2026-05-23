using System;
using System.Windows.Forms;

namespace MiniCompiler
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // This will now find Form1 flawlessly since the namespaces match perfectly
            Application.Run(new Form1());
        }
    }
}