using System.Windows;

namespace WpfApp1
{
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            ActionsUser actionsUser = new ActionsUser();

            (bool existUser, int idUser) user = actionsUser.SearchUser(TextBoxLogin.Text = "l", PasswordBoxPassword.Password = "p");

            if (user.existUser)
                switch (actionsUser.CountPostAndTheirNames())
                {
                    case "Администратор":
                        //AdminWindow admin = new AdminWindow(user.idUser);
                        //admin.Show();
                        //Close();
                        break;
                    case "Официант":
                        WaiterWindow waiter = new WaiterWindow(user.idUser);
                        waiter.Show();
                        Close();
                        break;
                    case "Повар":
                        //CockWindow cock = new CockWindow(user.idUser)
                        //cock.Show();
                        //Close();
                        break;
                }
            else
                MessageBox.Show("Неверный логин или пароль", "Ошибка при авторизации!", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
