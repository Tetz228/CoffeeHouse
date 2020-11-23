using System;
using System.Windows.Forms;
using System.Windows.Input;

namespace WpfApp1
{
    public partial class OrdersUserControl : System.Windows.Controls.UserControl
    {
        private readonly ActionsOrders actionsOrders;

        private string PostName { get; }

        public OrdersUserControl(int idUser, string postName)
        {
            InitializeComponent();

            PostName = postName;
            actionsOrders = new ActionsOrders(idUser);
            DataGridOrders.ItemsSource = actionsOrders.OutputOrders();
        }

        // Официант\повар
        private void DataGridOrders_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (DataGridOrders.SelectedItem != null)
            {
                Order selectedOrder = DataGridOrders.SelectedItem as Order;

                if (PostName == "Официант")
                    if (selectedOrder.Status_orders.Name == "Принят")
                    {
                        EditOrderWindow editOrder = new EditOrderWindow(selectedOrder, actionsOrders.GettingIdUser());
                        editOrder.ShowDialog();

                        DataGridOrders.ItemsSource = actionsOrders.OutputOrders();
                    }
                if (PostName == "Повар")
                {
                    ListDishesDrinksInOrderWindow listDishesDrinksInOrderWindow = new ListDishesDrinksInOrderWindow(selectedOrder.ID, PostName);
                    listDishesDrinksInOrderWindow.ShowDialog();
                }
            }
        }

        public void ChangeStatusDish()
        {
            if (DataGridOrders.SelectedItem != null)
            {
                Order selectedOrder = DataGridOrders.SelectedItem as Order;

                ListDishesDrinksInOrderWindow listDishesDrinksInOrderWindow = new ListDishesDrinksInOrderWindow(selectedOrder.ID, PostName);
                listDishesDrinksInOrderWindow.ShowDialog();
            }
        }

        private void DataGridOrders_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DataGridOrders.SelectedItem = null;
        }

        #region Официант
        public void UploadOrders()
        {
            DataGridOrders.ItemsSource = actionsOrders.OutputOrders();
        }

        public void FilterOnlyMyOrders()
        {
            DataGridOrders.ItemsSource = actionsOrders.MyOrders();
        }

        public void FilterShiftOrders()
        {
            DataGridOrders.ItemsSource = actionsOrders.OutputOrdersShift();
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
                    CashOrderWindow cashOrderWindow = new CashOrderWindow(selectedOrder.ID, selectedOrder.Order_price, paymentType.Type, PostName);
                    cashOrderWindow.ShowDialog();
                }
            }
            else
                MessageBox.Show("Ошибка! Выберете заказ из списка.", "Заказ не выбран.", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ShiftReport(DateTime? date)
        {
            DataGridOrders.ItemsSource = actionsOrders.ShiftReport(date);
        }
        #endregion
    }
}
