using System.Windows;

namespace WpfApp1
{
    public partial class CashOrderWindow : Window
    {
        private decimal Sum { get; }
        private string TypePayment { get; }

        private readonly ListDishesInOrderUserControl list;

        public CashOrderWindow(int idOrder, decimal sum, string typePayment, string postName)
        {
            InitializeComponent();

            Sum = sum;
            TypePayment = typePayment;
            list = new ListDishesInOrderUserControl(idOrder, postName);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MainControl.Content = list;
            TotalSum.Content += Sum + " руб.";
            PaymentType.Content += TypePayment;
        }

        private void ButtonOK_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }  
    }
}
