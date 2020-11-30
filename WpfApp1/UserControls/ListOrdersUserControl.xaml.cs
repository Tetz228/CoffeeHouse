using System;
using System.Windows.Forms;
using System.Windows.Input;

namespace WpfApp1
{
    public partial class ListOrdersUserControl : System.Windows.Controls.UserControl
    {
        private readonly ActionsOrders actionsOrders;

        private string PostName { get; }

        public ListOrdersUserControl(int idUser, string postName)
        {
            InitializeComponent();

            PostName = postName;
            actionsOrders = new ActionsOrders(idUser);
            
            UpdateOrders();
        }

        private void DataGridOrders_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ChangeOrder();
        }

        public void UpdateOrders()
        {
            DataGridOrders.ItemsSource = actionsOrders.OutputOrders();
        }

        public void ChangeOrder()
        {
            if (DataGridOrders.SelectedItem != null)
            {
                Order selectedOrder = DataGridOrders.SelectedItem as Order;

                if (PostName == "Официант")
                    if (selectedOrder.Status_orders.Name == "Принят")
                    {
                        EditOrderWindow editOrder = new EditOrderWindow(selectedOrder, actionsOrders.GettingIDUser(), PostName);
                        editOrder.ShowDialog();
                    }
                if (PostName == "Повар")
                {
                    ListDishesInOrderWindow listDishesDrinksInOrderWindow = new ListDishesInOrderWindow(selectedOrder.ID, PostName);
                    listDishesDrinksInOrderWindow.ShowDialog();
                }
                if (PostName == "Администратор")
                    if (selectedOrder.Status_orders.Name == "Принят")
                    {
                        EditOrderWindow editOrder = new EditOrderWindow(selectedOrder, actionsOrders.GettingIDUser(), PostName);
                        editOrder.ShowDialog();
                        
                        
                    }

                UpdateOrders();
            }
        }

        public void ChangeStatusDish()
        {
            if (DataGridOrders.SelectedItem != null)
            {
                Order selectedOrder = DataGridOrders.SelectedItem as Order;

                ListDishesInOrderWindow listDishesDrinksInOrderWindow = new ListDishesInOrderWindow(selectedOrder.ID, PostName);
                listDishesDrinksInOrderWindow.ShowDialog();
            }
        }

        private void DataGridOrders_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DataGridOrders.SelectedItem = null;
        }

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
    }
}
