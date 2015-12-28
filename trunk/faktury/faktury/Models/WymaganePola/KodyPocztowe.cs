using System;
using System.Data.Objects.DataClasses;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.ComponentModel;

namespace faktury.Models
{
    [MetadataType(typeof(KodyPocztoweMetadata))]
    public partial class KodyPocztowe : EntityObject
    {
        [Bind(Exclude = "KodPocztowyID")]
        public class KodyPocztoweMetadata
        {
            public int KodPocztowyID { get; set; }

            [DisplayName("Kod")]
            [Required(ErrorMessage = "Nazwa - wymagane pole")]
            [RegularExpression(@"[0-9]{2}-[0-9]{3}", ErrorMessage = "Wprowadź poprawny format kodu pocztowego: XX-XXX")]
            [StringLength(8)]
            public String Kod { get; set; }

            public int MiejscowoscID { get; set; }
        }
    }
}


