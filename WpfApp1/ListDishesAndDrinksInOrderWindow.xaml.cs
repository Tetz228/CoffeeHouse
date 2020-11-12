using System.Windows;

namespace WpfApp1
{
    public partial class ListDishesAndDrinksInOrderWindow : Window
    {
        private int IdOrder { get; }

        public static decimal SumOrder { get; set; }

        private readonly ActionsOrders actionsOrders = new ActionsOrders();

        public ListDishesAndDrinksInOrderWindow(int idOrder)
        {
            InitializeComponent();

            IdOrder = idOrder;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataGridOrderingDishes.ItemsSource = actionsOrders.OutputOrdering_dishes(IdOrder);
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddDishAndDrinkWindow addDishAndDrinkWindow = new AddDishAndDrinkWindow(IdOrder);
            addDishAndDrinkWindow.ShowDialog();

            DataGridOrderingDishes.ItemsSource = actionsOrders.OutputOrdering_dishes(IdOrder);
        }

        private void ConfirmOrder_Click(object sender, RoutedEventArgs e)
        {
            actionsOrders.AddSumOrder(IdOrder, SumOrder);
            SumOrder = 0;

            Close();
        }

        private void DataGridOrderingDishes_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DataGridOrderingDishes.SelectedItem = null;
        }
    }
}
