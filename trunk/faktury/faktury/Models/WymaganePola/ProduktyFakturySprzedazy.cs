using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Data.Objects.DataClasses;

namespace faktury.Models
{
    [MetadataType(typeof(ProduktyFakturySprzedazyMetadata))]
    public partial class ProduktyFakturySprzedazy : EntityObject
    {
        [Bind(Exclude = "ProduktFakturySprzedazyID")]
        public class ProduktyFakturySprzedazyMetadata
        {
            public int ProduktFakturySprzedazyID { get; set; }
            public int DokumentSprzedazyID { get; set; }
            public int TowarID { get; set; }

            [ScaffoldColumn(false)]
            [Required(ErrorMessage = "Ilość - wymagane pole")]
            [Range(0.00, 999999.00,
                ErrorMessage = "Ilość musi być między 0.00, a 999999.00")]
            public decimal Ilosc { get; set; }
        }
    }
}