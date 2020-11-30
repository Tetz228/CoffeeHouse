using System.Windows;
using System.Windows.Forms;

namespace WpfApp1.Add
{
    public partial class AddUserWindow : Window
    {
        private readonly ActionsUsers actionsUsers = new ActionsUsers();

        public AddUserWindow()
        {
            InitializeComponent();         
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
                actionsUsers.AddUser(TextBoxLogin.Text, PasswordBoxPassword.Password, (int)ComboBoxEmployee.SelectedValue);

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
