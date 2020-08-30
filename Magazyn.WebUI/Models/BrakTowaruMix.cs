using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Magazyn.Domain.Entities;

namespace Magazyn.WebUI.Models
{
    public class BrakTowaruMix
    {
        public List<SelectListItem> listItems = new List<SelectListItem>();

        public BrakTowaruEmail brakTowaru = new BrakTowaruEmail();

    }
}