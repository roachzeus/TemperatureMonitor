using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TemperatureMonitor.Monitor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace TemperatureMonitor.View
{
    public partial class TestForm : Form
    {
        public TestForm(List<FanControlSensor> fans)
        {
            InitializeComponent();
            listBoxFans.DataSource = fans;
        }

        private void listBoxFans_SelectionChanged(object sender, EventArgs e)
        {
            // this is before window is created/shown
            if (!rbStatic.Checked && !rbCrv.Checked && !rbDefault.Checked){return;}

            // cast to listbox
            int val = hsbSpd.Value;
            foreach (FanControlSensor f in listBoxFans.SelectedItems)
            {
                Debug.WriteLine(f.ToString());

                //f.SetFanSpeedDefault();
                //f.SetFanSpeed(hScrollBar1.Value);
            }
        }

        private void hsbSpd_Change(object sender, ScrollEventArgs e)
        {
            // to work around the small increment event fucking things up
            if (e.Type != ScrollEventType.EndScroll) { return; }

            hsbSpd = (HScrollBar)sender;
            lblVal.Text = hsbSpd.Value.ToString() + "*";

            if (rbStatic.Checked)
            {
                FanSpeedUpdate();
            } else if (rbDefault.Checked)
            {
                FansToDefault();
            }
            
            //Debug.WriteLine(hsbSpd.Value);
        }
        private void FanSpeedUpdate()
        {
            foreach (FanControlSensor f in listBoxFans.SelectedItems)
            {
                //f.SetFanSpeedDefault();
                f.SetFanSpeed(hsbSpd.Value);
            }
        }

        private void FansToDefault()
        {
            foreach (FanControlSensor f in listBoxFans.Items)
            {
                f.SetFanSpeedDefault();
            }
        }
    }
}
