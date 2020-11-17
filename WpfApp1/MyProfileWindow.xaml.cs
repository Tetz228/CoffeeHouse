using System.Windows;
using System.Windows.Media;

namespace WpfApp1
{
    public partial class MyProfileWindow : Window
    {
        private int IdProfile { get; }

        private string SelectedPost { get;}

        private readonly ActionsUsers user;

        public MyProfileWindow(int id, string post)
        {
            InitializeComponent();

            IdProfile = id;
            SelectedPost = post;
            user = new ActionsUsers(IdProfile);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LabelLFM.Content = user.GettingLFMEmployee();
            LabelPost.Content = SelectedPost;
            LabelPhone_number.Content = user.GettingPhoneNumberEmployee();
            LabelStatus.Content = user.GettingStatusName();
            ImageAvatar.Source = user.GettingPhoto();
        }

        private void ButtonChangePhoto_Click(object sender, RoutedEventArgs e)
        {
            user.ChangePhoto(out ImageSource image);

            if (image != null)
                ImageAvatar.Source = image;
        }

        private void ButtonOK_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
