using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace TestCleverbit.DataAccess.EntityFrameworkConfiguration
{
    public abstract class MsSqlDbContext : DbContext
    {
        private readonly IConnectionStringProvider _dataSourceConnectionStringProvider;

        public MsSqlDbContext(IConnectionStringProvider dataSourceConnectionStringProvider)
        {
            _dataSourceConnectionStringProvider = dataSourceConnectionStringProvider;
        }

        public abstract MsSqlDataSource DataSource { get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(_dataSourceConnectionStringProvider.GetConnectionStringFor(DataSource))
                .ConfigureWarnings(warnings => warnings.Throw(RelationalEventId.QueryClientEvaluationWarning));
        }
    }
}
