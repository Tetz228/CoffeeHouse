using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfApp1
{
    public partial class OrdersUserControl : UserControl
    {
        private ActionsOrders actionsOrders;

        private int IdEmployee { get; }

        public OrdersUserControl(int id)
        {
            InitializeComponent();
            IdEmployee = id;
            actionsOrders = new ActionsOrders(IdEmployee);
        }

        private void DataGridOrders_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (DataGridOrders.SelectedItem != null)
            {
                Order order = DataGridOrders.SelectedItem as Order;

                AddOrderWindow addOrder = new AddOrderWindow(order);
                addOrder.ShowDialog();

                DataGridOrders.ItemsSource = actionsOrders.OutputOrders();
            }
        }

        private void DataGridOrders_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DataGridOrders.SelectedItem = null;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            DataGridOrders.ItemsSource = actionsOrders.OutputOrders();
            MenuItemUser.Header = actionsOrders.GettingLFMEmployee();
        }

        private void AddOrder_Click(object sender, RoutedEventArgs e)
        {
            AddOrderWindow addOrderWindow = new AddOrderWindow();
            addOrderWindow.ShowDialog();
        }

        private void MenuItemLogOutAccount_Click(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            Window.GetWindow(this).Close();
            authWindow.Show();           
        }

        private void MenuItemProfile_Click(object sender, RoutedEventArgs e)
        {                                                               //Создать метод, который получает название должности
            MyProfileWindow myProfile = new MyProfileWindow(IdEmployee, "Официант");
            myProfile.ShowDialog();
        }

        private void MenuItemExit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void MenuItemReport_Click(object sender, RoutedEventArgs e)
        {
            DataGridOrders.ItemsSource = actionsOrders.OutputReportShiftEmployee(IdEmployee);
            
            GoToWaiterWindow.Visibility = Visibility.Visible;
            AddOrder.Visibility = Visibility.Collapsed;
            MenuItemUser.Visibility = Visibility.Collapsed;

            Window.GetWindow(this).Title = "Окно официанта -> Отчет за смену";

            DataGridOrders.IsEnabled = false;
        }

        private void GoToWaiterWindow_Click(object sender, RoutedEventArgs e)
        {
            DataGridOrders.ItemsSource = actionsOrders.OutputOrders();

            GoToWaiterWindow.Visibility = Visibility.Collapsed;
            AddOrder.Visibility = Visibility.Visible;
            MenuItemUser.Visibility = Visibility.Visible;  

            Window.GetWindow(this).Title = "Окно официанта -> Список заказов";

            DataGridOrders.IsEnabled = true;
        }
    }
}
