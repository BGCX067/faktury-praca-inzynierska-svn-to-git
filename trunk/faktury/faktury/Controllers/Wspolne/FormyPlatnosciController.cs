using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using faktury.Models;
using faktury.Models.Modele;

namespace faktury.Controllers.Wspolne
{
    [HandleError]
    public class FormyPlatnosciController : Controller
    {
        //
        // GET: /FormyPlatnosci/

        public ActionResult Index()
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");
            List<FormyPlatnosci> listaPanstw = FormyPlatnosciModel.PobierzListeFormPlatnosci();
            return View(listaPanstw);
        }

        //
        // GET: /FormyPlatnosci/Details/5

        public ActionResult Details(int id)
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");
            FormyPlatnosci formaPlatnosci = FormyPlatnosciModel.PobierzFormePlatnosciPoID(id);

            if (formaPlatnosci == null)
                return View("NieZnaleziono");
            else
                return View(formaPlatnosci);
        }

        //
        // GET: /FormyPlatnosci/Create

        public ActionResult Create()
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");
            FormyPlatnosci formaPlatnosci = new FormyPlatnosci();
            return View(formaPlatnosci);
        }

        //
        // POST: /FormyPlatnosci/Create

        [HttpPost]
        public ActionResult Create(FormyPlatnosci f)
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");
            try
            {
                if (ModelState.IsValid)
                {
                    using (FakturyDBEntitiess db = new FakturyDBEntitiess())
                    {
                        Uzytkownicy wlasciciel = UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name);


                        FormyPlatnosci formaPlatnosci = new FormyPlatnosci();
                        formaPlatnosci.DataWprowadzenia = DateTime.Now;
                            formaPlatnosci.WlascicielID = wlasciciel.UzytkownikID;
                        formaPlatnosci.Nazwa = f.Nazwa;

                        db.AddToFormyPlatnosci(formaPlatnosci);
                        db.SaveChanges();
                    }
                }
                else
                {
                    return View("Create", f);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /FormyPlatnosci/Edit/5

        public ActionResult Edit(int id)
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");
            FormyPlatnosci formaPlatnosci = FormyPlatnosciModel.PobierzFormePlatnosciPoID(id);
            return View(formaPlatnosci);
        }

        //
        // POST: /FormyPlatnosci/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormyPlatnosci f)
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

                        FormyPlatnosci formaPlatnosci = db.FormyPlatnosci.SingleOrDefault(o => o.FormaPlatnosciID == id);
                        formaPlatnosci.Nazwa = f.Nazwa;
                            formaPlatnosci.ModyfikujacyID = modyfikujacy.UzytkownikID;
                        formaPlatnosci.DataModyfikacji = DateTime.Now;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    return View("Edit", f);
                }
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /FormyPlatnosci/Delete/5

        public ActionResult Delete(int id)
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");
            FormyPlatnosci formaPlatnosci = FormyPlatnosciModel.PobierzFormePlatnosciPoID(id);

            if (formaPlatnosci == null)
                return View("NieZnaleziono");
            else
                return View(formaPlatnosci);
        }

        //
        // POST: /FormyPlatnosci/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormyPlatnosci f)
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");
            try
            {
                using (FakturyDBEntitiess db = new FakturyDBEntitiess())
                {
                    Uzytkownicy blokujacy = UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name);

                    FormyPlatnosci formaPlatnosci = db.FormyPlatnosci.SingleOrDefault(o => o.FormaPlatnosciID == id);
                   
                        formaPlatnosci.BlokujacyID = blokujacy.UzytkownikID;
                    formaPlatnosci.DataZablokowania = DateTime.Now;
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
