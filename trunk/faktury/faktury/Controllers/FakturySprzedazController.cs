using System;
using System.Linq;
using System.Web.Mvc;
using faktury.Models;
using faktury.Models.Modele;
using System.IO;
using System.Web;
using System.Net.Mail;
using System.Net;

namespace faktury.Controllers
{
    public class FakturySprzedazController : Controller
    {
        #region faktura
        //public ActionResult Index()
        //{
        //    if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
        //        return RedirectToAction("LogOn", "Account");

        //    return View(SprzedazModel.PobierzListFakturSprzedazy());
        //}

        public ActionResult Index(string sort)
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");

            sort = String.IsNullOrEmpty(sort) ? "DataWystawienia" : sort;
            return View(SprzedazModel.PobierzListFakturSprzedazy(sort));
        }

        public ActionResult Details(int id)
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");

            FakturaSprzedazy faktura = new FakturaSprzedazy();
            faktura.dokumentSprzedazy = SprzedazModel.DokumentSprzdazyPoID(id);
            faktura.ListaProduktowSprzedazy = ProduktyFakturySprzedazyModel.PobierzProduktyPoID(id);
            faktura.ListaRozliczeniaSprzedazy = RozliczenieFakturySprzedazyModel.PobierzListeRozliczenSprzedazyPoID(id);

