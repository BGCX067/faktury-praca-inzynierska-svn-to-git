using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using faktury.Models;
using faktury.Models.Modele;

namespace faktury.Controllers
{
    [HandleError]
    public class BankiController : Controller
    {
        //
        // GET: /Banki/
        // [Authorize]

        public ActionResult Index()
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");
            if ((UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name)).RolaID != UzytkownikModel.ZwrocNrAdministratora())
                return View("BrakUprawnien");

            List<Banki> listaBankow = BankModel.PobierzListeBankow();
            return View(listaBankow);
        }

        //
        // GET: /Banki/Details/5

        public ActionResult Details(int id)
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");
            if ((UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name)).RolaID != UzytkownikModel.ZwrocNrAdministratora())
                return View("BrakUprawnien");

            Banki bank = BankModel.PobierzBankPoID(id);

            if (bank == null)
                return View("NieZnaleziono");
            else
                return View(bank);
        }

        //
        // GET: /Banki/Create

        public ActionResult Create()
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");
            if ((UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name)).RolaID != UzytkownikModel.ZwrocNrAdministratora())
                return View("BrakUprawnien");
            Banki bank = new Banki();
            return View(bank);
        }

        //
        // POST: /Banki/Create

        [HttpPost]
        public ActionResult Create(Banki b)
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");
            if ((UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name)).RolaID != UzytkownikModel.ZwrocNrAdministratora())
                return View("BrakUprawnien");
            try
            {
                if (ModelState.IsValid)
                {
                    using (FakturyDBEntitiess db = new FakturyDBEntitiess())
                    {
                        Uzytkownicy wlasciciel = UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name);

                        Banki bank = new Banki();
                        bank.DataWprowadzenia = DateTime.Now;
                        bank.WlascicielID = wlasciciel.UzytkownikID;
                        bank.Nazwa = b.Nazwa;
                        bank.NrBanku = b.NrBanku;
                        bank.Uwagi = b.Uwagi;

                        db.AddToBanki(bank);
                        db.SaveChanges();
                    }
                }
                else
                {
                    return View("Create", b);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Banki/Edit/5

        public ActionResult Edit(int id)
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");
            if ((UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name)).RolaID != UzytkownikModel.ZwrocNrAdministratora())
                return View("BrakUprawnien");
            Banki bank = BankModel.PobierzBankPoID(id);
            return View(bank);
        }

        //
        // POST: /Banki/Edit/5

        [HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        public ActionResult Edit(int id, Banki b)
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");
            if ((UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name)).RolaID != UzytkownikModel.ZwrocNrAdministratora())
                return View("BrakUprawnien");
            try
            {
                if (ModelState.IsValid)
                {
                    using (FakturyDBEntitiess db = new FakturyDBEntitiess())
                    {
                        Uzytkownicy modyfikujacy = UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name);

                        Banki bank = db.Banki.SingleOrDefault(o => o.BankID == id);
                        bank.Nazwa = b.Nazwa;
                        bank.NrBanku = b.NrBanku;
                        bank.Uwagi = b.Uwagi;
                        bank.ModyfikujacyID = modyfikujacy.UzytkownikID;
                        bank.DataModyfikacji = DateTime.Now;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    return View("Edit", b);
                }
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Banki/Delete/5

        public ActionResult Delete(int id)
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");
            if ((UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name)).RolaID != UzytkownikModel.ZwrocNrAdministratora())
                return View("BrakUprawnien");
            Banki bank = BankModel.PobierzBankPoID(id);

            if (bank == null)
                return View("NieZnaleziono");
            else
                return View(bank);
        }

        //
        // POST: /Banki/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, Banki b)
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");
            if ((UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name)).RolaID != UzytkownikModel.ZwrocNrAdministratora())
                return View("BrakUprawnien");
            try
            {
                using (FakturyDBEntitiess db = new FakturyDBEntitiess())
                {
                    Uzytkownicy blokujacy = UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name);

                    Banki bank = db.Banki.SingleOrDefault(o => o.BankID == id);
                    bank.BlokujacyID = blokujacy.UzytkownikID;
                    bank.DataZablokowania = DateTime.Now;
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
