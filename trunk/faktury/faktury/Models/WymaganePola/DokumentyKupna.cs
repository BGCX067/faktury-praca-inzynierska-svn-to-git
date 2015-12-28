using System;
using System.Data.Objects.DataClasses;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.ComponentModel;

namespace faktury.Models
{
    [MetadataType(typeof(DokumentyKupnaMetadata))]
    public partial class DokumentyKupna : EntityObject
    {
        [Bind(Exclude = "DokumentKupnaID")]
        public class DokumentyKupnaMetadata
        {
            public int DokumentKupnaID { get; set; }

            [DisplayName("NrDokumentu")]
            [Required(ErrorMessage = "Nr dokumentu - wymagane pole")]
            [StringLength(64)]
            public String NrDokumentu { get; set; }

            [ScaffoldColumn(false)]
            [DataType(DataType.Date)]
            [DisplayName("Data Wystawienia:")]
            [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
            public System.DateTime DataWystawienia { get; set; }

            [ScaffoldColumn(false)]
            [DataType(DataType.Date)]
            [DisplayName("Data Sprzedaży:")]
            [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
            public System.DateTime DataSprzedazy { get; set; }

            public int DostawcaID { get; set; }

            public int FormaPlatnosciID { get; set; }

            [ScaffoldColumn(false)]
            [DataType(DataType.Date)]
            [DisplayName("Termin płatności:")]
            [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
            public System.DateTime TerminPlatnosci { get; set; }
        }
    }
}