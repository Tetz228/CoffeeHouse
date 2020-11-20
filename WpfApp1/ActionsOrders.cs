using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace WpfApp1
{
    public class ActionsOrders : ActionsUsers
    {
        public ActionsOrders(int id) : base(id) { }

        public ActionsOrders() { }

        #region Методы на вывод информации
        //Вывод информации о заказах
        public Order[] OutputOrders()
        {
            using (var db = new CafeEntities())
            {
                var selectOrders = db.Orders.Include(status => status.Status_orders)
                                                                         .Include(table => table.Table)
                                                                         .Include(emp => emp.Table.Employee)
                                                                         .Include(orderDishes => orderDishes.Ordering_dishes).ToArray();
                return selectOrders;
            }
        }

        //Вывод информации о "моих" заказах
        public Order[] MyOrders()
        {
            int idEmp = GettingIdEmployee();

            using (var db = new CafeEntities())
            {
                var selectMyOrders = db.Orders.Where(emp => emp.Table.Employee.ID == idEmp)
                                                                           .Include(status => status.Status_orders)
                                                                           .Include(table => table.Table)
                                                                           .Include(emp => emp.Table.Employee)
                                                                           .Include(orderDishes => orderDishes.Ordering_dishes).ToArray();

                return selectMyOrders;
            }
        }

        //Вывод информации о заказах за смену 
        public List<Order> OutputOrdersShift()
        {
            using (var db = new CafeEntities())
            {
                List<Order> orders = new List<Order>();

                var selectOrdersShift = db.Orders.Include(status => status.Status_orders)
                                                 .Include(table => table.Table)
                                                 .Include(emp => emp.Table.Employee)
                                                 .Include(orderDishes => orderDishes.Ordering_dishes).ToArray();

                //Выборка заказов за сегодняшнюю смену
                foreach (var data in selectOrdersShift)
                    if (data.Data_time.ToShortDateString() == DateTime.Now.ToShortDateString())
                        orders.Add(data);

                return orders;
            }
        }

        //Вывод информации о заказах за смену в выбранную дату
        public List<Order> ShiftReport(DateTime? date)
        {
            using (var db = new CafeEntities())
            {
                List<Order> orders = new List<Order>();
                DateTime dateShifrtReport = (DateTime)date;
                int idEmp = GettingIdEmployee();               

                var selectOrders = db.Orders.Include(status => status.Status_orders)
                                            .Include(table => table.Table)
                                            .Include(emp => emp.Table.Employee)
                                            .Include(orderDishes => orderDishes.Ordering_dishes)
                                            .Where(emp => emp.Table.Employee.ID == idEmp).ToList();

                foreach (var data in selectOrders)
                    if (data.Data_time.ToShortDateString() == dateShifrtReport.ToShortDateString())
                        orders.Add(data);

                return orders;
            }
        }

        //Вывод информации о блюдах, которые указаны в заказе
        public Ordering_dishes[] OutputOrdering_dishes(int idOrder)
        {
            using (var db = new CafeEntities())
            {
                var selectOrdering_dishes = db.Ordering_dishes.Where(dbOrdering => dbOrdering.Fk_order == idOrder).Include(order => order.Order)
                                                                                                                  .Include(typeDish => typeDish.Dish.Types_dishes)
                                                                                                                  .Include(statusDish => statusDish.Status_dish)
                                                                                                                  .Include(table => table.Order.Table).ToArray();

                //Подсчет суммы блюда и напитка
                foreach (var dishesAndDrink in selectOrdering_dishes)
                    dishesAndDrink.SumDish = dishesAndDrink.Count_dish * dishesAndDrink.Dish.Price;

                return selectOrdering_dishes;
            }
        }

        //Вывод блюд по типам
        public List<Dish> OutputByTypesDishes(int Fk_type)
        {
            using (var db = new CafeEntities())
            {
                var typesDishes = db.Dishes.Include(type => type.Types_dishes).Where(dish => dish.Fk_type_dish == Fk_type).ToList();

                return typesDishes;
            }
        }
        #endregion

        #region Заполнение ComboBox`ов
        // Заполнение ComboBox`а "Типы блюд"
        public List<Types_dishes> FillingComboBoxTypesDishes()
        {
            using (var db = new CafeEntities())
            {
                var typesDishes = db.Types_dishes.ToList();

                return typesDishes;
            }
        }

        // Заполнение ComboBox`а "Блюда"
        public List<Dish> FillingComboBoxDishes()
        {
            using (var db = new CafeEntities())
            {
                var dishes = db.Dishes.ToList();

                return dishes;
            }
        }

        // Заполнение ComboBox`а "Столы"
        public List<Table> FillingComboBoxTables()
        {
            using (var db = new CafeEntities())
            {
                var tables = db.Tables.ToList();

                return tables;
            }
        }

        // Заполнение ComboBox`а "Столы". Отображение только столов, за которые отвечает авторизованный пользователь
        public List<Table> FillingComboBoxTables(int idEmp)
        {
            using (var db = new CafeEntities())
            {
                var tables = db.Tables.Where(emp => emp.Fk_employee == idEmp).ToList();

                return tables;
            }
        }

        // Заполнение ComboBox`а "Статусы заказов"
        public List<Status_orders> FillingComboBoxStatusOrders()
        {
            using (var db = new CafeEntities())
            {
                var statusOrders = db.Status_orders.ToList();

                return statusOrders;
            }
        }

        // Заполнение ComboBox`а "Статусы блюд"
        //public List<Status_dish> FillingComboBoxStatusDishes()
        //{
        //    using (var db = new CafeEntities())
        //    {
        //        var statusDishes = db.Status_dish.ToList();

        //        return statusDishes;
        //    }
        //}
        #endregion

        #region Методы на добавление
        //Добавление заказа
        public void AddOrder(Dictionary<string, int> infoOrder, out int idOrder)
        {
            using (var db = new CafeEntities())
            {
                Order order = new Order
                {
                    Fk_table = infoOrder["table"],
                    Fk_status_order = infoOrder["status"],
                    Count_person = infoOrder["people"],
                    Data_time = DateTime.Now,
                    Order_price = 0
                };

                db.Orders.Add(order);
                db.SaveChanges();

                // Получение ID для того, чтоб добавить блюда в заказ
                idOrder = order.ID;
            }
        }

        //Добавление блюд, которые входят в определенный заказ
        public void AddOrder_dish(Dictionary<string, int> infoDisheDrinkInOrder, out decimal sum)
        {
            using (var db = new CafeEntities())
            {
                sum = 0;

                var statusDish = db.Status_dish.Where(status => status.Name == "Не готово").FirstOrDefault();

                Ordering_dishes ordering_Dishes = new Ordering_dishes()
                {
                    Fk_dish = infoDisheDrinkInOrder["dish"],
                    Fk_status_dish = statusDish.ID,
                    Count_dish = infoDisheDrinkInOrder["countDish"],
                    Fk_order = infoDisheDrinkInOrder["idOrder"]
                };

                db.Ordering_dishes.Add(ordering_Dishes);
                db.SaveChanges();

                var dishesOrder = db.Ordering_dishes.Include(dish => dish.Dish)
                                                    .Where(fk_order => fk_order.Fk_order == ordering_Dishes.Fk_order).ToList();

                foreach (var item in dishesOrder)
                    sum += item.Dish.Price * item.Count_dish;
            }
        }

        //Добавление суммы заказа после подтверждения заказа
        public void AddSumOrder(int idOrder, decimal sumOrder)
        {
            using (var db = new CafeEntities())
            {
                var orderSum = db.Orders.Where(order => order.ID == idOrder).FirstOrDefault();
                orderSum.Order_price = sumOrder;

                db.SaveChanges();
            }
        }
        #endregion

        #region Методы на обновление

        //Обновление статуса заказа
        public void UpdateStatusOrder(int idOrder, int idStatus)
        {
            using (var db = new CafeEntities())
            {
                var statusOrder = db.Orders.Where(order => order.ID == idOrder).FirstOrDefault();
                statusOrder.Fk_status_order = idStatus;

                db.SaveChanges();
            }
        }
        #endregion
    }
}
