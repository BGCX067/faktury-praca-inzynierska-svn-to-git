using System;
using System.Data.Objects.DataClasses;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.ComponentModel;

namespace faktury.Models
{
    [MetadataType(typeof(MiejscowosciMetadata))]
    public partial class Miejscowosci : EntityObject
    {
        [Bind(Exclude = "MiejscowoscID")]
        public class MiejscowosciMetadata
        {
            public int MiejscowoscID { get; set; }

            [DisplayName("Nazwa")]
            [Required(ErrorMessage = "Nazwa - wymagane pole")]
            [StringLength(64)]
            public String Nazwa { get; set; }

            public int KrajID { get; set; }
        }
    }
}
