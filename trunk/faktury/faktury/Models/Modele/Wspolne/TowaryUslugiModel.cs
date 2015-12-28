using System;
using System.Collections.Generic;
using System.Linq;
using faktury.Models.Repozytoria;

namespace faktury.Models.Modele
{
    public static class TowaryUslugiModel
    {
        public static List<TowaryUslugi> PobierzListTowarow()
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                return (from tu in db.TowaryUslugi
                        where object.Equals(tu.DataZablokowania, null)
                        orderby tu.Nazwa
                        select tu).ToList<TowaryUslugi>();
            }
        }

        public static IList<TowaryUslugiRepozytorium> PobierzListeTowarowRepozytorium()
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                IEnumerable<TowaryUslugi> towarUsluga = (from t in db.TowaryUslugi
                                                         where object.Equals(t.DataZablokowania, null)
                                                         select t).ToList<TowaryUslugi>();
                IList<TowaryUslugiRepozytorium> rezultat = new List<TowaryUslugiRepozytorium>();
                foreach (TowaryUslugi u in towarUsluga)
                {
                    TowaryUslugiRepozytorium towaryUslugi = new TowaryUslugiRepozytorium(u);
                    rezultat.Add(towaryUslugi);
                }
                return rezultat;
            }
        }

        internal static TowaryUslugi PobierzTowarUsugePoID(int id)
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                return db.TowaryUslugi.SingleOrDefault(t => t.TowarID == id);
            }
        }

        internal static TowaryUslugi ZapiszTowarUsluge(TowaryUslugiRepozytorium t)
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                if (t.NowyTowar.TowarID != 0)
                {
                    UsunTowarUsluge(t.NowyTowar.TowarID, t.NowyTowar.WlascicielID);
                }
                TowaryUslugi towarUsluga = t.NowyTowar;

                if (t.rodzaj)
                    towarUsluga.Rodzaj = "Towar";
                else
                    towarUsluga.Rodzaj = "Usługa";

                if (t.netto)
                {
                    towarUsluga.CenaNetto = t.cena;
                    towarUsluga.CenaBrutto = t.cena * (1 + (((decimal)StawkiVatModel.PobierzStawkeVatPoID(t.NowyTowar.StawkaVatID).Wartosc) / 100));
                }
                else
                {
                    towarUsluga.CenaBrutto = t.cena;
                    towarUsluga.CenaNetto = t.cena / (1 + (((decimal)StawkiVatModel.PobierzStawkeVatPoID(t.NowyTowar.StawkaVatID).Wartosc) / 100));
                }

                db.TowaryUslugi.AddObject(towarUsluga);
                db.SaveChanges();
            }
            return null;
        }

        internal static void UsunTowarUsluge(int id, int blokujacy)
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                TowaryUslugi TowarUsluga = db.TowaryUslugi.SingleOrDefault(o => o.TowarID == id);
                TowarUsluga.BlokujacyID = blokujacy;
                TowarUsluga.DataZablokowania = DateTime.Now;
                db.SaveChanges();
            }
        }
    }
}