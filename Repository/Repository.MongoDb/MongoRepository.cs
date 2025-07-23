using Core.Server.Abstractions.Tenant;
using Finbuckle.MultiTenant.Abstractions;
using MongoDB.Driver;
using Repository.Abstractions.Configurations.MongoDb;

namespace Repository.MongoDb
{
    public class MongoRepository<T> where T : class
    {
        internal readonly MongoDbConfiguration _configuration;
        internal readonly AppTenantInfo _appTenantInfo;
        internal readonly IMongoCollection<T> _collection;

        public MongoRepository(IMultiTenantContextAccessor<AppTenantInfo> tenantAccessor
            , MongoDbConfiguration configuration
            , string collectionName)
        {
            if (tenantAccessor.MultiTenantContext.TenantInfo is null)
            {
                throw new Exception("Tenant information is not available. Ensure that the MultiTenantContext is properly configured.");
            }
            _appTenantInfo = tenantAccessor.MultiTenantContext.TenantInfo;
            _configuration = configuration;
            var client = new MongoClient(_configuration.ConnectionString);
            var database = client.GetDatabase(_configuration.DatabaseName);
            _collection = database.GetCollection<T>(collectionName);
        }

    }
}
