namespace WpfApp1
{
    using System;
    using System.Collections.Generic;
    
    public partial class Shift_dates
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Shift_dates()
        {
            this.Shift_list = new HashSet<Shift_list>();
        }
    
        public int ID { get; set; }
        public System.DateTime Date { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Shift_list> Shift_list { get; set; }
    }
}
