using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Test_Service
{
    class ScanDisk
    {
        public delegate void DiskEventHandler(object o, DiskEventArgs e);

        // Tao bien event thong bao su kien thay doi o dia
        public event DiskEventHandler OnDiskHander;

        public Boolean state;
        // So disk 
        private int diskNumber = 0;
        
        public ScanDisk() 
        {
            this.state = false; 
        }
        public void Run(bool _value)
        {
            
            while (this.state == false)
            {
                // Lay thong tin o dia hien tai
                DriveInfo[] disk = System.IO.DriveInfo.GetDrives();

                // Kiem tra su thay doi cua o dia
                if (disk.Length != this.diskNumber)
                {
                    // Luu su thay doi sang cho lop DiskEventArgs
                    DiskEventArgs dv = new DiskEventArgs(disk.Length, disk);

                    //Kiem tra xem co Methor nao dang ky khong
                    if (OnDiskHander != null)
                    {
                        // Thong bao toi cac phuong thuc dang ky event nay
                        OnDiskHander(this, dv);
                    }

                    // Cap nhap lai so o dia
                    this.diskNumber = disk.Length;
                }
            }
        }

        public void Stop(Boolean state)
        {
            this.state = state;
        }
    }

    public class DiskEventArgs : EventArgs
    {
        // So o dia
        public int index;

        // Danh sach o dia
        public DriveInfo[] disk;

        public DiskEventArgs(int index, DriveInfo[] disk)
        {
            this.index = index;
            this.disk = disk;
        }
    }
}
