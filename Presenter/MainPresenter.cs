using LibreHardwareMonitor.Hardware;
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

        public void OnAddFanButtonClicked()
        {
            throw new NotImplementedException();
        }

        public void OnAddLoadButtonClicked()
        {
            throw new NotImplementedException();
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
                    data.Add(sensor.Name, sensor.Value ?? -1);
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
