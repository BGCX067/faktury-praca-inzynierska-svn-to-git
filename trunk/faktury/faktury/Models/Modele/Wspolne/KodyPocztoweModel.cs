using System.Collections.Generic;
using System.Linq;
using faktury.Models.Repozytoria;

namespace faktury.Models.Modele
{
    public static class KodyPocztoweModel
    {
        public static List<KodyPocztowe> pobierzListeKodowPocztowych()
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                return (from k in db.KodyPocztowe
                           where object.Equals(k.DataZablokowania, null)
                           orderby k.Kod
                           select k).ToList<KodyPocztowe>();               
            }

        }

        public static IList<KodyPocztoweRepozytorium> PobierzListeKodowPocztowychRepozytorium()
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                IEnumerable<KodyPocztowe> kodPocztowy = (from m in db.KodyPocztowe
                                                         where object.Equals(m.DataZablokowania, null)
                                                         select m).ToList<KodyPocztowe>();
                IList<KodyPocztoweRepozytorium> rezultat = new List<KodyPocztoweRepozytorium>();
                foreach (KodyPocztowe c in kodPocztowy)
                {
                    KodyPocztoweRepozytorium kodyPocztowe = new KodyPocztoweRepozytorium(c);
                    rezultat.Add(kodyPocztowe);
                }
                return rezultat;
            }
        }

        public static KodyPocztowe pobierzKodPocztowyPoID(int id)
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                KodyPocztowe kodPocztowy = db.KodyPocztowe.SingleOrDefault(k => k.KodPocztowyID == id);
                kodPocztowy.Miejscowosci = db.Miejscowosci.SingleOrDefault(m => m.MiejscowoscID == kodPocztowy.MiejscowoscID);
                return null;
            }
        }

        internal static KodyPocztowe DodajKodPocztowy(KodyPocztowe k)
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                db.KodyPocztowe.AddObject(k);
                db.SaveChanges();
            }
            return null;
        }
    }
}