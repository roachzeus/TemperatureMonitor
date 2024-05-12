using LibreHardwareMonitor.Hardware;
using System.ComponentModel;
using System.Diagnostics;
using TemperatureMonitor.Monitor;
using TemperatureMonitor.Presenter;
using TemperatureMonitor.View;

namespace TemperatureMonitor.View
{
    internal partial class MainUI : Form, IMainView
    {

        private IMainPresenter? presenter = null; // set from presenter
        public MainUI()
        {
            InitializeComponent();
        }

        public void SetPresenter(IMainPresenter presenter)
        {
            this.presenter = presenter;
        }

        public void AddMonitor(MonitorComponent component)
        {
            flp.Controls.Add(component);
        }

        public void RemoveMonitor(MonitorComponent component)
        {
            flp.Controls.Remove(component);
            component.Dispose();
        }

        public List<MonitorComponent> GetMonitors()
        {
            return flp.Controls.OfType<MonitorComponent>().ToList();
        }

        private void btnAddTemp_Click(object sender, EventArgs e)
        {
            // If it's really null, then you have miswired the app and it's your fault
            this.presenter.OnAddTempButtonClicked();
        }

        private void btnAddLoad_Click(object sender, EventArgs e)
        {
            // If it's really null, then you have miswired the app and it's your fault
            this.presenter.OnAddLoadButtonClicked();
        }

        private void btnAddFan_Click(object sender, EventArgs e)
        {
            // If it's really null, then you have miswired the app and it's your fault
            this.presenter.OnAddFanCtrlButtonClicked();
        }

        private void btnRem_Click(object sender, EventArgs e)
        {
            // If it's really null, then you have miswired the app and it's your fault
            this.presenter.OnRemoveButtonClicked();
        }

        private void btnAddFanRpm_Click(object sender, EventArgs e)
        {
            // If it's really null, then you have miswired the app and it's your fault
            //this.presenter.OnAddFanRpmButtonClicked();

            // /amdcpu/0/temperature/2, Core (Tctl/Tdie)
            // /amdcpu/0/temperature/3, CCD1 (Tdie)
            //Monitor.Monitor m = new Monitor.Monitor();
            OpenMonitor m = new();
            m.Start();
            var fans = m.GetFans();
            var ctrls = m.GetControls();
            fans.ForEach(fan =>
            {
                Debug.WriteLine("{0}, {1}, {2}, {3}", fan.Identifier, fan.Name, fan.SensorType, fan.Value);
            });
            ctrls.ForEach(ctrl =>
            {
                Debug.WriteLine("{0}, {1}, {2}, {3}", ctrl.Identifier, ctrl.Name, ctrl.SensorType, ctrl.Value);
            });
            m.Stop();
            //m.GetReadings().ForEach(s =>{Debug.WriteLine("{0}, {1}, {2}, {3}", s.Identifier, s.Name, s.SensorType, s.Value);});
            //var s1 = m.GetSensorById("/amdcpu/0/temperature/2");
            //var s2 = m.GetSensorById("/amdcpu/0/temperature/3");
            //Debug.WriteLine("{0}, {1}, {2}, {3}", s1.Identifier, s1.Name, s1.SensorType, s1.Value);
            //Debug.WriteLine("{0}, {1}, {2}, {3}", s2.Identifier, s2.Name, s2.SensorType, s2.Value);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
        }
        private void btnFanUI_Click(object sender, EventArgs e)
        {
            presenter.OnFanUiButtonClicked();
        }
    }
}
