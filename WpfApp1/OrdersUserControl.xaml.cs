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

        public void GoToCashOrderWindow()
        {
            if (DataGridOrders.SelectedItem != null)
            {
                Order selectedOrder = DataGridOrders.SelectedItem as Order;

                PaymentTypeWindow paymentType = new PaymentTypeWindow();
                paymentType.ShowDialog();

                if (paymentType.Type != null)
                {
                    CashOrderWindow cashOrderWindow = new CashOrderWindow(selectedOrder.ID, selectedOrder.Order_price, paymentType.Type);
                    cashOrderWindow.ShowDialog();
                }
            }
            else
                System.Windows.Forms.MessageBox.Show("Ошибка! Выберете заказ из списка.", "Заказ не выбран.", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void DataGridOrders_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (DataGridOrders.SelectedItem != null)
            {
                Order selectedOrder = DataGridOrders.SelectedItem as Order;

                if (selectedOrder.Status_orders.Name == "Принят")
                {
                    EditOrderWindow editOrder = new EditOrderWindow(selectedOrder, IdUser);
                    editOrder.ShowDialog();

                    DataGridOrders.ItemsSource = actionsOrders.OutputOrders();
                }
            }
        }

        private void DataGridOrders_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DataGridOrders.SelectedItem = null;
        }

        public void UpdateDataGrid()
        {
            DataGridOrders.ItemsSource = actionsOrders.OutputOrders();
        }

        public void FilterMyOrders()
        {
            DataGridOrders.ItemsSource = actionsOrders.MyOrders();
        }

        public void FilterShiftOrders()
        {
            DataGridOrders.ItemsSource = actionsOrders.OutputOrdersShift();
        }
    }
}
