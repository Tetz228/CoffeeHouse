using System.Windows;
using System.Windows.Forms;

namespace WpfApp1
{
    public partial class ListDishesDrinksInOrderWindow : Window
    {
        private int IdOrder { get; }

        public static decimal SumOrder { get; set; }

        private readonly ActionsOrders actionsOrders;

        public ListDishesDrinksInOrderWindow(int idOrder)
        {
            InitializeComponent();

            IdOrder = idOrder;
            actionsOrders = new ActionsOrders();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataGridOrderingDishes.ItemsSource = actionsOrders.OutputOrdering_dishes(IdOrder);
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddDishWindow addDishAndDrinkWindow = new AddDishWindow(IdOrder);
            addDishAndDrinkWindow.ShowDialog();

            DataGridOrderingDishes.ItemsSource = actionsOrders.OutputOrdering_dishes(IdOrder);
        }

        private void ConfirmOrder_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridOrderingDishes.Items.Count != 0)
            {
                actionsOrders.AddSumOrder(IdOrder, SumOrder);
                SumOrder = 0;

                Close();
            }
            else
                System.Windows.Forms.MessageBox.Show("Ошибка! В заказе отсутствуют блюда!", "Нет блюд в заказе", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void DataGridOrderingDishes_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DataGridOrderingDishes.SelectedItem = null;
        }
    }
}
