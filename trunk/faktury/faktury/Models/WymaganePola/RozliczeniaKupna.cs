using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.ComponentModel;

namespace faktury.Models
{
    [MetadataType(typeof(RozliczeniaKupnaMetadata))]
    public partial class RozliczeniaKupna
    {
        [Bind(Exclude = "RozliczenieKupnaID")]
        public class RozliczeniaKupnaMetadata 
        { 
            public int RozliczenieKupnaID { get; set; }
            public int DokumentKupnaID { get; set; }

            [ScaffoldColumn(false)]
            [Required(ErrorMessage = "Kwota jest wymagana")]
            [Range(0.01, 999999.00,
                ErrorMessage = "Cena musi być między 0.01, a 9999999.00")]
            public decimal Kwota { get; set; }

            [ScaffoldColumn(false)]
            [DataType(DataType.Date)]
            [DisplayName("Data zapłaty ")]
            [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
            public System.DateTime DataZaplaty { get; set; }
        }
    }
}