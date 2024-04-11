using LibreHardwareMonitor.Hardware;
using System.Diagnostics;

namespace TemperatureMonitor
{
    public partial class MainUI : Form
    {
        private Monitor.Monitor monitor;
        private ColorCalculator cCal;
        private List<String> polledItems;
        private Thread? workerThread;
        private bool shouldMonitorRun = true;
        private FlowUI otherUI;

        private List<ISensor> sensorList;

        public MainUI()
        {
            monitor = new Monitor.Monitor();
            cCal = new ColorCalculator();
            polledItems = new List<String>() { "", "", "", "" };
            otherUI = new FlowUI(this);
            otherUI.Hide();

            sensorList = new List<ISensor>();
            //otherUI.Visible = false;
            InitializeComponent();
            initSensorsList();
        }

        private void initSensorsList()
        {
            Dictionary<String, float> data = monitor.updateSensors(true);

            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();

            foreach (KeyValuePair<String, float> pair in data)
            {
                listBox1.Items.Add(pair.Key);
                listBox2.Items.Add(pair.Key);
                listBox3.Items.Add(pair.Key);
                listBox4.Items.Add(pair.Key);
            }
        }
        private void startPolling()
        {
            while (!this.IsHandleCreated)
            {
                return;
            }

            shouldMonitorRun = true;
            this.workerThread = new Thread(() =>
            {

                while (shouldMonitorRun)
                {
                    Dictionary<String, float> map = monitor.updateSensors(true);
                    BeginInvoke(() =>
                    {

                        // TODO this if spagethi looks awful, fix it.
                        if (map.ContainsKey(polledItems[0]))
                        {
                            lblKey1.Text = polledItems[0];
                            lblVal1.Text = Math.Round(map[polledItems[0]], 0).ToString();
                            lblVal1.ForeColor = cCal.ComputeTemperatureColor((double)map[polledItems[0]]);
                        }
                        else
                        {
                            lblKey1.Text = "N/A";
                            lblVal1.Text = "-1";
                            lblVal1.ForeColor = cCal.ComputeTemperatureColor((double)-1);
                        }
                        if (map.ContainsKey(polledItems[1]))
                        {
                            lblKey2.Text = polledItems[1];
                            lblVal2.Text = Math.Round(map[polledItems[1]], 0).ToString();
                            lblVal2.ForeColor = cCal.ComputeTemperatureColor((double)map[polledItems[1]]);
                        }
                        else
                        {
                            lblKey2.Text = "N/A";
                            lblVal2.Text = "-1";
                            lblVal2.ForeColor = cCal.ComputeTemperatureColor((double)-1);
                        }
                        if (map.ContainsKey(polledItems[2]))
                        {
                            lblKey3.Text = polledItems[2];
                            lblVal3.Text = Math.Round(map[polledItems[2]], 0).ToString();
                            lblVal3.ForeColor = cCal.ComputeTemperatureColor((double)map[polledItems[2]]);
                        }
                        else
                        {
                            lblKey3.Text = "N/A";
                            lblVal3.Text = "-1";
                            lblVal3.ForeColor = cCal.ComputeTemperatureColor((double)-1);
                        }
                        if (map.ContainsKey(polledItems[3]))
                        {
                            lblKey4.Text = polledItems[3];
                            lblVal4.Text = Math.Round(map[polledItems[3]], 0).ToString();
                            lblVal4.ForeColor = cCal.ComputeTemperatureColor((double)map[polledItems[3]]);
                        }
                        else
                        {
                            lblKey4.Text = "N/A";
                            lblVal4.Text = "-1";
                            lblVal4.ForeColor = cCal.ComputeTemperatureColor((double)-1);
                        }
                    });
                    Thread.Sleep(1000);
                };

            });
            btnStartStop.Text = "Stop";
            this.workerThread.Start();
        }

        private void updateField()
        {

        }
        private void btnStartStop_Click(object sender, EventArgs e)
        {
            if (this.workerThread != null && this.workerThread.IsAlive)
            {
                shouldMonitorRun = false;
                workerThread.Join();
                //this.workerThread = null;
                btnStartStop.Text = "Start";
            }
            else
            {
                startPolling();

            }
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            addToPolledItems((ListBox)sender, 0);
        }
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            addToPolledItems((ListBox)sender, 1);
        }
        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            addToPolledItems((ListBox)sender, 2);
        }
        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            addToPolledItems((ListBox)sender, 3);
        }
        private void addToPolledItems(ListBox lbox, int index)
        {
            if (lbox == null || lbox.SelectedItem == null) { return; }
            this.polledItems[index] = lbox.SelectedItem.ToString();
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

            lblVal1.Font = new Font("Segoe UI", size, FontStyle.Bold);
            lblVal2.Font = new Font("Segoe UI", size, FontStyle.Bold);
            lblVal3.Font = new Font("Segoe UI", size, FontStyle.Bold);
            lblVal4.Font = new Font("Segoe UI", size, FontStyle.Bold);
        }

        private void btnOtherUI_Click(object sender, EventArgs e)
        {

            if (otherUI == null || otherUI.IsDisposed)
            {
                otherUI = new FlowUI(this);
                otherUI.Show();
            }
            else if (!otherUI.Visible)
            {
                otherUI.Show();
            }
            else
            {
                otherUI.Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (sensorList.Count == 0)
            {
                sensorList = monitor.GetAll();
            }
            Debug.WriteLine("Found:");
            sensorList.ForEach(delegate (ISensor s) { Debug.WriteLine("{0} - {1} - {2} - ", s.SensorType, s.Name, s.Value); });

        }
    }
}
