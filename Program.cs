using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SendScreenAway
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
            Application.Run();

            //if (args.Length > 0)
            //{ Application.Run(new Form1(args[0])); }
            //else
            //{ Application.Run(new Form1("")); }
            
        }
    }
}
