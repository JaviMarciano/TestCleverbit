using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TestCleverbit.DataAccess.EntityFrameworkConfiguration;
using TestCleverbit.Domain.Entities;

namespace TestCleverbit.DataAccess
{
    public class GameDbContext : MsSqlDbContext
    {
        private readonly IOptions<GameDataOptions> _options;

        public GameDbContext(IOptions<GameDataOptions> options, IConnectionStringProvider dataSourceConnectionStringProvider)
            : base(dataSourceConnectionStringProvider)
        {
            _options = options;
        }

        public DbSet<User> User{ get; set; }
        public DbSet<Match> Match { get; set; }
        public DbSet<MatchItem> MatchItem { get; set; }

        public override MsSqlDataSource DataSource => _options.Value.DataSource;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
