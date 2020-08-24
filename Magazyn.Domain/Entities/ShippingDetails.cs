using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Magazyn.Domain.Entities
{
    public class ShippingDetails
    {
        
        public string Name { get; set; }
        
        public string Imie { get; set; }
        
        [Display(Name = "Email")]
        public string Email{ get; set; }

        [Display(Name = "Numer Telefonu")]
        public string Telefon { get; set; }
        
    }
}
