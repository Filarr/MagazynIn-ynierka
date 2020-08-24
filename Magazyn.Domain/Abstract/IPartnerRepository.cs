using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magazyn.Domain.Entities;


namespace Magazyn.Domain.Abstract
{
    public interface IPartnerRepository
    {
        IEnumerable<Partner> Partners { get; }

        void SavePartner(Partner partner);

        Partner DeletePartner(int partnerID);
    }
}
