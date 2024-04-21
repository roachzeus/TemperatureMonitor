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
            this.presenter.OnAddFanRpmButtonClicked();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
        }
    }
}
