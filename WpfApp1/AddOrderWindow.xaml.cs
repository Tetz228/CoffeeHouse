using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Forms;

namespace WpfApp1
{
    public partial class AddOrderWindow : Window
    {
        private readonly ActionsOrders actionsOrders;

        private string PostName { get; }

        public AddOrderWindow(int idUser, string postName)
        {
            InitializeComponent();

            actionsOrders = new ActionsOrders(idUser);
            PostName = postName;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (var db = new CafeEntities())
            {
                var statusOrder = db.Status_orders.Where(status => status.Name == "Принят").FirstOrDefault();

                ComboBoxStatusOrders.ItemsSource = actionsOrders.FillingComboBoxStatusOrders();
                ComboBoxStatusOrders.SelectedValue = statusOrder.ID;
                ComboBoxStatusOrders.IsEnabled = false;
            }

            ComboBoxTables.ItemsSource = actionsOrders.FillingComboBoxTables(actionsOrders.GettingIDEmployee());
            ComboBoxTables.SelectedIndex += 1;
        }

        private void ButtonConfirm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Dictionary<string, int> infoOrder = new Dictionary<string, int>
                {
                     { "table", (int)ComboBoxTables.SelectedValue },
                     { "status", (int)ComboBoxStatusOrders.SelectedValue },
                     { "people", Convert.ToInt32(TextBoxCountPeople.Text) }
                };

                actionsOrders.AddOrder(infoOrder, out int idOrder);

                Close();

                ListDishesDrinksInOrderWindow orderDetailsWindow = new ListDishesDrinksInOrderWindow(idOrder, PostName);
                orderDetailsWindow.ShowDialog();
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Ошибка при добавлении заказа.", "Ошибка! Некорректный ввод!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
