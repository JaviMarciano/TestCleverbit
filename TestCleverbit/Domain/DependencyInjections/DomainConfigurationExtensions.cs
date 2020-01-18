using Microsoft.Extensions.DependencyInjection;
using TestCleverbit.Domain.Services;
using TestCleverbit.Domain.Services.Contracts;

namespace TestCleverbit.Domain.DependencyInjections
{
    public static class DomainConfigurationExtensions
    {
        public static void AddDomainConfiguration(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IGameService, GameService>();
        }
    }
}
