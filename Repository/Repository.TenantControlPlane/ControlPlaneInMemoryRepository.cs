using Core.Server.Abstractions.Repository;
using Repository.Abstractions.Configurations.MongoDb;
using Repository.Abstractions.Configurations.MySql;

namespace Repository.TenantControlPlane
{
    public class ControlPlaneInMemoryRepository
    {
        private Dictionary<string, AbstractRepositoryConfiguration> _configurations
            = new(
            [
                new KeyValuePair<string, AbstractRepositoryConfiguration>
                    ("tenant1", new MongoDbConfiguration{
                        DatabaseName = "UsersDomainDB",
                        ConnectionString = "mongodb://localhost:27017/empresa1"
                    }),
                new KeyValuePair<string, AbstractRepositoryConfiguration>(
                    "tenant2", new MySqlDbConfiguration{
                        ConnectionString = "Server=localhost;Database=TenantControlPlane;User Id=root;Password=;"
                    })
            ]);

        public AbstractRepositoryConfiguration? GetTenantConfiguration(string tenantId)
        {
            return _configurations.SingleOrDefault(s => s.Key == tenantId).Value;
        }

    }
}
