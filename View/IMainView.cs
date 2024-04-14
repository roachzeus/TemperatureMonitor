using TemperatureMonitor.Presenter;

namespace TemperatureMonitor.View
{
    public interface IMainView
    {
        public void SetPresenter(IMainPresenter presenter);
        public void AddMonitor(MonitorComponent component);
        public void RemoveMonitor(MonitorComponent component);
        public List<MonitorComponent> GetMonitors();
        public void SetComponentValues(string id, string key, string value);
        public void setComponentItems(string id, List<string> items);
    }
}
