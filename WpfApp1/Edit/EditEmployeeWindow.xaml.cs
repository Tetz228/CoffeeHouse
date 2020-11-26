using System.Linq;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;

namespace WpfApp1.Edit
{
    public partial class EditEmployeeWindow : Window
    {
        private readonly Employee employee;
        private readonly ActionsEmployees actionsEmployees;

        public EditEmployeeWindow(Employee employee)
        {
            InitializeComponent();
            this.employee = employee;
            actionsEmployees = new ActionsEmployees(employee);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ComboBoxStatus.ItemsSource = actionsEmployees.FillingComboBoxStatus_employees();
            TextBoxLName.Text = employee.LName;
            TextBoxFName.Text = employee.FName;
            TextBoxMName.Text = employee.MName == "Не указано" ? TextBoxMName.Text = "" : employee.MName;

            if (TextBoxMName.Text == "")
            {
                CheckBoxMName.IsChecked = true;
                TextBoxMName.IsEnabled = false;
            }

            TextBoxPhoneNumber.Text = employee.Phone_number;
            ComboBoxStatus.SelectedValue = employee.Fk_status_employee;
            ImageAvatar.Source = actionsEmployees.GettingPhoto();
        }

        private void ButtonEditPhoto_Click(object sender, RoutedEventArgs e)
        {
            actionsEmployees.ChangePhoto(out ImageSource image);

            if (image != null)
                ImageAvatar.Source = image;
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using var db = new CafeEntities();
                int id = actionsEmployees.GettingIDEmployee();
                var employee = db.Employees.Where(emp => emp.ID == id).FirstOrDefault();

                employee.LName = TextBoxLName.Text;
                employee.FName = TextBoxFName.Text;
                employee.MName = TextBoxMName.Text == "" ? TextBoxMName.Text = "Не указано" : TextBoxMName.Text;
                employee.Fk_status_employee = (int)ComboBoxStatus.SelectedValue;
                employee.Phone_number = TextBoxPhoneNumber.Text;

                db.SaveChanges();

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

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            TextBoxMName.IsEnabled = true;
            TextBoxMName.Text = "";
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            TextBoxMName.IsEnabled = false;
            TextBoxMName.Text = "";
        }
    }
}
