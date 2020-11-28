using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1.Admin.Add
{
    public partial class AddTableWindow : Window
    {
        private readonly ActionsEmployees actionsEmployees = new ActionsEmployees();

        public AddTableWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
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
                using var db = new CafeEntities();

                Table table = new Table()
                {
                    Table_number = int.Parse(TextBoxNumberTable.Text),
                    Fk_employee = (int)ComboBoxEmployees.SelectedValue
                };

                db.Tables.Add(table);
                db.SaveChanges();

                Close();
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Ошибка при добавлении столика.", "Ошибка! Некорректный ввод!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
