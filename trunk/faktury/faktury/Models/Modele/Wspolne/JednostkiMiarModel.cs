using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace faktury.Models.Modele
{
    public class JednostkiMiarModel : Controller
    {
        public static List<JednostkiMiar> PobierzListeJednostekMiar()
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                return (from j in db.JednostkiMiar
                        where object.Equals(j.DataZablokowania, null)
                        orderby j.Nazwa
                        select j).ToList<JednostkiMiar>();
            }
        }

        internal static JednostkiMiar PobierzJednostkeMiarPoID(int id)
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                return db.JednostkiMiar.SingleOrDefault(j => j.JednostkaMiarID == id);
            }
        }
    }
}