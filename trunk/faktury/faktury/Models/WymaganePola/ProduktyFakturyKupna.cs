using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace faktury.Models
{
    [MetadataType(typeof(ProduktyFakturyKupnaMetadata))]
    public partial class ProduktyFakturyKupna
    {
        [Bind(Exclude = "ProduktFakturyKupnaID")]
        public class ProduktyFakturyKupnaMetadata
        {
            public int ProduktFakturyKupnaID { get; set; }
            public int DokumentKupnaID { get; set; }
            public int TowarID { get; set; }

            [ScaffoldColumn(false)]
            [Required(ErrorMessage = "Ilość - wymagane pole")]
            [Range(0.01, 999999.00,
                ErrorMessage = "Ilość musi być między 0.00, a 999999.00")]
            public decimal Ilosc { get; set; }
        }
    }
}