using System.Linq;

namespace faktury.Models.Repozytoria
{
    public class DostawcyRepozytorium
    {
        public DostawcyRepozytorium()
        {
            PelnaNazwaDostawcy = string.Empty;
            Dostawca = new Dostawcy();
            KodPocztowy = string.Empty;
            Miejscowosc = string.Empty;
            Panstwo = string.Empty;
            KodPocztowyKontakt = string.Empty;
            MiejscowoscKontakt = string.Empty;
        }

        public DostawcyRepozytorium(Dostawcy dostawca)
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                PelnaNazwaDostawcy = dostawca.Nazwa + " " + dostawca.Imie + " " + dostawca.Nazwisko;
                Dostawca = dostawca;
                KodPocztowy = (db.KodyPocztowe.FirstOrDefault(k => k.KodPocztowyID == Dostawca.KodPocztowyID)).Kod;
                Miejscowosc = (db.Miejscowosci.FirstOrDefault(m => m.MiejscowoscID ==
                    (db.KodyPocztowe.FirstOrDefault(k => k.KodPocztowyID == Dostawca.KodPocztowyID)).MiejscowoscID)).Nazwa;
                Panstwo = (db.Kraje.FirstOrDefault(p => p.KrajID ==
                    (db.Miejscowosci.FirstOrDefault(m => m.MiejscowoscID ==
                        (db.KodyPocztowe.FirstOrDefault(k => k.KodPocztowyID == Dostawca.KodPocztowyID)).MiejscowoscID)).KrajID)).Nazwa;
                KodPocztowyKontakt = (db.KodyPocztowe.FirstOrDefault(kk => kk.KodPocztowyID == Dostawca.KodPocztowyKontaktID)).Kod;
                MiejscowoscKontakt = (db.Miejscowosci.FirstOrDefault(mk => mk.MiejscowoscID ==
                    (db.KodyPocztowe.FirstOrDefault(kk => kk.KodPocztowyID == Dostawca.KodPocztowyKontaktID)).MiejscowoscID)).Nazwa;
            }
        }

        public string PelnaNazwaDostawcy { get; set; }
        public Dostawcy Dostawca { get; set; }
        public string KodPocztowy { get; set; }
        public string Miejscowosc { get; set; }
        public string Panstwo { get; set; }
        public string KodPocztowyKontakt { get; set; }
        public string MiejscowoscKontakt { get; set; }
    }
}