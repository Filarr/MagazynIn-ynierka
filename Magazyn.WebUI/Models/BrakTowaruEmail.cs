using Magazyn.Domain.Entities;
using Postal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Magazyn.WebUI.Models
{
    public class BrakTowaruEmail : Email
    {
        [Required(ErrorMessage = "Proszę nazwę produktu.")]
        [Display(Name = "Nazwa Produktu")]
        public string Name { get; set; }
        

        [Required(ErrorMessage = "Proszę podać ilość.")]
        [Display(Name = "Ilość produktu")]
        public string Ilość { get; set; }

        
        [Display(Name = "Nazwa kontrahenta")]
        public string Kontrahent { get; set; }

        
        [Display(Name = "Email")]
        public string emaill { get; set; }

    }
}