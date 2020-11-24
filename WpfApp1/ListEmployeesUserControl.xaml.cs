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
    public partial class ListEmployeesUserControl : UserControl
    {
        private readonly ActionsEmployees actionsEmployees;

        public ListEmployeesUserControl(int id)
        {
            InitializeComponent();

            actionsEmployees = new ActionsEmployees(id);
            DataGridEmployees.ItemsSource = actionsEmployees.GettingEmployees();
        }

        private void DataGridEmployees_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void DataGridEmployees_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
