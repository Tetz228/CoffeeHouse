namespace WpfApp1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SelectDishes
    {
        [Key]
        [Column("Название блюда", Order = 0)]
        [StringLength(50)]
        public string Название_блюда { get; set; }

        [Column("Тип блюда")]
        [StringLength(50)]
        public string Тип_блюда { get; set; }

        [Key]
        [Column("Цена блюда", Order = 1, TypeName = "money")]
        public decimal Цена_блюда { get; set; }
    }
}
