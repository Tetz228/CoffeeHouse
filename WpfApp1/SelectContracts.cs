namespace WpfApp1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SelectContracts
    {
        [Key]
        [Column("Номер трудового договора", Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Номер_трудового_договора { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(212)]
        public string Сотрудник { get; set; }
    }
}
