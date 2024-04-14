using LibreHardwareMonitor.Hardware;
using System.Diagnostics;

namespace TemperatureMonitor.Monitor
{
    internal class Monitor
    {
        //private static SemaphoreSlim semaphoreSlim = new SemaphoreSlim(1, 1);

        public const string sensorTemperature = "Temperature";
        public const string sensorLoad = "Load";
        public const string sensorFan = "Fan";
        public const string sensorControl = "Control";

        private readonly UpdateVisitor visitor;
        private Thread? t;
        //private List<ISensor> lastData;
        private List<ISubscriber> subscribers;
        private bool shouldRun = true;
        private int sleepInterval = 100;
        public Monitor()
        {
            visitor = new UpdateVisitor();
            t = new Thread(new ThreadStart(this.RunThread));
            //lastData = [];
            subscribers = [];
        }
        public Monitor(UpdateVisitor visitor, Thread t)
        {
            this.visitor = visitor;
            this.t = t;
            //lastData = [];
            subscribers = [];
        }

        public void Start()
        {
            t.Start();
        }

        public void Stop()
        {
            sleepInterval = 1;
            shouldRun = false;
            //t.Join();
            //t = null;
        }

        public void AddSubscriber(ISubscriber subscriber)
        {
            subscribers.Add(subscriber);
        }

        public void RemoveSubscriber(ISubscriber subscriber) {
            subscribers.Remove(subscriber);
        }
        public List<ISensor> GetReadings()
        {
            return LoopAll();
        }

        private List<ISensor> LoopAll()
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

            return sensors;
        }
        private void RunThread()
        {
            while (shouldRun)
            {
                //Debug.WriteLine("Updating sensors...");
                subscribers.ForEach(sub => {
                    sub.OnDataUpdated(LoopAll());
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