            return View(faktura);
        }

        public ActionResult Create()
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");
            KontrahentModel kontrahenci = new KontrahentModel();
            SelectList Kontrahent = kontrahenci.dodajWszystkich(OdbiorcyModel.PobierzWszystkichOdbiorcow());
            SelectList fP = new SelectList(FormyPlatnosciModel.PobierzListeFormPlatnosci(), "FormaPlatnosciID", "Nazwa");
            SelectList w = new SelectList(PanstwaModel.PobierzWaluty(), "KrajID", "WalutaSkrot");
            SelectList m = new SelectList(MiejscowosciModel.PobierzListeMiejscowosci(), "MiejscowoscID", "Nazwa");
            SelectList b = new SelectList(BankModel.PobierzListeBankow(), "BankID", "Nazwa");
            SelectList t = new SelectList(TowaryUslugiModel.PobierzListTowarow(), "TowarID", "Nazwa");

            if (Kontrahent.Count() == 0 || fP.Count() == 0 || w.Count() == 0 || m.Count() == 0 || b.Count() == 0 || t.Count() == 0)
            {
                System.Collections.Generic.List<string> brakuje = new System.Collections.Generic.List<string>();
                brakuje.Add("Odbiorcy");
                brakuje.Add("Towary i usługi");
                brakuje.Add("Formy płatności");
                brakuje.Add("Państwa i waluty");
                brakuje.Add("Miejscowości");
                brakuje.Add("Banki");

                ViewData["Brakuje"] = brakuje;
                return View("BladPostepowania");
            }
            else
            {
                ViewData["Kontrahenci"] = Kontrahent;
                ViewData["FormyPlatnosci"] = fP;
                ViewData["Waluty"] = w;
                ViewData["Miejscowosci"] = m;
                ViewData["Banki"] = b;
                return View(new DokumentySprzedazy());
            }
        }

        [HttpPost]
        public ActionResult Create(DokumentySprzedazy dokumentSprzedazy, int Kontrahent, int FormaPlatnosci, int Waluta, int Miejscowosc, int Bank)
        {
            try
            {
                if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                    return RedirectToAction("LogOn", "Account");

                if (dokumentSprzedazy.TerminPlatnosci < dokumentSprzedazy.DataWystawienia)
                    ModelState.AddModelError("TerminPlatnosci", "Data wystawienia musi być wcześniejsza niż temin płatności!");

                if (ModelState.IsValid)
                {
                    using (FakturyDBEntitiess db = new FakturyDBEntitiess())
                    {
                       // int numer = ((from f in db.DokumentySprzedazy select f).Count()) + 1;
                       // int nrDokmentu = SprzedazModel.NumerDokumentu(dokumentSprzedazy.DataWystawienia);
                        Uzytkownicy wlasciciel = UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name);
                        dokumentSprzedazy.WlascicielID = wlasciciel.UzytkownikID;
                        dokumentSprzedazy.DataWprowadzenia = DateTime.Now;
                        dokumentSprzedazy.KlientID = Kontrahent;
                        dokumentSprzedazy.FormaPlatnosciID = FormaPlatnosci;
                        dokumentSprzedazy.KrajID = Waluta;
                        dokumentSprzedazy.MiejscowoscID = Miejscowosc;
                        dokumentSprzedazy.BankID = Bank;
                        dokumentSprzedazy.NrDokumentu = SprzedazModel.NumerDokumentu(dokumentSprzedazy.DataWystawienia);
                       // dokumentSprzedazy.NrDokumentu = numer.ToString() + "/" + dokumentSprzedazy.DataWystawienia.Month.ToString() + "/" + dokumentSprzedazy.DataWystawienia.Year.ToString();
                        SprzedazModel.DodajFaktureSprzedazy(dokumentSprzedazy);

                    }
                    return RedirectToAction("CreateProduktySprzedazy", "FakturySprzedaz",
                        new { dokumentSprzedazyID = SprzedazModel.PobierzIdFakturySprzedazyPoNrDokumentu(dokumentSprzedazy.NrDokumentu) });
                }
                else
                {
                    KontrahentModel kontrahenci = new KontrahentModel();
                    ViewData["Kontrahenci"] = kontrahenci.dodajWszystkich(OdbiorcyModel.PobierzWszystkichOdbiorcow());
                    ViewData["FormyPlatnosci"] = new SelectList(FormyPlatnosciModel.PobierzListeFormPlatnosci(), "FormaPlatnosciID", "Nazwa", dokumentSprzedazy.KlientID);
                    ViewData["Waluty"] = new SelectList(PanstwaModel.PobierzWaluty(), "KrajID", "WalutaSkrot", dokumentSprzedazy.KlientID);
                    ViewData["Miejscowosci"] = new SelectList(MiejscowosciModel.PobierzListeMiejscowosci(), "MiejscowoscID", "Nazwa", dokumentSprzedazy.MiejscowoscID);
                    ViewData["Banki"] = new SelectList(BankModel.PobierzListeBankow(), "BankID", "Nazwa", dokumentSprzedazy.BankID);
                    return View("Create", dokumentSprzedazy);
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

            DokumentySprzedazy dokumentDoEdycji = SprzedazModel.PobierzFakturePoID(id);

            KontrahentModel kontrahenci = new KontrahentModel();
            ViewData["Kontrahenci"] = kontrahenci.dodajWszystkich(OdbiorcyModel.PobierzWszystkichOdbiorcow());
            ViewData["FormyPlatnosci"] = new SelectList(FormyPlatnosciModel.PobierzListeFormPlatnosci(), "FormaPlatnosciID", "Nazwa", dokumentDoEdycji.FormaPlatnosciID);
            ViewData["Waluty"] = new SelectList(PanstwaModel.PobierzWaluty(), "KrajID", "WalutaSkrot", dokumentDoEdycji.KrajID);
            ViewData["Miejscowosci"] = new SelectList(MiejscowosciModel.PobierzListeMiejscowosci(), "MiejscowoscID", "Nazwa", dokumentDoEdycji.MiejscowoscID);
            ViewData["Banki"] = new SelectList(BankModel.PobierzListeBankow(), "BankID", "Nazwa", dokumentDoEdycji.BankID);

            return View(dokumentDoEdycji);
        }

        [HttpPost]
        public ActionResult Edit(int id, DokumentySprzedazy dokumentSprzedazy, int Kontrahent, int FormaPlatnosci, int Waluta, int Miejscowosc, int Bank)
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");

            try
            {
                if (dokumentSprzedazy.TerminPlatnosci < dokumentSprzedazy.DataWystawienia)
                    ModelState.AddModelError("TerminPlatnosci", "Data wystawienia musi być wcześniejsza niż temin płatności!");

                if (ModelState.IsValid)
                {
                    using (FakturyDBEntitiess db = new FakturyDBEntitiess())
                    {
                        Uzytkownicy modyfikujacy = UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name);

                        DokumentySprzedazy edycjaDokumentu = new DokumentySprzedazy();

                        edycjaDokumentu.TypDokumentu = dokumentSprzedazy.TypDokumentu;
                        edycjaDokumentu.NrDokumentu = dokumentSprzedazy.NrDokumentu;
                        edycjaDokumentu.KlientID = Kontrahent;
                        edycjaDokumentu.MiejscowoscID = Miejscowosc;
                        edycjaDokumentu.KrajID = Waluta;
                        edycjaDokumentu.BankID = Bank;
                        edycjaDokumentu.FormaPlatnosciID = FormaPlatnosci;
                        edycjaDokumentu.DataWystawienia = dokumentSprzedazy.DataWystawienia;
                        edycjaDokumentu.DataSprzedazy = dokumentSprzedazy.DataSprzedazy;
                        edycjaDokumentu.TerminPlatnosci = dokumentSprzedazy.TerminPlatnosci;
                        edycjaDokumentu.WartoscNetto = dokumentSprzedazy.WartoscNetto;
                        edycjaDokumentu.WartoscBrutto = dokumentSprzedazy.WartoscBrutto;
                        edycjaDokumentu.PozostaloDoZaplaty = dokumentSprzedazy.PozostaloDoZaplaty;
                        edycjaDokumentu.Uwagi = dokumentSprzedazy.Uwagi;
                        edycjaDokumentu.WlascicielID = modyfikujacy.UzytkownikID;
                        edycjaDokumentu.DataWprowadzenia = DateTime.Now;
                        SprzedazModel.UsunFakture(id, modyfikujacy.UzytkownikID);
                        SprzedazModel.DodajFaktureSprzedazy(edycjaDokumentu);

                        ProduktyFakturySprzedazyModel.ZmianaNrFakturyDlaRProduktow(id,
                            SprzedazModel.PobierzIdFakturySprzedazyPoNrDokumentu(dokumentSprzedazy.NrDokumentu));
                        RozliczenieFakturySprzedazyModel.ZmianaNrFakturyDlaRozliczenia(id,
                            SprzedazModel.PobierzIdFakturySprzedazyPoNrDokumentu(dokumentSprzedazy.NrDokumentu));

                    }
                    return RedirectToAction("CreateProduktySprzedazy", "FakturySprzedaz",
                      new { dokumentSprzedazyID = SprzedazModel.PobierzIdFakturySprzedazyPoNrDokumentu(dokumentSprzedazy.NrDokumentu) });
                }
                else
                {
                    KontrahentModel kontrahenci = new KontrahentModel();
                    ViewData["Kontrahenci"] = kontrahenci.dodajWszystkich(OdbiorcyModel.PobierzWszystkichOdbiorcow());
                    ViewData["NrDokumentu"] = dokumentSprzedazy.NrDokumentu;
                    ViewData["FormyPlatnosci"] = new SelectList(FormyPlatnosciModel.PobierzListeFormPlatnosci(), "FormaPlatnosciID", "Nazwa", dokumentSprzedazy.FormaPlatnosciID);
                    ViewData["Waluty"] = new SelectList(PanstwaModel.PobierzWaluty(), "KrajID", "WalutaSkrot", dokumentSprzedazy.KrajID);
                    ViewData["Miejscowosci"] = new SelectList(MiejscowosciModel.PobierzListeMiejscowosci(), "MiejscowoscID", "Nazwa", dokumentSprzedazy.MiejscowoscID);
                    ViewData["Banki"] = new SelectList(BankModel.PobierzListeBankow(), "BankID", "Nazwa", dokumentSprzedazy.BankID);
                    return View("Edit", dokumentSprzedazy);
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

            DokumentySprzedazy DokumentDoUsuniecia = SprzedazModel.PobierzFakturePoID(id);
            return View(DokumentDoUsuniecia);
        }

        [HttpPost]
        public ActionResult Delete(int id, DokumentySprzedazy d)
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");

            try
            {
                using (FakturyDBEntitiess db = new FakturyDBEntitiess())
                {
                    Uzytkownicy blokujacy = UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name);
                    SprzedazModel.UsunFakture(id, blokujacy.UzytkownikID);
                    ProduktyFakturySprzedazyModel.UsunWszystkieProktyFaktury(id, blokujacy.UzytkownikID);
                    RozliczenieFakturySprzedazyModel.UsunWszystkieRozliczeniaFaktury(id, blokujacy.UzytkownikID);
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
        public ActionResult CreateProduktySprzedazy(int dokumentSprzedazyID)
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");

            FakturaSprzedazy faktura = new FakturaSprzedazy();
            faktura.dokumentSprzedazy = SprzedazModel.PobierzFakturePoID(dokumentSprzedazyID);
            faktura.ListaProduktowSprzedazy = ProduktyFakturySprzedazyModel.PobierzProduktyPoID(dokumentSprzedazyID);
            ViewData["Towary"] = new SelectList(TowaryUslugiModel.PobierzListTowarow(), "TowarID", "Nazwa");
            return View(faktura);
        }

        [HttpPost]
        public ActionResult CreateProduktySprzedazy(int dokumentSprzedazyID, FakturaSprzedazy dokumentSprzedazy, int Towary)
        {
            try
            {
                if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                    return RedirectToAction("LogOn", "Account");


                if (ModelState.IsValid)
                {
                    using (FakturyDBEntitiess db = new FakturyDBEntitiess())
                    {
                        ProduktyFakturySprzedazy nowyProdukt = new ProduktyFakturySprzedazy();
                        Uzytkownicy wlasciciel = UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name);
                        nowyProdukt.WlascicielID = wlasciciel.UzytkownikID;
                        nowyProdukt.DataWprowadzenia = DateTime.Now;
                        nowyProdukt.DokumentSprzedazyID = dokumentSprzedazyID;
                        nowyProdukt.TowarID = Towary;
                        nowyProdukt.Ilosc = dokumentSprzedazy.ProduktFakturySprzedazy.Ilosc;
                        TowaryUslugi Towar = TowaryUslugiModel.PobierzTowarUsugePoID(Towary);
                        if (Towar.Marza > 0)
                            nowyProdukt.WartoscNetto = (Towar.CenaNetto * (1 + (Towar.Marza / 100))) * nowyProdukt.Ilosc;
                        else
                            nowyProdukt.WartoscNetto = Towar.CenaNetto * nowyProdukt.Ilosc;

                        nowyProdukt.WartoscBrutto = nowyProdukt.WartoscNetto *
                            (1 + (((decimal)StawkiVatModel.PobierzStawkeVatPoID(Towar.StawkaVatID).Wartosc) / 100));

                        ProduktyFakturySprzedazyModel.DodajProduktDoFakturySprzedazy(nowyProdukt);
                        SprzedazModel.WyliczWartosciFaktury(dokumentSprzedazyID);

                    }
                    return RedirectToAction("CreateProduktySprzedazy", "FakturySprzedaz", new { dokumentSprzedazyID = dokumentSprzedazyID });
                }
                else
                {
                    FakturaSprzedazy faktura = new FakturaSprzedazy();
                    faktura.dokumentSprzedazy = SprzedazModel.PobierzFakturePoID(dokumentSprzedazyID);
                    faktura.ListaProduktowSprzedazy = ProduktyFakturySprzedazyModel.PobierzProduktyPoID(dokumentSprzedazyID);
                    ViewData["Towary"] = new SelectList(TowaryUslugiModel.PobierzListTowarow(), "TowarID", "Nazwa");
                    return View("CreateProduktySprzedazy", faktura);
                }
            }
            catch
            {
                return View();
            }
        }

        public ActionResult DeleteProduktFakturySprzedazy(int id)
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");

            try
            {
                using (FakturyDBEntitiess db = new FakturyDBEntitiess())
                {
                    ProduktyFakturySprzedazyModel.UsunProkuktFakturySprzedazy(id, (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name)).UzytkownikID);
                    SprzedazModel.WyliczWartosciFaktury((ProduktyFakturySprzedazyModel.PobierzProduktFakturySprzedazyPoID(id)).DokumentSprzedazyID);
                    return RedirectToAction("CreateProduktySprzedazy", "FakturySprzedaz",
                        new { dokumentSprzedazyID = (ProduktyFakturySprzedazyModel.PobierzProduktFakturySprzedazyPoID(id)).DokumentSprzedazyID });
                }
            }
            catch
            {
                return View();
            }
        }

        public ActionResult EditListaProduktowSprzedazy(int id)
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");

            try
            {
                using (FakturyDBEntitiess db = new FakturyDBEntitiess())
                {
                    return RedirectToAction("CreateProduktySprzedazy", "FakturySprzedaz",
                        new { dokumentSprzedazyID = id });
                }
            }
            catch
            {
                return View();
            }
        }
        #endregion

        #region rozliczenia
        public ActionResult CreateRozliczenieSprzedazy(int dokumentSprzedazyID)
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");

            FakturaSprzedazy faktura = new FakturaSprzedazy();
            faktura.dokumentSprzedazy = SprzedazModel.PobierzFakturePoID(dokumentSprzedazyID);
            faktura.ListaRozliczeniaSprzedazy = RozliczenieFakturySprzedazyModel.PobierzListeRozliczenSprzedazyPoID(dokumentSprzedazyID);
            return View(faktura);
        }

        [HttpPost]
        public ActionResult CreateRozliczenieSprzedazy(int dokumentSprzedazyID, FakturaSprzedazy dokumentSprzedazy)
        {
            try
            {
                if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                    return RedirectToAction("LogOn", "Account");


                if (ModelState.IsValid)
                {
                    using (FakturyDBEntitiess db = new FakturyDBEntitiess())
                    {
                        RozliczeniaSprzedazy noweRozliczenie = new RozliczeniaSprzedazy();
                        Uzytkownicy wlasciciel = UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name);
                        noweRozliczenie.WlascicielID = wlasciciel.UzytkownikID;
                        noweRozliczenie.DataWprowadzenia = DateTime.Now;
                        noweRozliczenie.DokumentSprzedazyID = dokumentSprzedazyID;
                        noweRozliczenie.DataWplaty = dokumentSprzedazy.RozliczenieSprzedazy.DataWplaty;
                        noweRozliczenie.Kwota = dokumentSprzedazy.RozliczenieSprzedazy.Kwota;

                        RozliczenieFakturySprzedazyModel.DodajRozliczenieFakturySprzedazy(noweRozliczenie);
                        SprzedazModel.WyliczWartosciFaktury(dokumentSprzedazyID);

                    }
                    return RedirectToAction("CreateRozliczenieSprzedazy", "FakturySprzedaz", new { dokumentSprzedazyID = dokumentSprzedazyID });
                }
                else
                {
                    FakturaSprzedazy faktura = new FakturaSprzedazy();
                    faktura.dokumentSprzedazy = SprzedazModel.PobierzFakturePoID(dokumentSprzedazyID);
                    faktura.ListaRozliczeniaSprzedazy = RozliczenieFakturySprzedazyModel.PobierzListeRozliczenSprzedazyPoID(dokumentSprzedazyID);
                    return View("CreateRozliczenieSprzedazy", faktura);
                }
            }
            catch
            {
                return View();
            }
        }

        public ActionResult EdytujRozliczeniaFakturySprzedazy(int id)
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");

            try
            {
                using (FakturyDBEntitiess db = new FakturyDBEntitiess())
                {
                    return RedirectToAction("CreateRozliczenieSprzedazy", "FakturySprzedaz",
                        new { dokumentSprzedazyID = id });
                }
            }
            catch
            {
                return View();
            }
        }

        public ActionResult DeleteRozliczenieFakturySprzedazy(int id)
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");

            try
            {
                using (FakturyDBEntitiess db = new FakturyDBEntitiess())
                {
                    RozliczenieFakturySprzedazyModel.UsunRozliczenieFakturySprzedazy(id, (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name)).UzytkownikID);
                    SprzedazModel.WyliczWartosciFaktury((RozliczenieFakturySprzedazyModel.PobierzRozliczenieFakturySprzedazyPoID(id)).DokumentSprzedazyID);
                    return RedirectToAction("CreateRozliczenieSprzedazy", "FakturySprzedaz",
                        new { dokumentSprzedazyID = (RozliczenieFakturySprzedazyModel.PobierzRozliczenieFakturySprzedazyPoID(id)).DokumentSprzedazyID });
                }
            }
            catch
            {
                return View();
            }
        }
        #endregion

        #region pdf

        public ActionResult CreatePDF(int id)
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");

            MemoryStream ms = FakturaPDF.StworzPDF(id);
            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=" + (SprzedazModel.PobierzFakturePoID(id)).NrDokumentu + ".pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.BinaryWrite(ms.ToArray());
            System.Web.HttpContext.Current.ApplicationInstance.CompleteRequest();

            return null;
        }
        #endregion

        public ActionResult Powiadomienie(int id)
        {
            





            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress("lukaszm88@gmail.com");
            mail.To.Add("lmigodzinski@gmail.com");
            mail.Subject = "My nowy temat";
            mail.Body = "Tu będzie text <br / > i znowu coś";
            mail.IsBodyHtml = true;

            SmtpServer.EnableSsl = true;
            SmtpServer.UseDefaultCredentials = false;
            SmtpServer.Send(mail);

            return null;
        }
    }
}
