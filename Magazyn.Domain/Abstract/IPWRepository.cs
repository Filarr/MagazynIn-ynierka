﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magazyn.Domain.Entities;

namespace Magazyn.Domain.Abstract
{
    public interface IPWRepository
    {
        IEnumerable<PW> PWs { get; }
        void SavePW(PW przychodwewnetrzny);
    }
}
