using System.Collections.Generic;

namespace faktury.Models.Modele
{
    public class FakturaKupna
    {
        public List<TowaryUslugi> towaryUslugi { get; set; }
        public DokumentyKupna dokumentKupna { get; set; }
        public ProduktyFakturyKupna ProduktFakturyKupna { get; set; }
        public RozliczeniaKupna RozliczenieKupna { get; set; }
        public List<ProduktyFakturyKupna> ListaProduktowKupna { get; set; }
        public List<RozliczeniaKupna> ListaRozliczeniaKupna { get; set; }
        public KontrahentKupnoModel Kontrahent { get; set; }
    }
}