using System;
using System.Linq;
using System.Web.Mvc;
using faktury.Models;
using faktury.Models.Modele;
using faktury.Models.Repozytoria;

namespace faktury.Controllers
{
    public class DostawcyController : Controller
    {
        //
        // GET: /Dostawcy/

        public ActionResult Index()
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");

            return View(DostawcyModel.PobierzListeDostawcowRepozytorium());
        }

        //
        // GET: /Dostawcy/Details/5

        public ActionResult Details(int id)
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");

            DostawcyRepozytorium Dostawca = new DostawcyRepozytorium(DostawcyModel.PobierzDostawcePoID(id));
            return View(Dostawca);
        }

        //
        // GET: /Dostawcy/Create

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
        // POST: /Dostawcy/Create

        [HttpPost]
        public ActionResult Create(Dostawcy d, int kodPocztowy, int kodPocztowyKontakt)
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");
            try
            {
                if (ModelState.IsValid)
                {
                    Uzytkownicy wlasciciel = UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name);
                    d.WlascicielID = wlasciciel.UzytkownikID;
                    d.KodPocztowyID = kodPocztowy;
                    d.KodPocztowyKontaktID = kodPocztowyKontakt;
                    d.DataWprowadzenia = DateTime.Now;
                    Dostawcy Dostawca = DostawcyModel.DodajDostawce(d);
                }
                else
                {
                    ViewData["KodPocztowy"] = new SelectList(KodyPocztoweModel.pobierzListeKodowPocztowych(), "KodPocztowyID", "Kod");
                    ViewData["KodPocztowyKontakt"] = new SelectList(KodyPocztoweModel.pobierzListeKodowPocztowych(), "KodPocztowyID", "Kod");
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
        // GET: /Dostawcy/Edit/5

        public ActionResult Edit(int id)
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");

            Dostawcy Dostawca = DostawcyModel.PobierzDostawcePoID(id);
            ViewData["KodPocztowy"] = new SelectList(KodyPocztoweModel.pobierzListeKodowPocztowych(), "KodPocztowyID", "Kod", Dostawca.KodPocztowyID);
            ViewData["KodPocztowyKontakt"] = new SelectList(KodyPocztoweModel.pobierzListeKodowPocztowych(), "KodPocztowyID", "Kod", Dostawca.KodPocztowyKontaktID);

            return View(Dostawca);
        }

        //
        // POST: /Dostawcy/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, Dostawcy Dostawca, int kodPocztowy, int kodPocztowyKontakt)
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
                        DostawcyModel.UsunDostawce(id, modyfikujacy.UzytkownikID);

                        Create(Dostawca, kodPocztowy, kodPocztowyKontakt);
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    ViewData["KodPocztowy"] = new SelectList(KodyPocztoweModel.pobierzListeKodowPocztowych(), "KodPocztowyID", "Kod");
                    ViewData["KodPocztowyKontakt"] = new SelectList(KodyPocztoweModel.pobierzListeKodowPocztowych(), "KodPocztowyID", "Kod");
                    return View("Edit", Dostawca);
                }
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Dostawcy/Delete/5

        public ActionResult Delete(int id)
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");

            DostawcyRepozytorium Dostawca = new DostawcyRepozytorium(DostawcyModel.PobierzDostawcePoID(id));
            return View(Dostawca);
        }

        //
        // POST: /Dostawcy/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, Dostawcy dostawca)
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");

            try
            {
                using (FakturyDBEntitiess db = new FakturyDBEntitiess())
                {
                    Uzytkownicy blokujacy = UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name);
                    DostawcyModel.UsunDostawce(id, blokujacy.UzytkownikID);
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
