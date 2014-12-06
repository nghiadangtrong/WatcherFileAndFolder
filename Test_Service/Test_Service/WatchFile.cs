using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace Test_Service
{
    class WatchFile
    {
        private String UserName;
        private FileSystemWatcher _watchFile;
        private string _connectString = @"Data Source=NGHIA-DANG-TRON\SQLEXPRESS;Initial Catalog=DatabaseWatchFile;Integrated Security=True";
        public WatchFile(string path)
        {

            _watchFile = new FileSystemWatcher(path, "*.*");

            _watchFile.Created += new FileSystemEventHandler(WatchCreate);
            _watchFile.Deleted += new FileSystemEventHandler(WatchDelete);
            _watchFile.Changed += new FileSystemEventHandler(WatchChanger);
            _watchFile.Renamed += new RenamedEventHandler(WatchRename);

            _watchFile.NotifyFilter = NotifyFilters.FileName
                                    | NotifyFilters.CreationTime
                                    | NotifyFilters.DirectoryName
                                    | NotifyFilters.LastAccess
                                    | NotifyFilters.LastWrite
                                    | NotifyFilters.Size;

            _watchFile.IncludeSubdirectories = true;
            _watchFile.EnableRaisingEvents = true;
        }

        protected void WatchCreate(object o, FileSystemEventArgs e)
        {
            try
            {
                String path = Path.GetDirectoryName(e.FullPath);

             
                foreach (String st in GetValue.OverLook)
                {
                    if (st == path)
                    {
                        return;
                    }
                }
                this.UserName = GetUserName.Name();
                OutController.WriteLog(String.Format("File {0}, User: {1}: Path {2}, Name {3}", e.ChangeType, GetUserName.Name(), path, e.Name));
                if (SaveOnDatabase.InitDatabase(_connectString))
                {
                    SaveOnDatabase.Save(System.DateTime.Now, e.ChangeType.ToString(), e.FullPath, this.UserName);
                }
                else 
                {
                    StreamWriter tmp = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "tmp.txt");
                    tmp.WriteLine("Khong the ket noi data");
                    tmp.Close();
                }
            }
            catch
            {
            
            }
        }

        protected void WatchDelete(object o, FileSystemEventArgs e)
        {
            try
            {
                String path = Path.GetDirectoryName(e.FullPath);


                foreach (String st in GetValue.OverLook)
                {
                    if (st == path)
                    {
                        return;
                    }
                }

                this.UserName = GetUserName.Name();
                OutController.WriteLog(String.Format("File {0}, User: {1}: Path {2}, Name {3}", e.ChangeType, GetUserName.Name(), path, e.Name));

                if (SaveOnDatabase.InitDatabase(_connectString))
                {
                    SaveOnDatabase.Save(System.DateTime.Now, e.ChangeType.ToString(), e.FullPath, this.UserName);
                }
                else
                {
                    StreamWriter tmp = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "tmp.txt");
                    tmp.WriteLine("Khong the ket noi data");
                    tmp.Close();
                }
            }
            catch
            { 
            
            }
        }

        protected void WatchChanger(object o, FileSystemEventArgs e)
        {
            try
            {
                String path = Path.GetDirectoryName(e.FullPath);


                foreach (String st in GetValue.OverLook)
                {
                    if (st == path)
                    {
                        return;
                    }
                }

                this.UserName = GetUserName.Name();
                OutController.WriteLog(String.Format("File {0}, User: {1}: Path {2}, Name {3}", e.ChangeType, GetUserName.Name(), path, e.Name));
                if (SaveOnDatabase.InitDatabase(_connectString))
                {
                    SaveOnDatabase.Save(System.DateTime.Now, e.ChangeType.ToString(), e.FullPath, this.UserName);
                }
                else
                {
                    StreamWriter tmp = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "tmp.txt");
                    tmp.WriteLine("Khong the ket noi data");
                    tmp.Close();
                }
            }
            catch
            {

            }
        }

        protected void WatchRename(object o, FileSystemEventArgs e)
        {
            try
            {
                String path = Path.GetDirectoryName(e.FullPath);


                foreach (String st in GetValue.OverLook)
                {
                    if (st == path)
                    {
                        return;
                    }
                }

                this.UserName = GetUserName.Name();
                OutController.WriteLog(String.Format("File {0}, User: {1}: Path {2}, Name {3}", e.ChangeType, GetUserName.Name(), path, e.Name));
                if (SaveOnDatabase.InitDatabase(_connectString))
                {
                    SaveOnDatabase.Save(System.DateTime.Now, e.ChangeType.ToString(), e.FullPath, this.UserName);
                }
                else
                {
                    StreamWriter tmp = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "tmp.txt");
                    tmp.WriteLine("Khong the ket noi data");
                    tmp.Close();
                }
            }
            catch 
            {
            
            }
        }
    }
}
