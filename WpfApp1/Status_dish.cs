namespace WpfApp1
{
    using System;
    using System.Collections.Generic;
    
    public partial class Status_dish
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Status_dish()
        {
            this.Ordering_dishes = new HashSet<Ordering_dishes>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ordering_dishes> Ordering_dishes { get; set; }
    }
}
