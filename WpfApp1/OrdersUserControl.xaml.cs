using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfApp1
{
    public partial class OrdersUserControl : UserControl
    {
        private ActionsOrders actionsOrders = new ActionsOrders();

        public OrdersUserControl()
        {
            InitializeComponent();
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
        }
    }
}
