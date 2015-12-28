using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using faktury.Models;
using faktury.Models.Modele;

namespace faktury.Controllers.Wspolne
{
    [HandleError]
    public class JednostkiMiarController : Controller
    {
        //
        // GET: /JednostkiMiar/

        public ActionResult Index()
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");
            List<JednostkiMiar> listaJednostekMiar = JednostkiMiarModel.PobierzListeJednostekMiar();
            return View(listaJednostekMiar);
        }

        //
        // GET: /JednostkiMiar/Details/5

        public ActionResult Details(int id)
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");
            JednostkiMiar jm = JednostkiMiarModel.PobierzJednostkeMiarPoID(id);

            if (jm == null)
                return View("NieZnaleziono");
            else
                return View(jm);
        }

        //
        // GET: /JednostkiMiar/Create

        public ActionResult Create()
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");
            JednostkiMiar jm = new JednostkiMiar();
            return View(jm);
        }

        //
        // POST: /JednostkiMiar/Create

        [HttpPost]
        public ActionResult Create(JednostkiMiar j)
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");
            try
            {
                if (ModelState.IsValid)
                {                   
                    using (FakturyDBEntitiess db = new FakturyDBEntitiess())
                    {
                        JednostkiMiar jm = new JednostkiMiar();
                        jm.DataWprowadzenia = DateTime.Now;
                        jm.WlascicielID = (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name)).UzytkownikID;
                        jm.Nazwa = j.Nazwa;

                        db.AddToJednostkiMiar(jm);
                        db.SaveChanges();
                    }
                }
                else
                {
                    return View("Create", j);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /JednostkiMiar/Edit/5

        public ActionResult Edit(int id)
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");
            JednostkiMiar jm = JednostkiMiarModel.PobierzJednostkeMiarPoID(id);
            return View(jm);
        }

        //
        // POST: /JednostkiMiar/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, JednostkiMiar j)
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
                        JednostkiMiar jm = db.JednostkiMiar.SingleOrDefault(o => o.JednostkaMiarID == id);
                        jm.Nazwa = j.Nazwa;
                        jm.ModyfikujacyID = wlasciciel.UzytkownikID;
                        jm.DataModyfikacji = DateTime.Now;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    return View("Edit", j);
                }
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /JednostkiMiar/Delete/5

        public ActionResult Delete(int id)
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");
            JednostkiMiar jm = JednostkiMiarModel.PobierzJednostkeMiarPoID(id);

            if (jm == null)
                return View("NieZnaleziono");
            else
                return View(jm);
        }

        //
        // POST: /JednostkiMiar/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, JednostkiMiar j)
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");
            try
            {
                using (FakturyDBEntitiess db = new FakturyDBEntitiess())
                {
                    JednostkiMiar jm = db.JednostkiMiar.SingleOrDefault(o => o.JednostkaMiarID == id);
                    jm.BlokujacyID = (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name)).UzytkownikID;
                    jm.DataZablokowania = DateTime.Now;
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
