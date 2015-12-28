using System;
using System.Linq;
using System.Web.Mvc;
using faktury.Models;
using faktury.Models.Modele;

namespace faktury.Controllers
{
    public class FakturyKupnoController : Controller
    {
        #region faktura
        public ActionResult Index(string sort)
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");

            sort = String.IsNullOrEmpty(sort) ? "DataWystawienia" : sort;

            return View(KupnoModel.PobierzListFakturKupna(sort));
        }

        public ActionResult Details(int id)
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");

            FakturaKupna faktura = new FakturaKupna();
            faktura.dokumentKupna = KupnoModel.DokumentKupnaPoID(id);
            faktura.ListaProduktowKupna = ProduktyFakturyKupnaModel.PobierzProduktyPoID(id);
            faktura.ListaRozliczeniaKupna = RozliczenieFakturyKupnaModel.PobierzListeRozliczenKupnaPoID(id);

            return View(faktura);
        }

        public ActionResult Create()
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");
            KontrahentKupnoModel kontrahenci = new KontrahentKupnoModel();
            SelectList kontrahent = kontrahenci.dodajWszystkich(DostawcyModel.PobierzListeDostawcow());
            SelectList t = new SelectList(TowaryUslugiModel.PobierzListTowarow(), "TowarID", "Nazwa");
            SelectList FormaPlatnosc = new SelectList(FormyPlatnosciModel.PobierzListeFormPlatnosci(), "FormaPlatnosciID", "Nazwa");

            if (FormaPlatnosc.Count() == 0 || kontrahent.Count() == 0 || t.Count() == 0)
            {
                System.Collections.Generic.List<string> brakuje = new System.Collections.Generic.List<string>();
                brakuje.Add("Dostawcy");
                brakuje.Add("Towary i usługi");
                brakuje.Add("Formy płatności");

                ViewData["Brakuje"] = brakuje;
                return View("BladPostepowania");
            }
            else
            {
                ViewData["FormyPlatnosci"] = FormaPlatnosc;
                ViewData["Kontrahenci"] = kontrahent;
                return View(new DokumentyKupna());
            }
        }

        [HttpPost]
        public ActionResult Create(DokumentyKupna dokumentKupna, int Kontrahent, int FormaPlatnosci)
        {
            try
            {
                if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                    return RedirectToAction("LogOn", "Account");

                if (dokumentKupna.TerminPlatnosci < dokumentKupna.DataWystawienia)
                    ModelState.AddModelError("TerminPlatnosci", "Data wystawienia musi być wcześniejsza niż temin płatności!");

                if (ModelState.IsValid)
                {
                    using (FakturyDBEntitiess db = new FakturyDBEntitiess())
                    {
                        Uzytkownicy wlasciciel = UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name);
                        dokumentKupna.WlascicielID = wlasciciel.UzytkownikID;
                        dokumentKupna.DataWprowadzenia = DateTime.Now;
                        dokumentKupna.DostawcaID = Kontrahent;
                        dokumentKupna.FormaPlatnosciID = FormaPlatnosci;
                        KupnoModel.DodajFaktureKupna(dokumentKupna);

                    }
                    return RedirectToAction("CreateProduktyKupna", "FakturyKupno",
                        new { dokumentKupnaID = KupnoModel.PobierzIdFakturyKupnaPoNrDokumentu(dokumentKupna.NrDokumentu) });
                }
                else
                {
                    KontrahentKupnoModel kontrahenci = new KontrahentKupnoModel();
                    ViewData["Kontrahenci"] = kontrahenci.dodajWszystkich(DostawcyModel.PobierzListeDostawcow());
                    ViewData["FormyPlatnosci"] = new SelectList(FormyPlatnosciModel.PobierzListeFormPlatnosci(), "FormaPlatnosciID", "Nazwa", dokumentKupna.FormaPlatnosciID);
                    return View("Create", dokumentKupna);
                }
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");

            DokumentyKupna dokumentDoEdycji = KupnoModel.PobierzFakturePoID(id);

            KontrahentKupnoModel kontrahenci = new KontrahentKupnoModel();
            ViewData["Kontrahenci"] = kontrahenci.dodajWszystkich(DostawcyModel.PobierzListeDostawcow());
            ViewData["FormyPlatnosci"] = new SelectList(FormyPlatnosciModel.PobierzListeFormPlatnosci(), "FormaPlatnosciID", "Nazwa", dokumentDoEdycji.FormaPlatnosciID);

            return View(dokumentDoEdycji);
        }

        [HttpPost]
        public ActionResult Edit(int id, DokumentyKupna dokumentKupna, int Kontrahent, int FormaPlatnosci)
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");

            try
            {
                if (dokumentKupna.TerminPlatnosci < dokumentKupna.DataWystawienia)
                    ModelState.AddModelError("TerminPlatnosci", "Data wystawienia musi być wcześniejsza niż temin płatności!");

                if (ModelState.IsValid)
                {
                    using (FakturyDBEntitiess db = new FakturyDBEntitiess())
                    {
                        Uzytkownicy modyfikujacy = UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name);

                        dokumentKupna.DostawcaID = Kontrahent;
                        dokumentKupna.FormaPlatnosciID = FormaPlatnosci;
                        dokumentKupna.WlascicielID = modyfikujacy.UzytkownikID;
                        dokumentKupna.DataWprowadzenia = DateTime.Now;
                        KupnoModel.UsunFakture(id, modyfikujacy.UzytkownikID);
                        KupnoModel.DodajFaktureKupna(dokumentKupna);

                        var nowyNr = KupnoModel.PobierzIdFakturyKupnaPoNrDokumentu(dokumentKupna.NrDokumentu);
                        ProduktyFakturyKupnaModel.ZmianaNrFakturyDlaRProduktow(id, nowyNr);
                        RozliczenieFakturyKupnaModel.ZmianaNrFakturyDlaRozliczenia(id, nowyNr);

                    }
                    return RedirectToAction("CreateProduktyKupna", "FakturyKupno", new
                    {
                        dokumentKupnaID = KupnoModel.PobierzIdFakturyKupnaPoNrDokumentu(dokumentKupna.NrDokumentu)
                    });
                }
                else
                {
                    KontrahentKupnoModel kontrahenci = new KontrahentKupnoModel();
                    ViewData["Kontrahenci"] = kontrahenci.dodajWszystkich(DostawcyModel.PobierzListeDostawcow());
                    ViewData["FormyPlatnosci"] = new SelectList(FormyPlatnosciModel.PobierzListeFormPlatnosci(), "FormaPlatnosciID", "Nazwa", dokumentKupna.FormaPlatnosciID);
                    return View("Edit", dokumentKupna);
                }
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");

            DokumentyKupna DokumentDoUsuniecia = KupnoModel.PobierzFakturePoID(id);
            return View(DokumentDoUsuniecia);
        }

        [HttpPost]
        public ActionResult Delete(int id, DokumentyKupna d)
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");

            try
            {
                using (FakturyDBEntitiess db = new FakturyDBEntitiess())
                {
                    Uzytkownicy blokujacy = UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name);
                    KupnoModel.UsunFakture(id, blokujacy.UzytkownikID);

                    ProduktyFakturyKupnaModel.UsunWszystkieProduktyFaktury(id, blokujacy.UzytkownikID);
                    RozliczenieFakturyKupnaModel.UsunWszystkieRozliczeniaFaktury(id, blokujacy.UzytkownikID);
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }
        #endregion

        #region produktyTowary
        public ActionResult CreateProduktyKupna(int dokumentKupnaID)
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");

            FakturaKupna faktura = new FakturaKupna();
            faktura.dokumentKupna = KupnoModel.PobierzFakturePoID(dokumentKupnaID);
            faktura.ListaProduktowKupna = ProduktyFakturyKupnaModel.PobierzProduktyPoID(dokumentKupnaID);
            ViewData["Towary"] = new SelectList(TowaryUslugiModel.PobierzListTowarow(), "TowarID", "Nazwa");
            return View(faktura);
        }

        [HttpPost]
        public ActionResult CreateProduktyKupna(int dokumentKupnaID, FakturaKupna dokumentKupna, int Towary)
        {
            try
            {
                if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                    return RedirectToAction("LogOn", "Account");

                if (ModelState.IsValid)
                {
                    using (FakturyDBEntitiess db = new FakturyDBEntitiess())
                    {
                        ProduktyFakturyKupna nowyProdukt = new ProduktyFakturyKupna();
                        Uzytkownicy wlasciciel = UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name);
                        nowyProdukt.WlascicielID = wlasciciel.UzytkownikID;
                        nowyProdukt.DataWprowadzenia = DateTime.Now;
                        nowyProdukt.DokumentKupnaID = dokumentKupnaID;
                        nowyProdukt.TowarID = Towary;
                        nowyProdukt.Ilosc = dokumentKupna.ProduktFakturyKupna.Ilosc;
                        TowaryUslugi Towar = TowaryUslugiModel.PobierzTowarUsugePoID(Towary);
                        nowyProdukt.WartoscNetto = Towar.CenaNetto * nowyProdukt.Ilosc;
                        nowyProdukt.WartoscBrutto = nowyProdukt.WartoscNetto *
                            (1 + (((decimal)StawkiVatModel.PobierzStawkeVatPoID(Towar.StawkaVatID).Wartosc) / 100));

                        ProduktyFakturyKupnaModel.DodajProduktDoFakturyKupna(nowyProdukt);
                        KupnoModel.WyliczWartosciFaktury(dokumentKupnaID);

                    }
                    return RedirectToAction("CreateProduktyKupna", "FakturyKupno", new { dokumentKupnaID = dokumentKupnaID });
                }
                else
                {
                    FakturaKupna faktura = new FakturaKupna();
                    faktura.dokumentKupna = KupnoModel.PobierzFakturePoID(dokumentKupnaID);
                    faktura.ListaProduktowKupna = ProduktyFakturyKupnaModel.PobierzProduktyPoID(dokumentKupnaID);
                    ViewData["Towary"] = new SelectList(TowaryUslugiModel.PobierzListTowarow(), "TowarID", "Nazwa");
                    return View("CreateProduktyKupna", faktura);
                }
            }
            catch
            {
                return View();
            }
        }

        public ActionResult DeleteProduktFakturKupna(int id)
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");

            try
            {
                using (FakturyDBEntitiess db = new FakturyDBEntitiess())
                {
                    ProduktyFakturyKupnaModel.UsunProkuktFakturyKupna(id, (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name)).UzytkownikID);
                    KupnoModel.WyliczWartosciFaktury((ProduktyFakturyKupnaModel.PobierzProduktFakturyKupnaPoID(id)).DokumentKupnaID);
                    return RedirectToAction("CreateProduktyKupna", "FakturyKupno",
                        new { dokumentKupnaID = (ProduktyFakturyKupnaModel.PobierzProduktFakturyKupnaPoID(id)).DokumentKupnaID });
                }
            }
            catch
            {
                return View();
            }
        }

        public ActionResult EditListaProduktowKupna(int id)
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");

            try
            {
                using (FakturyDBEntitiess db = new FakturyDBEntitiess())
                {
                    return RedirectToAction("CreateProduktyKupna", "FakturyKupno",
                        new { dokumentKupnaID = id });
                }
            }
            catch
            {
                return View();
            }
        }
        #endregion

        #region rozliczenia
        public ActionResult CreateRozliczenieKupna(int dokumentKupnaID)
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");

            FakturaKupna faktura = new FakturaKupna();
            faktura.dokumentKupna = KupnoModel.PobierzFakturePoID(dokumentKupnaID);
            faktura.ListaRozliczeniaKupna = RozliczenieFakturyKupnaModel.PobierzListeRozliczenKupnaPoID(dokumentKupnaID);
            return View(faktura);
        }

        [HttpPost]
        public ActionResult CreateRozliczenieKupna(int dokumentKupnaID, FakturaKupna dokumentKupna)
        {
            try
            {
                if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                    return RedirectToAction("LogOn", "Account");


                if (ModelState.IsValid)
                {
                    using (FakturyDBEntitiess db = new FakturyDBEntitiess())
                    {
                        RozliczeniaKupna noweRozliczenie = new RozliczeniaKupna();
                        Uzytkownicy wlasciciel = UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name);
                        noweRozliczenie.WlascicielID = wlasciciel.UzytkownikID;
                        noweRozliczenie.DataWprowadzenia = DateTime.Now;
                        noweRozliczenie.DokumentKupnaID = dokumentKupnaID;
                        noweRozliczenie.DataZaplaty = dokumentKupna.RozliczenieKupna.DataZaplaty;
                        noweRozliczenie.Kwota = dokumentKupna.RozliczenieKupna.Kwota;

                        RozliczenieFakturyKupnaModel.DodajRozliczenieFakturyKupna(noweRozliczenie);
                        KupnoModel.WyliczWartosciFaktury(dokumentKupnaID);

                    }
                    return RedirectToAction("CreateRozliczenieKupna", "FakturyKupno", new { dokumentKupnaID = dokumentKupnaID });
                }
                else
                {
                    FakturaKupna faktura = new FakturaKupna();
                    faktura.dokumentKupna = KupnoModel.PobierzFakturePoID(dokumentKupnaID);
                    faktura.ListaRozliczeniaKupna = RozliczenieFakturyKupnaModel.PobierzListeRozliczenKupnaPoID(dokumentKupnaID);
                    return View("CreateRozliczenieKupna", faktura);
                }
            }
            catch
            {
                return View();
            }
        }

        public ActionResult EdytujRozliczeniaFakturyKupna(int id)
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");

            try
            {
                using (FakturyDBEntitiess db = new FakturyDBEntitiess())
                {
                    return RedirectToAction("CreateRozliczenieKupna", "FakturyKupno",
                        new { dokumentKupnaID = id });
                }
            }
            catch
            {
                return View();
            }
        }

        public ActionResult DeleteRozliczenieFakturyKupna(int id)
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");

            try
            {
                using (FakturyDBEntitiess db = new FakturyDBEntitiess())
                {
                    RozliczenieFakturyKupnaModel.UsunRozliczenieFakturyKupna(id, (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name)).UzytkownikID);
                    KupnoModel.WyliczWartosciFaktury((RozliczenieFakturyKupnaModel.PobierzRozliczenieFakturyKupnaPoID(id)).DokumentKupnaID);
                    return RedirectToAction("CreateRozliczenieKupna", "FakturyKupno",
                        new { dokumentKupnaID = (RozliczenieFakturyKupnaModel.PobierzRozliczenieFakturyKupnaPoID(id)).DokumentKupnaID });
                }
            }
            catch
            {
                return View();
            }
        }
        #endregion
    }
}
