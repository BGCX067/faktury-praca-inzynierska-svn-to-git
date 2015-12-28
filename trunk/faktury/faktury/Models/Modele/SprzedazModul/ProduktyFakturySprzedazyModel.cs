using System;
using System.Collections.Generic;
using System.Linq;

namespace faktury.Models
{
    public static class ProduktyFakturySprzedazyModel
    {
        internal static ProduktyFakturySprzedazy PobierzProduktFakturySprzedazyPoID(int ProduktFakturySprzedazyID)
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                return db.ProduktyFakturySprzedazy.SingleOrDefault(d => d.ProduktFakturySprzedazyID == ProduktFakturySprzedazyID);
            }
        }

        internal static List<ProduktyFakturySprzedazy> PobierzProduktyPoID(int dokumentSprzedazyID)
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                List<ProduktyFakturySprzedazy> listaProdutkow = new List<ProduktyFakturySprzedazy>();
                List<ProduktyFakturySprzedazy> lista = (from p in db.ProduktyFakturySprzedazy
                                                        where p.DokumentSprzedazyID == dokumentSprzedazyID && object.Equals(p.DataZablokowania, null)
                                                        select p).ToList<ProduktyFakturySprzedazy>();
                foreach (ProduktyFakturySprzedazy p in lista)
                {
                    p.TowaryUslugi = db.TowaryUslugi.SingleOrDefault(t => t.TowarID == p.TowarID);
                    p.TowaryUslugi.StawkiVat = db.StawkiVat.SingleOrDefault(s => s.StawkaVatID == (p.TowaryUslugi).StawkaVatID);
                    p.TowaryUslugi.JednostkiMiar = db.JednostkiMiar.SingleOrDefault(j => j.JednostkaMiarID == (p.TowaryUslugi).JednostkaMiarID);
                    listaProdutkow.Add(p);
                }
                return listaProdutkow;
            }
        }

        internal static void DodajProduktDoFakturySprzedazy(ProduktyFakturySprzedazy nowyProdukt)
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                db.ProduktyFakturySprzedazy.AddObject(nowyProdukt);
                db.SaveChanges();
            }
        }

        internal static void UsunProkuktFakturySprzedazy(int id, int blokujacy)
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                ProduktyFakturySprzedazy ProduktDoUsuniecia = db.ProduktyFakturySprzedazy.SingleOrDefault(p => p.ProduktFakturySprzedazyID == id);
                ProduktDoUsuniecia.BlokujacyID = blokujacy;
                ProduktDoUsuniecia.DataZablokowania = DateTime.Now;
                db.SaveChanges();
            }
        }

        internal static void UsunWszystkieProktyFaktury(int IdFaktury, int blokujacy)
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                List<ProduktyFakturySprzedazy> lista = (from p in db.ProduktyFakturySprzedazy
                                                        where p.DokumentSprzedazyID == IdFaktury && object.Equals(p.DataZablokowania, null)
                                                        select p).ToList<ProduktyFakturySprzedazy>();
                foreach (ProduktyFakturySprzedazy p in lista)
                {
                    p.BlokujacyID = blokujacy;
                    p.DataZablokowania = DateTime.Now;
                    db.SaveChanges();
                }
            }
        }
        
        internal static void ZmianaNrFakturyDlaRProduktow(int staryIdFaktury, int noweIdFaktury)
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                List<ProduktyFakturySprzedazy> lista = (from p in db.ProduktyFakturySprzedazy
                                                    where p.DokumentSprzedazyID == staryIdFaktury && object.Equals(p.DataZablokowania, null)
                                                    select p).ToList<ProduktyFakturySprzedazy>();
                foreach (ProduktyFakturySprzedazy p in lista)
                {
                    p.DokumentSprzedazyID = noweIdFaktury;
                    db.SaveChanges();
                }
            }
        }
    }
}