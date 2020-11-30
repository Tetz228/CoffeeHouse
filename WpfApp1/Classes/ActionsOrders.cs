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
            using var db = new CafeEntities();
            var selectOrders = db.Orders.Include(status => status.Status_orders)
                                        .Include(table => table.Table)
                                        .Include(emp => emp.Table.Employee)
                                        .Include(orderDishes => orderDishes.Ordering_dishes).ToArray();
            return selectOrders;
        }

        //Вывод информации о "моих" заказах
        public Order[] MyOrders()
        {
            int idEmp = GettingIDEmployee();

            using var db = new CafeEntities();
            var selectMyOrders = db.Orders.Where(emp => emp.Table.Employee.ID == idEmp)
                                          .Include(status => status.Status_orders)
                                          .Include(table => table.Table)
                                          .Include(emp => emp.Table.Employee)
                                          .Include(orderDishes => orderDishes.Ordering_dishes).ToArray();

            return selectMyOrders;
        }

        //Вывод информации о заказах за смену 
        public List<Order> OutputOrdersShift()
        {
            using var db = new CafeEntities();
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

        //Вывод информации о заказах за смену в выбранную дату
        public List<Order> ShiftReport(DateTime? date)
        {
            using var db = new CafeEntities();
            List<Order> orders = new List<Order>();
            DateTime dateShifrtReport = (DateTime)date;
            int idEmp = GettingIDEmployee();

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

        //Вывод информации о блюдах, которые указаны в заказе
        public Ordering_dishes[] OutputOrdering_dishes(int idOrder)
        {
            using var db = new CafeEntities();
            var selectOrdering_dishes = db.Ordering_dishes.Where(dbOrdering => dbOrdering.Fk_order == idOrder)
                                                          .Include(order => order.Order)
                                                          .Include(typeDish => typeDish.Dish.Types_dishes)
                                                          .Include(statusDish => statusDish.Status_dish)
                                                          .Include(table => table.Order.Table).ToArray();

            return selectOrdering_dishes;
        }

        //Вывод блюд по типам
        public List<Dish> OutputByTypesDishes(int Fk_type)
        {
            using var db = new CafeEntities();
            var typesDishes = db.Dishes.Include(type => type.Types_dishes).Where(dish => dish.Fk_type_dish == Fk_type).ToList();

            return typesDishes;
        }
        #endregion

        #region Заполнение ComboBox`ов
        // Заполнение ComboBox`а "Типы блюд"
        public List<Types_dishes> FillingComboBoxTypesDishes()
        {
            using var db = new CafeEntities();
            var typesDishes = db.Types_dishes.ToList();

            return typesDishes;
        }

        // Заполнение ComboBox`а "Блюда"
        public List<Dish> FillingComboBoxDishes()
        {
            using var db = new CafeEntities();
            var dishes = db.Dishes.ToList();

            return dishes;
        }

        // Заполнение ComboBox`а "Столы"
        public List<Table> FillingComboBoxTables()
        {
            using var db = new CafeEntities();
            var tables = db.Tables.ToList();

            return tables;
        }

        // Заполнение ComboBox`а "Столы". Отображение только столов, за которые отвечает авторизованный пользователь
        public List<Table> FillingComboBoxTables(int idEmp)
        {
            using var db = new CafeEntities();
            var tables = db.Tables.Where(emp => emp.Fk_employee == idEmp).ToList();

            return tables;
        }

        // Заполнение ComboBox`а "Статусы заказов"
        public List<Status_orders> FillingComboBoxStatusOrders()
        {
            using var db = new CafeEntities();
            var statusOrders = db.Status_orders.ToList();

            return statusOrders;
        }

        // Заполнение ComboBox`а "Статусы блюд"
        public List<Status_dish> FillingComboBoxStatusDishes()
        {
            using var db = new CafeEntities();
            var statusDishes = db.Status_dish.ToList();

            return statusDishes;
        }
        #endregion

        #region Методы на добавление
        //Добавление заказа
        public void AddOrder(Dictionary<string, int> infoOrder, out int idOrder)
        {
            using var db = new CafeEntities();
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

        //Добавление блюд, которые входят в определенный заказ
        public void AddDishOrder(Dictionary<string, int> infoDisheDrinkInOrder, decimal priceDish)
        {
            using var db = new CafeEntities();
            var statusDish = db.Status_dish.Where(status => status.Name == "Не готово").Select(statusId => statusId.ID).FirstOrDefault();

            Ordering_dishes ordering_Dishes = new Ordering_dishes()
            {
                Fk_dish = infoDisheDrinkInOrder["dish"],
                Fk_status_dish = statusDish,
                Count_dish = infoDisheDrinkInOrder["countDish"],
                SumDish = priceDish * infoDisheDrinkInOrder["countDish"],
                Fk_order = infoDisheDrinkInOrder["idOrder"]
            };

            db.Ordering_dishes.Add(ordering_Dishes);
            db.SaveChanges();
        }

        //Добавление суммы заказа после подтверждения заказа
        public void CalculationAndAddSumOrder(int idOrder)
        {
            using var db = new CafeEntities();
            var dishes = db.Ordering_dishes.Where(orderId => orderId.Order.ID == idOrder).Include(orders => orders.Order).ToList();
            var order = db.Orders.Where(orderId => orderId.ID == idOrder).FirstOrDefault();
            decimal sum = default;

            foreach (var dish in dishes)
                sum += dish.Dish.Price * dish.Count_dish;

            order.Order_price = sum;

            db.SaveChanges();
        }
        #endregion

        #region Методы на обновление
        //Обновление статуса заказа
        public void UpdateStatusOrder(int idOrder, int idStatus)
        {
            using var db = new CafeEntities();
            var statusOrder = db.Orders.Where(order => order.ID == idOrder).FirstOrDefault();
            statusOrder.Fk_status_order = idStatus;

            db.SaveChanges();
        }

        //Обновление заказа
        public void UpdateOrder(Dictionary<string, int> infoOrder,Order order)
        {           
            using var db = new CafeEntities();
            var selectOrder = db.Orders.Where(idOrder => idOrder.ID == order.ID).FirstOrDefault();

            selectOrder.Fk_table = infoOrder["table"];
            selectOrder.Count_person = infoOrder["countPeople"];
            selectOrder.Fk_status_order = infoOrder["status"];

            db.SaveChanges();
        }

        //Обновление статуса блюда
        public void UpdateStatusDish(int idOrder, int idStatus)
        {
            using var db = new CafeEntities();
            var statusDish = db.Ordering_dishes.Where(orderDish => orderDish.ID == idOrder).FirstOrDefault();
            statusDish.Fk_status_dish = idStatus;

            db.SaveChanges();
        }
        #endregion
    }
}
