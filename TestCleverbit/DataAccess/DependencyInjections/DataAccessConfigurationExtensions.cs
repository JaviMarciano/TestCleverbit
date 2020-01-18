using Microsoft.Extensions.DependencyInjection;
using System;
using TestCleverbit.DataAccess.EntityFrameworkConfiguration;
using TestCleverbit.DataAccess.Repositories;
using TestCleverbit.Domain.Repositories;

namespace TestCleverbit.DataAccess.DependencyInjections
{
    public static class DataAccessConfigurationExtensions
    {
        public static void AddCoreDataConfiguration(this IServiceCollection services, Action<GameDataOptions> options)
        {
            services.Configure(options);
            services.AddSingleton<IConnectionStringProvider, ConfigurationBasedConnectionStringProvider>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IMatchItemRepository, MatchItemRepository>();
            services.AddTransient<IMatchRepository, MatchRepository>();
            services.AddDbContext<GameDbContext>(ServiceLifetime.Transient, ServiceLifetime.Singleton);
        }
    }
}
