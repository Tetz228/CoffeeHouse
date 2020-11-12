using System.Windows;
using System.Windows.Media;


namespace WpfApp1
{
    public partial class MyProfileWindow : Window
    {
        private int IdProfile { get; }

        private string Post { get; }

        ActionsUsers user;

        public MyProfileWindow(int id, string post)
        {
            InitializeComponent();

            IdProfile = id;
            Post = post;

            user = new ActionsUsers(IdProfile);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LabelLFM.Content = user.GettingLFMEmployee();
            LabelPost.Content = Post;
            LabelPhone_number.Content = user.GettingPhoneNumberEmployee();
            LabelStatus.Content = user.GettingStatusName();
            Avatar.Source = user.GettingPhoto();
        }

        private void ChangePhoto_Click(object sender, RoutedEventArgs e)
        {
            user.ChangePhoto(out ImageSource image);

            if (image != null)
                Avatar.Source = image;
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
