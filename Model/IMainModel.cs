using LibreHardwareMonitor.Hardware;
using TemperatureMonitor.Monitor;
using TemperatureMonitor.Presenter;

namespace TemperatureMonitor.Model
{
    public interface IMainModel
    {
        public void SetPresenter(IMainPresenter presenter);
        public void StartMonitoring();
        public void StopMonitoring();
        public List<Sensor> GetSensorsOfType(string type);
        public List<FanControlSensor> GetFanControls();
    }
}
