using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magazyn.Domain.Abstract;
using Magazyn.Domain.Entities;

namespace Magazyn.Domain.Concrete
{
    public class EFSetProductRepository : ISetProductRepository
    {
        private EFDbContext context = new EFDbContext();
        public IEnumerable<SetProduct> SetProducts
        {
            get { return context.SetProducts; }
        }

        public void SaveSetProduct(SetProduct zestaw)
        {
                context.SetProducts.Add(zestaw);
                context.SaveChanges();
        }

        public SetProduct DeleteSetProduct(int setID)
        {
            SetProduct dbEntry = context.SetProducts.Find(setID); if (dbEntry != null)
            {
                context.SetProducts.Remove(dbEntry);
                context.SaveChanges();
            }

            return dbEntry;
        }
    }
}
