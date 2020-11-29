using System.Data.Entity;
using System.Linq;

namespace WpfApp1
{
    class ActionsTables
    {
        public Table[] GettingAllTables()
        {
            using var db = new CafeEntities();
            var tables = db.Tables.Include(emp => emp.Employee).ToArray();

            return tables;
        }
    }
}
