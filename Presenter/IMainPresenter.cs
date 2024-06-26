﻿using LibreHardwareMonitor.Hardware;

namespace TemperatureMonitor.Presenter
{
    public interface IMainPresenter
    {
        public void OnAddTempButtonClicked();
        public void OnAddLoadButtonClicked();
        public void OnAddFanCtrlButtonClicked();
        public void OnAddFanRpmButtonClicked();
        public void OnRemoveButtonClicked();
        public void OnDataUpdated(Dictionary<string, List<ISensor>> sensorData);
        public void StopMonitor();
    }
}
