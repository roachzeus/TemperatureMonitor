using LibreHardwareMonitor.Hardware;
using System.Diagnostics;
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
        private void mainUI_Resize(object sender, EventArgs e)
        {
            MainUI mainUI = (MainUI)sender;
            int newWidth = mainUI.Size.Width;

            int size = 0;
            if (newWidth > 800)
            {
                size = 40;
            }
            else if (newWidth > 700)
            {
                size = 36;
            }
            else if (newWidth > 600)
            {
                size = 32;
            }
            else if (newWidth > 500)
            {
                size = 28;
            }
            else if (newWidth > 400)
            {
                size = 24;
            }

            //lblVal1.Font = new Font("Segoe UI", size, FontStyle.Bold);
            //lblVal2.Font = new Font("Segoe UI", size, FontStyle.Bold);
            //lblVal3.Font = new Font("Segoe UI", size, FontStyle.Bold);
            //lblVal4.Font = new Font("Segoe UI", size, FontStyle.Bold);
        }

        public void SetPresenter(IMainPresenter presenter)
        {
            this.presenter = presenter;
        }

        public void AddMonitor(MonitorComponent component)
        {
            flp.Controls.Add(component);
            //throw new NotImplementedException();
        }

        public void RemoveMonitor(MonitorComponent component)
        {
            flp.Controls.Remove(component);
            component.Dispose();
            //throw new NotImplementedException();
        }

        public List<MonitorComponent> GetMonitors()
        {
            return flp.Controls.OfType<MonitorComponent>().ToList();
        }

        public void SetComponentValues(string id, string key, string value)
        {
            throw new NotImplementedException();
        }

        public void setComponentItems(string id, List<string> items)
        {
            throw new NotImplementedException();
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
            this.presenter.OnAddFanButtonClicked();
        }

        private void btnRem_Click(object sender, EventArgs e)
        {
            this.presenter.OnRemoveButtonClicked();
        }
    }
}
