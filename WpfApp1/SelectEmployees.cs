namespace WpfApp1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SelectEmployees
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(212)]
        public string ФИО { get; set; }

        [StringLength(50)]
        public string Должность { get; set; }

        [StringLength(250)]
        public string Фотография { get; set; }

        [StringLength(50)]
        public string Статус { get; set; }

        [Key]
        [Column("Номер телефона", Order = 1)]
        [StringLength(50)]
        public string Номер_телефона { get; set; }
    }
}
