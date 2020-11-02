namespace WpfApp1
{
    using System;
    using System.Collections.Generic;
    
    public partial class Posts_employees
    {
        public int ID { get; set; }
        public int Fk_employee { get; set; }
        public int Fk_post { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual Post Post { get; set; }
    }
}
