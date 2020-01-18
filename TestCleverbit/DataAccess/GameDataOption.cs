using Microsoft.Extensions.Options;
using TestCleverbit.DataAccess.EntityFrameworkConfiguration;

namespace TestCleverbit.DataAccess
{
    public class GameDataOptions : IOptions<GameDataOptions>
    {
        public GameDataOptions Value => this;

        public MsSqlDataSource DataSource { get; set; }
    }  
}
