using Microsoft.Extensions.Configuration;
using System;

namespace TestCleverbit.DataAccess.EntityFrameworkConfiguration
{
    public class ConfigurationBasedConnectionStringProvider : IConnectionStringProvider
    {
        private readonly IConfiguration _configuration;

        public ConfigurationBasedConnectionStringProvider(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public string GetConnectionStringFor(DataSource dataSource)
        {
            return _configuration.GetConnectionString(dataSource.ConnectionStringName);
        }
    }
}
