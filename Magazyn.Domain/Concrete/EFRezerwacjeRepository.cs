using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magazyn.Domain.Abstract;
using Magazyn.Domain.Entities;

namespace Magazyn.Domain.Concrete
{
    public class EFRezerwacjeRepository : IRezerwacjeRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Rezerwacje> Rezerwacjes
        {
            get { return context.Rezerwacjes; }
        }

        public void SaveRezerwacje(Rezerwacje Rezerwacje)
        {
            if (Rezerwacje.RezerwacjeID == 0)
            {
                context.Rezerwacjes.Add(Rezerwacje);
            }
            else
            {
                Rezerwacje dbEntry = context.Rezerwacjes.Find(Rezerwacje.ZamowienieID);
                if (dbEntry != null)
                {
                    dbEntry.Complete = Rezerwacje.Complete;
                    dbEntry.Cena = Rezerwacje.Cena;
                    dbEntry.ProductID = Rezerwacje.ProductID;
                    dbEntry.Ilosc = Rezerwacje.Ilosc;
                    dbEntry.ZamowienieID = Rezerwacje.ZamowienieID;
                }
            }
            context.SaveChanges();
            
        }
    }
}
