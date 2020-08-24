
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magazyn.Domain.Abstract;
using Magazyn.Domain.Entities;

namespace Magazyn.Domain.Concrete
{
    public class EFOrderRepository : IOrderRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Order> Orders
        {
            get { return context.Orders; }
        }

        public void SaveOrder(Order order)
        {
            if (order.OrderID == 0)
            {
                context.Orders.Add(order);
            }
            else
            {
                Order dbEntry = context.Orders.Find(order.OrderID);
                if (dbEntry != null)
                {
                    dbEntry.Amount = order.Amount;
                    dbEntry.Complete = order.Complete;
                    dbEntry.Data = order.Data;
                    dbEntry.Ended = order.Ended;
                    dbEntry.LoginID = order.LoginID;

                }
            }
            context.SaveChanges();
        }

    }
}
