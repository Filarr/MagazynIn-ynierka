using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magazyn.Domain.Abstract;
using Magazyn.Domain.Entities;

namespace Magazyn.Domain.Concrete
{
    public class EFProductNameRepository : IProductNameRepository
    {
        private EFDbContext context = new EFDbContext();
        public IEnumerable<ProductName> ProductNames
        {
            get { return context.ProductNames; }
        }

        public void SaveProductName(ProductName productname)
        {
            if (productname.ProductNameID == 0)
            {
                context.ProductNames.Add(productname);
            }
            else
            {
                ProductName dbEntry = context.ProductNames.Find(productname.ProductNameID);
                if (dbEntry != null)
                {
                    dbEntry.Name = productname.Name;
                    dbEntry.Description = productname.Description;
                    dbEntry.Category = productname.Category;
                    dbEntry.ImageData = productname.ImageData;
                    dbEntry.ImageMimeType = productname.ImageMimeType;
                    dbEntry.CategoryID = productname.CategoryID;
                }
            }
            context.SaveChanges();
        }
        public ProductName DeleteProductName(int productnameID)
        {
            ProductName dbEntry = context.ProductNames.Find(productnameID); if (dbEntry != null)
            {
                context.ProductNames.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
