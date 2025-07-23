using Core.Server.Abstractions.Tenant;
using Finbuckle.MultiTenant.Abstractions;
using Repository.Abstractions.Configurations.MySql;

namespace Repository.MySql
{
    public abstract class MySqlRepository<T> where T : class
    {
        internal readonly MySqlDbConfiguration _configuration;
        internal readonly AppTenantInfo _appTenantInfo;

        public MySqlRepository(IMultiTenantContextAccessor<AppTenantInfo> tenantAccessor
            , MySqlDbConfiguration configuration)
        {
            _configuration = configuration;
            if (tenantAccessor.MultiTenantContext.TenantInfo is null)
            {
                throw new Exception("Tenant information is not available. Ensure that the MultiTenantContext is properly configured.");
            }
            _appTenantInfo = tenantAccessor.MultiTenantContext.TenantInfo;
        }
    }
}
