using NP.UI.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

//class Program
//{
//    static void Main(string[] args)
//    {
//        var server = new SimpleWebSocketServer();
//        server.Start(5050);

//        Console.WriteLine("Press ENTER to exit...");
//        Console.ReadLine();
//    }
//}

namespace NP.Host
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        [STAThread]
        static void Main()
        {
            ServicePointManager.SecurityProtocol =
                SecurityProtocolType.Tls12;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }


        //[STAThread]
        //static void Main()
        //{
        //    Application.EnableVisualStyles();
        //    Application.SetCompatibleTextRenderingDefault(false);
        //    Application.Run(new ChatStudioForm());
        //}
    }
}
