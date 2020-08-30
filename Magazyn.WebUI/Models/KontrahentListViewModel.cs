using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Magazyn.Domain.Entities;

namespace Magazyn.WebUI.Models
{
    public class KontrahentListViewModel
    {
        public IEnumerable<Kontrahent> Kontrahents { get; set; }
    }
}