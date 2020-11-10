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
    public partial class ReportShiftWindow : Window
    {
        private int IdEmp { get; set; }

        private ActionsOrders actionsOrders = new ActionsOrders();

        public ReportShiftWindow(int id)
        {
            InitializeComponent();
            IdEmp = id;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           DataGridOrders.ItemsSource = actionsOrders.OutputOrdersEmployee(IdEmp);
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
