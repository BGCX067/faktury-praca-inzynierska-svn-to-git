using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace faktury.Models.Modele
{
    public class PanstwaModel : Controller
    {
        public static List<Kraje> PobierzListePanstw()
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                return (from k in db.Kraje
                        where object.Equals(k.DataZablokowania, null) 
                        orderby k.Nazwa
                        select k).ToList<Kraje>();
            }
        }

        internal static Kraje PobierzPanstwoPoID(int id)
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                return db.Kraje.SingleOrDefault(k => k.KrajID == id);
            }
        }

        internal static List<Kraje> PobierzWaluty()
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                return (from k in db.Kraje select k).ToList<Kraje>();
            }
        }
    }
}
