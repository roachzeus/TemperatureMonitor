using LibreHardwareMonitor.Hardware;

namespace TemperatureMonitor.Monitor
{
    public class Monitor
    {
        private bool shoudRun = true;
        private Dictionary<String, float> valueData;
        public Monitor()
        {
            this.valueData = new Dictionary<String, float>();
        }

        public void doWork()
        {
            while (shoudRun)
            {

            }
        }

        public void stopWork()
        {
            shoudRun = false;
        }

        public Dictionary<String, float> updateSensors(bool includeMobo)
        {
            Computer computer = new Computer
            {
                IsCpuEnabled = true,
                IsGpuEnabled = true,
                IsMemoryEnabled = false,
                IsMotherboardEnabled = includeMobo,
                IsControllerEnabled = false,
                IsNetworkEnabled = false,
                IsStorageEnabled = false
            };

            computer.Open();
            computer.Accept(new UpdateVisitor());
            Dictionary<String, float> values = new Dictionary<String, float>();
            foreach (IHardware hardware in computer.Hardware)
            {
                
                //Console.WriteLine("Hardware: {0}", hardware.Name);
                foreach (IHardware subhardware in hardware.SubHardware)
                {
                   //Console.WriteLine("\tSubhardware: {0}", subhardware.Name);

                    foreach (ISensor sensor in subhardware.Sensors)
                    {
                        if (sensor.SensorType.ToString() != "Temperature")
                        {
                            continue;
                        }
                        values.Add(sensor.Name, sensor.Value ?? -1);
                        //Console.WriteLine("\t\tSensor: {0}, value: {1}", sensor.Name, sensor.Value);
                    }
                }
                
                foreach (ISensor sensor in hardware.Sensors)
                {
                    //Console.WriteLine("\tSensor: {0}, value: {1}, type: {2}", sensor.Name, sensor.Value, sensor.SensorType);

                    if (sensor.SensorType.ToString() != "Temperature")
                    {
                        continue;
                    }

                    if (sensor.Hardware.HardwareType.ToString() == "Cpu")
                    {
                        values.Add(sensor.Name, sensor.Value ?? -1);
                        //Console.WriteLine("\tSensor: {0}, value: {1}, type: {2}", sensor.Name, sensor.Value, sensor.SensorType);

                    }
                    else if (sensor.Hardware.HardwareType.ToString() == "GpuNvidia" || sensor.Hardware.HardwareType.ToString() == "GpuAmd")
                    {
                        values.Add(sensor.Name, sensor.Value ?? -1);
                        //Console.WriteLine("\tSensor: {0}, value: {1}, type: {2}", sensor.Name, sensor.Value, sensor.SensorType);
                    }
                }
            }

            computer.Close();
            return values;
        }
    }
}
