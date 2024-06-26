﻿using LibreHardwareMonitor.Hardware;

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
            Console.WriteLine(sensor.ToString());
        }
        public void VisitParameter(IParameter parameter) { }
    }
}
