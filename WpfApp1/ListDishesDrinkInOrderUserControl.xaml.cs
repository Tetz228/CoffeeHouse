using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using WpfApp1.Сook;

namespace WpfApp1
{
    public partial class ListDishesDrinkInOrderUserControl : System.Windows.Controls.UserControl
    {
        private readonly ActionsOrders actionsOrders;

        private int IdOrder { get; }
        private string PostName { get; }

        public ListDishesDrinkInOrderUserControl(int idOrder, string postName)
        {
            InitializeComponent();

            actionsOrders = new ActionsOrders();
            IdOrder = idOrder;
            PostName = postName;

            if (postName == "Повар" || postName == "Администратор")
                DataGridTextColumnStatusDish.Visibility = Visibility.Visible;

            UploadOrderingDishes();
        }

        public void UploadOrderingDishes()
        {
            DataGridOrderingDishes.ItemsSource = actionsOrders.OutputOrdering_dishes(IdOrder);
        }

        private void DataGridOrderingDishes_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DataGridOrderingDishes.SelectedItem = null;
        }

        // Подтвердить заказ
        public void ConfirmOrder()
        {
            if (DataGridOrderingDishes.Items.Count != 0)
            {
                if (PostName != "Повар")
                    actionsOrders.CalculationAndAddSumOrder(IdOrder);

                Window.GetWindow(this).Close();
            }
            else
                System.Windows.Forms.MessageBox.Show("Ошибка! В заказе отсутствуют блюда!", "Нет блюд в заказе", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Добавить блюдо в заказ
        public void AddDish()
        {
            AddDishWindow addDishAndDrinkWindow = new AddDishWindow(IdOrder);
            addDishAndDrinkWindow.ShowDialog();

            UploadOrderingDishes();
        }

        private void DataGridOrderingDishes_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (DataGridOrderingDishes.SelectedItem != null)
            {
                Ordering_dishes ordering_Dishes = DataGridOrderingDishes.SelectedItem as Ordering_dishes;

                if (PostName == "Повар")
                {
                    EditStatusDishWindow editStatusDishWindow = new EditStatusDishWindow(ordering_Dishes);
                    editStatusDishWindow.ShowDialog();

                    UploadOrderingDishes();
                }
            }
        }
    }
}
