using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Magazyn.Domain.Entities;

namespace Magazyn.WebUI.Models
{
    public class DodajProduktView
    {
        public Product product { get; set; }
        public PZ przychodZewnetrzny { get; set; }
        public Set zestaw { get; set; }

        public IEnumerable<Product> Products { get; set; }
    }
}