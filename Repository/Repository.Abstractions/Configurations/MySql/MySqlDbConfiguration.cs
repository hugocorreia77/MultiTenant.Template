using Core.Server.Abstractions.Repository;

namespace Repository.Abstractions.Configurations.MySql
{
    public class MySqlDbConfiguration : AbstractRepositoryConfiguration
    {
        public MySqlDbConfiguration()
        {
        }
        public MySqlDbConfiguration(string connectionString)
        {
            ConnectionString = connectionString;
        }
    }
}
