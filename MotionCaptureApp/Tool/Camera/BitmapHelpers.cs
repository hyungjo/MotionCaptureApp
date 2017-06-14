using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Media.Imaging;


namespace MotionCaptureApp.Tool.Camera
{
    static class BitmapHelpers
    {
        public static BitmapImage ToBitmapImage(this Bitmap bitmap)
        {
            BitmapImage bitmapImg = new BitmapImage();
            bitmapImg.BeginInit();
            MemoryStream ms = new MemoryStream();
            bitmap.Save(ms, ImageFormat.Bmp);
            ms.Seek(0, SeekOrigin.Begin);
            bitmapImg.StreamSource = ms;
            bitmapImg.EndInit();
            return bitmapImg;
        }
    }
}
