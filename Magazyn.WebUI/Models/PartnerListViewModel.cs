using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Magazyn.Domain.Entities;

namespace Magazyn.WebUI.Models
{
    public class PartnerListViewModel
    {
        public IEnumerable<Partner> Partners { get; set; }
    }
}