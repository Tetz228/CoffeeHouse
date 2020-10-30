namespace WpfApp1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SelectOrdering_dishes
    {
        [Column("Номер столика")]
        public int? Номер_столика { get; set; }

        [Column("Название блюда")]
        [StringLength(50)]
        public string Название_блюда { get; set; }

        [Column("Тип блюда")]
        [StringLength(50)]
        public string Тип_блюда { get; set; }

        [Column("Цена блюда", TypeName = "money")]
        public decimal? Цена_блюда { get; set; }

        [Key]
        [Column("Количество порций")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Количество_порций { get; set; }

        [Column("Статус блюда")]
        [StringLength(50)]
        public string Статус_блюда { get; set; }
    }
}
