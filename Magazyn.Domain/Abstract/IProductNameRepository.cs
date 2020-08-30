using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magazyn.Domain.Entities;

namespace Magazyn.Domain.Abstract
{
    public interface IProductNameRepository
    {
        IEnumerable<ProductName> ProductNames { get; }

        void SaveProductName(ProductName productname);

        ProductName DeleteProductName(int productnameID);

        
    }
}
