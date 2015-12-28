using System;
using System.Collections.Generic;
using System.Linq;

namespace faktury.Models.Modele
{
    public static class SprzedazModel
    {
        internal static DokumentySprzedazy PobierzFakturePoID(int dokumentSprzedazyID)
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                return db.DokumentySprzedazy.SingleOrDefault(d => d.DokumentSprzedazyID == dokumentSprzedazyID);
            }
        }

        internal static List<DokumentySprzedazy> PobierzListFakturSprzedazy(string sort)
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                var dokumentyFakturySprzedazy = (from f in db.DokumentySprzedazy
                                                 where object.Equals(f.DataZablokowania, null)
                                                 select f);
                foreach (DokumentySprzedazy d in dokumentyFakturySprzedazy)
                {
                    d.Banki = db.Banki.SingleOrDefault(b => b.BankID == d.BankID);
                    d.Miejscowosci = db.Miejscowosci.SingleOrDefault(m => m.MiejscowoscID == d.MiejscowoscID);
                    d.Klienci = db.Klienci.SingleOrDefault(k => k.KlientID == d.KlientID);
                    d.FormyPlatnosci = db.FormyPlatnosci.SingleOrDefault(f => f.FormaPlatnosciID == d.FormaPlatnosciID);
                    d.Kraje = db.Kraje.SingleOrDefault(b => b.KrajID == d.KrajID);
                }

                switch (sort)
                {
                    case "NrDokumentu":
                        dokumentyFakturySprzedazy = dokumentyFakturySprzedazy.OrderByDescending(f => f.NrDokumentu);
                        break;
                    case "Klient":
                        dokumentyFakturySprzedazy = dokumentyFakturySprzedazy.OrderBy(f => f.Klienci.Nazwa);
                        break;
                    case "DataWystawienia":
                        dokumentyFakturySprzedazy = dokumentyFakturySprzedazy.OrderByDescending(f => f.DataWystawienia);
                        break;
                    case "DataSprzedazy":
                        dokumentyFakturySprzedazy = dokumentyFakturySprzedazy.OrderByDescending(f => f.DataSprzedazy);
                        break;
                    case "TerminPlatnosci":
                        dokumentyFakturySprzedazy = dokumentyFakturySprzedazy.OrderByDescending(f => f.TerminPlatnosci);
                        break;
                    case "WartoscBrutto":
                        dokumentyFakturySprzedazy = dokumentyFakturySprzedazy.OrderByDescending(f => f.WartoscBrutto);
                        break;
                    case "DoZaplaty":
                        dokumentyFakturySprzedazy = dokumentyFakturySprzedazy.OrderByDescending(f => f.PozostaloDoZaplaty);
                        break;
                    default:
                        dokumentyFakturySprzedazy = dokumentyFakturySprzedazy.OrderByDescending(f => f.NrDokumentu);
                        break;
                }


                return dokumentyFakturySprzedazy.ToList();
            }
        }

        internal static DokumentySprzedazy DokumentSprzdazyPoID(int dokumentSprzedazyID)
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                DokumentySprzedazy dokumentSprzedazy = db.DokumentySprzedazy.SingleOrDefault(d => d.DokumentSprzedazyID == dokumentSprzedazyID);
                dokumentSprzedazy.Miejscowosci = db.Miejscowosci.SingleOrDefault(m => m.MiejscowoscID == dokumentSprzedazy.MiejscowoscID);
                dokumentSprzedazy.Klienci = db.Klienci.SingleOrDefault(k => k.KlientID == dokumentSprzedazy.KlientID);
                dokumentSprzedazy.FormyPlatnosci = db.FormyPlatnosci.SingleOrDefault(f => f.FormaPlatnosciID == dokumentSprzedazy.FormaPlatnosciID);
                dokumentSprzedazy.Banki = db.Banki.SingleOrDefault(b => b.BankID == dokumentSprzedazy.BankID);
                dokumentSprzedazy.Kraje = db.Kraje.SingleOrDefault(b => b.KrajID == dokumentSprzedazy.KrajID);
                return dokumentSprzedazy;
            }
        }

        internal static void DodajFaktureSprzedazy(DokumentySprzedazy dokumentSprzedazy)
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                db.DokumentySprzedazy.AddObject(dokumentSprzedazy);
                db.SaveChanges();
            }
        }

        internal static int PobierzIdFakturySprzedazyPoNrDokumentu(string NrDokumentu)
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                return (db.DokumentySprzedazy.SingleOrDefault(d => d.NrDokumentu == NrDokumentu && d.DataZablokowania == null)).DokumentSprzedazyID;
            }
        }

        internal static void UsunFakture(int id, int blokujacy)
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                DokumentySprzedazy FakturaDoUsuniecia = db.DokumentySprzedazy.SingleOrDefault(d => d.DokumentSprzedazyID == id);
                FakturaDoUsuniecia.BlokujacyID = blokujacy;
                FakturaDoUsuniecia.DataZablokowania = DateTime.Now;

                db.SaveChanges();
            }
        }

        internal static string NumerDokumentu(DateTime dataWystawienia)
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                int numer = ((from f in db.DokumentySprzedazy
                              where f.DataWystawienia.Month == dataWystawienia.Month && f.DataWystawienia.Year == dataWystawienia.Year
                              select f).Count()) + 1;
                return numer.ToString() + "/" + dataWystawienia.Month.ToString() + "/" + dataWystawienia.Year.ToString();
            }
        }

        internal static void WyliczWartosciFaktury(int id)
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                DokumentySprzedazy ObliczanaFaktura = db.DokumentySprzedazy.SingleOrDefault(d => d.DokumentSprzedazyID == id);
                var Brutto = (from p in db.ProduktyFakturySprzedazy
                              where p.DokumentSprzedazyID == ObliczanaFaktura.DokumentSprzedazyID &&
                              object.Equals(p.DataZablokowania, null)
                              select p).Count();

                var zaplacono = (from r in db.RozliczeniaSprzedazy
                                 where r.DokumentSprzedazyID == ObliczanaFaktura.DokumentSprzedazyID && object.Equals(r.DataZablokowania, null)
                                 select r).Count();

                if (zaplacono > 0 && Brutto > 0)
                {
                    ObliczanaFaktura.WartoscBrutto = (from p in db.ProduktyFakturySprzedazy
                                                      where p.DokumentSprzedazyID == ObliczanaFaktura.DokumentSprzedazyID && object.Equals(p.DataZablokowania, null)
                                                      select p).Sum(w => w.WartoscBrutto);
                    ObliczanaFaktura.WartoscNetto = (from p in db.ProduktyFakturySprzedazy
                                                     where p.DokumentSprzedazyID == ObliczanaFaktura.DokumentSprzedazyID && object.Equals(p.DataZablokowania, null)
                                                     select p).Sum(w => w.WartoscNetto);
                    ObliczanaFaktura.PozostaloDoZaplaty = ObliczanaFaktura.WartoscBrutto - (from r in db.RozliczeniaSprzedazy
                                                                                            where r.DokumentSprzedazyID == ObliczanaFaktura.DokumentSprzedazyID && object.Equals(r.DataZablokowania, null)
                                                                                            select r).Sum(w => w.Kwota);
                }
                else if (zaplacono == 0 && Brutto > 0)
                {
                    ObliczanaFaktura.WartoscBrutto = (from p in db.ProduktyFakturySprzedazy
                                                      where p.DokumentSprzedazyID == ObliczanaFaktura.DokumentSprzedazyID && object.Equals(p.DataZablokowania, null)
                                                      select p).Sum(w => w.WartoscBrutto);
                    ObliczanaFaktura.WartoscNetto = (from p in db.ProduktyFakturySprzedazy
                                                     where p.DokumentSprzedazyID == ObliczanaFaktura.DokumentSprzedazyID && object.Equals(p.DataZablokowania, null)
                                                     select p).Sum(w => w.WartoscNetto);
                    ObliczanaFaktura.PozostaloDoZaplaty = ObliczanaFaktura.WartoscBrutto;
                }
                else if (zaplacono > 0 && Brutto == 0)
                {
                    ObliczanaFaktura.WartoscBrutto = 0;
                    ObliczanaFaktura.WartoscNetto = 0;
                    ObliczanaFaktura.PozostaloDoZaplaty = -(from r in db.RozliczeniaSprzedazy
                                                            where r.DokumentSprzedazyID == ObliczanaFaktura.DokumentSprzedazyID && object.Equals(r.DataZablokowania, null)
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