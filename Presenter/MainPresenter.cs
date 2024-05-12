using LibreHardwareMonitor.Hardware;
using System.Diagnostics;
using TemperatureMonitor.Model;
using TemperatureMonitor.Monitor;
using TemperatureMonitor.View;

namespace TemperatureMonitor.Presenter
{
    internal class MainPresenter : IMainPresenter
    {
        private IMainModel model;
        private IMainView view;
        private TestForm? fanUI = null;
        public MainPresenter(IMainView view, IMainModel model)
        {
            this.view = view;
            this.model = model;
            this.view.SetPresenter(this);
            this.model.SetPresenter(this);
        }
        public void OnAddFanRpmButtonClicked()
        {
            AddControl(Monitor.SnapMonitor.sensorFan);
        }
        public void OnAddFanCtrlButtonClicked()
        {
            AddControl(Monitor.SnapMonitor.sensorControl);
        }

        public void OnAddLoadButtonClicked()
        {
            AddControl(Monitor.SnapMonitor.sensorLoad);
        }

        public void OnAddTempButtonClicked()
        {
            AddControl(Monitor.SnapMonitor.sensorTemperature);
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

        public void OnFanUiButtonClicked()
        {
            if (fanUI == null || fanUI.IsDisposed)
            {
                fanUI = new(model.GetFanControls());
                
            }
            fanUI.Show();
        }
        public void DataUpdated()
        {
            foreach (MonitorComponent c in view.GetMonitors())
            {
                c.RefreshReading();
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
                //model.GetAvailableSensorsOfType(type)
                new List<string>()
                );
            c.SetSensors(model.GetSensorsOfType(type));
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
