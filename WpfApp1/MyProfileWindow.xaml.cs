using System.Linq;
using System.Windows;

namespace WpfApp1
{
    public partial class MyProfileWindow : Window
    {
        private int IdProfile { get; set; }
        private string PostProfile { get; set; }

        public MyProfileWindow(int idProfile, string postProfile)
        {
            InitializeComponent();

            IdProfile = idProfile;
            PostProfile = postProfile;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GetInfoEmployee();

        }

        private void GetInfoEmployee()
        {
            using (CafeEntities db = new CafeEntities())
            {
                var selectEmp = db.Employees.FirstOrDefault(id => id.ID == IdProfile);

                LabelLFM.Content = selectEmp.MName != "Не указано"
                                               ? selectEmp.LName + " " + selectEmp.FName.Substring(0, 1) + ". " + selectEmp.FName.Substring(0, 1) + "."
                                               : selectEmp.LName + " " + selectEmp.FName.Substring(0, 1) + ".";

                LabelPost.Content = PostProfile;
                LabelPhone_number.Content = selectEmp.Phone_number;
                LabelStatus.Content = selectEmp.Status_employees.Name;
            }
        }
    }
}
