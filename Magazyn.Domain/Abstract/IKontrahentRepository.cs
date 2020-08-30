using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magazyn.Domain.Entities;

namespace Magazyn.Domain.Abstract
{
    public interface IKontrahentRepository
    {
        IEnumerable<Kontrahent> Kontrahents { get; }

        void SaveKontrahent(Kontrahent kontrahent);

        Kontrahent DeleteKontrahent(int kontrahentID);
    }
}
