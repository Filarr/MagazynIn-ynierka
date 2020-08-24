using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magazyn.Domain.Abstract;
using Magazyn.Domain.Entities;

namespace Magazyn.Domain.Concrete
{
    public class EFSetRepository : ISetRepository
    {
        private EFDbContext context = new EFDbContext();
        public IEnumerable<Set> Sets
        {
            get { return context.Sets; }
        }

        public void SaveSet(Set zestaw)
        {
            if (zestaw.SetID == 0)
            {
                context.Sets.Add(zestaw);
                context.SaveChanges();
            }
        }

        public Set DeleteZestaw(int setID)
        {
            Set dbEntry = context.Sets.Find(setID); if (dbEntry != null)
            {
                context.Sets.Remove(dbEntry);
                context.SaveChanges();
            }

            return dbEntry;
        }
    }
}
