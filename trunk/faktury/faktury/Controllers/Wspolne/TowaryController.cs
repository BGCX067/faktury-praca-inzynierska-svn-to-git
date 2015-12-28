using System;
using System.Linq;
using System.Web.Mvc;
using faktury.Models;
using faktury.Models.Modele;
using faktury.Models.Repozytoria;
using System.Collections.Generic;

namespace faktury.Controllers.Wspolne
{
    public class TowaryController : Controller
    {
        //
        // GET: /Towary/

        public ActionResult Index()
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");

            return View(TowaryUslugiModel.PobierzListeTowarowRepozytorium());
        }

        //
        // GET: /Towary/Details/5

        public ActionResult Details(int id)
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");

            TowaryUslugiRepozytorium towar = new TowaryUslugiRepozytorium(TowaryUslugiModel.PobierzTowarUsugePoID(id));
            return View(towar);
        }

        //
        // GET: /Towary/Create

        public ActionResult Create()
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account"); ;

            var TowarUsluga = new TowaryUslugiRepozytorium();

            SelectList stawkiVAT = new SelectList(StawkiVatModel.PobierzListeStawekVat(), "StawkaVatID", "Wartosc");
            SelectList jednostkiMiar = new SelectList(JednostkiMiarModel.PobierzListeJednostekMiar(), "JednostkaMiarID", "Nazwa");
            if (stawkiVAT.Count() == 0 || jednostkiMiar.Count() == 0)
            {
                List<string> brakuje = new List<string>();
                brakuje.Add("Stawki VAT");
                brakuje.Add("Jednostki miar");

                ViewData["Brakuje"] = brakuje;
                return View("BladPostepowania");
            }
            else
            {
                ViewData["StawkiVAT"] = stawkiVAT;
                ViewData["JenostkiMiar"] = jednostkiMiar;
                return View(TowarUsluga);
            }
        }

        //
        // POST: /Towary/Create

        [HttpPost]
        public ActionResult Create(TowaryUslugiRepozytorium t, int stawka, int jm)
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");

            try
            {
                if (ModelState.IsValid)
                {
                    Uzytkownicy wlasciciel = UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name);
                    t.NowyTowar.WlascicielID = wlasciciel.UzytkownikID;
                    t.NowyTowar.DataWprowadzenia = DateTime.Now;
                    t.NowyTowar.StawkaVatID = stawka;
                    t.NowyTowar.JednostkaMiarID = jm;
                    TowaryUslugi towar = TowaryUslugiModel.ZapiszTowarUsluge(t);
                }
                else
                {
                    ViewData["StawkiVAT"] = new SelectList(StawkiVatModel.PobierzListeStawekVat(), "StawkaVatID", "Wartosc", stawka);
                    ViewData["JenostkiMiar"] = new SelectList(JednostkiMiarModel.PobierzListeJednostekMiar(), "JednostkaMiarID", "Nazwa", jm);
                    return View("Create", t);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Towary/Edit/5

        public ActionResult Edit(int id)
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");

            TowaryUslugiRepozytorium towar = new TowaryUslugiRepozytorium(TowaryUslugiModel.PobierzTowarUsugePoID(id));
            towar.cena = (decimal)towar.TowarUsluga.CenaNetto;
            towar.netto = true;
            if (towar.TowarUsluga.Rodzaj.Equals("Towar"))
                towar.rodzaj = true;
            else
                towar.rodzaj = false;

            SelectList stawkiVAT = new SelectList(StawkiVatModel.PobierzListeStawekVat(), "StawkaVatID", "Wartosc", towar.TowarUsluga.StawkaVatID);
            SelectList jednostkiMiar = new SelectList(JednostkiMiarModel.PobierzListeJednostekMiar(), "JednostkaMiarID", "Nazwa", towar.TowarUsluga.JednostkaMiarID);
            if (stawkiVAT.Count() == 0 || jednostkiMiar.Count() == 0)
            {
                return View("BladPostepowania");
            }
            else
            {
                ViewData["StawkiVAT"] = stawkiVAT;
                ViewData["JenostkiMiar"] = jednostkiMiar;
                return View(towar);
            }
        }

        //
        // POST: /Towary/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, TowaryUslugiRepozytorium t, int stawka, int jm)
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");

            try
            {
                if (ModelState.IsValid)
                {
                    Uzytkownicy wlasciciel = UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name);
                    t.NowyTowar.WlascicielID = wlasciciel.UzytkownikID;
                    t.NowyTowar.TowarID = id;
                    t.NowyTowar.DataWprowadzenia = DateTime.Now;
                    t.NowyTowar.StawkaVatID = stawka;
                    t.NowyTowar.JednostkaMiarID = jm;
                    TowaryUslugi towar = TowaryUslugiModel.ZapiszTowarUsluge(t);
                }
                else
                {
                    ViewData["StawkiVAT"] = new SelectList(StawkiVatModel.PobierzListeStawekVat(), "StawkaVatID", "Wartosc");
                    ViewData["JenostkiMiar"] = new SelectList(JednostkiMiarModel.PobierzListeJednostekMiar(), "JednostkaMiarID", "Nazwa");
                    return View("Create", t);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Towary/Delete/5

        public ActionResult Delete(int id)
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");

            TowaryUslugiRepozytorium towar = new TowaryUslugiRepozytorium(TowaryUslugiModel.PobierzTowarUsugePoID(id));
            return View(towar);
        }

        //
        // POST: /Towary/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, TowaryUslugiRepozytorium t)
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");

            try
            {
                using (FakturyDBEntitiess db = new FakturyDBEntitiess())
                {
                    TowaryUslugiModel.UsunTowarUsluge(id, (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name)).UzytkownikID);
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
