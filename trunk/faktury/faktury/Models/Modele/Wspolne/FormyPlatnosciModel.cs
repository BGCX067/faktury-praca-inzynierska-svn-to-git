using System.Collections.Generic;
using System.Linq;

namespace faktury.Models.Modele
{
    public class FormyPlatnosciModel
    {
        public static List<FormyPlatnosci> PobierzListeFormPlatnosci()
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                return (from f in db.FormyPlatnosci
                        where object.Equals(f.DataZablokowania, null)
                        orderby f.Nazwa
                        select f).ToList<FormyPlatnosci>();
            }
        }

        internal static FormyPlatnosci PobierzFormePlatnosciPoID(int id)
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                return db.FormyPlatnosci.SingleOrDefault(f => f.FormaPlatnosciID == id);
            }
        }
    }
}
