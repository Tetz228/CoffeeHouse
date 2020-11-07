using System.Windows;

namespace WpfApp1
{
    public partial class WaiterWindow : Window
    {
        private int IdEmployee { get; }

        public WaiterWindow(int idEmp)
        {
            InitializeComponent();

            IdEmployee = idEmp;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ActionsOrders actionsOrders = new ActionsOrders(IdEmployee);

            DataGridOrders.ItemsSource = actionsOrders.OutputOrders();
            MenuItemUser.Header = actionsOrders.GettingLFMEmployee();
        }

        private void MenuItemLogOutAccount_Click(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();

            Close();
        }

        private void MenuItemProfile_Click(object sender, RoutedEventArgs e)
        {
            MyProfileWindow myProfile = new MyProfileWindow(IdEmployee);

            myProfile.ShowDialog();
        }

        private void MenuItemExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
