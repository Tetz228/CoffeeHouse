using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WpfApp1.Classes
{
    class ActionsPhoto
    {
        public void AddPhoto(out ImageSource image, out string wayToPhoto)
        {
            image = default;
            wayToPhoto = default;

            Microsoft.Win32.OpenFileDialog file = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "Картинки(*.JPG; *.PNG)| *.JPG; *.PNG",
                CheckFileExists = true,
                Title = "Выберете изображение"
            };

            if (file.ShowDialog() == true)
                image = new BitmapImage(new Uri(wayToPhoto = file.FileName));
        }
    }
}
