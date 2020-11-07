using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfApp1
{
    class ActionsOrders : ActionsUser
    {
        public ActionsOrders(int id) : base(id) {}

        public IEnumerable OutputOrders()
        {
            using (var db = new CafeEntities())
            {
                DataGrid itemsSource = new DataGrid();

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

                itemsSource.ItemsSource = selectOrders.ToList();

                return itemsSource.ItemsSource;
            }
        }
    }
}
