namespace WpfApp1
{
    using System;
    
    public partial class Select_orders_Result
    {
        public Nullable<int> Номер_столика { get; set; }
        public int Количество_человек { get; set; }
        public string Принял_заказ { get; set; }
        public string Статус_заказа { get; set; }
        public System.DateTime Дата_и_время_заказа { get; set; }
        public decimal Сумма_заказ { get; set; }
    }
}
