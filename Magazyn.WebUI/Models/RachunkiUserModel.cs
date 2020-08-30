using Magazyn.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Magazyn.WebUI.Models
{
    public class RachunkiUserModel
    {
        public IEnumerable<Rezerwacje> Sales { get; set; }
    }
}