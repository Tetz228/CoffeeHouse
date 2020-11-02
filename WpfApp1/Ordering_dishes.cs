namespace WpfApp1
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ordering_dishes
    {
        public int ID { get; set; }
        public int Fk_dish { get; set; }
        public int Fk_status_dish { get; set; }
        public int Count_dish { get; set; }
        public int Fk_drink { get; set; }
        public int Count_drink { get; set; }
        public int Fk_order { get; set; }
    
        public virtual Dish Dish { get; set; }
        public virtual Drink Drink { get; set; }
        public virtual Order Order { get; set; }
        public virtual Status_dish Status_dish { get; set; }
    }
}
