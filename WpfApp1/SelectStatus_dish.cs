namespace WpfApp1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SelectStatus_dish
    {
        [Key]
        [Column("Статус блюда")]
        [StringLength(50)]
        public string Статус_блюда { get; set; }
    }
}
