using LibreHardwareMonitor.Hardware;

namespace TemperatureMonitor.Monitor
{
    internal class MonitorData
    {
        private readonly Monitor monitor;
        private readonly MonitorThread monitorThread;
        //private Thread thread;
        public MonitorData()
        {
            this.monitor = new Monitor();
            monitorThread = new MonitorThread(this.monitor);
            //thread = new Thread(monitorThread.DoWork);
        }

        public MonitorData(Monitor monitor)
        {
            this.monitor = monitor;
            monitorThread = new MonitorThread(this.monitor);
            //thread = new Thread(monitorThread.DoWork);
        }
        public MonitorData(Monitor monitor, MonitorThread monitorThread)
        {
            this.monitor = monitor;
            this.monitorThread = monitorThread;
            //thread = new Thread(monitorThread.DoWork);
        }

        public void StartMonitoring()
        {
            monitorThread.Start();
        }

        public void StopMonitoring()
        {
            monitorThread.Stop();
        }

        public List<ISensor> GetTemperatures()
        {
            return monitor.GetAll().FindAll(s => s.SensorType.ToString() == Monitor.sensorTemperature);
        }
        public List<ISensor> GetLoads()
        {
            return monitor.GetAll().FindAll(s => s.SensorType.ToString() == Monitor.sensorLoad);
        }
        public List<ISensor> GetFansAsRpm()
        {
            return monitor.GetAll().FindAll(s => s.SensorType.ToString() == Monitor.sensorFan);
        }
        public List<ISensor> GetFansAsLoad()
        {
            return monitor.GetAll().FindAll(s => s.SensorType.ToString() == Monitor.sensorControl);
        }
    }
}
