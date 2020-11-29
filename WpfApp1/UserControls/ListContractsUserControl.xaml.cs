using System.Windows.Controls;
using System.Windows.Input;

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
