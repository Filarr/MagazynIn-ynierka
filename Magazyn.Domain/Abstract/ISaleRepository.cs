﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magazyn.Domain.Entities;


namespace Magazyn.Domain.Abstract
{
    public interface ISaleRepository
    {
        IEnumerable<Sale> Sales { get; }
        void SaveSale(Sale Sale);
    }
}
