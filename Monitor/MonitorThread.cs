using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureMonitor.Monitor
{
    internal class MonitorThread
    {
        private Monitor monitor;
        private Thread thread;
        private bool shouldRun = true;
        private int sleepInverval;

        public MonitorThread(Monitor monitor)
        {
            this.monitor = monitor;
            thread = new Thread(this.DoWork);
            sleepInverval = 100;
        }

        public void DoWork()
        {
            while (shouldRun)
            {
                monitor.UpdateSensors();
            }
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(sleepInverval);
            }
        }

        public void setSleepInterval(int sleepInverval)
        {
            this.sleepInverval = sleepInverval;
        }

        public void Start()
        {
            thread.Start();
        }

        public void Stop()
        {
            sleepInverval = 1;
            shouldRun = false;
        }
    }
}
