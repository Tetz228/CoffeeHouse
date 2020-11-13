using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfApp1
{
    public partial class OrdersAndReportUserControl : UserControl
    {
        private readonly ActionsOrders actionsOrders;

        private int IdUser { get; }

        public OrdersAndReportUserControl(int idUser)
        {
            InitializeComponent();

            IdUser = idUser;
            actionsOrders = new ActionsOrders(IdUser);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            DataGridOrders.ItemsSource = actionsOrders.OutputOrders();
        }

        private void DataGridOrders_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (DataGridOrders.SelectedItem != null)
            {
                Order order = DataGridOrders.SelectedItem as Order;

                AddOrderWindow addOrder = new AddOrderWindow(order, IdUser);
                addOrder.ShowDialog();

                DataGridOrders.ItemsSource = actionsOrders.OutputOrders();
            }            
        }

        private void DataGridOrders_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DataGridOrders.SelectedItem = null;
        }
        
        public void GoToReportShift()
        {            
            DataGridOrders.ItemsSource = actionsOrders.OutputReportShiftEmployee();
            DataGridOrders.IsEnabled = false;
        }

        public void GoToWaiterWindow()
        {
            DataGridOrders.ItemsSource = actionsOrders.OutputOrders();
            DataGridOrders.IsEnabled = true;
        }

        public void GoToCashOrderWindow()
        {            
            if (DataGridOrders.SelectedItem != null)
            {
                Order order = DataGridOrders.SelectedItem as Order;

            }
            else
            {
                MessageBox.Show("Выберите заказ для формирования приходно-кассового ордера");
            }
        }
    }
}
