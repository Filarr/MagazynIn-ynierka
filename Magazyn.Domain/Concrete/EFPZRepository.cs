using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magazyn.Domain.Abstract;
using Magazyn.Domain.Entities;

namespace Magazyn.Domain.Concrete
{
    public class EFPZRepository : IPZRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<PZ> PZs
        {
            get { return context.PZs; }
        }

        public void SavePZ(PZ przychodzewnetrzny)
        {
            if (przychodzewnetrzny.PZID == 0)
            {
                context.PZs.Add(przychodzewnetrzny);
                context.SaveChanges();
            }
        }
    }
}
