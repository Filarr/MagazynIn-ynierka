using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Magazyn.Domain.Entities;

namespace Magazyn.WebUI.Models
{
    public class LoginListViewModel
    {
        public IEnumerable<Login> Logins { get; set; }
    }
}