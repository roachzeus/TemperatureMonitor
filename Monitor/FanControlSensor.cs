using LibreHardwareMonitor.Hardware;

namespace TemperatureMonitor.Monitor
{
    public class FanControlSensor : Sensor
    {
        protected IControl control;
        public FanControlSensor(ISensor sensor) : base(sensor)
        {
            IControl control = sensor.Control;
            if (control == null)
            {
                throw new TempMonitorException("Sensor does not support control");
            }
            this.control = control;
        }
        public void SetFanSpeed(float speed)
        {
            control.SetSoftware(speed);
        }
        public void SetFanSpeedDefault()
        {
            control.SetDefault();
        }
    }
}
