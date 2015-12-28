using System;
using System.Web.Mvc;
using System.Data.Objects.DataClasses;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace faktury.Models
{
    [MetadataType(typeof(BankiMetadata))]
    public partial class Banki : EntityObject
    { }

    [Bind(Exclude = "BankID")]
    public class BankiMetadata
    {
        public int BankID { get; set; }

        [DisplayName("Nazwa")]
        [Required(ErrorMessage = "Nazwa banku - wymagane pole")]
        [StringLength(32)]
        public String Nazwa { get; set; }

        [DisplayName("NrBanku")]
        [Required(ErrorMessage = "Nr banku - wymagane pole")]
        [StringLength(64)]
        public String NrBanku { get; set; }
    }
}
