using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace Magazyn.Domain.Entities
{
    public class Sale
    {
        [HiddenInput(DisplayValue = false)]
        public int SaleID { get; set; }

        [Display(Name = "ID użytkownika")]
        public int LoginID { get; set; }

        [Display(Name = "ID zamówienia")]
        public int OrderID { get; set; }

        [Display(Name = "ID produktu")]
        public int ProductID { get; set; }

        [Display(Name = "Nazwa produktu")]
        public string ProductName { get; set; }

        [Display(Name = "Ilość")]
        public int Quantity { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Proszę podać dodatnią cenę.")]
        [Display(Name = "Za sztukę")]
        public decimal Price { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Proszę podać dodatnią cenę.")]
        [Display(Name = "Razem")]
        public decimal TotalAmount { get; set; }

        [Display(Name = "Kupno/Sprzedaż")]
        public string BuySell { get; set; }

        [Display(Name = "Kompletne")]
        public bool Complete { get; set; }

        [Display(Name = "Data wykonania")]
        public DateTime Data { get; set; }
    }
}
