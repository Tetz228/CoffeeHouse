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
using WpfApp1.Admin.Edit;

namespace WpfApp1
{
    public partial class ListShiftsUserControl : UserControl
    {
        private readonly ActionsShifts actionsShifts = new ActionsShifts();

        public ListShiftsUserControl()
        {
            InitializeComponent();

            UploadShifts();
        }

        public void UploadShifts()
        {
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
