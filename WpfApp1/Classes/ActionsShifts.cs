using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

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
    }
}
