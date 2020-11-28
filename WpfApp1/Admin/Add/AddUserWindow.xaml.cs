using System.Windows;
using System.Windows.Forms;

namespace WpfApp1.Add
{
    public partial class AddUserWindow : Window
    {
        private readonly ActionsUsers actionsUsers;

        public AddUserWindow()
        {
            InitializeComponent();
            actionsUsers = new ActionsUsers();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ComboBoxEmployee.ItemsSource = actionsUsers.GettingAllEmployees();
            ComboBoxEmployee.SelectedIndex += 1;
        }

        private void ButtonСonfirm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using var db = new CafeEntities();

                User user = new User()
                {
                    Login = TextBoxLogin.Text,
                    Password = PasswordBoxPassword.Password,
                    Fk_employee = (int)ComboBoxEmployee.SelectedValue
                };

                db.Users.Add(user);
                db.SaveChanges();

                Close();
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Ошибка при добавлении пользователя.", "Ошибка! Некорректный ввод!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
