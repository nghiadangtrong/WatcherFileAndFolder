using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Threading;
using System.Diagnostics;

namespace Test_Service
{
    class InputControl
    {
        ///System.Security.Principal.WindowsIdentity.GetCurrent().Name
        ///Doc file cau hinh
        ////

        public InputControl(String Config_File)
        {
            if (!InitReadFileConfig(Config_File))
            {
                throw new System.ArgumentException("Chua khoi tao xong EventMonitoring");  
            }
        }
        /// <summary>
        /// Doc va hien thi ten nguoi dung
        /// </summary>
        /// <param name="Config_file"></param>
        /// <returns></returns>
        public static Boolean InitReadFileConfig(String Config_file)
        {
            try
            {
                if (!File.Exists(Config_file))
                {
                    OutController.WriteLog("File Congfig Khong ton tai!");
                    return false;
                }
                OutController.WriteLog("File Config ton tai");
            
                XmlDocument xmlFile = new XmlDocument();
                xmlFile.Load(Config_file);

                // Bat dau doc file cau hinh 
                XmlNode xml_node = xmlFile.DocumentElement.SelectSingleNode("descendant::OUT/EVENTLOG");
                String Source_Name;
                if ((xml_node != null))
                {
                    Source_Name = xml_node.InnerText.Trim();
                    if (Source_Name.Length <= 0)
                    {
                        Source_Name = "ung Dung theo deo 002";
                    }
                    if (!OutController.WriteEventLog(Source_Name))
                    {
                        return false;
                    }
                    OutController.WriteLog("Dang ky thanh cong");
                    // Loai cac thu muc
                    Remove.RemoveFolder();

                    ScanDisk s = new ScanDisk();
                    s.OnDiskHander += new ScanDisk.DiskEventHandler(Getdisk);
                    s.Run(true);/*
                    new WatchFile(@"D:\");
                    new WatchFile(@"E:\");
                    new WatchFile(@"F:\");*/
                    OutController.WriteLog("Bat dau theo doi cac o dia(4)");
                    
                    return true;
                }
                    
                   /* String path1 = (Environment.GetFolderPath(Environment.SpecialFolder.UserProfile));
                    String User = Environment.UserName;
                    OutController.WriteLog(Environment.UserName+"\n" + Environment.SystemDirectory + "\n" + path1);*/

               
               
                return true;
            }catch
            {
                return false;
            }
        }

        public static void Getdisk(object o, DiskEventArgs e)
        {
            try
            {
                // Xoa list chua bien theo doi
                GetValue._GetWatcherNumber.Clear();

                for (int i = 0; i < e.index; i++)
                {
                    try
                    {
                        /*if (e.disk[i].Name == "C:\\")
                        {
                            continue;
                        }*/
                        // Tao va them Bien theo doi vao list bien theo doi
                        GetValue._GetWatcherNumber.Add(new WatchFile(@e.disk[i].Name));
                        OutController.WriteLog("Theo doi folder: " + e.disk[i].Name);
                    }
                    catch (System.Exception ex)
                    {
                        // Bo qua o disk khong hop le
                        continue;
                    }

                }
            }
            catch (System.Exception ex)
            {
                OutController.WriteLog("Loi khi duyet o dia!");
            }
        }
    }


    /*class WatcherFile
    {
        private FileSystemWatcher _watcherfile;
        private String Source_Name;
        public WatcherFile(String path, String Source)
        {
            _watcherfile = new FileSystemWatcher(@path);
            this.Source_Name = Source;
            _watcherfile.Created += new FileSystemEventHandler(WatchCreating);
            _watcherfile.EnableRaisingEvents = true;
        }

        protected void WatchCreating(object ob, FileSystemEventArgs e)
        {
            EventLog.WriteEntry(Source_Name, Environment.UserName, EventLogEntryType.Information, 3112);
            String time = System.DateTime.Now.ToString();
            OutController.WriteLog(String.Format("Time:" + time + "\nFile {0}, User: {1}: Path {2}, Name {3}", e.ChangeType, GetUserName.Name(), e.FullPath, e.Name));
        }
    }*/
}
