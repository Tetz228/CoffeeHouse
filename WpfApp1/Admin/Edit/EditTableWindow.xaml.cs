using System.Linq;
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
                using var db = new CafeEntities();

                var tables = db.Tables.Where(tl => tl.ID == table.ID).FirstOrDefault();

                tables.Table_number = int.Parse(TextBoxNumberTable.Text);
                tables.Fk_employee = (int)ComboBoxEmployees.SelectedValue;

                db.SaveChanges();

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
