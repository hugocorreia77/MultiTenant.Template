using Core.Server.Abstractions.Tenant;
using Finbuckle.MultiTenant.Abstractions;
using MongoDB.Driver;
using Repository.Abstractions.Configurations.MongoDb;
using Repository.Abstractions.Users;
using Repository.Abstractions.Users.Models;

namespace Repository.MongoDb.Users
{
    public class UserRepositoryMongoDb
        (IMultiTenantContextAccessor<AppTenantInfo> tenantAccessor, MongoDbConfiguration configuration) 
        : MongoRepository<User>(tenantAccessor,
            configuration,
            COLLECTION_NAME), IUserRepository
    {
        internal const string COLLECTION_NAME = "Users";

        public async Task<List<User>> GetUsersAsync(CancellationToken cancellationToken)
        {
            var filter = Builders<User>.Filter.Eq(user => user.TenantId, _appTenantInfo.Id);
            var findResult = await _collection.FindAsync(filter, cancellationToken: cancellationToken);
            return await findResult.ToListAsync(cancellationToken);
        }
    }
}
