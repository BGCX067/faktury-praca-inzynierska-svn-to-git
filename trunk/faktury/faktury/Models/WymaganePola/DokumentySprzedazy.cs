using System.Data.Objects.DataClasses;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.ComponentModel;

namespace faktury.Models
{
    [MetadataType(typeof(DokumentySprzedazyMetadata))]
    public partial class DokumentySprzedazy : EntityObject
    {
        [Bind(Exclude = "DokumentSprzedazyID")]
        public class DokumentySprzedazyMetadata
        {
            public int DokumentSprzedazyID { get; set; }

            [DisplayName("Typ dokumentu: ")]
            [StringLength(16)]
            public string TypDokumentu { get; set; }

            [DisplayName("Nr")]
            [StringLength(32)]
            public string NrDokumentu { get; set; }

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

            public int KlientID { get; set; }

            public int MiejscowoscID { get; set; }

            public int KrajID { get; set; }

            public int BankID { get; set; }

            public int FormaPlatnosciID { get; set; }

            [ScaffoldColumn(false)]
            [DataType(DataType.Date)]
            [DisplayName("Termin płatności:")]
            [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
            public System.DateTime TerminPlatnosci { get; set; }
        }
    }
}