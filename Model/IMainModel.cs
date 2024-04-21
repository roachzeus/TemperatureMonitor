using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemperatureMonitor.Presenter;

namespace TemperatureMonitor.Model
{
    public interface IMainModel
    {
        public void SetPresenter(IMainPresenter presenter);
        public void StartMonitoring();
        public void StopMonitoring();
        public List<string> GetAvailableSensorsOfType(string type);
    }
}
