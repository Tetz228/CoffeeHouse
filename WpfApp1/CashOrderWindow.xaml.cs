﻿using System.Windows;

namespace WpfApp1
{
    public partial class CashOrderWindow : Window
    {
        private int IdOrder { get; }

        private decimal Sum { get; }

        private string TypePayment { get; }

        private readonly ActionsOrders actionsOrders = new ActionsOrders();

        public CashOrderWindow(int idOrder, decimal sum, string typePayment)
        {
            InitializeComponent();
            IdOrder = idOrder;
            Sum = sum;
            TypePayment = typePayment;
        }

        private void ListView_Loaded(object sender, RoutedEventArgs e)
        {
            TotalSum.Content = "Итоговая сумма заказа: " + Sum + " руб.";
            PaymentType.Content = "Тип оплаты: " + TypePayment;
            ListViewDrinks.ItemsSource = ListViewDishes.ItemsSource = actionsOrders.OutputOrdering_dishes(IdOrder);
        }

        private void ButtonOK_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ButtonPrint_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
