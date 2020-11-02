namespace WpfApp1
{
    using System;
    
    public partial class Select_ordering_dishes_Result
    {
        public Nullable<int> Номер_столика { get; set; }
        public string Название_блюда { get; set; }
        public string Тип_блюда { get; set; }
        public Nullable<decimal> Цена_блюда { get; set; }
        public int Количество_порций { get; set; }
        public string Статус_блюда { get; set; }
        public string Название_напитка { get; set; }
        public string Тип_напитка { get; set; }
        public Nullable<decimal> Цена_напитка { get; set; }
        public int Количество_напитка { get; set; }
    }
}
