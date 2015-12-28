using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace faktury.Models.Modele
{
    public class StawkiVatModel : Controller
    {
        public static List<StawkiVat> PobierzListeStawekVat()
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                return (from s in db.StawkiVat
                        where object.Equals(s.DataZablokowania, null)
                        orderby s.Wartosc
                        select s).ToList<StawkiVat>();
            }
        }

        internal static StawkiVat PobierzStawkeVatPoID(int id)
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                return db.StawkiVat.SingleOrDefault(u => u.StawkaVatID == id);
            }
        }
    }    
}
