using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Magazyn.WebUI.Models
{
    public class LoginViewModel
    {
        public int userID { get; set; }

        [Required(ErrorMessage = "Proszę podać inną nazwę użytkownika.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Proszę podać hasło.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string LoginErrorMessage { get; set; }
    }
}