using MAB.Repositories;

namespace MAB.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICustomerRepository Customer { get; }
        IUserRepository User { get; }
        ISupplierRepository Supplier { get; }
        IOrderRepository Order { get; }
    }
}
