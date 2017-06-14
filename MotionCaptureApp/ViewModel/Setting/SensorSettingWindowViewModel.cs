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
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace MotionCaptureApp.ViewModel.Setting
{
    public class SensorSettingWindowViewModel : ObservableObject
    {
        SensorConnectionManager sensorConnectionManager;
        public SensorSettingWindowViewModel()
        {
            sensorConnectionManager = new SensorConnectionManager(this);
            sensorConnectionManager.connection();
            
            Thread sensor = new Thread(sensorConnectionManager.getStreamRawData);
            sensor.Start();
        }

        private SensorData sensorData0;
        public SensorData SensorData0 { get { return sensorData0; } set { Set(ref sensorData0, value); } }
        private SensorData sensorData1;
        public SensorData SensorData1 {get { return sensorData1; } set { Set(ref sensorData1, value); } }
        private SensorData sensorData2;
        public SensorData SensorData2 {get { return sensorData2; } set { Set(ref sensorData2, value); } }
        private SensorData sensorData3;
        public SensorData SensorData3 {get { return sensorData3; } set { Set(ref sensorData3, value); } }
        private SensorData sensorData4;
        public SensorData SensorData4 {get { return sensorData4; } set { Set(ref sensorData4, value); } }
        private SensorData sensorData5;
        public SensorData SensorData5 {get { return sensorData5; } set { Set(ref sensorData5, value); } }

    }
}
