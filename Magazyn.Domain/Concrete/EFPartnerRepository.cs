using Magazyn.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magazyn.Domain.Entities;


namespace Magazyn.Domain.Concrete
{
    public class EFPartnerRepository : IPartnerRepository
    {
        private EFDbContext context = new EFDbContext();
        public IEnumerable<Partner> Partners
        {
            get { return context.Partners; }
        }

        public void SavePartner(Partner partner)
        {
            if (partner.PartnerID == 0)
            {
                context.Partners.Add(partner);
            }
            else
            {
                Partner dbEntry = context.Partners.Find(partner.PartnerID);
                if (dbEntry != null)
                {
                    dbEntry.Name = partner.Name;
                    dbEntry.PartnerImageData = partner.PartnerImageData;
                    dbEntry.PartnerImageMimeType = partner.PartnerImageMimeType;
                }
            }
            context.SaveChanges();
        }
        public Partner DeletePartner(int partnerID)
        {
            Partner dbEntry = context.Partners.Find(partnerID); if (dbEntry != null)
            {
                context.Partners.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
