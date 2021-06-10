using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace GAinTSP
{
    class Program
    {
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Menu());
        }
    }
}
