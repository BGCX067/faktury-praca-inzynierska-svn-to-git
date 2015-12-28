using System.Collections.Generic;
using System.Linq;

namespace faktury.Models.Modele
{
    public class PrzedsiebiorstwoModel
    {
        public static List<DanePrzedsiebiorstwa> PobierzPrzedsiebiorstwo()
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                return (from p in db.DanePrzedsiebiorstwa where object.Equals(p.DataZablokowania, null) select p).ToList();             
            }
        }

        internal static void DodajPrzedsiebiorstwo(DanePrzedsiebiorstwa d)
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                db.DanePrzedsiebiorstwa.AddObject(d);
                db.SaveChanges();
            }
        }

        internal static DanePrzedsiebiorstwa PobierzPrzedsiebiorstwoPoID(int id)
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                return db.DanePrzedsiebiorstwa.SingleOrDefault(d => d.DanePrzedsiebiorstwaID == id);
            }
        }
    }
}