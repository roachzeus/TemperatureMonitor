using LibreHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemperatureMonitor.Monitor;
using TemperatureMonitor.Presenter;

namespace TemperatureMonitor.Model
{
    internal class MainModel : IMainModel, ISubscriber
    {
        private IMainPresenter? presenter; // set in presenter
        private Monitor.Monitor monitor;

        private Dictionary<string, List<string>> availableSensors;

        public MainModel()
        {
            monitor = new Monitor.Monitor();
            monitor.AddSubscriber(this);
            availableSensors = InitAvailableSensors();
        }

        public void StartMonitoring()
        {
            monitor.Start();
        }
        public void StopMonitoring()
        {
            monitor.Stop();
        }
        private Dictionary<string, List<string>> InitAvailableSensors()
        {
            Dictionary<string, List<string>> ret = [];

            foreach (ISensor sensor in monitor.GetReadings())
            {
                string key = sensor.SensorType.ToString();
                if (ret.TryGetValue(key, out List<string>? list))
                {
                    list.Add(sensor.Name);
                }
                else
                {
                    List<string> newList = [];
                    newList.Add(sensor.Name);
                    ret.Add(key, newList);
                }
            }

            return ret;
        }
        public List<string> GetAvailableSensorsOfType(string type)
        {
            return availableSensors.TryGetValue(type, out List<string>? list) ? list : [];
        }
        public void OnDataUpdated(List<ISensor> sensorData)
        {
            Dictionary<string, List<ISensor>> grouped = [];
            foreach (ISensor sensor in sensorData)
            {
                string key = sensor.SensorType.ToString();
                if (grouped.TryGetValue(key, out List<ISensor>? list))
                {
                    list.Add(sensor);
                }
                else
                {
                    List<ISensor> newList = [];
                    newList.Add(sensor);
                    grouped.Add(key, newList);
                }
            }
            presenter.OnDataUpdated(grouped);
        }
        public void SetPresenter(IMainPresenter presenter)
        {
            this.presenter = presenter;
        }
    }
}
