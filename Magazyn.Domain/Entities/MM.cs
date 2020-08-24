using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Magazyn.Domain.Entities
{
    public class MM
    {
        [HiddenInput(DisplayValue = false)]
        public int MMID { get; set; }

        [Display(Name = "Miesiac")]
        public int Miesiac { get; set; }

        [Display(Name = "Rok")]
        public int Rok { get; set; }

        [Display(Name = "Data wystawienia")]
        public DateTime DataWystawienia { get; set; }

       

        [Display(Name = "Wystawiający dokument")]
        public string Wystawiajacy { get; set; }

        [Display(Name = "Wystawiający dokument")]
        public string MagazynWydajacy { get; set; }

        [Display(Name = "Wystawiający dokument")]
        public string MagazynPrzyjmujacy { get; set; }

        [Display(Name = "Nazwa Produktu")]
        public string NazwaProduktu { get; set; }

        [Display(Name = "Ilość")]
        public int Ilosc { get; set; }

        
    }
}
