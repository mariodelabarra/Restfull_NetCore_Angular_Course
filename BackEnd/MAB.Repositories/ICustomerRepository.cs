using MAB.Models;
using System.Collections.Generic;
using System.Linq;

namespace MAB.Repositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        IEnumerable<CustomerList> CustumersPagedList(int page, int rows);
    }
}
