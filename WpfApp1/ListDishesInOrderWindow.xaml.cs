using System.Windows;

namespace WpfApp1
{
    public partial class ListDishesInOrderWindow : Window
    {
        private readonly ListDishesInOrderUserControl list;

        private string PostName { get; }

        public ListDishesInOrderWindow(int idOrder,string postName)
        {
            InitializeComponent();

            list = new ListDishesInOrderUserControl(idOrder, postName);
            PostName = postName;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (PostName == "Повар" || PostName == "Администратор")
                MenuItemAddDish.Visibility = Visibility.Hidden;

            MainControl.Content = list;
        }

        private void MenuItemAddDish_Click(object sender, RoutedEventArgs e)
        {
            list.AddDish();
        }

        private void MenuItemConfirmOrder_Click(object sender, RoutedEventArgs e)
        {            
            list.ConfirmOrder();
        }
    }
}
