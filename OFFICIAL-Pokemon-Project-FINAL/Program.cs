using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OFFICIAL_Pokemon_Project_FINAL
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

            /// PART WRITTEN BY US
            var myStartScreen = new Start_Screen(); // Creates new variable for a Start_Screen() instance
            myStartScreen.Show(); // Shows the newly created instance
            Application.Run(); // Runs the Application.
        }
    }
}
