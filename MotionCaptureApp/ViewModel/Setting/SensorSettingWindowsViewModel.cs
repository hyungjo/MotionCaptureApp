using MotionCaptureApp.Model.Sensor;
using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.ComponentModel;
using MotionCaptureApp.Tool.Sensor;
using System.Threading;

namespace MotionCaptureApp.ViewModel.Setting
{
    public class SensorSettingWindowsViewModel : INotifyPropertyChanged
    {
        SensorConnectionManager sensorConnectionManager;
        public SensorSettingWindowsViewModel()
        {
            sensorConnectionManager = new SensorConnectionManager(this);
            sensorConnectionManager.connection();

            MessageBox.Show("Test");
            Thread sensor = new Thread(sensorConnectionManager.getStreamRawData);
            sensor.Start();
        }

        private SensorData sensorData0;
        public SensorData SensorData0 { get { return this.sensorData0; } set { this.sensorData0 = value; OnPropertyChanged("SensorData0"); } }
        private SensorData sensorData1;
        public SensorData SensorData1 { get { return this.sensorData1; } set { this.sensorData1 = value; OnPropertyChanged("SensorData1"); } }
        private SensorData sensorData2;
        public SensorData SensorData2 { get { return this.sensorData2; } set { this.sensorData2 = value; OnPropertyChanged("SensorData2"); } }
        private SensorData sensorData3;
        public SensorData SensorData3 { get { return this.sensorData3; } set { this.sensorData3 = value; OnPropertyChanged("SensorData3"); } }
        private SensorData sensorData4;
        public SensorData SensorData4 { get { return this.sensorData4; } set { this.sensorData4 = value; OnPropertyChanged("SensorData4"); } }
        private SensorData sensorData5;
        public SensorData SensorData5 { get { return this.sensorData5; } set { this.sensorData5 = value; OnPropertyChanged("SensorData5"); } }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler eventHandler = this.PropertyChanged;

            if (eventHandler != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
