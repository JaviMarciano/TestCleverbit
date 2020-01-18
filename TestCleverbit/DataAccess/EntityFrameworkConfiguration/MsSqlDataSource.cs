namespace TestCleverbit.DataAccess.EntityFrameworkConfiguration
{
    public class MsSqlDataSource : DataSource<MsSqlDataSource>
    {
        public MsSqlDataSource(string connectionStringName) :
            base(connectionStringName)
        { }
    }
}
