//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

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
    
        public virtual Dishes Dishes { get; set; }
        public virtual Drinks Drinks { get; set; }
        public virtual Orders Orders { get; set; }
        public virtual Status_dish Status_dish { get; set; }
    }
}
