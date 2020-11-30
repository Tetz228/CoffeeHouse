using System.Linq;
using System.Windows;
using System.Windows.Forms;

namespace WpfApp1.Edit
{
    public partial class EditStatusEmployeeWindow : Window
    {
        private readonly Employee employee;
        private readonly ActionsEmployees actionsEmployees;

        public EditStatusEmployeeWindow(Employee employee)
        {
            InitializeComponent();
            this.employee = employee;
            actionsEmployees = new ActionsEmployees(employee);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ComboBoxStatus.ItemsSource = actionsEmployees.FillingComboBoxStatus_employees();
            ComboBoxStatus.SelectedValue = employee.Fk_status_employee;
        }
        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                actionsEmployees.EditStatus((int)ComboBoxStatus.SelectedValue);

                Close();
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Ошибка при изменении сотрудника.", "Ошибка! Некорректный ввод!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
