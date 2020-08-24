using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magazyn.Domain.Abstract;
using Magazyn.Domain.Entities;

namespace Magazyn.Domain.Concrete
{
    public class EFSaleRepository : ISaleRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Sale> Sales
        {
            get { return context.Sales; }
        }

        public void SaveSale(Sale Sale)
        {
            if (Sale.SaleID == 0)
            {
                context.Sales.Add(Sale);
            }
            else
            {
                Sale dbEntry = context.Sales.Find(Sale.OrderID);
                if (dbEntry != null)
                {
                    dbEntry.BuySell = Sale.BuySell;
                    dbEntry.Complete = Sale.Complete;
                    dbEntry.Data = Sale.Data;
                    dbEntry.LoginID = Sale.LoginID;
                    dbEntry.Price = Sale.Price;
                    dbEntry.ProductID = Sale.ProductID;
                    dbEntry.ProductName = Sale.ProductName;
                    dbEntry.Quantity = Sale.Quantity;
                    dbEntry.TotalAmount = Sale.TotalAmount;
                }
            }
            context.SaveChanges();
            
        }
    }
}
