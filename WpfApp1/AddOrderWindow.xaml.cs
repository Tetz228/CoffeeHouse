using System;
using System.Collections.Generic;
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

            Dictionary<string, int> infoOrder = new Dictionary<string, int>();
            infoOrder.Add("table", (int)ComboBoxTables.SelectedValue);
            infoOrder.Add("status", (int)ComboBoxStatusOrders.SelectedValue);
            infoOrder.Add("people", Convert.ToInt32(TextBoxCountPeople.Text));

            actionsOrders.AddOrder(infoOrder, out int idOrder);

            ListDishesAndDrinksInOrder orderDetailsWindow = new ListDishesAndDrinksInOrder(idOrder);

            Close();

            orderDetailsWindow.ShowDialog();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
