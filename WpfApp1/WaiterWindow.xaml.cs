using System.Linq;
using System.Windows;

namespace WpfApp1
{
    public partial class WaiterWindow : Window
    {
        private int IdEmployee { get; set; }
        private string EmployeePost { get; set; }

        public WaiterWindow(int idEmp, string empPost)
        {
            InitializeComponent();

            IdEmployee = idEmp;
            EmployeePost = empPost;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            OutputOrders();
        }

        private void OutputOrders()
        {
            using (CafeEntities db = new CafeEntities())
            {
                var selectOrders = from order in db.Orders
                                   join status_order in db.Status_orders on order.Fk_status_order equals status_order.ID
                                   join table in db.Tables on order.Fk_table equals table.ID
                                   join emp in db.Employees on table.Fk_employee equals emp.ID
                                   select new
                                   {
                                       ID = order.ID,
                                       Fk_table = table.Table_number,
                                       Count_person = order.Count_person,
                                       Fk_status_order = status_order.Name,
                                       Data_time = order.Data_time,
                                       Order_price = order.Order_price,
                                       Fk_emp = emp.LName + " " + emp.FName.Substring(0, 1) + ". " + emp.MName.Substring(0, 1) + "."
                                   };

                var selectEmp = db.Employees.FirstOrDefault(id => id.ID == IdEmployee);

                MenuItemUser.Header = selectEmp.MName != "Не указано"
                                                               ? selectEmp.LName + " " + selectEmp.FName.Substring(0, 1) + ". " + selectEmp.FName.Substring(0, 1) + "."
                                                               : selectEmp.LName + " " + selectEmp.FName.Substring(0, 1) + ".";

                DataGridOrders.ItemsSource = selectOrders.ToList();
            }
        }

        private void MenuItemExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MenuItemLogOutAccount_Click(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();

            Close();
        }

        private void MenuItemProfile_Click(object sender, RoutedEventArgs e)
        {
            MyProfileWindow myProfile = new MyProfileWindow(IdEmployee, EmployeePost);

            myProfile.ShowDialog();
        }
    }
}
