using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Magazyn.Domain.Entities
{
    public class Zamowienie
    {
        [HiddenInput(DisplayValue = false)]
        public int ZamowienieID { get; set; }

        [Display(Name = "ID użytkownika")]
        public int LoginID { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Proszę podać dodatnią cenę.")]
        [Display(Name = "Kwota Całkowita")]
        public decimal Cena { get; set; }

        [Display(Name = "Zakończone")]
        public bool Ended { get; set; }

        [Display(Name = "Kompletne")]
        public bool Complete { get; set; }

        [Display(Name = "Data zamówienia")]
        public DateTime Data { get; set; }
    }
}
