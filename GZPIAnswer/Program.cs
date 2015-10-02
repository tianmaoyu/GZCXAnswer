using System;
using System.Collections.Generic;
using System;
using System.Threading;
using System.Windows.Forms;

namespace GZPIAnswer
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        //[STAThread]
        [STAThreadAttribute]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new BrowserForm());
        }
    }
}
