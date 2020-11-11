using System.Windows;

namespace WpfApp1
{
    public partial class WaiterWindow : Window
    {
        private int IdEmployee { get; }

        private ActionsOrders actionsOrders;

        public WaiterWindow(int idEmp)
        {
            InitializeComponent();

            IdEmployee = idEmp;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            actionsOrders = new ActionsOrders(IdEmployee);

            DataGridOrders.ItemsSource = actionsOrders.OutputOrders();

            MenuItemUser.Header = actionsOrders.GettingLFMEmployee();
        }

        private void MenuItemLogOutAccount_Click(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();

            Close();
        }

        private void MenuItemProfile_Click(object sender, RoutedEventArgs e)
        {
            MyProfileWindow myProfile = new MyProfileWindow(IdEmployee, "Официант");

            myProfile.ShowDialog();
        }

        private void MenuItemExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddOrder_Click(object sender, RoutedEventArgs e)
        {
            AddOrderWindow addOrderWindow = new AddOrderWindow();

            addOrderWindow.ShowDialog();

            DataGridOrders.ItemsSource = actionsOrders.OutputOrders();
        }

        private void DataGridOrders_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (DataGridOrders.SelectedItem != null)
            {
                Order order = DataGridOrders.SelectedItem as Order;

                AddOrderWindow addOrder = new AddOrderWindow(order);
                addOrder.ShowDialog();

                DataGridOrders.ItemsSource = actionsOrders.OutputOrders();
                //Для админа\повара
                //ListDishesAndDrinksInOrderWindow listDishesAndDrinks = new ListDishesAndDrinksInOrderWindow(order.ID);
                //listDishesAndDrinks.ShowDialog();
            }
        }

        private void DataGridOrders_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DataGridOrders.SelectedItem = null;
        }
    }
}
