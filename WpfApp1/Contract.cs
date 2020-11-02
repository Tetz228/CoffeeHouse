namespace WpfApp1
{
    using System;
    using System.Collections.Generic;
    
    public partial class Contract
    {
        public int ID { get; set; }
        public int Number_contract { get; set; }
        public int Fk_employee { get; set; }
        public string Scan_contract { get; set; }
    
        public virtual Employee Employee { get; set; }
    }
}
