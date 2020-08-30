
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magazyn.Domain.Abstract;
using Magazyn.Domain.Entities;

namespace Magazyn.Domain.Concrete
{
    public class EFZamowienieRepository : IZamowienieRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Zamowienie> Zamowienies
        {
            get { return context.Zamowienies; }
        }

        public void SaveZamowienie(Zamowienie zamowienie)
        {
            if (zamowienie.ZamowienieID == 0)
            {
                context.Zamowienies.Add(zamowienie);
            }
            else
            {
                Zamowienie dbEntry = context.Zamowienies.Find(zamowienie.ZamowienieID);
                if (dbEntry != null)
                {
                    dbEntry.Cena = zamowienie.Cena;
                    dbEntry.Complete = zamowienie.Complete;
                    dbEntry.Data = zamowienie.Data;
                    dbEntry.Ended = zamowienie.Ended;
                    dbEntry.LoginID = zamowienie.LoginID;

                }
            }
            context.SaveChanges();
        }

    }
}
