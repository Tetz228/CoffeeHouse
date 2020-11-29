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
    public partial class ListShiftsDatesUserControl : UserControl
    {
        private readonly ActionsShiftsDates actionsShiftsDates = new ActionsShiftsDates();

        public ListShiftsDatesUserControl()
        {
            InitializeComponent();
            UploadShiftsDates();
        }

        public void UploadShiftsDates()
        {
            DataGridShiftsDates.ItemsSource = actionsShiftsDates.GettingAllShiftsDates();
        }

        private void DataGridContracts_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DataGridShiftsDates.SelectedItem = null;
        }
    }
}
