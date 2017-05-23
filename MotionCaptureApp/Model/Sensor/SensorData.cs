using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotionCaptureApp.Model.Sensor
{
    public class SensorData : INotifyPropertyChanged
    {
        public SensorData(string id, double x, double y, double z, double h, int battery)
        {
            ID = id;
            X = x;
            Y = y;
            Z = z;
            H = h;
            Battery = battery;
        }

        private string id;
        public string ID { get { return this.id; } set { this.id = value; OnPropertyChanged("ID"); } }
        private double x;
        public double X { get { return this.x; } set { this.x = value; OnPropertyChanged("X"); } }
        private double y;
        public double Y { get { return this.y; } set { this.y = value; OnPropertyChanged("Y"); } }
        private double z;
        public double Z { get { return this.z; } set { this.z = value; OnPropertyChanged("Z"); } }
        private double h;
        public double H { get { return this.h; } set { this.h = value; OnPropertyChanged("H"); } }
        private int battery;
        public int Battery { get { return this.battery; } set { this.battery = value; OnPropertyChanged("Battery"); } }

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
