using System.Windows;

namespace WpfApp1
{
    public partial class WaiterWindow : Window
    {
        private readonly ActionsOrders actionsOrders;

        private readonly OrdersAndReportUserControl reportsProfileUserControl; 

        private int IdUser { get; }

        public WaiterWindow(int idUser)
        {
            InitializeComponent();

            IdUser = idUser;
            actionsOrders = new ActionsOrders(idUser);
            reportsProfileUserControl = new OrdersAndReportUserControl(idUser);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MainControl.Content = reportsProfileUserControl;
            MenuItemUser.Header = actionsOrders.GettingLFMEmployee();
        }

        private void AddOrder_Click(object sender, RoutedEventArgs e)
        {
            AddOrderWindow addOrderWindow = new AddOrderWindow(IdUser);
            addOrderWindow.ShowDialog();

            reportsProfileUserControl.GoToWaiterWindow();
        }

        private void MenuItemLogOutAccount_Click(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();            
            authWindow.Show();

            Close();
        }

        private void MenuItemProfile_Click(object sender, RoutedEventArgs e)
        {                                                               //Создать метод, который получает название должности
            MyProfileWindow myProfile = new MyProfileWindow(IdUser, "Официант");
            myProfile.ShowDialog();
        }

        private void MenuItemExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MenuItemReport_Click(object sender, RoutedEventArgs e)
        {
            reportsProfileUserControl.GoToReportShift();

            GoToWaiterWindow.Visibility = Visibility.Visible;
            AddOrder.Visibility = Visibility.Collapsed;
            MenuItemUser.Visibility = Visibility.Collapsed;
            MenuItemCashOrder.Visibility = Visibility.Collapsed;

            Title = "Окно официанта -> Отчет за смену";    
        }

        private void GoToWaiterWindow_Click(object sender, RoutedEventArgs e)
        {
            reportsProfileUserControl.GoToWaiterWindow();

            GoToWaiterWindow.Visibility = Visibility.Collapsed;
            AddOrder.Visibility = Visibility.Visible;
            MenuItemUser.Visibility = Visibility.Visible;
            MenuItemCashOrder.Visibility = Visibility.Visible;

            Title = "Окно официанта -> Список заказов";
        }

        private void MenuItemCashOrder_Click(object sender, RoutedEventArgs e)
        {
            reportsProfileUserControl.GoToCashOrderWindow();
            
        }
    }
}
