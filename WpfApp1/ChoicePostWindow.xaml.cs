using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Windows;

namespace WpfApp1
{
    public partial class ChoicePostWindow : Window
    {
        private int IdEmp { get; }
        public string GetPost { get; set; }
        
        public ChoicePostWindow(int id)
        {
            InitializeComponent();

            IdEmp = id;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillingComboBox();
        }

        private void FillingComboBox()
        {
            using (var db = new CafeEntities())
            {
                ComboBoxChoiceRole.ItemsSource = db.Posts_employees.Include(post => post.Post).Where(emp => emp.Fk_employee == IdEmp).ToList();
                ComboBoxChoiceRole.SelectedIndex += 1;
            }
        }

        private void Сonfirm_Click(object sender, RoutedEventArgs e)
        {
            GetPost = ComboBoxChoiceRole.Text;
            Close();
        }

        private void Сancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
