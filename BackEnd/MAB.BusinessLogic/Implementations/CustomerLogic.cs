using MAB.BusinessLogic.Interfaces;
using MAB.Models;
using MAB.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAB.BusinessLogic.Implementations
{
    public class CustomerLogic : ICustomerLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        public CustomerLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<CustomerList> CustumersPagedList(int page, int rows)
        {
            return _unitOfWork.Customer.CustumersPagedList(page, rows);
        }

        public bool Delete(Customer customer)
        {
            return _unitOfWork.Customer.Delete(customer);
        }

        public Customer GetById(int id)
        {
            return _unitOfWork.Customer.GetById(id);
        }

        public int Insert(Customer customer)
        {
            return _unitOfWork.Customer.Insert(customer);
        }

        public bool Update(Customer customer)
        {
            return _unitOfWork.Customer.Update(customer);
        }
    }
}
