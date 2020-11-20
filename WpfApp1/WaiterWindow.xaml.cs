using System.Windows;

namespace WpfApp1
{
    public partial class WaiterWindow : Window
    {
        private readonly ActionsOrders actionsOrders;

        private readonly OrdersUserControl ordersUserControl; 

        private int IdUser { get; }

        public WaiterWindow(int idUser)
        {
            InitializeComponent();

            IdUser = idUser;
            actionsOrders = new ActionsOrders(idUser);
            ordersUserControl = new OrdersUserControl(idUser);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MainControl.Content = ordersUserControl;
            MenuItemUser.Header = actionsOrders.GettingLFMEmployee();
        }

        private void MenuItemAddOrder_Click(object sender, RoutedEventArgs e)
        {
            AddOrderWindow addOrderWindow = new AddOrderWindow(IdUser);
            addOrderWindow.ShowDialog();

            ordersUserControl.UpdateDataGrid();
        }

        private void MenuItemLogOutAccount_Click(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();            
            authWindow.Show();

            Close();
        }

        private void MenuItemProfile_Click(object sender, RoutedEventArgs e)
        {                                                              
            MyProfileWindow myProfile = new MyProfileWindow(IdUser,"Официант");
            myProfile.ShowDialog();
        }

        private void MenuItemExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MenuItemCashOrder_Click(object sender, RoutedEventArgs e)
        {
            ordersUserControl.GoToCashOrderWindow();
        }

        private void MenuItemReportShift_Click(object sender, RoutedEventArgs e)
        {
            ShiftReportWindow shiftOrderWindow = new ShiftReportWindow(IdUser);
            shiftOrderWindow.ShowDialog();
        }

        private void MenuItemMyOrders_Click(object sender, RoutedEventArgs e)
        {
            ordersUserControl.FilterMyOrders();

            Title = "Окно официанта -> Мои заказы";
        }

        private void MenuItemAllOrders_Click(object sender, RoutedEventArgs e)
        {
            ordersUserControl.UpdateDataGrid();

            Title = "Окно официанта -> Список всех заказов";
        }

        private void MenuItemShiftOrders_Click(object sender, RoutedEventArgs e)
        {
            ordersUserControl.FilterShiftOrders();

            Title = "Окно официанта -> Заказы за смену";
        }
    }
}
