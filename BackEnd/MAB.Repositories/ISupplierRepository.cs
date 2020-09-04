using MAB.Models;
using System.Collections.Generic;

namespace MAB.Repositories
{
    public interface ISupplierRepository : IRepository<Supplier>
    {
        IEnumerable<Supplier> SupplierPagedList(int page, int rows, string searchTerm);
    }
}
