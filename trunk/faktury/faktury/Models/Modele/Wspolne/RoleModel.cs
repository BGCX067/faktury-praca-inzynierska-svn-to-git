using System.Collections.Generic;
using System.Linq;

namespace faktury.Models.Modele
{
    public static class RoleModel
    {
        public static List<Role> PobierzListeStawekVat()
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                return (from r in db.Role
                        select r).ToList<Role>();
            }
        }
    }
}