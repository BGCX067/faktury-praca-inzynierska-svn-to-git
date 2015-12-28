using System;
using System.Collections.Generic;
using System.Linq;

namespace faktury.Models.Modele
{
    public class KupnoModel
    {
        internal static DokumentyKupna PobierzFakturePoID(int dokumentKupnaID)
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                return db.DokumentyKupna.SingleOrDefault(d => d.DokumentKupnaID == dokumentKupnaID);
            }
        }

        internal static List<DokumentyKupna> PobierzListFakturKupna(string sort)
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                var dokumentyFakturyKupna = (from k in db.DokumentyKupna
                                             where object.Equals(k.DataZablokowania, null)
                                             select k);
                foreach (DokumentyKupna d in dokumentyFakturyKupna)
                {
                    d.Dostawcy = db.Dostawcy.SingleOrDefault(k => k.DostawcaID == d.DostawcaID);
                    d.FormyPlatnosci = db.FormyPlatnosci.SingleOrDefault(k => k.FormaPlatnosciID == d.FormaPlatnosciID);
                }

                switch (sort)
                {
                    case "NrDokumentu":
                        dokumentyFakturyKupna = dokumentyFakturyKupna.OrderByDescending(f => f.NrDokumentu);
                        break;
                    case "Dostawca":
                        dokumentyFakturyKupna = dokumentyFakturyKupna.OrderBy(f => f.Dostawcy.Nazwa);
                        break;
                    case "DataWystawienia":
                        dokumentyFakturyKupna = dokumentyFakturyKupna.OrderByDescending(f => f.DataWystawienia);
                        break;
                    case "DataSprzedazy":
                        dokumentyFakturyKupna = dokumentyFakturyKupna.OrderByDescending(f => f.DataSprzedazy);
                        break;
                    case "TerminPlatnosci":
                        dokumentyFakturyKupna = dokumentyFakturyKupna.OrderByDescending(f => f.TerminPlatnosci);
                        break;
                    case "WartoscBrutto":
                        dokumentyFakturyKupna = dokumentyFakturyKupna.OrderByDescending(f => f.WartoscBrutto);
                        break;
                    case "DoZaplaty":
                        dokumentyFakturyKupna = dokumentyFakturyKupna.OrderByDescending(f => f.PozostaloDoZaplaty);
                        break;
                    default:
                        dokumentyFakturyKupna = dokumentyFakturyKupna.OrderByDescending(f => f.DataWystawienia);
                        break;
                }
                return dokumentyFakturyKupna.ToList();
            }
        }

        internal static DokumentyKupna DokumentKupnaPoID(int dokumentKupnaID)
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                DokumentyKupna dokumentKupna = db.DokumentyKupna.SingleOrDefault(d => d.DokumentKupnaID == dokumentKupnaID);
                dokumentKupna.Dostawcy = db.Dostawcy.SingleOrDefault(d => d.DostawcaID == dokumentKupna.DostawcaID);
                dokumentKupna.FormyPlatnosci = db.FormyPlatnosci.SingleOrDefault(f => f.FormaPlatnosciID == dokumentKupna.FormaPlatnosciID);
                return dokumentKupna;
            }
        }

        internal static void DodajFaktureKupna(DokumentyKupna dokumentKupna)
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                db.DokumentyKupna.AddObject(dokumentKupna);
                db.SaveChanges();
            }
        }

        internal static int PobierzIdFakturyKupnaPoNrDokumentu(string NrDokumentu)
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                return (db.DokumentyKupna.SingleOrDefault(d => d.NrDokumentu == NrDokumentu && d.DataZablokowania == null)).DokumentKupnaID;
            }
        }

        internal static void UsunFakture(int id, int blokujacy)
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                DokumentyKupna FakturaDoUsuniecia = db.DokumentyKupna.SingleOrDefault(d => d.DokumentKupnaID == id);
                FakturaDoUsuniecia.BlokujacyID = blokujacy;
                FakturaDoUsuniecia.DataZablokowania = DateTime.Now;
                db.SaveChanges();
            }
        }

        internal static void WyliczWartosciFaktury(int id)
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                DokumentyKupna ObliczanaFaktura = db.DokumentyKupna.SingleOrDefault(d => d.DokumentKupnaID == id);
                var Brutto = (from p in db.ProduktyFakturyKupna
                              where p.DokumentKupnaID == ObliczanaFaktura.DokumentKupnaID &&
                              object.Equals(p.DataZablokowania, null)
                              select p).Count();

                var zaplacono = (from r in db.RozliczeniaKupna
                                 where r.DokumentKupnaID == ObliczanaFaktura.DokumentKupnaID && object.Equals(r.DataZablokowania, null)
                                 select r).Count();

                if (zaplacono > 0 && Brutto > 0)
                {
                    ObliczanaFaktura.WartoscBrutto = (from p in db.ProduktyFakturyKupna
                                                      where p.DokumentKupnaID == ObliczanaFaktura.DokumentKupnaID && object.Equals(p.DataZablokowania, null)
                                                      select p).Sum(w => w.WartoscBrutto);
                    ObliczanaFaktura.WartoscNetto = (from p in db.ProduktyFakturyKupna
                                                     where p.DokumentKupnaID == ObliczanaFaktura.DokumentKupnaID && object.Equals(p.DataZablokowania, null)
                                                     select p).Sum(w => w.WartoscNetto);
                    ObliczanaFaktura.PozostaloDoZaplaty = ObliczanaFaktura.WartoscBrutto - (from r in db.RozliczeniaKupna
                                                                                            where r.DokumentKupnaID == ObliczanaFaktura.DokumentKupnaID && object.Equals(r.DataZablokowania, null)
                                                                                            select r).Sum(w => w.Kwota);
                }
                else if (zaplacono == 0 && Brutto > 0)
                {
                    ObliczanaFaktura.WartoscBrutto = (from p in db.ProduktyFakturyKupna
                                                      where p.DokumentKupnaID == ObliczanaFaktura.DokumentKupnaID && object.Equals(p.DataZablokowania, null)
                                                      select p).Sum(w => w.WartoscBrutto);
                    ObliczanaFaktura.WartoscNetto = (from p in db.ProduktyFakturyKupna
                                                     where p.DokumentKupnaID == ObliczanaFaktura.DokumentKupnaID && object.Equals(p.DataZablokowania, null)
                                                     select p).Sum(w => w.WartoscNetto);
                    ObliczanaFaktura.PozostaloDoZaplaty = ObliczanaFaktura.WartoscBrutto;
                }
                else if (zaplacono > 0 && Brutto == 0)
                {
                    ObliczanaFaktura.WartoscBrutto = 0;
                    ObliczanaFaktura.WartoscNetto = 0;
                    ObliczanaFaktura.PozostaloDoZaplaty = -(from r in db.RozliczeniaKupna
                                                            where r.DokumentKupnaID == ObliczanaFaktura.DokumentKupnaID && object.Equals(r.DataZablokowania, null)
                                                            select r).Sum(w => w.Kwota);
                }
                else
                {
                    ObliczanaFaktura.WartoscBrutto = 0;
                    ObliczanaFaktura.WartoscNetto = 0;
                    ObliczanaFaktura.PozostaloDoZaplaty = 0;
                }

                db.SaveChanges();
            }
        }
    }
}