using System;
using System.Data.Objects.DataClasses;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.ComponentModel;

namespace faktury.Models
{
    [MetadataType(typeof(DostawcyMetadata))]
    public partial class Dostawcy : EntityObject
    {
        [Bind(Exclude = "DostawcaID")]
        public class DostawcyMetadata
        {
            public int DostawcaID { get; set; }

            [DisplayName("Imię")]
            [StringLength(16)]
            public String Imie { get; set; }

            [DisplayName("Nazwisko")]
            [StringLength(32)]
            public String Nazwisko { get; set; }

            [DisplayName("Nazwa")]
            [StringLength(32)]
            public String Nazwa { get; set; }

            [DisplayName("Ulica")]
            [StringLength(64)]
            public String Ulica { get; set; }

            [DisplayName("NrDomu")]
            [Required(ErrorMessage = "Nr domu - wymagane pole")]
            [StringLength(8)]
            public String NrDomu { get; set; }

            [DisplayName("NrMieszkania")]
            [StringLength(8)]
            public String NrMieszkania { get; set; }

            public int KodPocztowyID { get; set; }

            [DisplayName("Imię do kontaktu")]
            [StringLength(16)]
            public String ImieKontakt { get; set; }

            [DisplayName("Nazwisko do Kontaktu")]
            [StringLength(32)]
            public String NazwiskoKontakt { get; set; }

            [DisplayName("Ulica do kontaktu")]
            [StringLength(64)]
            public String UlicaKontakt { get; set; }

            [DisplayName("Nr domu do Kontaktu")]
            [StringLength(8)]
            public String NrDomuKontakt { get; set; }

            [DisplayName("Nr mieszkania do Kontaktu")]
            [StringLength(8)]
            public String NrMieszkaniaKontakt { get; set; }

            public int KodPocztowyKontaktID { get; set; }

            [DisplayName("Nip")]
            [StringLength(16)]
            public String Nip { get; set; }

            [DisplayName("Telefon")]
            [StringLength(16)]
            public String Telefon { get; set; }

            [DisplayName("Telefon2")]
            [StringLength(16)]
            public String Telefon2 { get; set; }

            [DisplayName("Bank")]
            [StringLength(16)]
            public String Bank { get; set; }

            [DisplayName("NrBanku")]
            [StringLength(32)]
            public String NrBanku { get; set; }

            [RegularExpression(@"^([\w\!\#$\%\&\'\*\+\-\/\=\?\^\`{\|\}\~]+\.)*[\w\!\#$\%\&\'\*\+\-\/\=\?\^\`{\|\}\~]+@((((([a-zA-Z0-9]{1}[a-zA-Z0-9\-]{0,62}[a-zA-Z0-9]{1})|[a-zA-Z])\.)+[a-zA-Z]{2,6})|(\d{1,3}\.){3}\d{1,3}(\:\d{1,5})?)$",
            ErrorMessage = "Wprowadź poprawny format maila")]
            [StringLength(128)]
            public String Email { get; set; }
        }
    }
}