using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Magazyn.Domain.Entities
{
    public class RW
    {
        [HiddenInput(DisplayValue = false)]
        public int RWID { get; set; }

        [Display(Name = "Miesiac")]
        public int Miesiac { get; set; }

        [Display(Name = "Rok")]
        public int Rok { get; set; }

        [Display(Name = "Lista produktów")]
        public string Produkty { get; set; }

        [Display(Name = "Data wystawienia")]
        public DateTime DataWystawienia { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Proszę podać dodatnią cenę.")]
        [Display(Name = "Cena")]
        public decimal CenaCalkowita { get; set; }

        [Display(Name = "Wystawiający dokument")]
        public string Wystawiajacy { get; set; }
    }
}
