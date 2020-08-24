using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Postal;

namespace Magazyn.WebUI.Models
{
    public class FormularzEmail : Email
    {
        public string To {get; set; }

        [Required(ErrorMessage = "Proszę podać E-mail.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Proszę podać imie.")]
        [Display(Name = "Imie")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Proszę podać nazwisko.")]
        [Display(Name = "Nazwisko")]
        public string Surname { get; set; }

        public string Message { get; set; }

    }
}