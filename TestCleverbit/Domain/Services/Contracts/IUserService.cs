
using System.Threading.Tasks;
using TestCleverbit.Domain.Entities;

namespace TestCleverbit.Domain.Services.Contracts
{
    public interface IUserService
    {
        Task<User> Login(string email, string password);
    }
}
