using System.Windows.Controls;
using System.Windows.Input;
using WpfApp1.Admin.Edit;

namespace WpfApp1
{
    public partial class ListShiftsUserControl : UserControl
    {
        public ListShiftsUserControl()
        {
            InitializeComponent();

            UploadShifts();
        }

        public void UploadShifts()
        {
            ActionsShifts actionsShifts = new ActionsShifts();
            DataGridShifts.ItemsSource = actionsShifts.GettingAllShifts();
        }

        private void DataGridShifts_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DataGridShifts.SelectedItem = null;
        }

        private void DataGridShifts_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ChangeShifts();
        }

        public void ChangeShifts()
        {
            if (DataGridShifts.SelectedItem != null)
            {
                Shift_list shift_List = DataGridShifts.SelectedItem as Shift_list;

                EditShiftsWindow editTableWindow = new EditShiftsWindow(shift_List);
                editTableWindow.ShowDialog();

                UploadShifts();
            }
        }
    }
}
