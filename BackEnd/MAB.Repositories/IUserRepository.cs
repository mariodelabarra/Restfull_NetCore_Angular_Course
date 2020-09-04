using MAB.Models;

namespace MAB.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User ValidateUser(string email, string password);
    }
}
