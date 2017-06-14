using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotionCaptureApp.Model.Sensor
{
    public class SensorData
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
        public string ID { get { return this.id; } set { this.id = value; } }
        private double x;
        public double X { get { return this.x; } set { this.x = value;  } }
        private double y;
        public double Y { get { return this.y; } set { this.y = value;  } }
        private double z;
        public double Z { get { return this.z; } set { this.z = value;  } }
        private double h;
        public double H { get { return this.h; } set { this.h = value;  } }
        private int battery;
        public int Battery { get { return this.battery; } set { this.battery = value;  } }
        private string batteryStatusColor;
        public string BatteryStatusColor
        {
            get
            {
                if (Battery >= 80)
                    return "Green";
                else if (Battery >= 50)
                    return "Yello";
                else
                    return "Red";
            }
            set { this.batteryStatusColor = value; }
        }
    }
}
