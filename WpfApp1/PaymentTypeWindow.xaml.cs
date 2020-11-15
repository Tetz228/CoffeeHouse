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
    public partial class PaymentTypeWindow : Window
    {
        public string Type { get; set; } = "не выбран";

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
