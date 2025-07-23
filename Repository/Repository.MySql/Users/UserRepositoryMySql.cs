using Core.Server.Abstractions.Tenant;
using Finbuckle.MultiTenant.Abstractions;
using MySql.Data.MySqlClient;
using Repository.Abstractions.Configurations.MySql;
using Repository.Abstractions.Users;
using Repository.Abstractions.Users.Models;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Repository.MySql.Users
{
    public class UserRepositoryMySql(IMultiTenantContextAccessor<AppTenantInfo> tenantAccessor
        , MySqlDbConfiguration configuration) 
        : MySqlRepository<User>(tenantAccessor, configuration), IUserRepository
    {
        public async Task<List<User>> GetUsersAsync(CancellationToken cancellationToken)
        {
            const string sql = "SELECT Id, Name FROM Users where TenantId = @TenantId";

            var connection = new MySqlConnection(_configuration.ConnectionString);
            await connection.OpenAsync();
            using var command = new MySqlCommand(sql, connection);
            command.Attributes.SetAttribute(new MySqlAttribute
            {
                AttributeName = "TenantId",
                MySqlDbType = MySqlDbType.String,
                Value = _appTenantInfo.Id
            });
            using var reader = await command.ExecuteReaderAsync();

            List<User> users = [];
            while (await reader.ReadAsync())
            {
                users.Add(MapUser(reader));
            }

            return users;
        }

        private static User MapUser(DbDataReader reader)
        {
            return new User
            {
                TenantId = reader.GetString("TenantId"),
                Id = reader.GetGuid("Id"),
                Name = reader.GetString("Name"),
            };
        }
    }
}
