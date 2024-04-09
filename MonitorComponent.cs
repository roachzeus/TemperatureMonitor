using System.Collections.Generic;
using System.Windows.Forms;

namespace TemperatureMonitor
{
    internal class MonitorComponent : TableLayoutPanel
    {

        private Label keyLbl;
        private Label valLbl;
        private ListBox listBox;
        private CheckBox cb;

        private Dictionary<string, float> data;
        private ColorCalculator colorCalculator;

        public MonitorComponent(string key, string val, List<string> list)
        {
            data = new Dictionary<string, float>();
            colorCalculator = new ColorCalculator();
            initControls(key, val, list);
        }
        
        private void initControls(string key, string val, List<string> list)
        {
            //this.SuspendLayout();
            this.Size = new Size(188, 400);
            //this.Width = 500;
            //this.Height = 500;
            this.MinimumSize = new Size(188, 400);
            //this.AutoSize = true;
            this.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.ColumnCount = 1;
            this.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            //this.Location = new Point(5, 5);
            this.Margin = new Padding(5);
            this.Name = "monitorComponent";
            this.RowCount = 4;
            this.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
            this.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            this.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            this.RowStyles.Add(new RowStyle(SizeType.Percent, 55F));
            //this.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            //this.BorderStyle = BorderStyle.FixedSingle;
            this.Visible = true;
            this.TabIndex = 10;

            cb = new CheckBox();
            cb.Anchor = AnchorStyles.Right;
            cb.AutoSize = true;
            cb.Checked = false;

            keyLbl = new Label();
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


            valLbl = new Label();
            valLbl.Text = val;

            valLbl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            valLbl.AutoSize = true;
            valLbl.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            valLbl.ForeColor = Color.Silver;
            valLbl.Location = new Point(0, 0);
            valLbl.Margin = new Padding(5);
            valLbl.Name = "key";
            //valLbl.Size = new Size(200, 100);
            //valLbl.MinimumSize = new Size(200, 100);
            valLbl.TextAlign = ContentAlignment.MiddleCenter;
            valLbl.TabIndex = 2;

            listBox = new ListBox();
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
            listBox.SelectedValueChanged += selectedSensorChanged;
            
            //listBox.Size = new Size(200, 180);
            //listBox.MinimumSize = new Size(200, 180);

            this.Controls.Add(cb);
            this.Controls.Add(keyLbl);
            this.Controls.Add(valLbl);
            this.Controls.Add(listBox);
            //this.ResumeLayout(false);
            //this.PerformLayout();
        }
        public void setSelected(bool selected)
        {
            this.cb.Checked = selected;
        }

        public bool isSelected()
        {
            return cb.Checked;
        }

        public void updateData(Dictionary<string, float> data)
        {
            this.data = data;
            BeginInvoke(() => {
                updateReading(listBox);
            }); 
        }

        private void selectedSensorChanged(object sender, EventArgs e)
        {
            updateReading((ListBox)sender);
        }

        private void updateReading(ListBox box)
        {
            if (box != null && box.SelectedItem != null)
            {
                string key = box.SelectedItem.ToString() ?? "null";
                keyLbl.Text = key;
                valLbl.Text = this.data.TryGetValue(key, out float value) ? Math.Round(value, 0).ToString() : "-1";
                valLbl.ForeColor = colorCalculator.computeColor(value);
            }
        }
    }
}
