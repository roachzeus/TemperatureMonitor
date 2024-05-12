using LibreHardwareMonitor.Hardware;

namespace TemperatureMonitor.Monitor
{
    internal class OpenMonitor
    {
        public const string sensorTemperature = "Temperature";
        public const string sensorLoad = "Load";
        public const string sensorFan = "Fan";
        public const string sensorControl = "Control";

        private readonly Computer computer;
        private Thread? t = null;

        private Dictionary<string, List<ISensor>> sensorMap;
        private readonly List<INotifySubscriber> subscribers;

        private bool shouldRun = true;
        //private int sleepInterval = 100;
        private int sleepInterval = 50;

        public OpenMonitor()
        {
            computer = GetComputer();
            sensorMap = InitSensorMap();
            t = GetNewThread();
            subscribers = [];
        }

        public List<ISensor> Get(string type)
        {
            return sensorMap[type]; // TODO maybe use trygetvalue
            //return sensorMap.TryGetValue(type, out List<ISensor> sensors) ? sensors : [];
        }
        public List<ISensor> GetTemperatures()
        {
            return sensorMap[sensorTemperature];
        }
        public List<ISensor> GetLoads()
        {
            return sensorMap[sensorLoad];
        }
        public List<ISensor> GetFans()
        {
            return sensorMap[sensorFan];
        }
        public List<ISensor> GetControls()
        {
            return sensorMap[sensorControl];
        }
        public void Start()
        {
            computer.Open();
            computer.Accept(new UpdateVisitor());
            PopulateSensorsParallel();
            t ??= GetNewThread();
            t.Start();
        }
        public void Stop()
        {
            sleepInterval = 1;
            shouldRun = false;
            sensorMap.Clear();
            sensorMap = InitSensorMap();
            t?.Join();
            t = null;
            computer.Close();
        }
        private void Update()
        {
            Parallel.ForEach(computer.Hardware, hw => {

                Parallel.ForEach(hw.SubHardware, subHw => {
                    subHw.Update();
                });

                hw.Update();
            });

        }
        public void AddSubscriber(INotifySubscriber subscriber)
        {
            subscribers.Add(subscriber);
        }

        public void RemoveSubscriber(INotifySubscriber subscriber)
        {
            subscribers.Remove(subscriber);
        }
        private void RunThread()
        {
            while (shouldRun)
            {
                //Debug.WriteLine("Updating sensors...");
                Update();
                subscribers.ForEach(sub => {
                    sub.DataUpdated();
                });

                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(sleepInterval);
                }
            }
        }
        private void PopulateSensors()
        {
            Dictionary<string, List<ISensor>> localMap = InitSensorMap();
            foreach (IHardware hardware in computer.Hardware)
            {
                foreach (IHardware subhardware in hardware.SubHardware)
                {
                    foreach (ISensor sensor in subhardware.Sensors)
                    {
                        if (localMap.TryGetValue(sensor.SensorType.ToString(), out List<ISensor>? value))
                        {
                            value.Add(sensor);
                        }
                    }
                }
                foreach (ISensor sensor in hardware.Sensors)
                {
                    if (localMap.TryGetValue(sensor.SensorType.ToString(), out List<ISensor>? value))
                    {
                        value.Add(sensor);
                    }
                }
            }

            // TODO use semaphoreSlim?
            sensorMap = localMap;
        }

        private void PopulateSensorsParallel()
        {
            Dictionary<string, List<ISensor>> localMap = InitSensorMap();

            Parallel.ForEach(computer.Hardware, hw => {
                Parallel.ForEach(hw.SubHardware, subHw => {
                    Parallel.ForEach(subHw.Sensors, sensor =>
                    {
                        if (localMap.TryGetValue(sensor.SensorType.ToString(), out List<ISensor>? value))
                        {
                            value.Add(sensor);
                        }
                    });
                });

                Parallel.ForEach(hw.Sensors, sensor =>
                {
                    if (localMap.TryGetValue(sensor.SensorType.ToString(), out List<ISensor>? value))
                    {
                        value.Add(sensor);
                    }
                });
            });
            // TODO use semaphoreSlim?
            sensorMap = localMap;
        }
        private Thread GetNewThread()
        {
            return new Thread(new ThreadStart(this.RunThread));
        }
        private static Dictionary<string, List<ISensor>> InitSensorMap()
        {
            Dictionary<string, List<ISensor>> map = new();
            map.Add(sensorTemperature, new List<ISensor>());
            map.Add(sensorLoad, new List<ISensor>());
            map.Add(sensorControl, new List<ISensor>());
            map.Add(sensorFan, new List<ISensor>());
            return map;
        }
        private static Computer GetComputer()
        {
            return new Computer
            {
                IsCpuEnabled = true,
                IsGpuEnabled = true,
                IsMotherboardEnabled = true,
                //
                IsMemoryEnabled = false,
                IsControllerEnabled = false,
                IsNetworkEnabled = false,
                IsStorageEnabled = false,
                IsPsuEnabled = false,
                IsBatteryEnabled = false
            };
        }
    }
}
