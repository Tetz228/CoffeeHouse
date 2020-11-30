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

        public void AddTable(int numberTable, int employee)
        {
            using var db = new CafeEntities();

            Table table = new Table()
            {
                Table_number = numberTable,
                Fk_employee = employee
            };

            db.Tables.Add(table);
            db.SaveChanges();
        }

        public void EditTable(int idTable, int numberTable, int idEmployee)
        {
            using var db = new CafeEntities();

            var tables = db.Tables.Where(tl => tl.ID == idTable).FirstOrDefault();

            tables.Table_number = numberTable;
            tables.Fk_employee = idEmployee;

            db.SaveChanges();
        }
    }
}
