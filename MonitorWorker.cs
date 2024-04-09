using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureMonitor
{
    internal class MonitorWorker
    {
        private Monitor.Monitor m;
        private bool shouldRun = true;
        private bool working = false;
        private List<MonitorComponent> mcs;
        private List<string> sensorNames;

        public MonitorWorker() 
        {
            m = new Monitor.Monitor();
            sensorNames = m.updateSensors(true).Keys.ToList();
            mcs = new List<MonitorComponent>();
        }

        public async void doWork()
        {
            while (shouldRun)
            {
                // m = new Monitor.Monitor();
                Dictionary<string, float> data = m.updateSensors(true);

                working = true;
                foreach (MonitorComponent component in mcs)
                {
                    component.updateData(data);
                }
                working = false;
                Thread.Sleep(1000);
            }
        }

        public List<string> getSensorNames()
        {
            return sensorNames;
        }

        public void setComponents(List<MonitorComponent> mcs)
        {
            if (working)
            {
                Thread.Sleep(250);
            }
            this.mcs = mcs;
        }

        public void stop() {
            shouldRun = false;
        }

    }
}
