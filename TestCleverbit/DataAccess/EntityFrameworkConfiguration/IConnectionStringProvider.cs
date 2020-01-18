namespace TestCleverbit.DataAccess.EntityFrameworkConfiguration
{
    public interface IConnectionStringProvider
    {
        string GetConnectionStringFor(DataSource dataSource);
    }
}
