using System.Windows.Controls;
using System.Windows.Input;

namespace WpfApp1
{
    public partial class ListShiftsDatesUserControl : UserControl
    {
        public ListShiftsDatesUserControl()
        {
            InitializeComponent();
            UploadShiftsDates();
        }

        public void UploadShiftsDates()
        {
            ActionsShiftsDates actionsShiftsDates = new ActionsShiftsDates();
            DataGridShiftsDates.ItemsSource = actionsShiftsDates.GettingAllShiftsDates();
        }

        private void DataGridContracts_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DataGridShiftsDates.SelectedItem = null;
        }
    }
}
