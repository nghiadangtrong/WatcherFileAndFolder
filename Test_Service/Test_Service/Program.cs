using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.IO;

namespace Test_Service
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
#if DEBUG
            //new InputControl(@"C:\Users\NGHIA-DANG-TRONG\Documents\Visual Studio 2010\Projects\Test_Service\Test_Service\Config.xml");
            StreamWriter write_file = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + @"\log.txt", true);
            write_file.WriteLine("User: " + Environment.UserName);
            write_file.WriteLine("UserDomainName: " + Environment.UserDomainName);
            write_file.Close();
#else
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
			{ 
				new Service1() 
			};
            ServiceBase.Run(ServicesToRun);
#endif
        }
    }
}
