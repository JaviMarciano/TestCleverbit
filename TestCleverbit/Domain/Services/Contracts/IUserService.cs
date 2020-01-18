
using System.Threading.Tasks;

namespace TestCleverbit.Domain.Services.Contracts
{
    public interface IUserService
    {
        Task<bool> Login(string email, string password);
    }
}
