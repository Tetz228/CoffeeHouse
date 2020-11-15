using System.Windows;

namespace WpfApp1
{
    public partial class WaiterWindow : Window
    {
        private readonly ActionsOrders actionsOrders;

        private readonly OrdersUserControl ordersAndReportUserControl; 

        private int IdUser { get; }

        public WaiterWindow(int idUser)
        {
            InitializeComponent();

            IdUser = idUser;
            actionsOrders = new ActionsOrders(idUser);
            ordersAndReportUserControl = new OrdersUserControl(idUser);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MainControl.Content = ordersAndReportUserControl;
            MenuItemUser.Header = actionsOrders.GettingLFMEmployee();
        }

        private void MenuItemAddOrder_Click(object sender, RoutedEventArgs e)
        {
            AddOrderWindow addOrderWindow = new AddOrderWindow(IdUser);
            addOrderWindow.ShowDialog();

            ordersAndReportUserControl.UpdateUserControl();
        }

        private void MenuItemLogOutAccount_Click(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();            
            authWindow.Show();

            Close();
        }

        private void MenuItemProfile_Click(object sender, RoutedEventArgs e)
        {                                                              
            MyProfileWindow myProfile = new MyProfileWindow(IdUser, "Официант");
            myProfile.ShowDialog();
        }

        private void MenuItemExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        //Отчёты
        private void MenuItemCashOrder_Click(object sender, RoutedEventArgs e)
        {
            ordersAndReportUserControl.GoToCashOrderWindow();
        }

        private void MenuItemReportShift_Click(object sender, RoutedEventArgs e)
        {
            
        }

        //Фильтры
        private void MenuItemMyOrders_Click(object sender, RoutedEventArgs e)
        {
            //ordersAndReportUserControl
        }

        private void MenuItemShiftOrders_Click(object sender, RoutedEventArgs e)
        {
            ordersAndReportUserControl.FilterShiftOrders();
        }

        private void MenuItemAllOrders_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
