using System.Windows;

namespace WpfApp1.Сook
{
    public partial class СookWindow : Window
    {
        private readonly OrdersUserControl orders;

        public int IdUser { get; }

        public СookWindow(int idUser)
        {
            InitializeComponent();

            IdUser = idUser;

            orders = new OrdersUserControl(idUser, "Повар");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MainControl.Content = orders;
        }

        private void MenuItemEditOrder_Click(object sender, RoutedEventArgs e)
        {
            orders.ChangeStatusDish();
        }
    }
}
