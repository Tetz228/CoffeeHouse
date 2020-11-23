using System.Windows;
using WpfApp1.Сook;

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

            (bool existUser, int idUser) = actionsUser.SearchUser(TextBoxLogin.Text = "lo", PasswordBoxPassword.Password = "pa");

            if (existUser)
                switch (actionsUser.CountPostAndTheirNames())
                {
                    case "Администратор":
                        //AdminWindow admin = new AdminWindow(idUser);
                        //admin.Show();
                        //Close();
                        break;
                    case "Официант":
                        WaiterWindow waiter = new WaiterWindow(idUser);
                        waiter.Show();
                        Close();
                        break;
                    case "Повар":
                        СookWindow cock = new СookWindow(idUser);
                        cock.Show();
                        Close();
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
