using System.Data.Objects.DataClasses;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.ComponentModel;

namespace faktury.Models
{
    [MetadataType(typeof(StawkiVatMetadata))]
    public partial class StawkiVat : EntityObject
    {
        [Bind(Exclude = "StawkaVatID")]
        public class StawkiVatMetadata
        {
            public int StawkaVatID { get; set; }

            [DisplayName("Wartosc")]
            [Required(ErrorMessage = "Wartość - wymagane pole")]
            [Range(0, 100,
                ErrorMessage = "Wartość stawki VAT musi być między 0%, a 100%")]  
            public int Wartosc { get; set; }

        }
    }
}
  
