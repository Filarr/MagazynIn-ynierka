﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Magazyn.Domain.Entities
{
    public class Product
    {
        [HiddenInput(DisplayValue = false)]
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Proszę podać nazwę produktu.")]
        [Display(Name = "Nazwa")]
        public string Name { get; set; }

        [DataType(DataType.MultilineText), Display(Name = "Opis")]
        [Required(ErrorMessage = "Proszę podać opis.")]
        public string Description { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Proszę podać dodatnią cenę.")]
        [Display(Name = "Cena")]
        public decimal Price {get; set; }

        [Required(ErrorMessage = "Proszę określić kategorię.")]
        [Display(Name = "Kategoria")]
        public string Category { get; set; }

        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }

        [Display(Name = "Razem")]
        public int Total { get; set; }

        [Display(Name = "Magazyn 1")]
        public int Warehouse1 { get; set; }

        [Display(Name = "Magazyn 2")]
        public int Warehouse2 { get; set; }
    }
}
