using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magazyn.Domain.Abstract;
using Magazyn.Domain.Entities;

namespace Magazyn.Domain.Concrete
{
    public class EFRZRepository : IRZRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<RZ> RZs
        {
            get { return context.RZs; }
        }

        public void SaveRZ(RZ rozchodzewnetrzny)
        {
            if (rozchodzewnetrzny.RZID == 0)
            {
                context.RZs.Add(rozchodzewnetrzny);
                context.SaveChanges();
            }
        }
    }
}
