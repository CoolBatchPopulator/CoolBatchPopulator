﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CoolBatchPopulator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Evandro este aqui
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmCoolBatchPopulator());
        }
    }
}
