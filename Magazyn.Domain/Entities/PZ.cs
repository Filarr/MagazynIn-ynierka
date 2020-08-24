using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Magazyn.Domain.Entities
{
    public class PZ
    {
        [HiddenInput(DisplayValue = false)]
        public int PZID { get; set; }

        [Display(Name = "Miesiac")]
        public int Miesiac { get; set; }

        [Display(Name = "Rok")]
        public int Rok { get; set; }

        [Display(Name = "Lista produktów")]
        public string Produkt { get; set; }

        [Display(Name = "Ilość")]
        public int Ilosc { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Proszę podać dodatnią cenę.")]
        [Display(Name = "Cena")]
        public decimal Cena { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Proszę podać dodatnią cenę.")]
        [Display(Name = "Cena")]
        public decimal CenaCalkowita { get; set; }

        [Display(Name = "Data wystawienia")]
        public DateTime DataWystawienia { get; set; }

        [Display(Name = "Kontahent")]
        public string Kontrahent { get; set; }

        [Display(Name = "Adres")]
        public string Adres { get; set; }

        [Display(Name = "Miasto")]
        public string Miasto { get; set; }

        [Display(Name = "Kod")]
        public string KodPocztowy { get; set; }

        [Display(Name = "Wystawiający dokument")]
        public string Wystawiajacy { get; set; }

        [Display(Name = "Magazyn")]
        public string Magazyn { get; set; }
    }
}
