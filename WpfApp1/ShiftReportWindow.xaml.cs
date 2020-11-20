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
