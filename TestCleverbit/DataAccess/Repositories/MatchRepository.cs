using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestCleverbit.DataAccess.EntityFrameworkConfiguration;
using TestCleverbit.Domain.Entities;
using TestCleverbit.Domain.Repositories;

namespace TestCleverbit.DataAccess.Repositories
{
    public class MatchRepository : MsSqlRepository<GameDbContext, int, Match>, IMatchRepository
    {
        public MatchRepository(GameDbContext dbContext, IOptions<GameDataOptions> options, IConnectionStringProvider connectionStringProvider)
            : base(dbContext, options.Value.DataSource, connectionStringProvider) { }

        public override Expression<Func<Match, int>> KeyProperty => x => x.Id;


        public Task<List<Match>> GetAllMatches()
        {
            return DbContext.Set<Match>().Include(x => x.Items).ToListAsync();
        }
    }
}
