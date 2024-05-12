using LibreHardwareMonitor.Hardware;
using TemperatureMonitor.Monitor;
using TemperatureMonitor.Util;

namespace TemperatureMonitor.View
{
    public class MonitorComponent : TableLayoutPanel
    {
        // TODO should be internal class? and it's interface should be public?
        private readonly ColorCalculator colorCalculator;

        private readonly Label keyLbl;
        private readonly Label valLbl;
        private readonly ListBox listBox;
        private readonly CheckBox cb;

        private Dictionary<string, float> data;
        private Dictionary<string, ISensor> sensors;
        private string type;

        public MonitorComponent(string type, List<string> items, ColorCalculator? colorCalculator = null)
        {
            this.colorCalculator = colorCalculator ?? new ColorCalculator();
            cb = new CheckBox();
            keyLbl = new Label();
            valLbl = new Label();
            listBox = new ListBox();
            data = [];
            sensors = new();
            this.type = type;
            InitControls("Select sensor", "N/A", items);
        }

        private void InitControls(string key, string val, List<string> list)
        {
            //this.SuspendLayout();
            Size = new Size(186, 400);
            //this.Width = 500;
            //this.Height = 500;
            MinimumSize = new Size(186, 400);
            //this.AutoSize = true;
            Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ColumnCount = 1;
            ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            //this.Location = new Point(5, 5);
            Margin = new Padding(5);
            Name = "monitorComponent";
            RowCount = 4;
            RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
            RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            RowStyles.Add(new RowStyle(SizeType.Percent, 55F));
            //this.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            //this.BorderStyle = BorderStyle.FixedSingle;
            Visible = true;
            TabIndex = 10;

            // Checkbox
            cb.Anchor = AnchorStyles.Right;
            cb.AutoSize = true;
            cb.Checked = false;

            // Key label
            keyLbl.Text = key;
            keyLbl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            keyLbl.AutoSize = true;
            keyLbl.Font = new Font("Segoe UI", 16F);
            keyLbl.ForeColor = Color.Silver;
            keyLbl.Location = new Point(0, 0);
            keyLbl.Margin = new Padding(5);
            keyLbl.Name = "key";
            //keyLbl.Size = new Size(200,100);
            //keyLbl.MinimumSize = new Size(200, 100);
            keyLbl.TextAlign = ContentAlignment.MiddleCenter;
            keyLbl.TabIndex = 2;

            // Value label
            valLbl.Text = val;
            valLbl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            valLbl.AutoSize = true;
            valLbl.Font = new Font("Segoe UI", 32F, FontStyle.Bold);
            valLbl.ForeColor = Color.Silver;
            valLbl.Location = new Point(0, 0);
            valLbl.Margin = new Padding(5);
            valLbl.Name = "key";
            //valLbl.Size = new Size(200, 100);
            //valLbl.MinimumSize = new Size(200, 100);
            valLbl.TextAlign = ContentAlignment.MiddleCenter;
            valLbl.TabIndex = 2;

            // Listbox
            foreach (string item in list)
            {
                listBox.Items.Add(item);
            }

            listBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listBox.AutoSize = true;
            listBox.Font = new Font("Segoe UI", 12F);
            listBox.ForeColor = Color.Silver;
            listBox.BackColor = Color.FromArgb(32, 32, 32);
            listBox.Location = new Point(0, 0);
            listBox.Margin = new Padding(5);
            listBox.Name = "keys";
            listBox.TabIndex = 4;
            listBox.SelectedValueChanged += delegate { SelectedSensorChanged(listBox, new EventArgs()); };

            //listBox.Size = new Size(200, 180);
            //listBox.MinimumSize = new Size(200, 180);

            Controls.Add(cb);
            Controls.Add(keyLbl);
            Controls.Add(valLbl);
            Controls.Add(listBox);
            //this.ResumeLayout(false);
            //this.PerformLayout();
        }
        public bool IsSelected()
        {
            return cb.Checked;
        }
        public string GetComponentType()
        {
            return type;
        }
        public void SetSensors(List<Sensor> sensorList)
        {
            //sensors.Clear();
            //listBox.Items.Clear();
            listBox.DataSource = sensorList;
            /*
            foreach (ISensor sensor in sensorList)
            {
                sensors.Add(sensor.Name, sensor);
                listBox.Items.Add(sensor.Name);
            }
            */
        }
        public void UpdateData(Dictionary<string, float> data)
        {
            this.data = data;
            BeginInvoke(() =>
            {
                RefreshReadingPanel();
            });
        }
        public void RefreshReading()
        {
            BeginInvoke(() =>
            {
                RefreshReadingPanel();
            });
        }
        private void RefreshReadingPanel()
        {
            if (listBox.SelectedItem is Sensor selected) //listBox.SelectedIndex != -1
            {
                keyLbl.Text = selected.GetName();
                valLbl.Text = Math.Round(selected.GetValue(), 0).ToString();
                valLbl.ForeColor = GetColor(selected.GetValue());
            }
            else
            {
                ShowErrorValues();
            }

        }
        private void SelectedSensorChanged(object sender, EventArgs e)
        {
            //UpdateReading((ListBox)sender);
            //RefreshReadingPanel((ListBox)sender);
            RefreshReadingPanel();
        }
        private void UpdateReading(ListBox box)
        {
            if (box != null && box.SelectedItem != null)
            {
                string key = box.SelectedItem.ToString() ?? "null";
                keyLbl.Text = key;
                valLbl.Text = data.TryGetValue(key, out float value) ? Math.Round(value, 0).ToString() : "-1";

                valLbl.ForeColor = GetColor(value);
            }
        }
        private Color GetColor(float value)
        {
            switch (type)
            {
                case Monitor.SnapMonitor.sensorTemperature:
                    return colorCalculator.ComputeTemperatureColor(value);
                case Monitor.SnapMonitor.sensorFan:
                    return colorCalculator.ComputeFanSpeedColor(value);
                case Monitor.SnapMonitor.sensorControl:
                case Monitor.SnapMonitor.sensorLoad:
                default:
                    return colorCalculator.ComputeLoadColor(value);
            }
        }
        private void ShowErrorValues()
        {
            keyLbl.Text = "No selection";
            valLbl.Text = "-1";
            valLbl.ForeColor = colorCalculator.White();
        }
    }
}

