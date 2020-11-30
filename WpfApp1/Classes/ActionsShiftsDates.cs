using System;
using System.Linq;

namespace WpfApp1
{
    class ActionsShiftsDates
    {
        public Shift_dates[] GettingAllShiftsDates()
        {
            using var db = new CafeEntities();

            var shift_dates = db.Shift_dates.ToArray();

            return shift_dates;
        }

        public void AddShiftDate(DateTime date)
        {
            using var db = new CafeEntities();
            Shift_dates shiftDate = new Shift_dates()
            {
                Date = date
            };

            db.Shift_dates.Add(shiftDate);
            db.SaveChanges();
        }
    }
}
