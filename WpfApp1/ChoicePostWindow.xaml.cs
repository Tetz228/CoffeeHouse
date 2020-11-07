using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Windows;

namespace WpfApp1
{
    public partial class ChoicePostWindow : Window
    {
        private User UserAndRoles { get; set; }

        public int GetFkPost { get; set; }
        

        public ChoicePostWindow(User user)
        {
            InitializeComponent();

            UserAndRoles = user;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillingComboBox();
        }

        private void FillingComboBox()
        {
            using (CafeEntities db = new CafeEntities())
            {
                ComboBoxChoiceRole.DataContext = db.Posts_employees.Include(post => post.Post).Where(emp => UserAndRoles.Employee.ID == emp.Fk_employee).ToList();
                ComboBoxChoiceRole.SelectedIndex += 1;
            }
        }

        private void Сonfirm_Click(object sender, RoutedEventArgs e)
        {
            GetFkPost = (int)ComboBoxChoiceRole.SelectedValue;

            Close();
        }

        private void Сancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
