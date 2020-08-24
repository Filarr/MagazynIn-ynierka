using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magazyn.Domain.Abstract;
using Magazyn.Domain.Entities;

namespace Magazyn.Domain.Concrete
{
    public class EFPWRepository : IPWRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<PW> PWs
        {
            get { return context.PWs; }
        }

        public void SavePW(PW przychodwewnetrzny)
        {
            if (przychodwewnetrzny.PWID == 0)
            {
                context.PWs.Add(przychodwewnetrzny);
                context.SaveChanges();
            }
        }
    }
}
