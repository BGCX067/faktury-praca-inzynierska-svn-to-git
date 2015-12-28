using System;
using System.Linq;
using System.Web.Mvc;
using faktury.Models.Modele;
using faktury.Models;

namespace faktury.Controllers
{
    public class PrzedsiebiorstwoController : Controller
    {
        //
        // GET: /Przedsiebiorstwo/

        public ActionResult Index()
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");
            if ((UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name)).RolaID != UzytkownikModel.ZwrocNrAdministratora())
                return View("BrakUprawnien");

            if (PrzedsiebiorstwoModel.PobierzPrzedsiebiorstwo().Count() == 0)
                return RedirectToAction("Create", "Przedsiebiorstwo");
            else
                return RedirectToAction("Details", "Przedsiebiorstwo");
        }

        //
        // GET: /Przedsiebiorstwo/Details/5

        public ActionResult Details(int? id)
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");
            if ((UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name)).RolaID != UzytkownikModel.ZwrocNrAdministratora())
                return View("BrakUprawnien");

            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                PrzedsiebiorstwoRepozytorium Przedsiebiorca = 
                    new PrzedsiebiorstwoRepozytorium(
                        PrzedsiebiorstwoModel.PobierzPrzedsiebiorstwoPoID((db.DanePrzedsiebiorstwa.SingleOrDefault(d => d.DataZablokowania == null)).DanePrzedsiebiorstwaID));
                return View(Przedsiebiorca);
            }
        }

        //
        // GET: /Przedsiebiorstwo/Create

        public ActionResult Create()
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");
            if ((UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name)).RolaID != UzytkownikModel.ZwrocNrAdministratora())
                return View("BrakUprawnien");

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
        // POST: /Przedsiebiorstwo/Create

        [HttpPost]
        public ActionResult Create(DanePrzedsiebiorstwa d, int kodPocztowy, int kodPocztowyKontakt)
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return View("LogOn", "Account");

            try
            {
                if (ModelState.IsValid)
                {
                    Uzytkownicy wlasciciel = UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name);
                    d.WlascicielID = wlasciciel.UzytkownikID;
                    d.KodPocztowyID = kodPocztowy;
                    d.KodPocztowyKontaktID = kodPocztowyKontakt;
                    d.DataWprowadzenia = DateTime.Now;
                    PrzedsiebiorstwoModel.DodajPrzedsiebiorstwo(d);
                }
                else
                {
                    ViewData["KodPocztowy"] = new SelectList(KodyPocztoweModel.pobierzListeKodowPocztowych(), "KodPocztowyID", "Kod", d.KodPocztowyID);
                    ViewData["KodPocztowyKontakt"] = new SelectList(KodyPocztoweModel.pobierzListeKodowPocztowych(), "KodPocztowyID", "Kod", d.KodPocztowyKontaktID);
                    return View("Create", d);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Przedsiebiorstwo/Edit/5

        public ActionResult Edit(int id)
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");
            if ((UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name)).RolaID != UzytkownikModel.ZwrocNrAdministratora())
                return View("BrakUprawnien");

            DanePrzedsiebiorstwa Przedsiebiorstwo = PrzedsiebiorstwoModel.PobierzPrzedsiebiorstwoPoID(id);
            ViewData["KodPocztowy"] = new SelectList(KodyPocztoweModel.pobierzListeKodowPocztowych(), "KodPocztowyID", "Kod", Przedsiebiorstwo.KodPocztowyID);
            ViewData["KodPocztowyKontakt"] = new SelectList(KodyPocztoweModel.pobierzListeKodowPocztowych(), "KodPocztowyID", "Kod", Przedsiebiorstwo.KodPocztowyKontaktID);
            return View(Przedsiebiorstwo);
        }

        //
        // POST: /Przedsiebiorstwo/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, DanePrzedsiebiorstwa Przedsiebiorca, int kodPocztowy, int kodPocztowyKontakt)
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
                        DanePrzedsiebiorstwa przedsiebiorca = db.DanePrzedsiebiorstwa.SingleOrDefault(o => o.DanePrzedsiebiorstwaID == id);
                        przedsiebiorca = Przedsiebiorca;
                        przedsiebiorca.ModyfikujacyID = modyfikujacy.UzytkownikID;
                        przedsiebiorca.KodPocztowyID = kodPocztowy;
                        przedsiebiorca.KodPocztowyKontaktID = kodPocztowyKontakt;
                        przedsiebiorca.DataModyfikacji = DateTime.Now;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    ViewData["KodPocztowy"] = new SelectList(KodyPocztoweModel.pobierzListeKodowPocztowych(), "KodPocztowyID", "Kod", Przedsiebiorca.KodPocztowyID);
                    ViewData["KodPocztowyKontakt"] = new SelectList(KodyPocztoweModel.pobierzListeKodowPocztowych(), "KodPocztowyID", "Kod", Przedsiebiorca.KodPocztowyKontaktID);
                    return View("Edit", Przedsiebiorca);
                }
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Przedsiebiorstwo/Delete/5

        public ActionResult Delete(int id)
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");
            if ((UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name)).RolaID != UzytkownikModel.ZwrocNrAdministratora())
                return View("BrakUprawnien");

            PrzedsiebiorstwoRepozytorium Przedsiebiorca = new PrzedsiebiorstwoRepozytorium(PrzedsiebiorstwoModel.PobierzPrzedsiebiorstwoPoID(id));
            return View(Przedsiebiorca);
        }

        //
        // POST: /Przedsiebiorstwo/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, PrzedsiebiorstwoRepozytorium Przedsiębiorstwo)
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
                    DanePrzedsiebiorstwa przedsiebiorca = db.DanePrzedsiebiorstwa.SingleOrDefault(o => o.DanePrzedsiebiorstwaID == id);

                    przedsiebiorca.ModyfikujacyID = blokujacy.UzytkownikID;
                    przedsiebiorca.DataModyfikacji = DateTime.Now;
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
