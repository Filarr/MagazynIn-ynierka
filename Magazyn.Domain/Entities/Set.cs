using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Magazyn.Domain.Entities
{
    public class Set
    {
        [HiddenInput(DisplayValue = false)]
        public int SetID { get; set; }

        [Display(Name = "Nazwa zestawu")]
        public string Name { get; set; }

        [Display(Name = "Produkt 1")]
        public string ProduktName1 { get; set; }

        [Display(Name = "Produkt 2")]
        public string ProduktName2 { get; set; }

        [Display(Name = "Produkt 3")]
        public string ProduktName3 { get; set; }

        [Display(Name = "Produkt 4")]
        public string ProduktName4 { get; set; }

        [Display(Name = "Produkt 5")]
        public string ProduktName5 { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Proszę podać dodatnią cenę.")]
        [Display(Name = "Cena")]
        public decimal Cena{ get; set; }

        public int ProductID { get; set; }
    }
}
