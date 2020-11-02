namespace WpfApp1
{
    using System;
    using System.Collections.Generic;
    
    public partial class Shift_list
    {
        public int ID { get; set; }
        public int Fk_employee { get; set; }
        public int Fk_shift_date { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual Shift_dates Shift_dates { get; set; }
    }
}
