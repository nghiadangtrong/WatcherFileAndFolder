using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;

namespace Test_Service
{
    public partial class Service1 : ServiceBase
    {
        private bool Stopping;
        private ManualResetEvent StopEvent;

        public Service1()
        {
            this.Stopping = false;
            this.StopEvent = new ManualResetEvent(false);
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {

            //OutController.WriteLog(System.Security.Principal.WindowsIdentity.GetCurrent().Name);
            ThreadPool.QueueUserWorkItem(new WaitCallback(ServiceThread));
            base.OnStart(args);
        }

        protected override void OnStop()
        {
            this.Stopping = true;
            this.StopEvent.WaitOne();
            base.OnStop();
        }

        private void ServiceThread(object state)
        {
            // chay ung dung
            new InputControl(AppDomain.CurrentDomain.BaseDirectory + "Config.xml");

            while (!Stopping)
            {
                Thread.Sleep(10000);
            }
            this.StopEvent.Set();
        }
    }
}
