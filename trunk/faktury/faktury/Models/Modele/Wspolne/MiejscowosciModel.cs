using System.Collections.Generic;
using System.Linq;
using faktury.Models.Repozytoria;

namespace faktury.Models.Modele
{
    public static class MiejscowosciModel
    {
        public static List<Miejscowosci> PobierzListeMiejscowosci()
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                return (from m in db.Miejscowosci
                        where object.Equals(m.DataZablokowania, null)
                        orderby m.Nazwa
                        select m).ToList<Miejscowosci>();
            }
        }

        public static IList<MiejscowosciRepozytorium> PobierzListeMiejscowosciRepozytorium()
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                IEnumerable<Miejscowosci> miejscowosci = (from m in db.Miejscowosci
                                                          where object.Equals(m.DataZablokowania, null)
                                                          select m).ToList<Miejscowosci>();
                IList<MiejscowosciRepozytorium> rezultat = new List<MiejscowosciRepozytorium>();
                foreach (Miejscowosci c in miejscowosci)
                {
                    MiejscowosciRepozytorium miejscowosc = new MiejscowosciRepozytorium(c);
                    rezultat.Add(miejscowosc);
                }
                return rezultat;
            }
        }

        internal static Miejscowosci PobierzMiejscowoscPoID(int id)
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                Miejscowosci miejscowosc = db.Miejscowosci.SingleOrDefault(u => u.MiejscowoscID == id);
                miejscowosc.Kraje = db.Kraje.SingleOrDefault(k => k.KrajID == miejscowosc.KrajID);
                return miejscowosc;
            }
        }

        internal static Miejscowosci DodajMiejscowosc(Miejscowosci m)
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                db.Miejscowosci.AddObject(m);
                db.SaveChanges();
            }
            return null;
        }
    }
}