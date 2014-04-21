using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirMouse
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            bool runMinimized = false;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (args != null)
            {
               foreach(var str in args)
                {
                    var strToEval = str.Trim('-').ToLower();
                    if (strToEval == "minimized")
                    {
                        runMinimized = true;
                        break;
                    }
                 
                }
            }

            Application.Run(new Form1(runMinimized));
        }
    }
}
