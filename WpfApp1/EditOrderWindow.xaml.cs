using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Forms;

namespace WpfApp1
{
    public partial class EditOrderWindow : Window
    {
        private readonly ActionsOrders actionsOrders;
        private readonly Order order;

        private string PostName { get; }

        public EditOrderWindow(Order selectedOrder, int idUser, string postName)
        {
            InitializeComponent();

            order = selectedOrder;
            actionsOrders = new ActionsOrders(idUser);
            PostName = postName;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ComboBoxTables.ItemsSource = actionsOrders.FillingComboBoxTables();
            ComboBoxStatusOrders.ItemsSource = actionsOrders.FillingComboBoxStatusOrders();

            ComboBoxTables.SelectedValue = order.Fk_table;
            ComboBoxStatusOrders.SelectedValue = order.Status_orders.ID;
            TextBoxCountPeople.Text = order.Count_person.ToString();

            if (PostName == "Официант")
            {
                ComboBoxTables.IsEnabled = false;
                TextBoxCountPeople.IsEnabled = false;
            }
            else
            {
                ComboBoxTables.IsEnabled = true;
                TextBoxCountPeople.IsEnabled = true;
            }
        }

        private void ButtonConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (PostName == "Официант")
            {
                actionsOrders.UpdateStatusOrder(order.ID, (int)ComboBoxStatusOrders.SelectedValue);
            }
            else
            {
                try
                {
                    Dictionary<string, int> infoOrder = new Dictionary<string, int>
                    {
                         { "table", (int)ComboBoxTables.SelectedValue },
                         { "countPeople", Convert.ToInt32(TextBoxCountPeople.Text) },
                         { "status", (int)ComboBoxStatusOrders.SelectedValue },
                         { "idOrder", order.ID }
                    };

                    actionsOrders.UpdateOrder(infoOrder);
                }
                catch
                {
                    System.Windows.Forms.MessageBox.Show("Ошибка при редактировании заказа!", "Ошибка! Некорректный ввод!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            Close();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
