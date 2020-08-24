using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magazyn.Domain.Abstract;
using Magazyn.Domain.Entities;

namespace Magazyn.Domain.Concrete
{
    public class EFRWRepository : IRWRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<RW> RWs
        {
            get { return context.RWs; }
        }

        public void SaveRW(RW rozchodwewnetrzny)
        {
            if (rozchodwewnetrzny.RWID == 0)
            {
                context.RWs.Add(rozchodwewnetrzny);
                context.SaveChanges();
            }
        }
    }
}
