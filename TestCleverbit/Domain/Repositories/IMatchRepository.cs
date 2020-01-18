using System.Collections.Generic;
using System.Threading.Tasks;
using TestCleverbit.Domain.Entities;

namespace TestCleverbit.Domain.Repositories
{
    public interface IMatchRepository : ICrudRepository<int, Match>
    {
        Task<List<Match>> GetAllMatches();
    }
}
