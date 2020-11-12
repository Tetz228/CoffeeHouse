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
            ActionsUsers actionsUser = new ActionsUsers();

            (bool userExist, int idUser) existAndIdUser = actionsUser.SearchUser(TextBoxLogin.Text = "l", PasswordBoxPassword.Password = "p");

            if (existAndIdUser.userExist)
                switch (actionsUser.CountPostAndTheirNames())
                {
                    case "Администратор":
                        //AdminWindow admin = new AdminWindow(user.userId);
                        //admin.Show();
                        //Close();
                        break;
                    case "Официант":
                        WaiterWindow waiter = new WaiterWindow(existAndIdUser.idUser);
                        waiter.Show();
                        Close();
                        break;
                    case "Повар":
                        //CockWindow cock = new CockWindow(user.userId)
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
