using MotionCaptureApp.Model.Sensor;
using MotionCaptureApp.ViewModel.Setting;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace MotionCaptureApp.Tool.Sensor
{
    public class SensorConnectionManager
    {
        private SerialPort sp;
        private volatile bool stopGetDataFlag = true;
        private SensorSettingWindowsViewModel sensor;

        public SensorConnectionManager(SensorSettingWindowsViewModel sensor)
        {
            this.sensor = sensor;

            sp = new SerialPort();
            sp.PortName = "COM3";
            sp.BaudRate = 921600;
            sp.DataBits = 8;
            sp.Parity = Parity.None;
            sp.StopBits = StopBits.One;

            MessageBox.Show("connected");
        }

        public void connection()
        {
            sp.Open();
        }

        public void disconnection()
        {
            sp.Close();
        }

        public void getStreamRawData()
        {
            while (stopGetDataFlag)
            {
                string rawData = sp.ReadLine();
                Console.WriteLine(rawData);
                string[] parseData = rawData.Split(',');
                SensorData sd = new SensorData(
                    parseData[0],
                    Convert.ToDouble(parseData[1]),
                    Convert.ToDouble(parseData[2]),
                    Convert.ToDouble(parseData[3]),
                    Convert.ToDouble(parseData[4]),
                    Convert.ToInt16(parseData[5])
                    );

                switch (sd.ID)
                {
                    case "100-0": sensor.SensorData0 = sd; break;
                    case "100-1": sensor.SensorData1 = sd; break;
                    case "100-2": sensor.SensorData1 = sd; break;
                    case "100-3": sensor.SensorData1 = sd; break;
                    case "100-4": sensor.SensorData1 = sd; break;
                }
                Thread.Sleep(100);
            }
        }

        public void stopGetData()
        {
            this.stopGetDataFlag = false;
        }

    }
}
