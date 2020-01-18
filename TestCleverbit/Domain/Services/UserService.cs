using System.Threading.Tasks;
using TestCleverbit.Domain.Repositories;
using TestCleverbit.Domain.Services.Contracts;

namespace TestCleverbit.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<bool> Login(string email, string password)
        {
            var user = await _userRepository.GetAllAsync();
            return true;
        }
    }
}
