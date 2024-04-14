using LibreHardwareMonitor.Hardware;
using System.Diagnostics;
using TemperatureMonitor.Model;
using TemperatureMonitor.View;

namespace TemperatureMonitor.Presenter
{
    internal class MainPresenter : IMainPresenter
    {
        private IMainModel model;
        private IMainView view;
        public MainPresenter(IMainView view, IMainModel model)
        {
            this.view = view;
            this.model = model;
            this.view.SetPresenter(this);
            this.model.SetPresenter(this);
        }
        public void OnAddFanPerButtonClicked()
        {
            AddControl(Monitor.Monitor.sensorFan);
        }
        public void OnAddFanCtrlButtonClicked()
        {
            AddControl(Monitor.Monitor.sensorControl);
        }

        public void OnAddLoadButtonClicked()
        {
            AddControl(Monitor.Monitor.sensorLoad);
        }

        public void OnAddTempButtonClicked()
        {
            AddControl(Monitor.Monitor.sensorTemperature);
        }

        public void OnRemoveButtonClicked()
        {
            foreach (MonitorComponent c in view.GetMonitors())
            {
                if (c.IsSelected())
                {
                    view.RemoveMonitor(c);
                }
            }
            if (view.GetMonitors().Count == 0)
            {
                model.StopMonitoring();
            }
        }

        public void OnDataUpdated(Dictionary<string, List<ISensor>> sensorData)
        {
            foreach (MonitorComponent c in view.GetMonitors())
            {
                string type = c.GetComponentType();
                Dictionary<string, float> data = [];
                foreach (ISensor sensor in sensorData[type])
                {
                    if(!data.TryAdd(sensor.Name, sensor.Value ?? -1))
                    {
                        Debug.WriteLine("WARN: duplicate '{0} and {1}' found. Skipping...", sensor.Name, sensor.Value);
                    }
                    
                }
                c.UpdateData(data);
            }
        }

        public void StopMonitor()
        {
            model.StopMonitoring();
        }

        private void AddControl(string type)
        {
            if (view.GetMonitors().Count == 0)
            {
                model.StartMonitoring();
            }
            MonitorComponent c = new MonitorComponent(type,
                model.GetAvailableSensorsOfType(type));
            view.AddMonitor(c);


        }

        /*
protected override void Dispose(bool disposing)
{
if (disposing)
{
worker.stop();
worker = null;
monitorThread.Join();
monitorThread = null;

}
base.Dispose(disposing);
}
*/
    }
}
