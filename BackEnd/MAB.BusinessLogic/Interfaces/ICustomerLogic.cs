using MAB.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAB.BusinessLogic.Interfaces
{
    public interface ICustomerLogic
    {
        Customer GetById(int id);
        IEnumerable<CustomerList> CustumersPagedList(int page, int rows);
        int Insert(Customer customer);
        bool Update(Customer customer);
        bool Delete(Customer customer);
    }
}
