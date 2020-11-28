using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace WpfApp1
{
    class ActionsContracts
    {
        public Contract[] GettingAllContracts()
        {
            using var db = new CafeEntities();
            var contracts = db.Contracts.Include(emp => emp.Employee).ToArray();

            return contracts;
        }
    }
}
