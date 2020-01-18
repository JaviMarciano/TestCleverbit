using Microsoft.Extensions.Options;
using System;
using System.Linq.Expressions;
using TestCleverbit.DataAccess.EntityFrameworkConfiguration;
using TestCleverbit.Domain.Entities;
using TestCleverbit.Domain.Repositories;

namespace TestCleverbit.DataAccess.Repositories
{
    public class MatchItemRepository : MsSqlRepository<GameDbContext, int, MatchItem>, IMatchItemRepository
    {
        public MatchItemRepository(GameDbContext dbContext, IOptions<GameDataOptions> options, IConnectionStringProvider connectionStringProvider)
            : base(dbContext, options.Value.DataSource, connectionStringProvider) { }

        public override Expression<Func<MatchItem, int>> KeyProperty => x => x.Id;

    }
}
