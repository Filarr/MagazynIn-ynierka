using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Magazyn.Domain.Entities
{
    public class SetProduct
    {
        public int SetProductID { get; set; }

        public int SetID { get; set; }

        public int ProductNameID { get; set; }

    }
}
