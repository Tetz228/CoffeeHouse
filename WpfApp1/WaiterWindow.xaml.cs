using System.Windows;

namespace WpfApp1
{
    public partial class WaiterWindow : Window
    {
        private int IdEmployee { get; }

        private ActionsOrders actionsOrders;

        public WaiterWindow(int idEmp)
        {
            InitializeComponent();

            IdEmployee = idEmp;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            actionsOrders = new ActionsOrders(IdEmployee);
            OrderControl.Content = new OrdersUserControl();

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
            MyProfileWindow myProfile = new MyProfileWindow(IdEmployee, "Официант");
            myProfile.ShowDialog();
        }

        private void MenuItemExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddOrder_Click(object sender, RoutedEventArgs e)
        {
            AddOrderWindow addOrderWindow = new AddOrderWindow();
            addOrderWindow.ShowDialog();    
        }

        private void MenuItemReport_Click(object sender, RoutedEventArgs e)
        {
            OrderControl.Content = new ReportShiftUserControl(IdEmployee);

            GoToWaiterWindow.Visibility = Visibility.Visible;
            AddOrder.Visibility = Visibility.Collapsed;
            MenuItemUser.Visibility = Visibility.Collapsed;

            Title = "Окно официанта -> Отчет за смену";
        }

        private void GoToWaiterWindow_Click(object sender, RoutedEventArgs e)
        {
            OrderControl.Content = new OrdersUserControl();

            GoToWaiterWindow.Visibility = Visibility.Collapsed;
            AddOrder.Visibility = Visibility.Visible;
            MenuItemUser.Visibility = Visibility.Visible;  
            
            Title = "Окно официанта -> Список заказов";
        }
    }
}
