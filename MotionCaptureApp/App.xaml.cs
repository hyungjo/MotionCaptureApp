using System;
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
        public string CurrentPath { get; set; }

        public App()
        {
            CurrentPath = Environment.CurrentDirectory;
        }
    }
}
