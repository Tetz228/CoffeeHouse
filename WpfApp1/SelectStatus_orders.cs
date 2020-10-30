namespace WpfApp1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SelectStatus_orders
    {
        [Key]
        [Column("Статус заказа")]
        [StringLength(50)]
        public string Статус_заказа { get; set; }
    }
}
