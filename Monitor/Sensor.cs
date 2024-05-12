using LibreHardwareMonitor.Hardware;
namespace TemperatureMonitor.Monitor
{
    public class Sensor
    {
        protected readonly ISensor sensor;

        public Sensor(ISensor sensor)
        {
            this.sensor = sensor;
        }
        public float GetValue()
        {
            return sensor.Value ?? -1;
        }
        public string GetName()
        {
            return sensor.Name;
        }
        public string GetId()
        {
            return sensor.Identifier.ToString();
        }
        public string GetSensorType()
        {
            return sensor.SensorType.ToString();
        }
        public bool SupportsControl()
        {
            return sensor.Control != null;
        }
        public override string ToString()
        {
            return GetName();
        }
    }
}
