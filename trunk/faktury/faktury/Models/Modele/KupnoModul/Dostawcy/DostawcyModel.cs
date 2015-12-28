using System;
using System.Collections.Generic;
using System.Linq;
using faktury.Models.Repozytoria;

namespace faktury.Models.Modele
{
    public class DostawcyModel
    {
        public static List<Dostawcy> PobierzListeDostawcow()
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                return (from b in db.Dostawcy
                        where object.Equals(b.DataZablokowania, null)
                        select b).ToList<Dostawcy>();
            }
        }

        public static IList<DostawcyRepozytorium> PobierzListeDostawcowRepozytorium()
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                IEnumerable<Dostawcy> dostawca = PobierzListeDostawcow();
                IList<DostawcyRepozytorium> rezultat = new List<DostawcyRepozytorium>();
                foreach (Dostawcy u in dostawca)
                {
                    DostawcyRepozytorium dostawcy = new DostawcyRepozytorium(u);
                    rezultat.Add(dostawcy);
                }
                return rezultat;
            }
        }

        internal static Dostawcy PobierzDostawcePoID(int id)
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                return db.Dostawcy.SingleOrDefault(d => d.DostawcaID == id);
            }
        }


        internal static Dostawcy DodajDostawce(Dostawcy d)
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                db.Dostawcy.AddObject(d);
                db.SaveChanges();
            }
            return null;
        }

        internal static void UsunDostawce(int id, int blokujacy)
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                Dostawcy Dostawca = db.Dostawcy.SingleOrDefault(d => d.DostawcaID == id);
                Dostawca.BlokujacyID = blokujacy;
                Dostawca.DataZablokowania = DateTime.Now;
                db.SaveChanges();
            }
        }
    }
}