using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PartsIffTool
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
            Application.Run(new StartupWindow());
            //Application.Run(new IffDoctor());
        }
    }
}
