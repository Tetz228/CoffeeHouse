using System.Windows;

namespace WpfApp1
{
    public partial class ListDishesDrinksInOrderWindow : Window
    {
        private readonly ListDishesDrinkInOrderUserControl list;

        private string PostName { get; }

        public ListDishesDrinksInOrderWindow(int idOrder,string postName)
        {
            InitializeComponent();

            list = new ListDishesDrinkInOrderUserControl(idOrder, postName);
            PostName = postName;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (PostName == "Повар")
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
