using LibreHardwareMonitor.Hardware;
using System.Diagnostics;

namespace TemperatureMonitor.Monitor
{
    internal class CompositeFan
    {
        private readonly ISensor cSensor;
        private readonly ISensor fSensor;
        private CompositeFan(ISensor cSensor, ISensor fSensor)
        {
            this.cSensor = cSensor;
            this.fSensor = fSensor;
        }
        public float GetValuePercent()
        {
            return cSensor.Value ?? -1;
        }
        public float GetValueRpm()
        {
            return fSensor.Value ?? -1;
        }
        public string GetName()
        {
            return cSensor.Name;
        }
        public string GetId()
        {
            return cSensor.Identifier.ToString();
        }
        public void SetFanSpeed(float speed)
        {
            cSensor.Control.SetSoftware(speed);
        }
        public void SetFanSpeedDefault()
        {
            cSensor.Control.SetDefault();
        }
        public static CompositeFan Build(ISensor cSensor, ISensor fSensor)
        {
            if (cSensor.Control == null)
            {
                throw new TempMonitorException("Control sensor does not support control");
            }

            if (cSensor.Name != fSensor.Name)
            {
                throw new TempMonitorException("Sensor names do not match");
            }

            if (cSensor.Identifier.ToString() != fSensor.Identifier.ToString().Replace("fan", "control"))
            {
                Debug.WriteLine("Identifiers do not seem to correspond to each other {0} vs. {1}",
                    cSensor.Identifier.ToString(),
                    fSensor.Identifier.ToString());

                throw new TempMonitorException("Identifiers do not seem to correspond to each other {0} vs. {1}");
            }

            return new CompositeFan(cSensor, fSensor);
        }
    }
}
