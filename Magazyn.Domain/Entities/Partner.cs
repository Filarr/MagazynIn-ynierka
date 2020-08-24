using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Magazyn.Domain.Entities
{
    public class Partner
    {
        [HiddenInput(DisplayValue = false)]
        public int PartnerID { get; set; }

        [Required(ErrorMessage = "Proszę podać nazwę firmy.")]
        [Display(Name = "Nazwa")]
        public string Name { get; set; }

        public byte[] PartnerImageData { get; set; }
        public string PartnerImageMimeType { get; set; }

    }
}
