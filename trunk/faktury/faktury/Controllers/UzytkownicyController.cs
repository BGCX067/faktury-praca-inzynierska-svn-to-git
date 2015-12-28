using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using faktury.Models;
using faktury.Models.Modele;

namespace faktury.Controllers
{
    public class UzytkownicyController : Controller
    {
        //
        // GET: /Uzytkownicy/

        public ActionResult Index()
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");
            if ((UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name)).RolaID != UzytkownikModel.ZwrocNrAdministratora())
                return View("BrakUprawnien");

            List<Uzytkownicy> listUzytkownikow = UzytkownikModel.PobierzListeUzytkownikow();
            return View(listUzytkownikow);
        }

        //
        // GET: /Uzytkownicy/Details/5

        public ActionResult Details(int id)
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");
            if ((UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name)).RolaID != UzytkownikModel.ZwrocNrAdministratora())
                return View("BrakUprawnien");
            Uzytkownicy uzytkownik = UzytkownikModel.PobierzUzytkownikaPoID(id);
            return View(uzytkownik);
        }


        //
        // GET: /Uzytkownicy/Edit/5

        public ActionResult Edit(int id)
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");
            if ((UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name)).RolaID != UzytkownikModel.ZwrocNrAdministratora())
                return View("BrakUprawnien");

            Uzytkownicy uzytkownik = UzytkownikModel.PobierzUzytkownikaPoID(id);
            SelectList kodyPocztowe = new SelectList(KodyPocztoweModel.pobierzListeKodowPocztowych(), "KodPocztowyID", "Kod", uzytkownik.KodPocztowyID);
            SelectList role = new SelectList(RoleModel.PobierzListeStawekVat(), "RolaID", "Nazwa", uzytkownik.RolaID);
            if (kodyPocztowe.Count() == 0 || role.Count() == 0)
            {
                return View("BladPostepowania");
            }
            ViewData["KodyPocztowe"] = kodyPocztowe;
            ViewData["Role"] = role;
            return View(uzytkownik);
        }

        //
        // POST: /Uzytkownicy/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, Uzytkownicy user, int Rola, int KodPocztowy)
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");
            if ((UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name)).RolaID != UzytkownikModel.ZwrocNrAdministratora())
                return View("BrakUprawnien");

            try
            {
                Uzytkownicy modyfikujacy = UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name);
                user.ModyfikujacyID = modyfikujacy.UzytkownikID;
                if (UzytkownikModel.EdytujUzytkownika(id, user, Rola, KodPocztowy))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    SelectList kodyPocztowe = new SelectList(KodyPocztoweModel.pobierzListeKodowPocztowych(), "KodPocztowyID", "Kod", KodPocztowy);
                    SelectList role = new SelectList(RoleModel.PobierzListeStawekVat(), "RolaID", "Nazwa", Rola);
                    if (kodyPocztowe.Count() == 0 || role.Count() == 0)
                    {
                        return View("BladPostepowania");
                    }
                    ViewData["KodyPocztowe"] = kodyPocztowe;
                    ViewData["Role"] = role;
                    Uzytkownicy uzytkownik = UzytkownikModel.PobierzUzytkownikaPoID(id);
                    return View("Edit", uzytkownik);
                }
            }
            catch
            {
                Uzytkownicy uzytkownik = UzytkownikModel.PobierzUzytkownikaPoID(id);
                ViewData["KodyPocztowe"] = new SelectList(KodyPocztoweModel.pobierzListeKodowPocztowych(), "KodPocztowyID", "Kod", KodPocztowy);
                ViewData["Role"] = new SelectList(RoleModel.PobierzListeStawekVat(), "RolaID", "Nazwa", Rola);
                return View("Edit", uzytkownik);
            }
        }

        //
        // GET: /Uzytkownicy/Delete/5

        public ActionResult Delete(int id)
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");
            if ((UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name)).RolaID != UzytkownikModel.ZwrocNrAdministratora())
                return View("BrakUprawnien");

            return View(UzytkownikModel.PobierzUzytkownikaPoID(id));
        }

        //
        // POST: /Uzytkownicy/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, Uzytkownicy user)
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");
            if ((UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name)).RolaID != UzytkownikModel.ZwrocNrAdministratora())
                return View("BrakUprawnien");

            try
            {
                using (FakturyDBEntitiess db = new FakturyDBEntitiess())
                {
                    Uzytkownicy EdycjaUzytkownika = db.Uzytkownicy.SingleOrDefault(u => u.UzytkownikID == id);

                    Uzytkownicy blokujacy = UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name);
                    EdycjaUzytkownika.BlokujacyID = blokujacy.UzytkownikID;
                    EdycjaUzytkownika.DataZablokowania = DateTime.Now;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
