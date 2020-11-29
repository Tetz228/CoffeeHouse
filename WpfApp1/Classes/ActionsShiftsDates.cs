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
    }
}
