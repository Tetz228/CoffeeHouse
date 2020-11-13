using System.Windows;

namespace WpfApp1
{
    public partial class WaiterWindow : Window
    {
        private int IdUser { get; }

        public WaiterWindow(int idUser)
        {
            InitializeComponent();

            IdUser = idUser;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MainControl.Content = new OrdersReportsProfileUserControl(IdUser);          
        }
    }
}
