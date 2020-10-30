namespace WpfApp1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SelectOrders
    {
        [Column("Номер столика")]
        public int? Номер_столика { get; set; }

        [Key]
        [Column("Принял заказ", Order = 0)]
        [StringLength(212)]
        public string Принял_заказ { get; set; }

        [Column("Статус заказа")]
        [StringLength(50)]
        public string Статус_заказа { get; set; }

        [Key]
        [Column("Дата и время заказа", Order = 1)]
        public DateTime Дата_и_время_заказа { get; set; }

        [Key]
        [Column("Сумма заказ", Order = 2, TypeName = "money")]
        public decimal Сумма_заказ { get; set; }
    }
}
