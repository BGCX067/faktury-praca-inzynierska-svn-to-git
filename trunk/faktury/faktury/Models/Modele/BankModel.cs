using System.Collections.Generic;
using System.Linq;

namespace faktury.Models.Modele
{
    public class BankModel
    {
        public static List<Banki> PobierzListeBankow()
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                return (from b in db.Banki
                        where object.Equals(b.DataZablokowania, null)
                        select b).ToList<Banki>();
            }
        }

        internal static Banki PobierzBankPoID(int id)
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                return db.Banki.SingleOrDefault(u => u.BankID == id);
            }
        }
    }
}