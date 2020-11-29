using System.Windows;

namespace WpfApp1
{
    public partial class PaymentTypeWindow : Window
    {
        public string Type { get; set; }

        public PaymentTypeWindow()
        {
            InitializeComponent();
        }

        private void Сashless_Click(object sender, RoutedEventArgs e)
        {
            Type = "безналичный";
            Close();
        }

        private void Сash_Click(object sender, RoutedEventArgs e)
        {
            Type = "наличный";
            Close();
        }
    }
}
