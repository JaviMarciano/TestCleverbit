using TestCleverbit.Domain.Entities;

namespace TestCleverbit.Domain.Repositories
{
    public interface IUserRepository : ICrudRepository<int, User>
    { 
    }
}
