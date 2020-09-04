using MAB.BusinessLogic.Interfaces;
using MAB.Models;
using MAB.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAB.BusinessLogic.Implementations
{
    public class OrderLogic : IOrderLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<OrderList> GetPaginatedOrder(int page, int rows)
        {
            return _unitOfWork.Order.GetPaginatedOrder(page, rows);
        }
    }
}
