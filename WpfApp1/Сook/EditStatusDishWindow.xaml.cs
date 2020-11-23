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

namespace WpfApp1.Сook
{
    public partial class EditStatusDishWindow : Window
    {
        private readonly Ordering_dishes order_Dish;

        private readonly ActionsOrders actionsOrders = new ActionsOrders();

        public EditStatusDishWindow(Ordering_dishes ordering_Dishes)
        {
            InitializeComponent();

            order_Dish = ordering_Dishes;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ComboBoxStatusDishes.ItemsSource = actionsOrders.FillingComboBoxStatusDishes();

            ComboBoxStatusDishes.SelectedValue = order_Dish.Fk_status_dish;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ButtonСonfirm_Click(object sender, RoutedEventArgs e)
        {
            actionsOrders.UpdateStatusDish(order_Dish.ID, (int)ComboBoxStatusDishes.SelectedValue);

            Close();
        }
    }
}
