using System;
using System.Collections.Generic;
using System.Linq;

namespace faktury.Models
{
    public class RozliczenieFakturySprzedazyModel
    {
        internal static RozliczeniaSprzedazy PobierzRozliczenieFakturySprzedazyPoID(int RozliczenieFakturySprzedazyID)
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                return db.RozliczeniaSprzedazy.SingleOrDefault(d => d.RozliczenieSprzedazyID == RozliczenieFakturySprzedazyID);
            }
        }

        internal static List<RozliczeniaSprzedazy> PobierzListeRozliczenSprzedazyPoID(int dokumentSprzedazyID)
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                List<RozliczeniaSprzedazy> listaRozliczenieSprzedazy = new List<RozliczeniaSprzedazy>();
                List<RozliczeniaSprzedazy> lista = (from r in db.RozliczeniaSprzedazy
                                                        where r.DokumentSprzedazyID == dokumentSprzedazyID && object.Equals(r.DataZablokowania, null)
                                                    select r).ToList<RozliczeniaSprzedazy>();
                foreach (RozliczeniaSprzedazy p in lista)
                {
                    listaRozliczenieSprzedazy.Add(p);
                }
                return listaRozliczenieSprzedazy;
            }
        }

        internal static void DodajRozliczenieFakturySprzedazy(RozliczeniaSprzedazy noweRozliczenie)
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                db.RozliczeniaSprzedazy.AddObject(noweRozliczenie);
                db.SaveChanges();
            }
        }

        internal static void UsunRozliczenieFakturySprzedazy(int id, int blokujacy)
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                RozliczeniaSprzedazy RozliczenieDoUsuniecia = db.RozliczeniaSprzedazy.SingleOrDefault(p => p.RozliczenieSprzedazyID == id);
                RozliczenieDoUsuniecia.BlokujacyID = blokujacy;
                RozliczenieDoUsuniecia.DataZablokowania = DateTime.Now;
                db.SaveChanges();
            }
        }

        internal static void UsunWszystkieRozliczeniaFaktury(int IdFaktury, int blokujacy)
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                List<RozliczeniaSprzedazy> lista = (from p in db.RozliczeniaSprzedazy
                                                        where p.DokumentSprzedazyID == IdFaktury && object.Equals(p.DataZablokowania, null)
                                                        select p).ToList<RozliczeniaSprzedazy>();
                foreach (RozliczeniaSprzedazy p in lista)
                {
                    p.BlokujacyID = blokujacy;
                    p.DataZablokowania = DateTime.Now;
                    db.SaveChanges();
                }
            }
        }

        internal static void ZmianaNrFakturyDlaRozliczenia(int staryIdFaktury, int noweIdFaktury)
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                List<RozliczeniaSprzedazy> lista = (from p in db.RozliczeniaSprzedazy
                                                    where p.DokumentSprzedazyID == staryIdFaktury && object.Equals(p.DataZablokowania, null)
                                                    select p).ToList<RozliczeniaSprzedazy>();
                foreach (RozliczeniaSprzedazy p in lista)
                {
                    p.DokumentSprzedazyID = noweIdFaktury;
                    db.SaveChanges();
                }
            }
        }
    }
}