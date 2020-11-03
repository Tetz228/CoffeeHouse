using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace WpfApp1
{
    public partial class ChoiceRoleWindow : Window
    {
        public List<Posts_employees> PostsEmployee { get; set; }

        public string GetRole { get; set; }

        public ChoiceRoleWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillingComboBox();
        }

        private void FillingComboBox()
        {
            ComboBoxChoiceRole.DataContext = PostsEmployee.ToList();
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
