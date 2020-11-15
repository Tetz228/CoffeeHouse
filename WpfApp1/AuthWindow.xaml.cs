using System.Windows;

namespace WpfApp1
{
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            ActionsUsers actionsUser = new ActionsUsers();

            (bool existUser, int idUser) = actionsUser.SearchUser(TextBoxLogin.Text = "l", PasswordBoxPassword.Password = "p");

            if (existUser)
                switch (actionsUser.CountPostAndTheirNames())
                {
                    case "Администратор":
                        //AdminWindow admin = new AdminWindow(user.userId);
                        //admin.Show();
                        //Close();
                        break;
                    case "Официант":
                        WaiterWindow waiter = new WaiterWindow(idUser);
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

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
