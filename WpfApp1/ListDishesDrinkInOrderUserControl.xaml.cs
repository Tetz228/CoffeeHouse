using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;

namespace WpfApp1
{
    public partial class ListDishesDrinkInOrderUserControl : System.Windows.Controls.UserControl
    {
        private readonly ActionsOrders actionsOrders;

        public static decimal SumOrder { get; set; }

        private int IdOrder { get; }

        public ListDishesDrinkInOrderUserControl(int idOrder)
        {
            InitializeComponent();

            actionsOrders = new ActionsOrders();
            IdOrder = idOrder;

            FillDataDrid();
        }

        public void FillDataDrid()
        {
            DataGridOrderingDishes.ItemsSource = actionsOrders.OutputOrdering_dishes(IdOrder);
        }

        private void DataGridOrderingDishes_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DataGridOrderingDishes.SelectedItem = null;
        }

        public void ConfOrder()
        {
            if (DataGridOrderingDishes.Items.Count != 0)
            {
                actionsOrders.AddSumOrder(IdOrder, SumOrder);
                SumOrder = 0;

                Window.GetWindow(this).Close();
            }
            else
                System.Windows.Forms.MessageBox.Show("Ошибка! В заказе отсутствуют блюда!", "Нет блюд в заказе", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void AddDish()
        {
            AddDishWindow addDishAndDrinkWindow = new AddDishWindow(IdOrder);
            addDishAndDrinkWindow.ShowDialog();

            FillDataDrid();
        }
    }
}
