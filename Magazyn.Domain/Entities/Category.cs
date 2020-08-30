using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Magazyn.Domain.Entities
{
    public class Category
    {
        public int CategoryID { get; set; }

        [Display(Name = "Nazwa")]
        public string Name { get; set; }
    }
}
