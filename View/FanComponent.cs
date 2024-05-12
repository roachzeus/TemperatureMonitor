using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemperatureMonitor.Util;

namespace TemperatureMonitor.View
{
    internal class FanComponent : TableLayoutPanel
    {
        private readonly ColorCalculator colorCalculator;

        public FanComponent() : base()
        {
            colorCalculator = new ColorCalculator();
        }
    }
}
