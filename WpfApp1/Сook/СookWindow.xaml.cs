using System.Windows;

namespace WpfApp1.Сook
{
    public partial class СookWindow : Window
    {
        private readonly ListOrdersUserControl orders;
        private readonly ActionsUsers actionsUsers;

        private string PostName { get; } = "Повар";

        public СookWindow(int idUser)
        {
            InitializeComponent();

            actionsUsers = new ActionsUsers(idUser);
            orders = new ListOrdersUserControl(idUser, PostName);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MainControl.Content = orders;
            MenuItemUser.Header = actionsUsers.GettingLFMEmployee();
        }

        private void MenuItemEditOrder_Click(object sender, RoutedEventArgs e)
        {
            orders.ChangeStatusDish();
        }

        private void MenuItemProfile_Click(object sender, RoutedEventArgs e)
        {
            MyProfileWindow myProfileWindow = new MyProfileWindow(actionsUsers.GettingIDUser(), PostName);
            myProfileWindow.ShowDialog();
        }

        private void MenuItemLogOutAccount_Click(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();

            Close();
        }

        private void MenuItemExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
