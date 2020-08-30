using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace Magazyn.Domain.Entities
{
    public class Rezerwacje
    {
        [HiddenInput(DisplayValue = false)]
        public int RezerwacjeID { get; set; }

        [Display(Name = "ID zamówienia")]
        public int ZamowienieID { get; set; }

        [Display(Name = "ID produktu")]
        public int ProductID { get; set; }

        [Display(Name = "Ilość")]
        public int Ilosc { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Proszę podać dodatnią cenę.")]
        [Display(Name = "Za sztukę")]
        public decimal Cena { get; set; }

        [Display(Name = "Kompletne")]
        public bool Complete { get; set; }
    }
}
