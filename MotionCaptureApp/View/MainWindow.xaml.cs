using MotionCaptureApp.View.File;
using MotionCaptureApp.View.Setting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MotionCaptureApp
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void openNewProjectWindow(object sender, RoutedEventArgs e)
        {
            NewProjectWindow npw = new NewProjectWindow();
            npw.Owner = this;
            npw.Show();
        }

        private void openSensorSettingWindow(object sender, RoutedEventArgs e)
        {
            SensorSettingWindow ssw = new SensorSettingWindow();
            ssw.Owner = this;
            ssw.Show();
        }
    }
}
