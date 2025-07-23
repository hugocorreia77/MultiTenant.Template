using Core.Server.Abstractions.Repository;

namespace Repository.Abstractions.Configurations.MongoDb
{
    public class MongoDbConfiguration : AbstractRepositoryConfiguration
    {
        public string DatabaseName { get; set; } = string.Empty;
        public MongoDbConfiguration()
        {
        }
        public MongoDbConfiguration(string connectionString, string databaseName)
        {
            ConnectionString = connectionString;
            DatabaseName = databaseName;
        }
    }
}
