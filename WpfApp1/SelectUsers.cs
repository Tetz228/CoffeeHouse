namespace WpfApp1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SelectUsers
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(30)]
        public string Логин { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(30)]
        public string Пароль { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(212)]
        public string Сотрудник { get; set; }
    }
}
