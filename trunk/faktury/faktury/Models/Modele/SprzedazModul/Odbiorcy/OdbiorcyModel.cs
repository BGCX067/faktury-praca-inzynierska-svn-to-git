using System;
using System.Collections.Generic;
using System.Linq;

namespace faktury.Models.Modele
{
    public class OdbiorcyModel
    {

        internal static List<Klienci> PobierzWszystkichOdbiorcow()
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                return (from k in db.Klienci 
                        where object.Equals(k.DataZablokowania, null)
                        select k).ToList<Klienci>();
            }
        }

        public static IList<OdbiorcyRepozytorium> PobierzListeOdbiorcowRepozytorium()
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                IEnumerable<Klienci> odbiorca = PobierzWszystkichOdbiorcow();
                IList<OdbiorcyRepozytorium> rezultat = new List<OdbiorcyRepozytorium>();
                foreach (Klienci u in odbiorca)
                {
                    OdbiorcyRepozytorium odbiorcy = new OdbiorcyRepozytorium(u);
                    rezultat.Add(odbiorcy);
                }
                return rezultat;
            }
        }

        internal static Klienci PobierzOdbiorcePoID(int id)
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                return db.Klienci.SingleOrDefault(d => d.KlientID == id);
            }
        }

        internal static Klienci DodajOdbiorce(Klienci k)
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                db.Klienci.AddObject(k);
                db.SaveChanges();
            }
            return null;
        }

        internal static void UsunOdbiorce(int id, int blokujacy)
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                Klienci Klient = db.Klienci.SingleOrDefault(d => d.KlientID == id);
                Klient.BlokujacyID = blokujacy;
                Klient.DataZablokowania = DateTime.Now;
                db.SaveChanges();
            }
        }
    }
}