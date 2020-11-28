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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    public partial class ListContractsUserControl : UserControl
    {
        private readonly ActionsContracts actionsContracts = new ActionsContracts();

        public ListContractsUserControl()
        {
            InitializeComponent();

            UploadContract();
        }

        public void UploadContract()
        {
            DataGridContracts.ItemsSource = actionsContracts.GettingAllContracts();
        }

        private void DataGridContracts_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DataGridContracts.SelectedItem = null;
        }
    }
}
