using System.Collections.Generic;

namespace faktury.Models.Modele
{
    public class FakturaSprzedazy
    {
        public List<TowaryUslugi> towaryUslugi { get; set; }
        public DokumentySprzedazy dokumentSprzedazy { get; set; }
        public ProduktyFakturySprzedazy ProduktFakturySprzedazy { get; set; }
        public RozliczeniaSprzedazy RozliczenieSprzedazy { get; set; }
        public List<ProduktyFakturySprzedazy> ListaProduktowSprzedazy { get; set; }   
        public List<RozliczeniaSprzedazy> ListaRozliczeniaSprzedazy { get; set; }
        public KontrahentModel Kontrahent { get; set; }
    }
}