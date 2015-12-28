using System.Collections.Generic;
using System.Web.Mvc;

namespace faktury.Models.Modele
{
    public class KontrahentModel
    {
        public int KontrahentID { set; get; }
        public string pelnaNazwaKontrahenta { set; get; }

        public KontrahentModel()
        { }

        public KontrahentModel(Klienci k)
        {
            this.KontrahentID = k.KlientID;
            this.pelnaNazwaKontrahenta = k.Nazwa + " " + k.Imie + " " + k.Nazwisko;
        }

        public SelectList dodajWszystkich(List<Klienci> listaKlientow)
        {
            List<KontrahentModel> listaKontrahentow = new List<KontrahentModel>();
            foreach (Klienci k in listaKlientow)
            {
                listaKontrahentow.Add(new KontrahentModel(k));
            }
            return new SelectList(listaKontrahentow, "KontrahentID", "pelnaNazwaKontrahenta");
        }
    }
}