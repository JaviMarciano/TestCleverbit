using System.Collections.Generic;
using System.Threading.Tasks;
using TestCleverbit.Domain.Entities;

namespace TestCleverbit.Domain.Services.Contracts
{
    public interface IGameService
    {
        Task Play(int number, string currentUser);
        Task<List<Match>> GetAllMatches();
    }
}
