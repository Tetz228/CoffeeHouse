using System.Windows.Controls;
using System.Windows.Input;
using WpfApp1.Edit;

namespace WpfApp1
{
    public partial class ListEmployeesUserControl : UserControl
    {
        public ListEmployeesUserControl()
        {
            InitializeComponent();
            UploadEmployees();
        }

        public void UploadEmployees()
        {
            ActionsEmployees actionsEmployees = new ActionsEmployees();
            DataGridEmployees.ItemsSource = actionsEmployees.GettingAllEmployees();
        }

        public void ChangeEmployee()
        {
            if (DataGridEmployees.SelectedItem != null)
            {
                Employee selectedEmployee = DataGridEmployees.SelectedItem as Employee;

                EditStatusEmployeeWindow editEmployeeWindow = new EditStatusEmployeeWindow(selectedEmployee);
                editEmployeeWindow.ShowDialog();

                UploadEmployees();
            }
        }

        private void DataGridEmployees_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DataGridEmployees.SelectedItem = null;
        }

        private void DataGridEmployees_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ChangeEmployee();
        }
    }
}
