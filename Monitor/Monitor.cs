using LibreHardwareMonitor.Hardware;

namespace TemperatureMonitor.Monitor
{
    // TODO refactor class to internal
    internal class Monitor
    {
        private static SemaphoreSlim semaphoreSlim = new SemaphoreSlim(1, 1);

        public const string sensorTemperature = "Temperature";
        public const string sensorLoad = "Load";
        public const string sensorFan = "Fan";
        public const string sensorControl = "Control";

        private readonly UpdateVisitor visitor;
        private List<ISensor> lastData;
        public Monitor()
        {
            visitor = new UpdateVisitor();
            lastData = [];
        }
        public Monitor(UpdateVisitor visitor)
        {
            this.visitor = visitor;
            lastData = [];
        }
        /*
        public List<ISensor> GetTemperatures()
        {
            semaphoreSlim.Wait();
            try
            {
                return lastData.FindAll(s => s.SensorType.ToString() == sensorTemperature);
            } finally
            {
                semaphoreSlim.Release();
            }
        }
        public List<ISensor> GetLoads()
        {
            semaphoreSlim.Wait();
            try
            {
                return lastData.FindAll(s => s.SensorType.ToString() == sensorLoad);
            }
            finally
            {
                semaphoreSlim.Release();
            }
        }
        public List<ISensor> GetFansAsRpm()
        {
            semaphoreSlim.Wait();
            try
            {
                return lastData.FindAll(s => s.SensorType.ToString() == sensorFan);
            }
            finally
            {
                semaphoreSlim.Release();
            }
        }
        public List<ISensor> GetFansAsLoad()
        {
            semaphoreSlim.Wait();
            try
            {
                return lastData.FindAll(s => s.SensorType.ToString() == sensorControl);
            }
            finally
            {
                semaphoreSlim.Release();
            }
        }
        */
        public List<ISensor> GetAll()
        {
            semaphoreSlim.Wait();
            try
            {
                return lastData;
            }
            finally
            {
                semaphoreSlim.Release();
            }
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
            computer.Accept(visitor);
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

        public void UpdateSensors()
        {
            Computer computer = getDefaultComputer();
            computer.Open();
            computer.Accept(visitor);

            List<ISensor> sensors = [];
            foreach (IHardware hardware in computer.Hardware)
            {
                foreach (IHardware subhardware in hardware.SubHardware)
                {
                    foreach (ISensor sensor in subhardware.Sensors)
                    {
                        sensors.Add(sensor);
                    }
                }

                foreach (ISensor sensor in hardware.Sensors)
                {
                    sensors.Add(sensor);
                }
            }

            computer.Close();

            semaphoreSlim.Wait();
            try
            {
                lastData = sensors;
            }
            finally
            {
                semaphoreSlim.Release();
            }
        }

        private Computer getDefaultComputer()
        {
            return new Computer
            {
                IsCpuEnabled = true,
                IsGpuEnabled = true,
                IsMemoryEnabled = false,
                IsMotherboardEnabled = true,
                IsControllerEnabled = false,
                IsNetworkEnabled = false,
                IsStorageEnabled = false
            };
        }
    }
}
