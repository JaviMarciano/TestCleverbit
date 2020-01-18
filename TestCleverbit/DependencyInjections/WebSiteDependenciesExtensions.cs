using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestCleverbit.DataAccess.DependencyInjections;
using TestCleverbit.DataAccess.EntityFrameworkConfiguration;
using TestCleverbit.Domain.DependencyInjections;

namespace TestCleverbit.DependencyInjections
{
    public static class WebSiteDependenciesExtensions
    {
        public static void AddWebSiteDependencies(this IServiceCollection services, IConfiguration configuration)
        {            
            services.AddDomainConfiguration();
            services.AddCoreDataConfiguration(options => options.DataSource = new MsSqlDataSource("CleverbitGame"));
        }
    }
}
