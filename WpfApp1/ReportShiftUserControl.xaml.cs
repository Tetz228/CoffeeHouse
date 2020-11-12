using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    public partial class ReportShiftUserControl : UserControl
    {
        private int IdEmp { get; set; }

        public ReportShiftUserControl(int id)
        {
            InitializeComponent();
            IdEmp = id;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ActionsOrders actionsOrders = new ActionsOrders();
            DataGridOrders.ItemsSource = actionsOrders.OutputReportShiftEmployee(IdEmp);
        }
    }
}
