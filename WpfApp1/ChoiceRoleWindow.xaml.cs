using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace WpfApp1
{
    public partial class ChoiceRoleWindow : Window
    {
        private List<Posts_employees> RolesUser { get; set; }

        public string GetRole { get; set; }

        public ChoiceRoleWindow(List<Posts_employees> rolesUser)
        {
            InitializeComponent();

            RolesUser = rolesUser;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillingComboBox();
        }

        private void FillingComboBox()
        {
            ComboBoxChoiceRole.DataContext = RolesUser.ToList();
            ComboBoxChoiceRole.SelectedIndex += 1;
        }

        private void Сonfirm_Click(object sender, RoutedEventArgs e)
        {
            GetRole = ComboBoxChoiceRole.Text;

            Close();
        }

        private void Сancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
