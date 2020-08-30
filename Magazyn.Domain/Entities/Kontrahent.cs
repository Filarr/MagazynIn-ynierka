using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Magazyn.Domain.Entities
{
    public class Kontrahent
    {
        [HiddenInput(DisplayValue = false)]
        public int KontrahentID { get; set; }

        [Display(Name = "Nazwa")]
        public string NazwaKontrahenta { get; set; }

        [Display(Name = "Adres")]
        public string Adres { get; set; }

        [Display(Name = "Miasto")]
        public string Miasto { get; set; }

        [Display(Name = "Kod pocztowy")]
        public string KodPocztowy { get; set; }

        [Display(Name = "Numer telefonu")]
        public string NumerTelefonu { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
    }
}
