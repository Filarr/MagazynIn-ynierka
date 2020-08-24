using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Magazyn.Domain.Entities;

namespace Magazyn.Domain.Concrete
{
    public class EFDbContext : DbContext {
        public DbSet<Product> Products { get; set; }
        public DbSet<Login> Logins { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Sale> Sales { get; set; }

        public DbSet<Partner> Partners { get; set; }

        public DbSet<MM> MMs { get; set; }

        public DbSet<RZ> RZs { get; set; }

        public DbSet<RW> RWs { get; set; }
 
        public DbSet<PW> PWs { get; set; }

        public DbSet<PZ> PZs { get; set; }

        public DbSet<Set> Sets { get; set; }




    }
}
