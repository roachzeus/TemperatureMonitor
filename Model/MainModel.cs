using LibreHardwareMonitor.Hardware;
using System.Diagnostics;
using TemperatureMonitor.Monitor;
using TemperatureMonitor.Presenter;

namespace TemperatureMonitor.Model
{
    internal class MainModel : IMainModel, INotifySubscriber
    {
        private IMainPresenter? presenter; // set in presenter
        //private Monitor.Monitor monitor;
        private OpenMonitor monitor;

        public MainModel()
        {
            //monitor = new Monitor.Monitor();
            monitor = new OpenMonitor();
            monitor.AddSubscriber(this);
        }

        public void StartMonitoring()
        {
            monitor.Start();
        }
        public void StopMonitoring()
        {
            monitor.Stop();
        }
        public List<Sensor> GetSensorsOfType(string type)
        {
            List<Sensor> list = new();
            foreach (ISensor sensor in monitor.Get(type))
            {
                list.Add(new Sensor(sensor));
            }
            return list;
        }
        public List<FanControlSensor> GetFanControls()
        {
            List<FanControlSensor> list = new();
            foreach (ISensor sensor in monitor.Get(OpenMonitor.sensorControl))
            {
                try
                {
                    list.Add(new FanControlSensor(sensor));
                } catch (TempMonitorException e)
                {
                    Debug.WriteLine("Failed to create FanControlSensor: {0}", e.Message);
                }
            }
            return list;
        }
        public void DataUpdated()
        {
            presenter.DataUpdated();
        }
        public void SetPresenter(IMainPresenter presenter)
        {
            this.presenter = presenter;
        }
    }
}
