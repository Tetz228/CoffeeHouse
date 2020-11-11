using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    public partial class AddDishAndDrinkWindow : Window
    {
        private ActionsOrders actionsOrders = new ActionsOrders();

        private int IdOrder { get; }

        public AddDishAndDrinkWindow(int idOrder)
        {
            InitializeComponent();
            IdOrder = idOrder;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ComboBoxTypesDishes.DataContext = actionsOrders.FillingComboBoxTypesDishes();
            ComboBoxTypesDrinks.DataContext = actionsOrders.FillingComboBoxTypesDrinks();
            ComboBoxDishes.DataContext = actionsOrders.FillingComboBoxDishes();
            ComboBoxDrinks.DataContext = actionsOrders.FillingComboBoxDrinks();

            ComboBoxTypesDishes.SelectedIndex += 1;
            ComboBoxTypesDrinks.SelectedIndex += 1;
        }

        private void ComboBoxTypesDishes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxDishes.DataContext = actionsOrders.OutputByTypesDishes((int)ComboBoxTypesDishes.SelectedValue);
            ComboBoxDishes.SelectedIndex += 1;
        }

        private void ComboBoxTypesDrinks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxDrinks.DataContext = actionsOrders.OutputByTypesDrinks((int)ComboBoxTypesDrinks.SelectedValue);
            ComboBoxDrinks.SelectedIndex += 1;
        }

        private void ButtonСonfirm_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new CafeEntities())
            {
                var sql = db.Status_dish.Where(status => status.Name == "Не готово").FirstOrDefault();

                Dictionary<string, int> infoDisheAndDrinkInOrder = new Dictionary<string, int>
                {
                    { "dish", (int)ComboBoxDishes.SelectedValue },
                    { "status", sql.ID},
                    { "countDish", Convert.ToInt32(TextBoxCountDishes.Text) },
                    { "drink", (int)ComboBoxDrinks.SelectedValue },
                    { "countDrink", Convert.ToInt32(TextBoxCountDrink.Text) },
                    { "idOrder", IdOrder }
                };

                actionsOrders.AddOrder_dish(infoDisheAndDrinkInOrder, out decimal sum);

                ListDishesAndDrinksInOrderWindow.SumOrder += sum;

                Close();
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
