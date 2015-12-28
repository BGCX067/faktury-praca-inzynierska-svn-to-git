using System;
using System.Data.Objects.DataClasses;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.ComponentModel;

namespace faktury.Models
{
    [MetadataType(typeof(KrajeMetadata))]
    public partial class Kraje : EntityObject
    {
        [Bind(Exclude = "KrajID")]
        public class KrajeMetadata
        {
            public int KrajID { get; set; }

            [DisplayName("Nazwa")]
            [Required(ErrorMessage = "Nazwa - wymagane pole")]
            [StringLength(64)]
            public String Nazwa { get; set; }

            [DisplayName("Waluta")]
            [Required(ErrorMessage = "Waluta - wymagane pole")]
            [StringLength(32)]
            public String Waluta { get; set; }

            [DisplayName("Waluta skrót")]
            [Required(ErrorMessage = "Skrótowe oznaczenie waluty - wymagane pole")]
            [StringLength(8)]
            public String WalutaSkrot { get; set; }
        }
    }
}
  
