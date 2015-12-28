using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using faktury.Models;
using faktury.Models.Modele;

namespace faktury.Controllers.Wspolne
{
    [HandleError]
    public class StawkiVatController : Controller
    {
        //
        // GET: /StawkiVat/

        public ActionResult Index()
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");
            List<StawkiVat> stawkiVat = StawkiVatModel.PobierzListeStawekVat();
            return View(stawkiVat);
        }

        //
        // GET: /StawkiVat/Details/5

        public ActionResult Details(int id)
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");
            StawkiVat stawkaVat = StawkiVatModel.PobierzStawkeVatPoID(id);

            if (stawkaVat == null)
                return View("NieZnaleziono");
            else
                return View(stawkaVat);
        }

        //
        // GET: /StawkiVat/Create

        public ActionResult Create()
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");
            StawkiVat stawkaVat = new StawkiVat();
            return View(stawkaVat);
        } 

        //
        // POST: /StawkiVat/Create

        [HttpPost]
        public ActionResult Create(StawkiVat s)
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");
            try
            {
                if (ModelState.IsValid)
                {
                    using (FakturyDBEntitiess db = new FakturyDBEntitiess())
                    {
                        StawkiVat stawkaVat = new StawkiVat();
                        stawkaVat.DataWprowadzenia = DateTime.Now;
                        stawkaVat.WlascicielID = (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name)).UzytkownikID;
                        stawkaVat.Wartosc = s.Wartosc;
                        db.AddToStawkiVat(stawkaVat);
                        db.SaveChanges();
                    }
                }
                else
                {
                    return View("Create", s);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /StawkiVat/Edit/5
 
        public ActionResult Edit(int id)
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");
            StawkiVat stawkaVat = StawkiVatModel.PobierzStawkeVatPoID(id);
            return View(stawkaVat);
        }

        //
        // POST: /StawkiVat/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, StawkiVat s)
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");
            try
            {
                if (ModelState.IsValid)
                {
                    using (FakturyDBEntitiess db = new FakturyDBEntitiess())
                    {
                        StawkiVat stawkaVat = db.StawkiVat.SingleOrDefault(o => o.StawkaVatID == id);
                        stawkaVat.Wartosc = s.Wartosc;
                        stawkaVat.ModyfikujacyID = (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name)).UzytkownikID;
                        stawkaVat.DataModyfikacji = DateTime.Now;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    return View("Edit", s);
                }
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /StawkiVat/Delete/5
 
        public ActionResult Delete(int id)
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");
            StawkiVat stawkaVat = StawkiVatModel.PobierzStawkeVatPoID(id);

            if (stawkaVat == null)
                return View("NieZnaleziono");
            else
                return View(stawkaVat);
        }

        //
        // POST: /StawkiVat/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");
            try
            {
                using (FakturyDBEntitiess db = new FakturyDBEntitiess())
                {
                    StawkiVat stawkaVat = db.StawkiVat.SingleOrDefault(o => o.StawkaVatID == id);
                    stawkaVat.BlokujacyID = (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name)).UzytkownikID;
                    stawkaVat.DataZablokowania = DateTime.Now;
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
