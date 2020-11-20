using System.Windows;

namespace WpfApp1
{
    public partial class ListDishesDrinksInOrderWindow : Window
    {
        private readonly ListDishesDrinkInOrderUserControl list;

        public ListDishesDrinksInOrderWindow(int idOrder)
        {
            InitializeComponent();
            list = new ListDishesDrinkInOrderUserControl(idOrder);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MainControl.Content = list;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            list.AddDish();
        }

        private void ConfirmOrder_Click(object sender, RoutedEventArgs e)
        {
            list.ConfOrder();
        }
    }
}
