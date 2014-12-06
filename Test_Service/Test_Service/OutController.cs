using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Net;
using System.Collections.Specialized;

namespace Test_Service
{
    class OutController
    {
       
        public static void WriteLog(String mss)
        {
            try
            {
                StreamWriter _WriteFile = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory+@"\Log.txt", true);
                _WriteFile.WriteLine(mss);
                _WriteFile.Close();
            }
            catch
            { 
            
            }
        }

        /// <summary>
        /// dang ky vao Event viewer
        /// </summary>
        /// <param name="Source_Name"></param>
        /// <returns></returns>
        public static Boolean WriteEventLog(String Source_Name)
        {
            try
            {
                WriteLog("Bat dau dang ky Event viewer");
                //Kiem tra Event Log da co name trung khong
                try 
                {
                    if (!EventLog.SourceExists(Source_Name))
                    {
                        EventLog.CreateEventSource(Source_Name, "Application");
                    }
                }
                catch 
                {
                    WriteLog("Khong the tao Event");
                    return false;
                }

                EventLog.WriteEntry(Source_Name, "Ung dung theo doi bat dau chay", EventLogEntryType.Information, 3112);
                return true;
            }
            catch
            {
                WriteLog("Khong the bat dau dang ky su kien");
                return false;
            }
        }
    }

    class  Remove
    {
        public static void RemoveFolder()
        {
            // Loai cac thu muc
            GetValue.OverLook.Add(Environment.SystemDirectory);
            GetValue.OverLook.Add(Environment.GetEnvironmentVariable("TEMP"));
            GetValue.OverLook.Add(Environment.GetFolderPath(Environment.SpecialFolder.System));
            GetValue.OverLook.Add(Environment.ExpandEnvironmentVariables("%SystemRoot%"));
            GetValue.OverLook.Add(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory));
            OutController.WriteLog("Nhung thu muc loai:");
            foreach (String l in GetValue.OverLook)
            {
                OutController.WriteLog(l);
            }

        }
    }
}


