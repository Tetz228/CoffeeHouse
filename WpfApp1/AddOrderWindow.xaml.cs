﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace WpfApp1
{
    public partial class AddOrderWindow : Window
    {
        private Order order;

        public AddOrderWindow()
        {
            InitializeComponent();
        }

        public AddOrderWindow(Order order)
        {
            InitializeComponent();

            this.order = new Order();

            this.order = order;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ActionsOrders actionsOrders = new ActionsOrders();

            if (order == null)
            {
                ComboBoxTables.DataContext = actionsOrders.FillingComboBoxTables();
                ComboBoxStatusOrders.DataContext = actionsOrders.FillingComboBoxStatusOrders();

                using (var db = new CafeEntities())
                {
                    var sql = db.Status_orders.Where(status => status.Name == "Не оплачен").FirstOrDefault();

                    ComboBoxTables.SelectedIndex += 1;
                    ComboBoxStatusOrders.SelectedValue = sql.ID;
                    ComboBoxStatusOrders.IsEnabled = false;
                }
            }
            
            else
            {
                ComboBoxTables.DataContext = actionsOrders.FillingComboBoxTables();
                ComboBoxStatusOrders.DataContext = actionsOrders.FillingComboBoxStatusOrders();

                ComboBoxTables.SelectedValue = order.Table.Table_number;
                ComboBoxStatusOrders.SelectedValue = order.Status_orders.ID;
                TextBoxCountPeople.Text = order.Count_person.ToString();

                ComboBoxTables.IsEnabled = false;
                TextBoxCountPeople.IsEnabled = false;
            }
        }

        private void ButtonConfirm_Click(object sender, RoutedEventArgs e)
        {
            ActionsOrders actionsOrders = new ActionsOrders();

            if (order == null)
            {                
                Dictionary<string, int> infoOrder = new Dictionary<string, int>();
                infoOrder.Add("table", (int)ComboBoxTables.SelectedValue);
                infoOrder.Add("status", (int)ComboBoxStatusOrders.SelectedValue);
                infoOrder.Add("people", Convert.ToInt32(TextBoxCountPeople.Text));

                actionsOrders.AddOrder(infoOrder, out int idOrder);

                ListDishesAndDrinksInOrderWindow orderDetailsWindow = new ListDishesAndDrinksInOrderWindow(idOrder);

                Close();

                orderDetailsWindow.ShowDialog();
            }
            else
            {
                actionsOrders.UpdateOrder(order.ID, (int)ComboBoxStatusOrders.SelectedValue);

                Close();
            }
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
