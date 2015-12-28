using System;
using System.Linq;
using System.Web.Mvc;
using faktury.Models;
using faktury.Models.Modele;

namespace faktury.Controllers
{
    public class OdbiorcyController : Controller
    {
        //
        // GET: /Odbiorcy/

        public ActionResult Index()
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");
            return View(OdbiorcyModel.PobierzListeOdbiorcowRepozytorium());
        }

        //
        // GET: /Odbiorcy/Details/5

        public ActionResult Details(int id)
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");
            
            OdbiorcyRepozytorium Odbiorca = new OdbiorcyRepozytorium(OdbiorcyModel.PobierzOdbiorcePoID(id));
            return View(Odbiorca);
        }

        //
        // GET: /Odbiorcy/Create

        public ActionResult Create()
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");

            SelectList kodPocztowy = new SelectList(KodyPocztoweModel.pobierzListeKodowPocztowych(), "KodPocztowyID", "Kod");
            SelectList kodPocztowyKontakt = new SelectList(KodyPocztoweModel.pobierzListeKodowPocztowych(), "KodPocztowyID", "Kod");

            if (kodPocztowy.Count() == 0)
            {
                System.Collections.Generic.List<string> brakuje = new System.Collections.Generic.List<string>();
                brakuje.Add("Kody pocztowe");

                ViewData["Brakuje"] = brakuje;
                return View("BladPostepowania");
            }
            else
            {
                ViewData["KodPocztowy"] = kodPocztowy;
                ViewData["KodPocztowyKontakt"] = kodPocztowyKontakt;
                return View();
            }
        }

        //
        // POST: /Odbiorcy/Create

        [HttpPost]
        public ActionResult Create(Klienci k, int kodPocztowy, int kodPocztowyKontakt)
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");
            try
            {
                if (ModelState.IsValid)
                {
                    Uzytkownicy wlasciciel = UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name);
                    k.WlascicielID = wlasciciel.UzytkownikID;
                    k.KodPocztowyID = kodPocztowy;
                    k.KodPocztowyKontaktID = kodPocztowyKontakt;
                    k.DataWprowadzenia = DateTime.Now;
                    Klienci Klient = OdbiorcyModel.DodajOdbiorce(k);
                }
                else
                {
                    ViewData["KodPocztowy"] = new SelectList(KodyPocztoweModel.pobierzListeKodowPocztowych(), "KodPocztowyID", "Kod");
                    ViewData["KodPocztowyKontakt"] = new SelectList(KodyPocztoweModel.pobierzListeKodowPocztowych(), "KodPocztowyID", "Kod");
                    return View("Create", k);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Odbiorcy/Edit/5

        public ActionResult Edit(int id)
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");

            Klienci Odbiorca = OdbiorcyModel.PobierzOdbiorcePoID(id);
            ViewData["KodPocztowy"] = new SelectList(KodyPocztoweModel.pobierzListeKodowPocztowych(), "KodPocztowyID", "Kod", Odbiorca.KodPocztowyID);
            ViewData["KodPocztowyKontakt"] = new SelectList(KodyPocztoweModel.pobierzListeKodowPocztowych(), "KodPocztowyID", "Kod", Odbiorca.KodPocztowyKontaktID);
            return View(Odbiorca);
        }

        //f
        // POST: /Odbiorcy/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, Klienci Odbiorca, int kodPocztowy, int kodPocztowyKontakt)
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");

            try
            {
                if (ModelState.IsValid)
                {
                    using (FakturyDBEntitiess db = new FakturyDBEntitiess())
                    {
                        Uzytkownicy modyfikujacy = UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name);
                        OdbiorcyModel.UsunOdbiorce(id, modyfikujacy.UzytkownikID);

                        Create(Odbiorca, kodPocztowy, kodPocztowyKontakt);
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    ViewData["KodPocztowy"] = new SelectList(KodyPocztoweModel.pobierzListeKodowPocztowych(), "KodPocztowyID", "Kod", Odbiorca.KodPocztowyID);
                    ViewData["KodPocztowyKontakt"] = new SelectList(KodyPocztoweModel.pobierzListeKodowPocztowych(), "KodPocztowyID", "Kod", Odbiorca.KodPocztowyKontaktID);
                    return View("Edit", Odbiorca);
                }
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Odbiorcy/Delete/5

        public ActionResult Delete(int id)
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");

            OdbiorcyRepozytorium Odbiorca = new OdbiorcyRepozytorium(OdbiorcyModel.PobierzOdbiorcePoID(id));
            return View(Odbiorca);
        }

        //
        // POST: /Odbiorcy/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, Klienci Odbiorca)
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");

            try
            {
                using (FakturyDBEntitiess db = new FakturyDBEntitiess())
                {
                    Uzytkownicy blokujacy = UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name);
                    OdbiorcyModel.UsunOdbiorce(id, blokujacy.UzytkownikID);
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
