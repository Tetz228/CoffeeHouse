using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;

namespace WpfApp1
{
    public partial class AddDishAndDrinkWindow : Window
    {
        private readonly ActionsOrders actionsOrders = new ActionsOrders();

        private int IdOrder { get; }

        public AddDishAndDrinkWindow(int idOrder)
        {
            InitializeComponent();

            IdOrder = idOrder;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ComboBoxTypesDishes.ItemsSource = actionsOrders.FillingComboBoxTypesDishes();
            ComboBoxTypesDrinks.ItemsSource = actionsOrders.FillingComboBoxTypesDrinks();
            ComboBoxDishes.ItemsSource = actionsOrders.FillingComboBoxDishes();
            ComboBoxDrinks.ItemsSource = actionsOrders.FillingComboBoxDrinks();
        }

        private void ComboBoxTypesDishes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxTypesDishes.SelectedValue != null)
            {
                ComboBoxDishes.ItemsSource = actionsOrders.OutputByTypesDishes((int)ComboBoxTypesDishes.SelectedValue);
                ComboBoxDishes.SelectedIndex += 1;
            }
        }

        private void ComboBoxTypesDrinks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxTypesDrinks.SelectedValue != null)
            {
                ComboBoxDrinks.ItemsSource = actionsOrders.OutputByTypesDrinks((int)ComboBoxTypesDrinks.SelectedValue);
                ComboBoxDrinks.SelectedIndex += 1;
            }
        }

        private void ButtonСonfirm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Dictionary<string, int> infoDisheDrinkInOrder = new Dictionary<string, int>
                {
                     { "dish", (int)ComboBoxDishes.SelectedValue },
                     { "countDish", Convert.ToInt32(TextBoxCountDishes.Text) },
                     { "drink", (int)ComboBoxDrinks.SelectedValue },
                     { "countDrink", Convert.ToInt32(TextBoxCountDrinks.Text) },
                     { "idOrder", IdOrder }
                };

                actionsOrders.AddOrder_dish(infoDisheDrinkInOrder, out decimal sum);

                ListDishesDrinksInOrderWindow.SumOrder = sum;

                Close();
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Ошибка при добавлении блюда или напитка в заказ.", "Ошибка! Некорректный ввод!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ChechBoxDrink_Checked(object sender, RoutedEventArgs e)
        {
            ComboBoxTypesDrinks.IsEnabled = true;
            ComboBoxDrinks.IsEnabled = true;
            TextBoxCountDrinks.IsEnabled = true;

            TextBoxCountDrinks.Text = "1";
            ComboBoxTypesDrinks.SelectedIndex += 1;
        }

        private void ChechBoxDrink_Unchecked(object sender, RoutedEventArgs e)
        {
            ComboBoxTypesDrinks.IsEnabled = false;
            ComboBoxDrinks.IsEnabled = false;
            TextBoxCountDrinks.IsEnabled = false;

            TextBoxCountDrinks.Text = "";
            ComboBoxDrinks.SelectedIndex = -1;
            ComboBoxTypesDrinks.SelectedIndex = -1;
        }

        private void ChechBoxDish_Checked(object sender, RoutedEventArgs e)
        {
            ComboBoxTypesDishes.IsEnabled = true;
            ComboBoxDishes.IsEnabled = true;
            TextBoxCountDishes.IsEnabled = true;

            TextBoxCountDishes.Text = "1";
            ComboBoxTypesDishes.SelectedIndex += 1;
        }

        private void ChechBoxDish_Unchecked(object sender, RoutedEventArgs e)
        {
            ComboBoxTypesDishes.IsEnabled = false;
            ComboBoxDishes.IsEnabled = false;
            TextBoxCountDishes.IsEnabled = false;

            TextBoxCountDishes.Text = "";
            ComboBoxDishes.SelectedIndex = -1;
            ComboBoxTypesDishes.SelectedIndex = -1;
        }
    }
}
