using System.Windows;
using System.Windows.Media;


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
            ActionsUsers user = new ActionsUsers(IdProfile);

            LabelLFM.Content = user.GettingLFMEmployee();
            LabelPost.Content = Post;
            LabelPhone_number.Content = user.GettingPhoneNumberEmployee();
            LabelStatus.Content = user.GettingStatusName();
            Avatar.Source = user.GettingPhoto();
        }

        private void ChangePhoto_Click(object sender, RoutedEventArgs e)
        {
            ActionsUsers user = new ActionsUsers(IdProfile);
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
