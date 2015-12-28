using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using faktury.Models.Modele;
using faktury.Models;

namespace faktury.Controllers
{
    public class AccountController : Controller
    {

        //
        // GET: /Account/LogOn

        public ActionResult LogOn()
        {
            return View();
        }

        //
        // POST: /Account/LogOn

        [HttpPost]
        public ActionResult LogOn(LogOnModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {

                MojMembershipProvider mojMembership = new MojMembershipProvider();
                if (mojMembership.ValidateUser(model.UserName, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                        && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Został wprowadzony niepoprawny login lub hasło.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/LogOff

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/Register

        public ActionResult Register()
        {
            if (!UzytkownikModel.SprawdzListeUzytkownikow())
            {
                Uzytkownicy wlasciciel = UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name);
                if (wlasciciel != null && wlasciciel.RolaID == UzytkownikModel.ZwrocNrAdministratora())
                {
                    SelectList kodyPocztowe = new SelectList(KodyPocztoweModel.pobierzListeKodowPocztowych(), "KodPocztowyID", "Kod");
                    SelectList role = new SelectList(RoleModel.PobierzListeStawekVat(), "RolaID", "Nazwa");
                    if (kodyPocztowe.Count() == 0 || role.Count() == 0)
                    {
                        List<string> brakuje = new List<string>();
                        brakuje.Add("Kody pocztowe");

                        ViewData["Brakuje"] = brakuje;
                        return View("BladPostepowania");
                    }
                    ViewData["KodyPocztowe"] = kodyPocztowe;
                    ViewData["Role"] = role;
                    return View();
                }
                else
                {
                    return View("BladRejestracjiAdmin");
                }
            }
            else
            {
                UzytkownikModel.Pierwszy();

                return View("PierwszyUzytkownik");
            }
        }

        //
        // POST: /Account/Register

        [HttpPost]
        public ActionResult Register(Uzytkownicy uzytkownik, int Rola = 0, int KodPocztowy = 0)
        {
            if (ModelState.IsValid)
            {
                MembershipCreateStatus createStatus;
                if (KodPocztowy != 0)
                {
                    Uzytkownicy wlasciciel = UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name);

                    uzytkownik.WlascicielID = wlasciciel.UzytkownikID;
                    uzytkownik.DataWprowadzenia = DateTime.Now;
                    MojMembershipProvider.CreateUser(uzytkownik, KodPocztowy, Rola, out createStatus);

                    if (createStatus == MembershipCreateStatus.Success)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", ErrorCodeToString(createStatus));
                    }
                }
                else
                {
                    Rola = UzytkownikModel.ZwrocNrAdministratora();
                    MojMembershipProvider.CreateUser(uzytkownik, Rola, out createStatus);

                    if (createStatus == MembershipCreateStatus.Success)
                    {
                        FormsAuthentication.SetAuthCookie(uzytkownik.Login, false /* createPersistentCookie */);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", ErrorCodeToString(createStatus));
                    }
                }
            }
            else if (KodPocztowy != 0)
            {

                // If we got this far, something failed, redisplay form
                SelectList kodyPocztowe = new SelectList(KodyPocztoweModel.pobierzListeKodowPocztowych(), "KodPocztowyID", "Kod");
                SelectList role = new SelectList(RoleModel.PobierzListeStawekVat(), "RolaID", "Nazwa");
                if (kodyPocztowe.Count() == 0 || role.Count() == 0)
                {
                    return View("Error");
                }
                ViewData["KodyPocztowe"] = kodyPocztowe;
                ViewData["Role"] = role;
                return View(uzytkownik);
            }
            else
                return View("PierwszyUzytkownik");
            return View(uzytkownik);

        }

        //
        // GET: /Account/ChangePassword

        [Authorize]
        public ActionResult ChangePassword()
        {
            return View();
        }

        //
        // POST: /Account/ChangePassword

        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {
                // ChangePassword will throw an exception rather
                // than return false in certain failure scenarios.
                bool changePasswordSucceeded;
                try
                {
                    if (User.Identity.Name == "")
                    {
                        ModelState.AddModelError("", "Nie można wskazać zalogowanego użytkownika");
                    }
                    Uzytkownicy uzytkownik = UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name);
                    changePasswordSucceeded = UzytkownikModel.ZmienHaslo(uzytkownik, model.OldPassword, model.NewPassword, model.ConfirmPassword);
                }
                catch (Exception)
                {
                    changePasswordSucceeded = false;
                }

                if (changePasswordSucceeded)
                {
                    return RedirectToAction("ChangePasswordSuccess");
                }
                else
                {
                    ModelState.AddModelError("", "Hasło jest nieprawidłowe lub nowe hasło jest nieprawidłowe.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ChangePasswordSuccess

        public ActionResult ChangePasswordSuccess()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetInfo(string country)
        {
            return Json(new { agent = country, other = "Blech" }, JsonRequestBehavior.AllowGet);
        }

        #region Status Codes
        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "Nazwa użytkownika istnieje. Proszę podać inną nazwę użytkownika.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "Nazwa użytkownika dla tego adresu e-mail już istnieje. Wprowadź inny adres e-mail.";

                case MembershipCreateStatus.InvalidPassword:
                    return "Podane hasło jest nieprawidłowe, proszę podać prawidłową wartość hasła.";

                case MembershipCreateStatus.InvalidEmail:
                    return "Adres E-mail jest nieprawidłowy. Proszę sprawdzić wartość i spróbuj ponownie.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "Nieprawidłowa odpowiedź. Proszę sprawdzić wartość i spróbuj ponownie.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "Nieprawidłowa pytanie. Proszę sprawdzić wartość i spróbuj ponownie.";

                case MembershipCreateStatus.InvalidUserName:
                    return "Błędna nazwa użytkownika. Proszę sprawdzić wartość i spróbuj ponownie..";

                case MembershipCreateStatus.ProviderError:
                    return "Podczas procesu uwirzytniania wystąpił błąd. Proszę sprawdzić swój wpis i spróbuj ponownie. Jeśli problem nie ustąpi, skontaktuj się z administratorem systemu.";

                case MembershipCreateStatus.UserRejected:
                    return "Tworzenie użytkownika zostało anulowane. Proszę sprawdzić swój wpis i spróbuj ponownie. Jeśli problem nie ustąpi, skontaktuj się z administratorem systemu.";

                default:
                    return "Wystąpił nieznany błąd. Proszę sprawdzić swój wpis i spróbuj ponownie. Jeśli problem nie ustąpi, skontaktuj się z administratorem systemu.";
            }
        }
        #endregion
    }
}
