using System.Threading.Tasks;
using TestCleverbit.Domain.Entities;

namespace TestCleverbit.Domain.Repositories
{
    public interface IUserRepository : ICrudRepository<int, User>
    {
        Task<User> GetByEmailAndPassword(string email, string password);
    }
}
