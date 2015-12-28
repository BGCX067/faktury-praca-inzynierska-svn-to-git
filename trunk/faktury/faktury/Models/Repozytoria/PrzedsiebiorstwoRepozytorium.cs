using System.Linq;

namespace faktury.Models
{
    public class PrzedsiebiorstwoRepozytorium
    {
        public string PelnaNazwaPrzedsiebiorstwa { get; set; }
        public DanePrzedsiebiorstwa Przedsiebiorstwo { get; set; }
        public string KodPocztowy { get; set; }
        public string Miejscowosc { get; set; }
        public string Panstwo { get; set; }
        public string KodPocztowyKontakt { get; set; }
        public string MiejscowoscKontakt { get; set; }

        public PrzedsiebiorstwoRepozytorium()
        {
            PelnaNazwaPrzedsiebiorstwa = string.Empty;
            Przedsiebiorstwo = new DanePrzedsiebiorstwa();
            KodPocztowy = string.Empty;
            Miejscowosc = string.Empty;
            Panstwo = string.Empty;
            KodPocztowyKontakt = string.Empty;
            MiejscowoscKontakt = string.Empty;
        }

        public PrzedsiebiorstwoRepozytorium(DanePrzedsiebiorstwa danePrzedsiebiorsta)
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                PelnaNazwaPrzedsiebiorstwa = danePrzedsiebiorsta.Nazwa + " " + danePrzedsiebiorsta.Imie + " " + danePrzedsiebiorsta.Nazwisko;
                Przedsiebiorstwo = danePrzedsiebiorsta;
                KodPocztowy = (db.KodyPocztowe.FirstOrDefault(k => k.KodPocztowyID == Przedsiebiorstwo.KodPocztowyID)).Kod;
                Miejscowosc = (db.Miejscowosci.FirstOrDefault(m => m.MiejscowoscID ==
                    (db.KodyPocztowe.FirstOrDefault(k => k.KodPocztowyID == Przedsiebiorstwo.KodPocztowyID)).MiejscowoscID)).Nazwa;
                Panstwo = (db.Kraje.FirstOrDefault(p => p.KrajID ==
                    (db.Miejscowosci.FirstOrDefault(m => m.MiejscowoscID ==
                        (db.KodyPocztowe.FirstOrDefault(k => k.KodPocztowyID == Przedsiebiorstwo.KodPocztowyID)).MiejscowoscID)).KrajID)).Nazwa;
                KodPocztowyKontakt = (db.KodyPocztowe.FirstOrDefault(kk => kk.KodPocztowyID == Przedsiebiorstwo.KodPocztowyKontaktID)).Kod;
                MiejscowoscKontakt = (db.Miejscowosci.FirstOrDefault(mk => mk.MiejscowoscID ==
                    (db.KodyPocztowe.FirstOrDefault(kk => kk.KodPocztowyID == Przedsiebiorstwo.KodPocztowyKontaktID)).MiejscowoscID)).Nazwa;
            }
        }
    }
}