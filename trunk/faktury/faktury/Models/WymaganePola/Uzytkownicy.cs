using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace faktury.Models
{
    [MetadataType(typeof(UzytkownicyMetadata))]
    public partial class Uzytkownicy
    {
        [Bind(Exclude = "UzytkownikID")]
        public class UzytkownicyMetadata
        {
            public int UzytkownikID { get; set; }

            [DisplayName("Imię")]
            [Required(ErrorMessage = "Imię - wymagane pole")]
            [StringLength(16)]
            public String Imie { get; set; }

            [DisplayName("Nazwisko")]
            [Required(ErrorMessage = "Nazwisko - wymagane pole")]
            [StringLength(32)]
            public String Nazwisko { get; set; }

            [DisplayName("Ulica")]
            [StringLength(64)]
            public String Ulica { get; set; }

            [DisplayName("Nr domu")]
            [StringLength(8)]
            public String NrDomu { get; set; }

            [DisplayName("Nr mieszkania")]
            [StringLength(8)]
            public String NrMieszkania { get; set; }

            public int KodPocztowyID { get; set; }

            [DisplayName("Nip")]
            [StringLength(16)]
            public String Nip { get; set; }

            [DisplayName("Pesel")]
            [StringLength(16)]
            public String Pesel { get; set; }

            [RegularExpression(@"^([\w\!\#$\%\&\'\*\+\-\/\=\?\^\`{\|\}\~]+\.)*[\w\!\#$\%\&\'\*\+\-\/\=\?\^\`{\|\}\~]+@((((([a-zA-Z0-9]{1}[a-zA-Z0-9\-]{0,62}[a-zA-Z0-9]{1})|[a-zA-Z])\.)+[a-zA-Z]{2,6})|(\d{1,3}\.){3}\d{1,3}(\:\d{1,5})?)$",
           ErrorMessage = "Wprowadź poprawny format maila")]
            [StringLength(128)]
            public String Email { get; set; }

            [DisplayName("Login")]
            [StringLength(16)]
            [Required(ErrorMessage = "Login - wymagane pole")]
            public String Login { get; set; }
        }
    }
}