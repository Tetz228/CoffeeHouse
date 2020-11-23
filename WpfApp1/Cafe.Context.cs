namespace WpfApp1
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CafeEntities : DbContext
    {
        public CafeEntities()
            : base("name=CafeEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Contract> Contracts { get; set; }
        public virtual DbSet<Dish> Dishes { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Ordering_dishes> Ordering_dishes { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Posts_employees> Posts_employees { get; set; }
        public virtual DbSet<Shift_dates> Shift_dates { get; set; }
        public virtual DbSet<Shift_list> Shift_list { get; set; }
        public virtual DbSet<Status_dish> Status_dish { get; set; }
        public virtual DbSet<Status_employees> Status_employees { get; set; }
        public virtual DbSet<Status_orders> Status_orders { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Table> Tables { get; set; }
        public virtual DbSet<Types_dishes> Types_dishes { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
