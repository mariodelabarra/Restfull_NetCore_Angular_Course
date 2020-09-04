using MAB.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAB.BusinessLogic.Interfaces
{
    public interface IOrderLogic
    {
        IEnumerable<OrderList> GetPaginatedOrder(int page, int rows);
    }
}
