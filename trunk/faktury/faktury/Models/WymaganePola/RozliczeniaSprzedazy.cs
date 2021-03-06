﻿using System.Data.Objects.DataClasses;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.ComponentModel;

namespace faktury.Models
{
    [MetadataType(typeof(RozliczeniaSprzedazyyMetadata))]
    public partial class RozliczeniaSprzedazy : EntityObject
    {
        [Bind(Exclude = "RozliczenieSprzedazyID")]
        public class RozliczeniaSprzedazyyMetadata
        {
            public int RozliczenieSprzedazyID { get; set; }
            public int DokumentSprzedazyID { get; set; }

            [ScaffoldColumn(false)]
            [Required(ErrorMessage = "Kwota jest wymagana")]
            [Range(0.01, 999999.00,
                ErrorMessage = "Cena musi być między 0.01, a 9999999.00")]
            public decimal Kwota { get; set; }

            [ScaffoldColumn(false)]
            [DataType(DataType.Date)]
            [DisplayName("Data wpłaty ")]
            [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
            public System.DateTime DataWplaty { get; set; }
        }
    }
}