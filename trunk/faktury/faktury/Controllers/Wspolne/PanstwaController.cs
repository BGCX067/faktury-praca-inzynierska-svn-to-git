using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using faktury.Models;
using faktury.Models.Modele;

namespace faktury.Controllers.Wspolne
{
    [HandleError]
    public class PanstwaController : Controller
    {
        //
        // GET: /Kraje/

        public ActionResult Index()
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");
            List<Kraje> listaPanstw = PanstwaModel.PobierzListePanstw();
            return View(listaPanstw);
        }

        //
        // GET: /Kraje/Details/5

        public ActionResult Details(int id)
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");
            Kraje panstwo = PanstwaModel.PobierzPanstwoPoID(id);

            if (panstwo == null)
                return View("NieZnaleziono");
            else
                return View(panstwo);
        }

        //
        // GET: /Kraje/Create

        public ActionResult Create()
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");
            Kraje panstwo = new Kraje();
            return View(panstwo);
        }

        //
        // POST: /Kraje/Create

        [HttpPost]
        public ActionResult Create(Kraje p)
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");
            try
            {
                if (ModelState.IsValid)
                {                   
                    using (FakturyDBEntitiess db = new FakturyDBEntitiess())
                    {
                        Kraje panstwo = new Kraje();
                        panstwo.DataWprowadzenia = DateTime.Now;
                        panstwo.WlascicielID = (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name)).UzytkownikID;
                        panstwo.Nazwa = p.Nazwa;
                        panstwo.Waluta = p.Waluta;
                        panstwo.WalutaSkrot = p.WalutaSkrot;

                        db.AddToKraje(panstwo);
                        db.SaveChanges();
                    }
                }
                else
                {
                    return View("Create", p);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Kraje/Edit/5

        public ActionResult Edit(int id)
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");
            Kraje panstwo = PanstwaModel.PobierzPanstwoPoID(id);
            return View(panstwo);
        }

        //
        // POST: /Kraje/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, Kraje p)
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");
            try
            {
                if (ModelState.IsValid)
                {
                    using (FakturyDBEntitiess db = new FakturyDBEntitiess())
                    {
                        Kraje panstwo = db.Kraje.SingleOrDefault(o => o.KrajID == id);
                        panstwo.Nazwa = p.Nazwa;
                        panstwo.Waluta = p.Waluta;
                        panstwo.WalutaSkrot = p.WalutaSkrot;
                        panstwo.ModyfikujacyID = (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name)).UzytkownikID;
                        panstwo.DataModyfikacji = DateTime.Now;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    return View("Edit", p);
                }
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Kraje/Delete/5

        public ActionResult Delete(int id)
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");
            Kraje panstwo = PanstwaModel.PobierzPanstwoPoID(id);

            if (panstwo == null)
                return View("NieZnaleziono");
            else
                return View(panstwo);
        }

        //
        // POST: /Kraje/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, Kraje p)
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");
            try
            {
                using (FakturyDBEntitiess db = new FakturyDBEntitiess())
                {
                    Kraje panstwo = db.Kraje.SingleOrDefault(o => o.KrajID == id);
                    panstwo.BlokujacyID = (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name)).UzytkownikID;
                    panstwo.DataZablokowania = DateTime.Now;
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
