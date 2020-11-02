namespace WpfApp1
{
    using System;
    using System.Collections.Generic;
    
    public partial class Types_drinks
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Types_drinks()
        {
            this.Drinks = new HashSet<Drink>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Drink> Drinks { get; set; }
    }
}
