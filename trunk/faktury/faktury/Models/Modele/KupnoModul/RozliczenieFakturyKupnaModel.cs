using System;
using System.Collections.Generic;
using System.Linq;

namespace faktury.Models
{
    public class RozliczenieFakturyKupnaModel
    {
        internal static RozliczeniaKupna PobierzRozliczenieFakturyKupnaPoID(int RozliczenieFakturyKupnaID)
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                return db.RozliczeniaKupna.SingleOrDefault(d => d.RozliczenieKupnaID == RozliczenieFakturyKupnaID);
            }
        }

        internal static List<RozliczeniaKupna> PobierzListeRozliczenKupnaPoID(int dokumentKupnaID)
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                List<RozliczeniaKupna> listaRozliczenieKupna = new List<RozliczeniaKupna>();
                List<RozliczeniaKupna> lista = (from r in db.RozliczeniaKupna
                                                where r.DokumentKupnaID == dokumentKupnaID && object.Equals(r.DataZablokowania, null)
                                                select r).ToList<RozliczeniaKupna>();
                foreach (RozliczeniaKupna p in lista)
                {
                    listaRozliczenieKupna.Add(p);
                }
                return listaRozliczenieKupna;
            }
        }

        internal static void DodajRozliczenieFakturyKupna(RozliczeniaKupna noweRozliczenie)
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                db.RozliczeniaKupna.AddObject(noweRozliczenie);
                db.SaveChanges();
            }
        }

        internal static void UsunRozliczenieFakturyKupna(int id, int blokujacy)
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                RozliczeniaKupna RozliczenieDoUsuniecia = db.RozliczeniaKupna.SingleOrDefault(p => p.RozliczenieKupnaID == id);
                RozliczenieDoUsuniecia.BlokujacyID = blokujacy;
                RozliczenieDoUsuniecia.DataZablokowania = DateTime.Now;
                db.SaveChanges();
            }
        }

        internal static void UsunWszystkieRozliczeniaFaktury(int IdFaktury, int blokujacy)
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                List<RozliczeniaKupna> lista = (from p in db.RozliczeniaKupna
                                                where p.DokumentKupnaID == IdFaktury && object.Equals(p.DataZablokowania, null)
                                                select p).ToList<RozliczeniaKupna>();
                foreach (RozliczeniaKupna p in lista)
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
                List<RozliczeniaKupna> lista = (from p in db.RozliczeniaKupna
                                                where p.DokumentKupnaID == staryIdFaktury && object.Equals(p.DataZablokowania, null)
                                                select p).ToList<RozliczeniaKupna>();
                foreach (RozliczeniaKupna p in lista)
                {
                    p.DokumentKupnaID = noweIdFaktury;
                    db.SaveChanges();
                }
            }
        }
    }
}