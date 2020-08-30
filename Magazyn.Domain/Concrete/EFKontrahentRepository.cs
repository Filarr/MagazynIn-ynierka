using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magazyn.Domain.Abstract;
using Magazyn.Domain.Entities;

namespace Magazyn.Domain.Concrete
{
    public class EFKontrahentRepository : IKontrahentRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Kontrahent> Kontrahents
        {
            get { return context.Kontrahents; }
        }

        public void SaveKontrahent(Kontrahent kontrahent)
        {
            if (kontrahent.KontrahentID == 0)
            {
                context.Kontrahents.Add(kontrahent);
            }
            else
            {
                Kontrahent dbEntry = context.Kontrahents.Find(kontrahent.KontrahentID);
                if (dbEntry != null)
                {
                    dbEntry.NazwaKontrahenta = kontrahent.NazwaKontrahenta;
                    dbEntry.Adres = kontrahent.Adres;
                    dbEntry.Miasto = kontrahent.Miasto;
                    dbEntry.KodPocztowy = kontrahent.KodPocztowy;
                    dbEntry.NumerTelefonu = kontrahent.NumerTelefonu;
                    dbEntry.Email = kontrahent.Email;
                    dbEntry.ImageData = kontrahent.ImageData;
                    dbEntry.ImageMimeType = kontrahent.ImageMimeType;
                }
            }
            context.SaveChanges();
        }

        public Kontrahent DeleteKontrahent(int kontrahentID)
        {
            Kontrahent dbEntry = context.Kontrahents.Find(kontrahentID); if (dbEntry != null)
            {
                context.Kontrahents.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
