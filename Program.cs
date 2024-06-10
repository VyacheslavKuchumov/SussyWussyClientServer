using NEfotobudka_githubik.admin;
using NEfotobudka_githubik.ceo;
using NEfotobudka_githubik.verra_ceo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEfotobudka_githubik
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
            Application.Run(new Vhod());
        }
    }
}
