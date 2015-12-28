using System.Web.Mvc;
using faktury.Models.Modele;

namespace faktury.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");
            ViewBag.Message = "Witam!";

            return View();
        }

        public ActionResult About()
        {
            if (UzytkownikModel.PobierzUzytkownikaPoLoginie(User.Identity.Name) == null)
                return RedirectToAction("LogOn", "Account");
            return View();
        }
    }
}
