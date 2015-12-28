using System;
using System.Data.Objects.DataClasses;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.ComponentModel;

namespace faktury.Models
{
    [MetadataType(typeof(DanePrzedsiebiorstwaMetadata))]
    public partial class DanePrzedsiebiorstwa : EntityObject
    {
        [Bind(Exclude = "DanePrzedsiebiorstwaID")]
        public class DanePrzedsiebiorstwaMetadata
        {
            public int DanePrzedsiebiorstwaID { get; set; }

            [DisplayName("Nazwa")]
            [StringLength(32)]
            public String Nazwa { get; set; }

            [DisplayName("Imię")]
            [StringLength(16)]
            public String Imie { get; set; }

            [DisplayName("Nazwisko")]
            [StringLength(32)]
            public String Nazwisko { get; set; }

            [DisplayName("Ulica")]
            [StringLength(64)]
            public String Ulica { get; set; }

            [DisplayName("Nr domu")]
            [Required(ErrorMessage = "Nr domu - wymagane pole")]
            [StringLength(8)]
            public String NrDomu { get; set; }

            [DisplayName("Nr mieszkania")]
            [StringLength(8)]
            public String NrMieszkania { get; set; }

            public int KodPocztowyID { get; set; }
            
            [DisplayName("Ulica do kontaktu")]
            [StringLength(64)]
            public String UlicaKontakt { get; set; }

            [DisplayName("Nr domu do kontaktu")]
            [StringLength(8)]
            public String NrDomuKontakt { get; set; }

            [DisplayName("Nr mieszkania do kontaktu")]
            [StringLength(8)]
            public String NrMieszkaniaKontakt { get; set; }

            public int KodPocztowyKontaktID { get; set; }

            [DisplayName("Nip")]
            [StringLength(16)]
            public String Nip { get; set; }

            [DisplayName("Regon")]
            [StringLength(16)]
            public String Regon { get; set; }

            [DisplayName("Www")]
            [StringLength(128)]
            public String Www { get; set; }

            [DisplayName("Telefon")]
            [StringLength(16)]
            public String Telefon { get; set; }

            [DisplayName("Telefon2")]
            [StringLength(16)]
            public String Telefon2 { get; set; }

            [DisplayName("Fax")]
            [StringLength(16)]
            public String Fax { get; set; }

            [RegularExpression(@"^([\w\!\#$\%\&\'\*\+\-\/\=\?\^\`{\|\}\~]+\.)*[\w\!\#$\%\&\'\*\+\-\/\=\?\^\`{\|\}\~]+@((((([a-zA-Z0-9]{1}[a-zA-Z0-9\-]{0,62}[a-zA-Z0-9]{1})|[a-zA-Z])\.)+[a-zA-Z]{2,6})|(\d{1,3}\.){3}\d{1,3}(\:\d{1,5})?)$",
            ErrorMessage = "Wprowadź poprawny format maila")]
            [StringLength(128)]
            public String Email { get; set; }
        }
    }
}