using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
    public partial class EditOrderWindow : Window
    {
        private readonly ActionsOrders actionsOrders;
        private readonly Order selectedOrder;

        public EditOrderWindow(Order order, int idUser)
        {
            InitializeComponent();

            selectedOrder = order;

            actionsOrders = new ActionsOrders(idUser);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ComboBoxTables.ItemsSource = actionsOrders.FillingComboBoxTables();
            ComboBoxStatusOrders.ItemsSource = actionsOrders.FillingComboBoxStatusOrders();

            ComboBoxTables.SelectedValue = selectedOrder.Fk_table;
            ComboBoxStatusOrders.SelectedValue = selectedOrder.Status_orders.ID;
            TextBoxCountPeople.Text = selectedOrder.Count_person.ToString();

            ComboBoxTables.IsEnabled = false;
            TextBoxCountPeople.IsEnabled = false;
        }

        private void ButtonConfirm_Click(object sender, RoutedEventArgs e)
        {
            actionsOrders.UpdateStatusOrder(selectedOrder.ID, (int)ComboBoxStatusOrders.SelectedValue);

            Close();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
