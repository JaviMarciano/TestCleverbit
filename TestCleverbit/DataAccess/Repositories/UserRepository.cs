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
    public class UserRepository : MsSqlRepository<GameDbContext, int, User>, IUserRepository
    {
        public UserRepository(GameDbContext dbContext, IOptions<GameDataOptions> options, IConnectionStringProvider connectionStringProvider)
            : base(dbContext, options.Value.DataSource, connectionStringProvider) { }

        public override Expression<Func<User, int>> KeyProperty => x => x.Id;

        public Task<User> GetByEmailAndPassword(string email, string password)
        {
            return DbContext.Set<User>().FirstOrDefaultAsync(x => x.Email == email && x.Password == password);
        }

    }
}
