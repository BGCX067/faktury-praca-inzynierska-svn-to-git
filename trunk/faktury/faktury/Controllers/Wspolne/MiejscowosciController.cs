using System;
using System.Linq;
using System.Web.Mvc;
using faktury.Models;
using faktury.Models.Modele;
using System.Collections.Generic;

namespace faktury.Controllers.Wspolne
{
    [HandleError]
    public class MiejscowosciController : Controller
    {
        //
        // GET: /Miejscowosci/

        public ActionResult Index()
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");
            return View(MiejscowosciModel.PobierzListeMiejscowosciRepozytorium());
        }

        //
        // GET: /Miejscowosci/Details/5

        public ActionResult Details(int id)
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");
            Miejscowosci miejscowosc = MiejscowosciModel.PobierzMiejscowoscPoID(id);
            return View(miejscowosc);
        }

        //
        // GET: /Miejscowosci/Create

        public ActionResult Create()
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");
            SelectList Kraj =
                new SelectList(PanstwaModel.PobierzListePanstw(), "KrajID", "Nazwa");
            if (Kraj.Count() == 0)
            {
                List<string> brakuje = new List<string>();
                brakuje.Add("Państwa i waluty");

                ViewData["Brakuje"] = brakuje;
                return View("BladPostepowania");
            }
            else
            {
                ViewData["Kraje"] = Kraj;
                return View();
            }
        }

        //
        // POST: /Miejscowosci/Create

        [HttpPost]
        public ActionResult Create(Miejscowosci m, int kraj)
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");

            try
            {
                if (ModelState.IsValid)
                {
                    Uzytkownicy wlasciciel = UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name);
                    m.WlascicielID = wlasciciel.UzytkownikID;
                    m.KrajID = kraj;
                    m.DataWprowadzenia = DateTime.Now;
                    Miejscowosci miejscowosc = MiejscowosciModel.DodajMiejscowosc(m);
                }
                else
                {
                    ViewData["Kraje"] = new SelectList(PanstwaModel.PobierzListePanstw(), "KrajID", "Nazwa");
                    return View("Create", m);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Miejscowosci/Edit/5

        public ActionResult Edit(int id)
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");
            Miejscowosci miejscowosc = MiejscowosciModel.PobierzMiejscowoscPoID(id);
            ViewData["Kraje"] = new SelectList(PanstwaModel.PobierzListePanstw(),
                "KrajID", "Nazwa", miejscowosc.KrajID);
            return View(miejscowosc);
        }

        //
        // POST: /Miejscowosci/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, Miejscowosci m, int kraj)
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

                        Miejscowosci miejscowosc = db.Miejscowosci.SingleOrDefault(o => o.MiejscowoscID == id);
                        miejscowosc.ModyfikujacyID = modyfikujacy.UzytkownikID;
                        miejscowosc.Nazwa = m.Nazwa;
                        miejscowosc.KrajID = kraj;
                        miejscowosc.DataModyfikacji = DateTime.Now;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    ViewData["Kraje"] = new SelectList(PanstwaModel.PobierzListePanstw(), "KrajID", "Nazwa", kraj);
                    return View("Edit", m);
                }
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Miejscowosci/Delete/5

        public ActionResult Delete(int id)
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");
            Miejscowosci miejscowosc = MiejscowosciModel.PobierzMiejscowoscPoID(id);
            ViewData["Kraje"] = new SelectList(PanstwaModel.PobierzListePanstw(), "KrajID", "Nazwa", miejscowosc.KrajID);

            return View(miejscowosc);
        }

        //
        // POST: /Miejscowosci/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, Miejscowosci m)
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");
            try
            {
                using (FakturyDBEntitiess db = new FakturyDBEntitiess())
                {
                    Uzytkownicy blokujacy = UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name);

                    Miejscowosci miejscowosc = db.Miejscowosci.SingleOrDefault(o => o.MiejscowoscID == id);
                    miejscowosc.BlokujacyID = blokujacy.UzytkownikID;
                    miejscowosc.DataZablokowania = DateTime.Now;
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
