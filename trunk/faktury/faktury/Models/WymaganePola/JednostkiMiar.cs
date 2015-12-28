using System;
using System.Data.Objects.DataClasses;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.ComponentModel;

namespace faktury.Models
{
    [MetadataType(typeof(JednostkiMiarMetadata))]
    public partial class JednostkiMiar : EntityObject
    {
        [Bind(Exclude = "JednostkaMiarID")]
        public class JednostkiMiarMetadata
        {
            public int JednostkaMiarID { get; set; }

            [DisplayName("Nazwa")]
            [Required(ErrorMessage = "Nazwa - wymagane pole")]
            [StringLength(16)]
            public String Nazwa { get; set; }
        }
    }
}
  
