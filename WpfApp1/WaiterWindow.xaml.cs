using System.Windows;

namespace WpfApp1
{
    public partial class WaiterWindow : Window
    {
        private int IdEmployee { get; }

        public WaiterWindow(int idEmp)
        {
            InitializeComponent();

            IdEmployee = idEmp;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MainControl.Content = new OrdersUserControl(IdEmployee);          
        }
    }
}
