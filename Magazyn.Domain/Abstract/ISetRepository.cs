using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magazyn.Domain.Entities;

namespace Magazyn.Domain.Abstract
{
    public interface ISetRepository
    {
        IEnumerable<Set> Sets { get; }
        void SaveSet(Set zestaw);

        Set DeleteZestaw(int setID);
    }

    
}
