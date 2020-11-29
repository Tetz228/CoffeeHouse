using System;
using System.Windows;

namespace WpfApp1
{
    public partial class ShiftReportWindow : Window
    {
        private readonly ListOrdersUserControl ordersUserControl;

        public ShiftReportWindow(int idUser, string postName)
        {
            InitializeComponent();

            ordersUserControl = new ListOrdersUserControl(idUser, postName);
            DatePickerDate.SelectedDate = DateTime.Now;

            if (postName == "Администратор")
                Title = "Отчет о заказах";
            else
                Title = "Отчёт официанта";
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
