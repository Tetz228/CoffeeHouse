using System.Data.Entity;
using System.Linq;

namespace WpfApp1
{
    class ActionsShifts
    {
        public Shift_list[] GettingAllShifts()
        {
            using var db = new CafeEntities();
            var shifts = db.Shift_list.Include(emp => emp.Employee).Include(shiftDate => shiftDate.Shift_dates).ToArray();

            return shifts;
        }

        public void AddShift(int employee, int date)
        {
            using var db = new CafeEntities();

            Shift_list shift_List = new Shift_list()
            {
                Fk_employee = employee,
                Fk_shift_date = date
            };

            db.Shift_list.Add(shift_List);
            db.SaveChanges();
        }

        public void EditShift(int idShift, int employee, int date)
        {
            using var db = new CafeEntities();
            var shifts = db.Shift_list.Where(shiftList => shiftList.ID == idShift).FirstOrDefault();

            shifts.Fk_employee = employee;
            shifts.Fk_shift_date = date;

            db.SaveChanges();
        }
    }
}
