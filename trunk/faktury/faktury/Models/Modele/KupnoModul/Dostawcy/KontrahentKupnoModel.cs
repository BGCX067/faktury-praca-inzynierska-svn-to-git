using System.Collections.Generic;
using System.Web.Mvc;

namespace faktury.Models.Modele
{
    public class KontrahentKupnoModel
    {    
        public int KontrahentID { set; get; }
        public string pelnaNazwaKontrahenta { set; get; }

        public KontrahentKupnoModel()
        { }

        public KontrahentKupnoModel(Dostawcy d)
        {
            this.KontrahentID = d.DostawcaID;
            this.pelnaNazwaKontrahenta = d.Nazwa + " " + d.Imie + " " + d.Nazwisko;
        }

        public SelectList dodajWszystkich(List<Dostawcy> listaDostawcow)
        {
            List<KontrahentKupnoModel> listaKontrahentow = new List<KontrahentKupnoModel>();
            foreach (Dostawcy d in listaDostawcow)
            {
                listaKontrahentow.Add(new KontrahentKupnoModel(d));
            }
            return new SelectList(listaKontrahentow, "KontrahentID", "pelnaNazwaKontrahenta");
        }
    }
}