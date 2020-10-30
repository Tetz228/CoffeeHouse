namespace WpfApp1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SelectType_dish
    {
        [Key]
        [Column("Тип блюда")]
        [StringLength(50)]
        public string Тип_блюда { get; set; }
    }
}
