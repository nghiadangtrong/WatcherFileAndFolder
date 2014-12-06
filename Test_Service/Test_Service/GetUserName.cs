using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Test_Service
{
    class GetUserName
    {
        public static String UserName;
        public static String Name()
        {
            try
            {

                UserName = null;
                EventLog myLog = new EventLog();
                myLog.Log = "Security";
                myLog.Source = "Microsoft Windows security auditing";
             
                for (int i = myLog.Entries.Count; i >= 0; i--)
                {

                    if (myLog.Entries[i - 1].EventID == 4648)
                    {
                        
                        //Console.WriteLine("\t eime: " + myLog.Entries[i-1].TimeWritten);
                        return myLog.Entries[i - 1].ReplacementStrings[5];
                    }
                }
                return null;

            }
            catch (System.SystemException e)
            {
                //Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
