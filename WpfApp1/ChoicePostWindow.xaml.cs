using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Windows;

namespace WpfApp1
{
    public partial class ChoicePostWindow : Window
    {
        public int GetFkPost { get; set; }

        private int IdUser { get; set; }

        public ChoicePostWindow(int id)
        {
            InitializeComponent();

            IdUser = id;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillingComboBox();
        }

        private void FillingComboBox()
        {
            using (var db = new CafeEntities())
            {
                ComboBoxChoiceRole.ItemsSource = db.Posts_employees.Include(post => post.Post).Where(emp => emp.Fk_employee == IdUser).ToList();
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
