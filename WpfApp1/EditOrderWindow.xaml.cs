using System.Windows;

namespace WpfApp1
{
    public partial class EditOrderWindow : Window
    {
        private readonly ActionsOrders actionsOrders;
        private readonly Order order;

        public EditOrderWindow(Order selectedOrder, int idUser)
        {
            InitializeComponent();

            order = selectedOrder;
            actionsOrders = new ActionsOrders(idUser);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ComboBoxTables.ItemsSource = actionsOrders.FillingComboBoxTables();
            ComboBoxStatusOrders.ItemsSource = actionsOrders.FillingComboBoxStatusOrders();

            ComboBoxTables.SelectedValue = order.Fk_table;
            ComboBoxStatusOrders.SelectedValue = order.Status_orders.ID;
            TextBoxCountPeople.Text = order.Count_person.ToString();

            ComboBoxTables.IsEnabled = false;
            TextBoxCountPeople.IsEnabled = false;
        }

        private void ButtonConfirm_Click(object sender, RoutedEventArgs e)
        {
            actionsOrders.UpdateStatusOrder(order.ID, (int)ComboBoxStatusOrders.SelectedValue);

            Close();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
