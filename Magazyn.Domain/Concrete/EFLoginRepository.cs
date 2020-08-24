using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magazyn.Domain.Abstract;
using Magazyn.Domain.Entities;

namespace Magazyn.Domain.Concrete
{
    public class EFLoginRepository : ILoginRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Login> Logins
        {
            get { return context.Logins; }
        }

        public void SaveLogin(Login login)
        {
            if (login.LoginID == 0)
            {
                context.Logins.Add(login);
            }
            else
            {
                Login dbEntry = context.Logins.Find(login.LoginID);
                if (dbEntry != null)
                {
                    dbEntry.User = login.User;
                    dbEntry.Password = login.Password;
                    dbEntry.Email = login.Email;
                    dbEntry.Name = login.Name;
                    dbEntry.Surname = login.Surname;
                    dbEntry.Phone = login.Phone;
                    dbEntry.Admin = login.Admin;
                    dbEntry.Activate = login.Activate;
                }
            }
            context.SaveChanges();
        }

        public void Active(Login login)
        {
            Login dbEntry = context.Logins.Find(login.LoginID);
            if (dbEntry != null)
            {
                dbEntry.Activate = true;
            }
            context.SaveChanges();
        }

        public void DeActive(Login login)
        {
            Login dbEntry = context.Logins.Find(login.LoginID);
            if (dbEntry != null)
            {
                dbEntry.Activate = false;
            }
            context.SaveChanges();
        }

        public Login DeleteLogin(int loginID)
        {
            Login dbEntry = context.Logins.Find(loginID); if (dbEntry != null)
            {
                context.Logins.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
