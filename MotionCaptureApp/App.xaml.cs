using MotionCaptureApp.Model.Sensor;
using MotionCaptureApp.Tool.DB;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MotionCaptureApp
{
    /// <summary>
    /// App.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class App : Application
    {
        public DBConnectionManager DBConnection { get; set; }

        public App()
        {
            DBConnection = new DBConnectionManager(Environment.CurrentDirectory);
            
        }
    }
}
