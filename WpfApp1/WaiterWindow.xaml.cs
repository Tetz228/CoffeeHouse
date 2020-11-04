using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
    public partial class WaiterWindow : Window
    {
        public User FoundUser { get; set; }

        public WaiterWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            OutputOrders();
        }

        private void OutputOrders()
        {
            CafeEntities db = new CafeEntities();

            var sql = from order in db.Orders
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

            MenuItemUser.Header = FoundUser.Employee.MName != "Не указано" 
                                                           ? FoundUser.Employee.LName + " " + FoundUser.Employee.FName.Substring(0,1) + ". " + FoundUser.Employee.FName.Substring(0, 1) + "."
                                                           : FoundUser.Employee.LName + " " + FoundUser.Employee.FName.Substring(0, 1) + ".";

            DataGridOrders.ItemsSource = sql.ToList();
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
    }
}
