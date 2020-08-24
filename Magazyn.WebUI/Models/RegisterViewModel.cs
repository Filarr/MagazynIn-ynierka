using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Magazyn.WebUI.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Proszę podać nazwę użytkownika.")]
        public string User { get; set; }

        [Required(ErrorMessage = "Proszę podać hasło.")]
        [DataType(DataType.Password)]
        public string Pass { get; set; }

        [Required(ErrorMessage = "Proszę podać imię")]
        [DataType(DataType.Password)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Proszę podać nazwisko")]
        [DataType(DataType.Password)]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Proszę podać E-mail")]
        [DataType(DataType.Password)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Proszę podać Numer Telefonu")]
        [DataType(DataType.Password)]
        public string Phone { get; set; }



    }
}