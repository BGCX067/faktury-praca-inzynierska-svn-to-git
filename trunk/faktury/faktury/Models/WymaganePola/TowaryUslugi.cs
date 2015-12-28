using System;
using System.Data.Objects.DataClasses;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.ComponentModel;

namespace faktury.Models
{
    [MetadataType(typeof(TowaryUslugiMetadata))]
    public partial class TowaryUslugi : EntityObject
    {
        [Bind(Exclude = "TowarID")]
        public class TowaryUslugiMetadata
        {
            public int TowarID { get; set; }

            [DisplayName("Nazwa")]
            [Required(ErrorMessage = "Nazwa - wymagane pole")]
            [StringLength(64)]
            public String Nazwa { get; set; }

            [Range(0.00, 999999.00,
                ErrorMessage = "Marża musi być między 0.00, a 9999999.00")]
            public decimal Marza { get; set; }

            public int JednostkaMiarID { get; set; }

            public int StawkaVatID { get; set; }
        }
    }
}
  
