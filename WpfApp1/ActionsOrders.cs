using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Controls;

namespace WpfApp1
{
    public class ActionsOrders : ActionsUsers
    {
        public ActionsOrders(int id) : base(id) { }

        public ActionsOrders() {}

        #region Методы на вывод информации

        //Вывод информации о заказах
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

                return itemsSource.ItemsSource = selectOrders.ToList();
            }
        }

        //Вывод информации о блюдах, которые указаны в заказе
        public IEnumerable OutputOrdering_dishes(int idOrder)
        {
            using (var db = new CafeEntities())
            {
                DataGrid itemsSource = new DataGrid();

                var selectOrdering_dishes = from ordering_dishes in db.Ordering_dishes
                                   join orders in db.Orders on ordering_dishes.Fk_order equals orders.ID
                                   join tables in db.Tables on orders.Fk_table equals tables.ID
                                   join dishes in db.Dishes on ordering_dishes.Fk_dish equals dishes.ID
                                   join types_dishes in db.Types_dishes on dishes.Fk_type_dish equals types_dishes.ID
                                   join status_dish in db.Status_dish on ordering_dishes.Fk_status_dish equals status_dish.ID
                                   join drinks in db.Drinks on ordering_dishes.Fk_drink equals drinks.ID
                                   join types_drink in db.Types_drinks on drinks.Fk_drink_type equals types_drink.ID
                                   where orders.ID == idOrder
                                   select new
                                   {
                                       ID = ordering_dishes.ID,
                                       Fk_dish = dishes.Name,
                                       Fk_status_dish = status_dish.Name,
                                       Count_dish = ordering_dishes.Count_dish,
                                       Fk_drink = drinks.Name,
                                       Count_drink = ordering_dishes.Count_drink,
                                       Fk_order = ordering_dishes.Fk_order
                                   };
               
                return itemsSource.ItemsSource = selectOrdering_dishes.ToList();
            }
        }
        #endregion

        #region Заполнение ComboBox`ов

        // Заполнение ComboBox`а под названием "Типы блюд"
        public object FillingComboBoxTypesDishes()
        {
            using (var db = new CafeEntities())
            {
                object obj = db.Types_dishes.ToList();

                return obj;
            }
        }

        // Заполнение ComboBox`а под названием "Типы напитков"
        public object FillingComboBoxTypesDrinks()
        {
            using (var db = new CafeEntities())
            {
                object obj = db.Types_drinks.ToList();

                return obj;
            }
        }

        // Заполнение ComboBox`а под названием "Блюда"
        public object FillingComboBoxDishes()
        {
            using (var db = new CafeEntities())
            {
                object obj = db.Dishes.ToList();

                return obj;
            }
        }

        // Заполнение ComboBox`а под названием "Напитки"
        public object FillingComboBoxDrinks()
        {
            using (var db = new CafeEntities())
            {
                object obj = db.Drinks.ToList();

                return obj;
            }
        }

        // Заполнение ComboBox`а под названием "Столы"
        public object FillingComboBoxTables()
        {
            using (var db = new CafeEntities())
            {
                object obj = db.Tables.ToList();

                return obj;
            }
        }

        // Заполнение ComboBox`а под названием "Статусы заказов"
        public object FillingComboBoxStatusOrders()
        {
            using (var db = new CafeEntities())
            {
                object obj = db.Status_orders.ToList();

                return obj;
            }
        }

        // Заполнение ComboBox`а под названием "Статусы блюд"
        public object FillingComboBoxStatusDishes()
        {
            using (var db = new CafeEntities())
            {
                object obj = db.Status_dish.ToList();

                return obj;
            }
        }
        #endregion

        #region Вывод блюд/напитков по типам

        //Вывод блюд по типам
        public List<Dish> OutputByTypesDishes(int Fk_type)
        {
            using (var db = new CafeEntities())
            {
                var typesDishes = db.Dishes.Include(type => type.Types_dishes).Where(dish => dish.Fk_type_dish == Fk_type).ToList();

                return typesDishes;
            }
        }

        //Вывод напитков по типам
        public List<Drink> OutputByTypesDrinks(int Fk_type)
        {
            using (var db = new CafeEntities())
            {
                var typesDrinks = db.Drinks.Include(type => type.Types_drinks).Where(drink => drink.Fk_drink_type == Fk_type).ToList();

                return typesDrinks;
            }
        }
        #endregion

        #region Методы на добавление

        //Добавление заказа
        public void AddOrder(int numberTable, int statusOrder, string coutPeople, out int idOrder)
        {
            using (var db = new CafeEntities())
            {
                Order order = new Order
                {
                    Fk_table = numberTable,
                    Fk_status_order = statusOrder,
                    Count_person = Convert.ToInt32(coutPeople),
                    Data_time = DateTime.Now,
                    Order_price = 0
                };

                db.Orders.Add(order);
                db.SaveChanges();

                idOrder = order.ID;

            }
        }

        //Добавление блюд, которые входят в определенный заказ
        public void AddOrder_dish(int idDish, int idStatusDish, int countDishes, int idDrink, int countDrinks, int idOrder)
        {
            using (var db = new CafeEntities())
            {
                Ordering_dishes ordering_Dishes = new Ordering_dishes()
                {
                    Fk_dish = idDish,
                    Fk_status_dish = idStatusDish,
                    Count_dish = countDishes,
                    Fk_drink = idDrink,
                    Count_drink = countDrinks,
                    Fk_order = idOrder
                };

                db.Ordering_dishes.Add(ordering_Dishes);
                db.SaveChanges();
            }
        }
        #endregion
    }
}
