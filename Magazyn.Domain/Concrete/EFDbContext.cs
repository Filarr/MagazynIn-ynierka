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

        public DbSet<ProductName> ProductNames { get; set; }

        public DbSet<Login> Logins { get; set; }
        public DbSet<Category> Categorys { get; set; }

        public DbSet<Zamowienie> Zamowienies { get; set; }

        public DbSet<Rezerwacje> Rezerwacjes { get; set; }

        public DbSet<Partner> Partners { get; set; }

        public DbSet<RZ> RZs { get; set; }

        public DbSet<RW> RWs { get; set; }
 
        public DbSet<PW> PWs { get; set; }

        public DbSet<PZ> PZs { get; set; }

        public DbSet<Set> Sets { get; set; }

        public DbSet<Kontrahent> Kontrahents { get; set; }

        public DbSet<SetProduct> SetProducts { get; set; }


    }
}
