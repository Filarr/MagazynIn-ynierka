﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Magazyn.Domain.Entities;

namespace Magazyn.WebUI.Models
{
    public class CartIndexViewModel
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}