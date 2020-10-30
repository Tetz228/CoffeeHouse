namespace WpfApp1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SelectTables
    {
        [Key]
        [Column("Номер столика", Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Номер_столика { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(212)]
        public string Сотрудник { get; set; }
    }
}
