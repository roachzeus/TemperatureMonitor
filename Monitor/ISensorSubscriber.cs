using LibreHardwareMonitor.Hardware;

namespace TemperatureMonitor.Monitor
{
    internal interface ISensorSubscriber
    {
        public void OnDataUpdated(List<ISensor> sensorData);
    }
}
