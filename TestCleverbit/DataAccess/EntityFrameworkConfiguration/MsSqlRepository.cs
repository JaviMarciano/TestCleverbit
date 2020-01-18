using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace TestCleverbit.DataAccess.EntityFrameworkConfiguration
{
    public abstract class MsSqlRepository<TDbContext, TKey, TEntity> : EFCoreRepository<TDbContext, TKey, TEntity>
        where TDbContext : DbContext
        where TEntity : class, new()
    {
        private readonly string _connectionString;

        public MsSqlRepository(TDbContext dbContext, MsSqlDataSource dataSource, IConnectionStringProvider connectionStringProvider)
            : base(dbContext)
        {
            _connectionString = connectionStringProvider.GetConnectionStringFor(dataSource);
        }

        protected SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
