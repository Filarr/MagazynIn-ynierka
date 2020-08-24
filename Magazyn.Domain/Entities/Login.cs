using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Magazyn.Domain.Entities
{
    public class Login
    {
        [HiddenInput(DisplayValue = false)]
        public int LoginID { get; set; }

        [Required(ErrorMessage = "Proszę podać inną nazwę użytkownika.")]
        [Display(Name = "Login")]
        public string User { get; set; }

    
        [Required(ErrorMessage = "Proszę podać hasło.")]
        [Display(Name = "Hasło")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Proszę podać E-mail.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Proszę podać imie.")]
        [Display(Name = "Imie")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Proszę podać nazwisko.")]
        [Display(Name = "Nazwisko")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Proszę podać numer telefonu.")]
        [Display(Name = "Numer Telefonu")]
        public string Phone { get; set; }

        [Display(Name = "Administrator")]
        public bool Admin { get; set; }

        [Display(Name = "Aktywowane?")]
        public bool Activate { get; set; }

        
    }
}
