using System.Linq;

namespace faktury.Models.Repozytoria
{
    public class MiejscowosciRepozytorium
    {
        public MiejscowosciRepozytorium()
        {
            MiejscowosciKraje = new Kraje();
            Miejscowosc = new Miejscowosci();
        }

        public MiejscowosciRepozytorium(Miejscowosci miejscowosc)
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                MiejscowosciKraje = db.Kraje.SingleOrDefault(k => k.KrajID == miejscowosc.KrajID);
                Miejscowosc = miejscowosc;
            }
        }

         public Kraje MiejscowosciKraje;
         public Miejscowosci Miejscowosc;
    }
}