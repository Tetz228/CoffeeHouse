using System.Windows;
using System.Windows.Forms;

namespace WpfApp1.Admin.Add
{
    public partial class AddTableWindow : Window
    {
        public AddTableWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ActionsEmployees actionsEmployees = new ActionsEmployees();

            ComboBoxEmployees.ItemsSource = actionsEmployees.GettingAllEmployeesWaiter();
            ComboBoxEmployees.SelectedIndex += 1;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ButtonСonfirm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ActionsTables actionsTables = new ActionsTables();
                actionsTables.AddTable(int.Parse(TextBoxNumberTable.Text), (int)ComboBoxEmployees.SelectedValue);

                Close();
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Ошибка при добавлении столика.", "Ошибка! Некорректный ввод!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
