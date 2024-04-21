using LibreHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureMonitor.Monitor
{
    internal interface ISubscriber
    {
        public void OnDataUpdated(List<ISensor> sensorData);
    }
}
