namespace WpfApp1
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public int ID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int Fk_employee { get; set; }
    
        public virtual Employee Employee { get; set; }
    }
}
