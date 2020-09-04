using MAB.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAB.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        IEnumerable<OrderList> GetPaginatedOrder(int page, int rows);
    }
}
