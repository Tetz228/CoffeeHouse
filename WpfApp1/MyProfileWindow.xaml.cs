using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Linq;
using System.Data.Entity;


namespace WpfApp1
{
    public partial class MyProfileWindow : Window
    {
        private int IdProfile { get; }

        private string Post { get; }

        public MyProfileWindow(int id, string post)
        {
            InitializeComponent();

            IdProfile = id;
            Post = post;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ActionsUser user = new ActionsUser(IdProfile);

            LabelLFM.Content = user.GettingLFMEmployee();
            LabelPost.Content = Post;
            LabelPhone_number.Content = user.GettingPhoneNumberEmployee();
            LabelStatus.Content = user.GettingStatusName();
            Avatar.Source = user.GettingPhoto();
        }

        private void ChangePhoto_Click(object sender, RoutedEventArgs e)
        {
            ActionsUser user = new ActionsUser(IdProfile);
            user.ChangePhoto(out ImageSource image);

            if (image != null)
                Avatar.Source = image;
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ChangePassword_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("В разработке");
        }
    }
}
