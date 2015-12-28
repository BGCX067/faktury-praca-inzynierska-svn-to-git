using System.Linq;

namespace faktury.Models.Repozytoria
{
    public class KodyPocztoweRepozytorium
    {
        public KodyPocztoweRepozytorium()
        {
            KodyPocztoweMiejscowosci = new Miejscowosci();
            KodPocztowy = new KodyPocztowe();
        }

        public KodyPocztoweRepozytorium(KodyPocztowe kodPocztowy)
        {

            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                KodyPocztoweMiejscowosci = db.Miejscowosci.SingleOrDefault(m => m.MiejscowoscID == kodPocztowy.MiejscowoscID);
                KodPocztowy = kodPocztowy;
            }
        }

        public Miejscowosci KodyPocztoweMiejscowosci;
        public KodyPocztowe KodPocztowy;
    }
}