using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;

namespace Converter
{
    static class Program
    {
        //public static bool Looping = true;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main_Form());

            /*while (Looping)
            {
                if (!Loader.C)
                {
                    //Loader.CC();
                    Loader.CT();
                    Thread.Sleep(1000);
                }
            }*/
        }
    }
}
