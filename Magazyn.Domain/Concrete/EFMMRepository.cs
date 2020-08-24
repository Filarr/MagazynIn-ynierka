using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magazyn.Domain.Abstract;
using Magazyn.Domain.Entities;

namespace Magazyn.Domain.Concrete
{
    public class EFMMRepository : IMMRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<MM> MMs
        {
            get { return context.MMs; }
        }

        public void SaveMM(MM przesunieciemagazynowe)
        {
            if (przesunieciemagazynowe.MMID == 0)
            {
                context.MMs.Add(przesunieciemagazynowe);
                context.SaveChanges();
            }
        }
    }
}
