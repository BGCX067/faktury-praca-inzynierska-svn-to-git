using System;
using System.Collections.Generic;
using System.Linq;

namespace faktury.Models
{
    public class ProduktyFakturyKupnaModel
    {
        internal static ProduktyFakturyKupna PobierzProduktFakturyKupnaPoID(int ProduktFakturyKupnaID)
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                return db.ProduktyFakturyKupna.SingleOrDefault(d => d.ProduktFakturyKupnaID == ProduktFakturyKupnaID);
            }
        }

        internal static List<ProduktyFakturyKupna> PobierzProduktyPoID(int dokumentKupnaID)
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                List<ProduktyFakturyKupna> listaProdutkow = new List<ProduktyFakturyKupna>();
                List<ProduktyFakturyKupna> lista = (from p in db.ProduktyFakturyKupna
                                                    where p.DokumentKupnaID == dokumentKupnaID && object.Equals(p.DataZablokowania, null)
                                                    select p).ToList<ProduktyFakturyKupna>();
                foreach (ProduktyFakturyKupna p in lista)
                {
                    p.TowaryUslugi = db.TowaryUslugi.SingleOrDefault(t => t.TowarID == p.TowarID);
                    p.TowaryUslugi.StawkiVat = db.StawkiVat.SingleOrDefault(s => s.StawkaVatID == (p.TowaryUslugi).StawkaVatID);
                    listaProdutkow.Add(p);
                }
                return listaProdutkow;
            }
        }

        internal static void DodajProduktDoFakturyKupna(ProduktyFakturyKupna nowyProdukt)
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                db.ProduktyFakturyKupna.AddObject(nowyProdukt);
                db.SaveChanges();
            }
        }

        internal static void UsunProkuktFakturyKupna(int id, int blokujacy)
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                ProduktyFakturyKupna ProduktDoUsuniecia = db.ProduktyFakturyKupna.SingleOrDefault(p => p.ProduktFakturyKupnaID == id);
                ProduktDoUsuniecia.BlokujacyID = blokujacy;
                ProduktDoUsuniecia.DataZablokowania = DateTime.Now;
                db.SaveChanges();
            }
        }

        internal static void UsunWszystkieProduktyFaktury(int IdFaktury, int blokujacy)
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                List<ProduktyFakturyKupna> lista = (from p in db.ProduktyFakturyKupna
                                                    where p.DokumentKupnaID == IdFaktury && object.Equals(p.DataZablokowania, null)
                                                    select p).ToList<ProduktyFakturyKupna>();
                foreach (ProduktyFakturyKupna p in lista)
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
                List<ProduktyFakturyKupna> lista = (from p in db.ProduktyFakturyKupna
                                                    where p.DokumentKupnaID == staryIdFaktury && object.Equals(p.DataZablokowania, null)
                                                    select p).ToList<ProduktyFakturyKupna>();
                foreach (ProduktyFakturyKupna p in lista)
                {
                    p.DokumentKupnaID = noweIdFaktury;
                    db.SaveChanges();
                }
            }
        }
    }
}