using LibreHardwareMonitor.Hardware;
using LibreHardwareMonitor.Hardware.Cpu;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace TemperatureMonitor.Monitor
{
    internal class SnapMonitor
    {
        //private static SemaphoreSlim semaphoreSlim = new SemaphoreSlim(1, 1);

        public const string sensorTemperature = "Temperature";
        public const string sensorLoad = "Load";
        public const string sensorFan = "Fan";
        public const string sensorControl = "Control";

        private readonly UpdateVisitor visitor;
        private Thread? t;
        //private List<ISensor> lastData;
        private List<ISensorSubscriber> subscribers;
        private bool shouldRun = true;
        private int sleepInterval = 100;
        public SnapMonitor()
        {
            visitor = new UpdateVisitor();
            t = GetNewThread();
            //lastData = [];
            subscribers = [];
        }

        public void Start()
        {
            t ??= GetNewThread();
            t.Start();
        }

        public void Stop()
        {
            sleepInterval = 1;
            shouldRun = false;
            t?.Join();
            t = null;
        }

        public void AddSubscriber(ISensorSubscriber subscriber)
        {
            subscribers.Add(subscriber);
        }

        public void RemoveSubscriber(ISensorSubscriber subscriber) {
            subscribers.Remove(subscriber);
        }

        public ISensor? GetSensorById(string id)
        {
            Computer computer = GetDefaultComputer();
            computer.Open();
            computer.Accept(visitor);

            List<Task<ISensor?>> tasks = new();

            Parallel.ForEach(computer.Hardware, hw => {

                Parallel.ForEach(hw.SubHardware, subHw => {
                    tasks.Add(TryGetSensor(subHw.Sensors, id));
                });

                tasks.Add(TryGetSensor(hw.Sensors, id));
            });

            ConfiguredTaskAwaitable<ISensor?[]> awaitable = Task.WhenAll(tasks).ConfigureAwait(continueOnCapturedContext: false);

            ISensor?[]? awaitableResult = awaitable.GetAwaiter().GetResult();

            computer.Close();

            if (awaitableResult == null)
            {
                return null;
            }

            return awaitableResult.OfType<ISensor>().FirstOrDefault();
        }

        private async Task<ISensor?> TryGetSensor(ISensor[] sensors, string id)
        {
            ISensor? foundSensor = null;
            await Task.Run(() =>
            {
                Parallel.ForEach(sensors, (sensor, state) =>
                {
                    if (sensor.Identifier.ToString() == id)
                    {
                        foundSensor = sensor;
                        state.Break();
                    }
                });
                //return foundSensor;
            }).ConfigureAwait(continueOnCapturedContext: false);
            return foundSensor;
        }

        public List<ISensor> GetReadings()
        {
            return LoopAll();
        }

        private List<ISensor> LoopAll()
        {
            Computer computer = GetDefaultComputer();
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

            return sensors;
        }
        private void RunThread()
        {
            while (shouldRun)
            {
                //Debug.WriteLine("Updating sensors...");
                List<ISensor> data = LoopAll();
                subscribers.ForEach(sub => {
                    sub.OnDataUpdated(data);
                });

                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(sleepInterval);
                }
            }
        }
        /*
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
        */
        private Thread GetNewThread()
        {
            return new Thread(new ThreadStart(this.RunThread));
        }
        private Computer GetDefaultComputer()
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
