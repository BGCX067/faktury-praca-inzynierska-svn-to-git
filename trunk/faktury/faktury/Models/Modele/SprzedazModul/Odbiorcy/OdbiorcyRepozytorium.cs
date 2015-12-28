using System.Linq;

namespace faktury.Models
{
    public class OdbiorcyRepozytorium
    {
        public string PelnaNazwaOdbiorcy { get; set; }
        public Klienci Odbiorca;
        public string KodPocztowy { get; set; }
        public string Miejscowosc { get; set; }
        public string Panstwo { get; set; }
        public string KodPocztowyKontakt { get; set; }
        public string MiejscowoscKontakt { get; set; }        

        public OdbiorcyRepozytorium()
        {
            PelnaNazwaOdbiorcy = string.Empty;
            KodPocztowy = string.Empty;
            Miejscowosc = string.Empty;
            Panstwo = string.Empty;
            KodPocztowyKontakt = string.Empty;
            MiejscowoscKontakt = string.Empty;
            Odbiorca = new Klienci();
        }

        public OdbiorcyRepozytorium(Klienci o)
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                PelnaNazwaOdbiorcy = o.Nazwa + " " + o.Imie + " " + o.Nazwisko;
                Odbiorca = o;
                KodPocztowy = (db.KodyPocztowe.FirstOrDefault(k => k.KodPocztowyID == Odbiorca.KodPocztowyID)).Kod;

                Miejscowosc = (db.Miejscowosci.FirstOrDefault(m => m.MiejscowoscID ==
                    (db.KodyPocztowe.FirstOrDefault(k => k.KodPocztowyID == Odbiorca.KodPocztowyID)).MiejscowoscID)).Nazwa;

                Panstwo = (db.Kraje.FirstOrDefault(p => p.KrajID ==
                        (db.Miejscowosci.FirstOrDefault(m => m.MiejscowoscID ==
                            (db.KodyPocztowe.FirstOrDefault(k => k.KodPocztowyID == Odbiorca.KodPocztowyID)).MiejscowoscID)).KrajID)).Nazwa;

                KodPocztowyKontakt = (db.KodyPocztowe.FirstOrDefault(kk => kk.KodPocztowyID == Odbiorca.KodPocztowyKontaktID)).Kod;
                MiejscowoscKontakt = (db.Miejscowosci.FirstOrDefault(mk => mk.MiejscowoscID ==
                        (db.KodyPocztowe.FirstOrDefault(kk => kk.KodPocztowyID == Odbiorca.KodPocztowyKontaktID)).MiejscowoscID)).Nazwa;
            }
        }


    }
}