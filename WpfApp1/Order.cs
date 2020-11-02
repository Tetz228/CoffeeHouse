namespace WpfApp1
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            this.Ordering_dishes = new HashSet<Ordering_dishes>();
        }
    
        public int ID { get; set; }
        public int Fk_table { get; set; }
        public int Fk_status_order { get; set; }
        public int Count_person { get; set; }
        public System.DateTime Data_time { get; set; }
        public decimal Order_price { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ordering_dishes> Ordering_dishes { get; set; }
        public virtual Status_orders Status_orders { get; set; }
        public virtual Table Table { get; set; }
    }
}
