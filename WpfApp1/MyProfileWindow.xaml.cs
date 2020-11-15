using System.Windows;
using System.Windows.Media;

namespace WpfApp1
{
    public partial class MyProfileWindow : Window
    {
        private int IdProfile { get; }

        private readonly ActionsUsers user;

        public MyProfileWindow(int id)
        {
            InitializeComponent();

            IdProfile = id;
            user = new ActionsUsers(IdProfile);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LabelLFM.Content = user.GettingLFMEmployee();
            LabelPost.Content = user.GettingSelectedPostEmployee();
            LabelPhone_number.Content = user.GettingPhoneNumberEmployee();
            LabelStatus.Content = user.GettingStatusName();
            Avatar.Source = user.GettingPhoto();
        }

        private void ButtonChangePhoto_Click(object sender, RoutedEventArgs e)
        {
            user.ChangePhoto(out ImageSource image);

            if (image != null)
                Avatar.Source = image;
        }

        private void ButtonOK_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
