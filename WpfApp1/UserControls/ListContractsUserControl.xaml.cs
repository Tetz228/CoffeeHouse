using System.Windows.Controls;
using System.Windows.Input;

namespace WpfApp1
{
    public partial class ListContractsUserControl : UserControl
    {
        public ListContractsUserControl()
        {
            InitializeComponent();

            UploadContract();
        }

        public void UploadContract()
        {
            ActionsContracts actionsContracts = new ActionsContracts();

            DataGridContracts.ItemsSource = actionsContracts.GettingAllContracts();
        }

        private void DataGridContracts_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DataGridContracts.SelectedItem = null;
        }
    }
}
