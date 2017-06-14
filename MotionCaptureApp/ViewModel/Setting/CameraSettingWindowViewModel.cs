using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Accord.Video.FFMPEG;
using AForge.Video;
using AForge.Video.DirectShow;
using Microsoft.Win32;
using MotionCaptureApp.Tool.Camera;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace MotionCaptureApp.ViewModel.Setting
{
    class CameraSettingWindowViewModel : ObservableObject, IDisposable
    {
        public ObservableCollection<FilterInfo> VideoDevices { get; set; }
        private IVideoSource videoSource;
        private VideoFileWriter videoFileWriter;
        private bool isRecording;
        private DateTime? firstFrameTime;

        private BitmapImage _image;
        public BitmapImage Image { get { return _image; } set { Set(ref _image, value); } }

        private FilterInfo _currentDevice;
        public FilterInfo CurrentDevice { get { return _currentDevice; } set { Set(ref _currentDevice, value); } }

        public ICommand StartRecordingCommand { get; private set; }
        public ICommand StopRecordingCommand { get; private set; }

        public CameraSettingWindowViewModel()
        {
            VideoDevices = new ObservableCollection<FilterInfo>();

            StartRecordingCommand = new RelayCommand(StartRecording);
            StopRecordingCommand = new RelayCommand(StopRecording);

            GetVideoDevices();
            StartCamera();
        }

        private void GetVideoDevices()
        {
            var devices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo device in devices)
            {
                VideoDevices.Add(device);
            }
            if (VideoDevices.Any())
            {
                CurrentDevice = VideoDevices[0];
            }
            else
            {
                //MessageBox.Show("No webcam found");
            }
        }

        private void StartCamera()
        {
            var rectangle = new Rectangle();
            foreach (var screen in System.Windows.Forms.Screen.AllScreens)
            {
                rectangle = Rectangle.Union(rectangle, screen.Bounds);
            }
            videoSource = new ScreenCaptureStream(rectangle);
            videoSource.NewFrame += capturedWebCamNewFrame;
            videoSource.Start();

            /*
            if (CurrentDevice != null)
            {
                videoSource = new VideoCaptureDevice(CurrentDevice.MonikerString);
                videoSource.NewFrame += capturedWebCamNewFrame;
                videoSource.Start();
            }
            else
            {
                MessageBox.Show("Current device can't be null");
            }
            */
        }

        private void StopCamera()
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.Stop();
                videoSource.NewFrame -= capturedWebCamNewFrame;
                
            }
            Image = null;
            MessageBox.Show("캡쳐 종료");
        }

        private void StartRecording()
        {
            var dialog = new SaveFileDialog();
            dialog.FileName = "CapturedVideo";
            dialog.DefaultExt = ".avi";
            dialog.AddExtension = true;
            var dialogresult = dialog.ShowDialog();
            if (dialogresult != true)
            {
                return;
            }
            firstFrameTime = null;
            videoFileWriter = new VideoFileWriter();
            videoFileWriter.Open(dialog.FileName, (int)Math.Round(Image.Width, 0), (int)Math.Round(Image.Height, 0));
            isRecording = true;
        }

        private void StopRecording()
        {
            isRecording = false;
            videoFileWriter.Close();
            videoFileWriter.Dispose();
        }

        private void capturedWebCamNewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {
                if (isRecording)
                {
                    //TODO
                    //센서 데이터 수집 시간과 동기화
                    if (firstFrameTime != null)
                    {
                        videoFileWriter.WriteVideoFrame(eventArgs.Frame, DateTime.Now - firstFrameTime.Value);
                    }
                    else
                    {
                        videoFileWriter.WriteVideoFrame(eventArgs.Frame);
                        firstFrameTime = DateTime.Now;
                    }
                }
                using (var bitmap = (Bitmap)eventArgs.Frame.Clone())
                {
                    Image = bitmap.ToBitmapImage();
                }
                Image.Freeze(); // 메모리 누수 방지
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                StopCamera();
            }
        }

        public void Dispose()
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.Stop();
            }
            videoFileWriter?.Dispose();
        }
    }
}