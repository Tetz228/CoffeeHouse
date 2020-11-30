using System.Windows;
using System.Windows.Forms;

namespace WpfApp1.Admin.Edit
{
    public partial class EditTableWindow : Window
    {
        private readonly Table table;
        private readonly ActionsEmployees actionsEmployees = new ActionsEmployees();

        public EditTableWindow(Table table)
        {
            InitializeComponent();

            this.table = table;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ComboBoxEmployees.ItemsSource = actionsEmployees.GettingAllEmployeesWaiter();
            ComboBoxEmployees.SelectedValue = table.Fk_employee;
            TextBoxNumberTable.Text = table.Table_number.ToString();
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ActionsTables actionsTables = new ActionsTables();
                actionsTables.EditTable(table.ID, int.Parse(TextBoxNumberTable.Text), (int)ComboBoxEmployees.SelectedValue);

                Close();
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Ошибка при изменении стола.", "Ошибка! Некорректный ввод!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
