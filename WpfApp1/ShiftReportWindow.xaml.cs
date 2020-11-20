using System;
using System.Windows;

namespace WpfApp1
{
    public partial class ShiftReportWindow : Window
    {
        private OrdersUserControl ordersUserControl;

        public ShiftReportWindow(int idUser)
        {
            InitializeComponent();
            ordersUserControl = new OrdersUserControl(idUser);
            DatePickerDate.SelectedDate = DateTime.Now;
        }

        private void ButtonSearch_Click(object sender, RoutedEventArgs e)
        {
            ordersUserControl.ShiftReport(DatePickerDate.SelectedDate);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MainControl.Content = ordersUserControl;
            ordersUserControl.ShiftReport(DatePickerDate.SelectedDate);
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
