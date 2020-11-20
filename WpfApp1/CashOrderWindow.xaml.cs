using System.Windows;

namespace WpfApp1
{
    public partial class CashOrderWindow : Window
    {
        private decimal Sum { get; }

        private string TypePayment { get; }

        private readonly ListDishesDrinkInOrderUserControl list;

        public CashOrderWindow(int idOrder, decimal sum, string typePayment)
        {
            InitializeComponent();

            Sum = sum;
            TypePayment = typePayment;
            list = new ListDishesDrinkInOrderUserControl(idOrder);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MainControl.Content = list;
            list.FillDataDrid();

            TotalSum.Content += Sum + " руб.";
            PaymentType.Content += TypePayment;
        }

        private void ButtonOK_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }  
    }
}
