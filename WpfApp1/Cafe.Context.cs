namespace WpfApp1
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
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
        public virtual DbSet<Drink> Drinks { get; set; }
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
        public virtual DbSet<Table> Tables { get; set; }
        public virtual DbSet<Types_dishes> Types_dishes { get; set; }
        public virtual DbSet<Types_drinks> Types_drinks { get; set; }
        public virtual DbSet<User> Users { get; set; }
    
        public virtual ObjectResult<Select_contracts_Result> Select_contracts()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Select_contracts_Result>("Select_contracts");
        }
    
        public virtual int Select_dishes()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Select_dishes");
        }
    
        public virtual ObjectResult<Select_drinks_Result> Select_drinks()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Select_drinks_Result>("Select_drinks");
        }
    
        public virtual ObjectResult<Select_employees_Result> Select_employees()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Select_employees_Result>("Select_employees");
        }
    
        public virtual ObjectResult<Select_ordering_dishes_Result> Select_ordering_dishes()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Select_ordering_dishes_Result>("Select_ordering_dishes");
        }
    
        public virtual ObjectResult<Select_orders_Result> Select_orders()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Select_orders_Result>("Select_orders");
        }
    
        public virtual ObjectResult<string> Select_posts()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("Select_posts");
        }
    
        public virtual ObjectResult<Select_posts_employees_Result> Select_posts_employees()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Select_posts_employees_Result>("Select_posts_employees");
        }
    
        public virtual ObjectResult<Nullable<System.DateTime>> Select_shift_dates()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<System.DateTime>>("Select_shift_dates");
        }
    
        public virtual ObjectResult<Select_shift_list_Result> Select_shift_list()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Select_shift_list_Result>("Select_shift_list");
        }
    
        public virtual ObjectResult<string> Select_status_dish()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("Select_status_dish");
        }
    
        public virtual ObjectResult<string> Select_status_employees()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("Select_status_employees");
        }
    
        public virtual ObjectResult<string> Select_status_orders()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("Select_status_orders");
        }
    
        public virtual ObjectResult<Select_tables_Result> Select_tables()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Select_tables_Result>("Select_tables");
        }
    
        public virtual ObjectResult<string> Select_types_dishes()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("Select_types_dishes");
        }
    
        public virtual ObjectResult<string> Select_types_drinks()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("Select_types_drinks");
        }
    
        public virtual ObjectResult<Select_users_Result> Select_users()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Select_users_Result>("Select_users");
        }
    }
}
