using LibreHardwareMonitor.Hardware;
using System.Diagnostics;

namespace TemperatureMonitor.Monitor
{
    internal class UpdateVisitor : IVisitor
    {
        public void VisitComputer(IComputer computer)
        {
            computer.Traverse(this);
        }
        public void VisitHardware(IHardware hardware)
        {
            hardware.Update();
            foreach (IHardware subHardware in hardware.SubHardware) subHardware.Accept(this);
        }
        public void VisitSensor(ISensor sensor)
        {
            Debug.WriteLine("Visited: " + sensor.Identifier.ToString());
        }
        public void VisitParameter(IParameter parameter) { }
    }
}
