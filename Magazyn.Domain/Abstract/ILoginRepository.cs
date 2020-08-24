using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magazyn.Domain.Entities;

namespace Magazyn.Domain.Abstract
{
    public interface ILoginRepository
    {
        IEnumerable<Login> Logins { get; }

        void SaveLogin(Login login);
        void Active(Login login);
        void DeActive(Login login);

        Login DeleteLogin(int loginID);
    }


}
