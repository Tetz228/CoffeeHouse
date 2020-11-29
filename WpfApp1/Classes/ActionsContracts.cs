using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Media;
using System.Windows.Media.Imaging;

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

        public void AddContract(int numberContract, int idEmp, string wayToPhoto)
        {
            using var db = new CafeEntities();

            Contract contract = new Contract()
            {
                Number_contract = numberContract,
                Fk_employee = idEmp,
                Scan_contract = wayToPhoto,
            };

            db.Contracts.Add(contract);
            db.SaveChanges();
        }
    }
}
