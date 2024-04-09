namespace TemperatureMonitor
{
    public partial class OtherUI : Form
    {
        private MainUI mainUI;
        private List<MonitorComponent> monitorComponents;
        private Thread? monitorThread;
        private MonitorWorker worker;
        public OtherUI(MainUI parent)
        {
            this.mainUI = parent;
            InitializeComponent();
            monitorComponents = new List<MonitorComponent>();
            worker = new MonitorWorker();


            monitorThread = null;
            //thread.Start();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (monitorThread == null || !monitorThread.IsAlive)
            {
                worker = new MonitorWorker();
                monitorThread = new Thread(worker.doWork);
            }
            if (monitorComponents.Count == 0)
            {
                monitorThread.Start();
            }
            //List<string> list = new List<string>();
            //list.Add("1");
            //list.Add("2");
            //list.Add("3");
            //flp.SuspendLayout();
            MonitorComponent c = new MonitorComponent("Select sensor", "N/A", worker.getSensorNames());
            //c.PerformLayout();
            c.Visible = true;
            flp.Controls.Add(c);
            //flp.ResumeLayout(false);
            flp.PerformLayout();
            //Controls.Add(c);
            monitorComponents.Add(c);

            worker.setComponents(monitorComponents);

        }

        private void btnRem_Click(object sender, EventArgs e)
        {

            foreach (MonitorComponent c in monitorComponents.ToList())
            {
                if (c.isSelected())
                {
                    this.Controls.Remove(c);
                    c.Dispose();
                    monitorComponents.Remove(c);
                }
            }
            if (monitorComponents.Count == 0 && monitorThread != null)
            {
                worker.stop();
                monitorThread.Join();
            }
            this.PerformLayout();
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
