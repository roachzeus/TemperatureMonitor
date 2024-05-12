using System;

namespace TemperatureMonitor
{
    internal class TempMonitorException: Exception
    {
        public TempMonitorException(){}
        public TempMonitorException(string message) : base(message){}
        public TempMonitorException(string message, Exception inner) : base(message, inner){}
    }
}
