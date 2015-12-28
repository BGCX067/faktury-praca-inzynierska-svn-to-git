using System;
using System.Data.Objects.DataClasses;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.ComponentModel;

namespace faktury.Models
{
    [MetadataType(typeof(FormyPlatnosciMetadata))]
    public partial class FormyPlatnosci : EntityObject
    {
        [Bind(Exclude = "FormaPlatnosciID")]
        public class FormyPlatnosciMetadata
        {
            public int FormaPlatnosciID { get; set; }

            [DisplayName("Nazwa")]
            [Required(ErrorMessage = "Nazwa - wymagane pole")]
            [StringLength(16)]
            public String Nazwa { get; set; }
        }
    }
}