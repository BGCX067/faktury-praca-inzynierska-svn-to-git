using System;
using System.Linq;
using System.Web.Mvc;
using faktury.Models;
using faktury.Models.Modele;
using System.Collections.Generic;

namespace faktury.Controllers.Wspolne
{
    public class KodyPocztoweController : Controller
    {
        //
        // GET: /KodyPocztowe/

        public ActionResult Index()
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");
            return View(KodyPocztoweModel.PobierzListeKodowPocztowychRepozytorium());
        }

        //
        // GET: /KodyPocztowe/Details/5

        public ActionResult Details(int id)
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");
            KodyPocztowe kodPocztowy = KodyPocztoweModel.pobierzKodPocztowyPoID(id);
            return View(kodPocztowy);
        }

        //
        // GET: /KodyPocztowe/Create

        public ActionResult Create()
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");

            SelectList miejscowosc = new SelectList(MiejscowosciModel.PobierzListeMiejscowosci(), "MiejscowoscID", "Nazwa");
            if (miejscowosc.Count() == 0)
            {
                List<string> brakuje = new List<string>();
                brakuje.Add("Miejscowości");
                ViewData["Brakuje"] = brakuje;

                return View("BladPostepowania");
            }
            else
            {
                ViewData["Miejscowosci"] = miejscowosc;
                return View();
            }
        }

        //
        // POST: /KodyPocztowe/Create

        [HttpPost]
        public ActionResult Create(KodyPocztowe k, int miejscowosc)
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");
            try
            {
                if (ModelState.IsValid)
                {
                    Uzytkownicy wlasciciel = UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name);
                    k.WlascicielID = wlasciciel.UzytkownikID;
                    k.MiejscowoscID = miejscowosc;
                    k.DataWprowadzenia = DateTime.Now;
                    KodyPocztowe KodPocztowy = KodyPocztoweModel.DodajKodPocztowy(k);
                }
                else
                {
                    ViewData["Miejscowosci"] = new SelectList(MiejscowosciModel.PobierzListeMiejscowosci(), "MiejscowoscID", "Nazwa");
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
        // GET: /KodyPocztowe/Edit/5

        public ActionResult Edit(int id)
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");

            KodyPocztowe kodPocztowy = KodyPocztoweModel.pobierzKodPocztowyPoID(id);
            ViewData["Miejscowosci"] = new SelectList(MiejscowosciModel.PobierzListeMiejscowosci(),
               "MiejscowoscID", "Nazwa", kodPocztowy.MiejscowoscID);
            return View(kodPocztowy);
        }

        //
        // POST: /KodyPocztowe/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, KodyPocztowe k, int miejscowosc)
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

                        KodyPocztowe kodPocztowy = db.KodyPocztowe.SingleOrDefault(o => o.KodPocztowyID == id);
                        kodPocztowy.Kod = k.Kod;
                        kodPocztowy.MiejscowoscID = miejscowosc;
                        kodPocztowy.ModyfikujacyID = modyfikujacy.UzytkownikID;
                        kodPocztowy.DataModyfikacji = DateTime.Now;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    ViewData["Miejscowosci"] = new SelectList(MiejscowosciModel.PobierzListeMiejscowosci(),
              "MiejscowoscID", "Nazwa", KodyPocztoweModel.pobierzKodPocztowyPoID(id));
                    return View("Edit", k);
                }
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /KodyPocztowe/Delete/5

        public ActionResult Delete(int id)
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");
            KodyPocztowe kodPocztowy = KodyPocztoweModel.pobierzKodPocztowyPoID(id);
            ViewData["Miejscowosci"] = new SelectList(MiejscowosciModel.PobierzListeMiejscowosci(),
               "MiejscowoscID", "Nazwa", kodPocztowy.KodPocztowyID);
            return View(kodPocztowy);
        }

        //
        // POST: /KodyPocztowe/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, KodyPocztowe k)
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");
            try
            {
                using (FakturyDBEntitiess db = new FakturyDBEntitiess())
                {
                    Uzytkownicy blokujacy =
                        UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name);

                    KodyPocztowe kodPocztowy =
                        db.KodyPocztowe.SingleOrDefault(o => o.KodPocztowyID == id);
                    kodPocztowy.BlokujacyID = blokujacy.UzytkownikID;
                    kodPocztowy.DataZablokowania = DateTime.Now;
                    db.SaveChanges();
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
