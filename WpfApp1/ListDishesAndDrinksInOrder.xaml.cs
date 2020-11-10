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
    public partial class ListDishesAndDrinksInOrder : Window
    {
        private int IdOrder { get;}
        private decimal Summ { get; set; }

        public ListDishesAndDrinksInOrder(int idOrder)
        {
            InitializeComponent();
            IdOrder = idOrder;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddDishAndDrinkWindow addDishAndDrinkWindow = new AddDishAndDrinkWindow(IdOrder);
            addDishAndDrinkWindow.ShowDialog();

            ActionsOrders actionsOrders = new ActionsOrders();
            DataGridOrderingDishes.ItemsSource = actionsOrders.OutputOrdering_dishes(IdOrder);
        }

        private void ConfirmOrder_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
