using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace faktury.Models.Repozytoria
{
    [MetadataType(typeof(TowarUslugaMetadata))]
    public class TowaryUslugiRepozytorium
    {
        public TowaryUslugiRepozytorium()
        {
            TowarUsluga = new TowaryUslugi();
            JednostkaTowar = new JednostkiMiar();
            VatTowar = new StawkiVat();
            rodzaj = true;
            netto = true;
            cena = 0;
            NowyTowar = new TowaryUslugi();
        }

        public TowaryUslugiRepozytorium(TowaryUslugi towar)
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                JednostkaTowar = db.JednostkiMiar.SingleOrDefault(k => k.JednostkaMiarID == towar.JednostkaMiarID);
                VatTowar = db.StawkiVat.SingleOrDefault(s => s.StawkaVatID == towar.StawkaVatID);
                TowarUsluga = NowyTowar = towar;
            }
        }

        public TowaryUslugi TowarUsluga;
        public JednostkiMiar JednostkaTowar;
        public StawkiVat VatTowar;
        public TowaryUslugi NowyTowar { get; set; }
        public bool rodzaj { get; set; }
        public bool netto { get; set; }
        public decimal cena { get; set; }
    }
}

public class TowarUslugaMetadata
{
    [Required(ErrorMessage = "Cena jest wymagana")]
    [Range(0.01, 999999.00,
        ErrorMessage = "Cena musi być między 0.01, a 999999.00")]
    public decimal cena { get; set; }
}