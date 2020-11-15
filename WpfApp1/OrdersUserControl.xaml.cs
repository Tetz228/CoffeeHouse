using System.Windows;
using control = System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;

namespace WpfApp1
{
    public partial class OrdersUserControl : control.UserControl
    {
        private readonly ActionsOrders actionsOrders;

        private int IdUser { get; }

        public OrdersUserControl(int idUser)
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

        public void UpdateUserControl()
        {
            DataGridOrders.ItemsSource = actionsOrders.OutputOrders();
        }

        public void GoToCashOrderWindow()
        {
            if (DataGridOrders.SelectedItem != null)
            {
                Order order = DataGridOrders.SelectedItem as Order;

                CashOrderWindow cashOrderWindow = new CashOrderWindow(order.ID,order.Order_price);
                cashOrderWindow.ShowDialog();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Ошибка! Выберете заказ из списка.", "Заказ не выбран.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void FilterMyOrders()
        {

        }

        public void FilterShiftOrders()
        {
            DataGridOrders.ItemsSource = actionsOrders.OutputOrdersShift();
        }
    }
}
