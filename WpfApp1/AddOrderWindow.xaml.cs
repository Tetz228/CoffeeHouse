using System.Windows;

namespace WpfApp1
{
    public partial class AddOrderWindow : Window
    {
        public AddOrderWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ActionsOrders actionsOrders = new ActionsOrders();

            ComboBoxTables.DataContext = actionsOrders.FillingComboBoxTables();
            ComboBoxStatusOrders.DataContext = actionsOrders.FillingComboBoxStatusOrders();

            ComboBoxTables.SelectedIndex += 1;
            ComboBoxStatusOrders.SelectedIndex += 1;
        }

        private void ButtonConfirm_Click(object sender, RoutedEventArgs e)
        {
            ActionsOrders actionsOrders = new ActionsOrders();

            actionsOrders.AddOrder((int)ComboBoxTables.SelectedValue, (int)ComboBoxStatusOrders.SelectedValue, TextBoxCountPeople.Text, out int idOrder);

            OrderDetailsWindow orderDetailsWindow = new OrderDetailsWindow(idOrder);

            Close();

            orderDetailsWindow.ShowDialog();
        }
    }
}
